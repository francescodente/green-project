class APIUtilsClass {

    constructor() {
        if (!!APIUtilsClass.APIUtils) {
            return APIUtilsClass.APIUtils;
        }
        APIUtilsClass.APIUtils = this;
    }

    updateCartBadge() {
        return new Promise(function(resolve, reject) {
            API.getCartSize(localStorage.getObject("authData").userId)
            .then(function(data) {
                $(".cart-badge").html(data != 0 ? data : "");
                resolve(data);
            })
            .catch(function(jqXHR) { reject(jqXHR) });
        });
    }

    async getOrRefreshAuth() {
        if (API.isTokenRefreshing) {
            console.log("token is refreshing...");
            return API.tokenPromise;
        }
        let authData = localStorage.getObject("authData");
        if (authData == null) {
            //console.log("authData null");
            return null;
        }
        if (Date.now() < Date.parse(authData.expiration)) {
            //console.log("token ok");
            return authData;
        }
        console.log("token expired");
        API.isTokenRefreshing = true;
        API.tokenPromise = API.refreshToken(authData.token);
        try {
            authData = await API.tokenPromise;
            localStorage.setObject("authData", authData);
            console.log("token refreshed");
            return authData;
        } catch (e) {
            console.log(e);
            console.log("token refresh failed -> logout");
            //API.logout();
            return null;
        } finally {
            API.isTokenRefreshing = false;
        }
    }

    getOrUpdateCurrentUserInfo(fullResponse = false) {
        const UPDATE_INTERVAL_MINUTES = 10;
        return new Promise(function(resolve, reject) {
            let authData = localStorage.getObject("authData");
            if (authData == null) {
                reject(null);
                return;
            }
            let userData = localStorage.getObject("userData");
            let now = Date.now();
            let expired = userData == null ? true : parseInt((now - userData.expiration) / 60000) < UPDATE_INTERVAL_MINUTES;
            if (!fullResponse && !expired) {
                resolve(userData);
                return;
            }
            let isLocallySubscribed = userData == null ? false : userData.isLocallySubscribed;
            API.getUserInfo(authData.userId)
            .then(function(data) {
                data.expiration = now;
                localStorage.setObject("userData", {
                    expiration: data.expiration,
                    isSubscribed: data.isSubscribed,
                    isLocallySubscribed: isLocallySubscribed,
                    marketingConsent: data.marketingConsent,
                    shouldChangePassword: data.shouldChangePassword
                });
                resolve(data);
            })
            .catch(function(jqXHR) { reject(jqXHR) });
        });
    }

    getOrUpdateCategories() {
        const UPDATE_INTERVAL_MINUTES = 30;
        return new Promise(function(resolve, reject) {
            let now = Date.now();
            let categories = localStorage.getObject("categories");
            if (categories != null && parseInt((now - categories.expiration) / 60000) < UPDATE_INTERVAL_MINUTES) {
                resolve(categories);
                return;
            }
            API.getCategories()
            .then(function(data) {
                data.expiration = now;
                localStorage.setObject("categories", data);
                resolve(data);
            })
            .catch(function(jqXHR) { reject(jqXHR) });
        });
    }

    getOrUpdateZones() {
        const UPDATE_INTERVAL_MINUTES = 60;
        return new Promise(function(resolve, reject) {
            let now = Date.now();
            let zones = localStorage.getObject("zones");
            if (zones != null && parseInt((now - zones.expiration) / 60000) < UPDATE_INTERVAL_MINUTES) {
                resolve(zones);
                return;
            }
            API.getZones()
            .then(function(data) {
                zones = {
                    children: data,
                    expiration: now
                };
                localStorage.setObject("zones", zones);
                resolve(zones);
            })
            .catch(function(jqXHR) { reject(jqXHR) });
        });
    }

    // Weekly orders

    async subscribe(addressId, notes) {
        let userId = localStorage.getObject("authData").userId;
        let data = {
            addressId: addressId,
            notes: notes
        };
        let weeklyOrder = localStorage.getObject("weeklyOrder");
        console.log(weeklyOrder);
        // Subscribe
        await API.subscribe(userId, data);
        console.log("subscribed. adding crates");
        // Add crates
        for (let crate of weeklyOrder.crates) {
            let data = await API.addWeeklyCrate(userId, crate.crateDescription.crateId);
            console.log(crate);
            // Add crate products
            for (let product of crate.products) {
                await API.addProductToCrate(userId, data.orderDetailId, product.product.productId, product.quantity);
                console.log(product);
            }
        }
        // Add extra products
        console.log("crates added. adding extras");
        for (let product of weeklyOrder.extraProducts) {
            await API.addExtraProduct(userId, product.itemId, product.quantity);
            console.log(product);
        }
        // Set isLocallySubscribed to false, set isSubscribed to true, delete weeklyOrder
        let userData = localStorage.getObject("userData");
        userData.isSubscribed = true;
        userData.isLocallySubscribed = false;
        localStorage.setObject("userData", userData);
        localStorage.removeItem("weeklyOrder");
        console.log("done");
    }

    unsubscribe() {
        return API.unsubscribe(localStorage.getObject("authData").userId);
    }

    editSubscription(addressId, notes) {
        let data = {
            addressId: addressId,
            notes: notes
        };
        return API.editSubscription(localStorage.getObject("authData").userId, data);
    }

    locallySubscribe() {
        if (localStorage.getObject("userData").isLocallySubscribed) {
            return;
        }
        let weeklyOrder = {
            nextOrderDetailId: 0,
            crates: [],
            extraProducts: [],
            prices: {
                subtotal: 0,
                iva: 0,
                shippingCost: 0,
                total: 0
            }
        };
        localStorage.setObject("weeklyOrder", weeklyOrder);
        localStorage.setObjectProperty("userData", "isLocallySubscribed", true);
    }

    isSubscribed() {
        let userData = localStorage.getObject("userData");
        if (userData == null) return false;
        return userData.isSubscribed;
    }

    isLocallySubscribed() {
        let userData = localStorage.getObject("userData");
        if (userData == null) return false;
        return userData.isLocallySubscribed;
    }

    getNextOrderDetailId(weeklyOrder) {
        let orderDetailId = weeklyOrder.nextOrderDetailId;
        weeklyOrder.nextOrderDetailId++;
        return orderDetailId;
    }

    updateWeeklyOrderPrices(weeklyOrder) {
        const defaultShippingFee = 3.9;
        let zoneShippingFee = 0; // TODO get shipping fee from address
        let subtotal = 0;
        let iva = 0;
        weeklyOrder.crates.forEach(crate => {
            subtotal += crate.crateDescription.price;
            iva += crate.crateDescription.price * crate.crateDescription.ivaPercentage;
            console.log(iva);
        });
        weeklyOrder.extraProducts.forEach(product => {
            subtotal += product.price * product.quantity;
            iva += product.price * product.quantity * product.ivaPercentage;
            console.log(iva);
        });
        let shippingCost = zoneShippingFee + (weeklyOrder.extraProducts.length > 0 ? defaultShippingFee : 0);
        weeklyOrder.prices.subtotal = subtotal;
        weeklyOrder.prices.iva = iva;
        weeklyOrder.prices.shippingCost = shippingCost;
        weeklyOrder.prices.total = subtotal + iva + shippingCost;
        return weeklyOrder;
    }

    getWeeklyOrder() {
        let authData = localStorage.getObject("authData");
        let userData = localStorage.getObject("userData");
        if (userData.isSubscribed) {
            return API.getWeeklyOrder(authData.userId);
        }
        if (userData.isLocallySubscribed) {
            return Promise.resolve(localStorage.getObject("weeklyOrder"));
        }
        return Promise.resolve(null);
    }

    addWeeklyCrate(crate) {
        let userData = localStorage.getObject("userData");
        if (userData.isSubscribed) {
            return API.addWeeklyCrate(userData.userId, crate.crateId);
        }
        this.locallySubscribe();
        let weeklyOrder = localStorage.getObject("weeklyOrder");
        let crateDetail = {
            orderDetailId: this.getNextOrderDetailId(weeklyOrder),
            crateDescription: {
                crateId: crate.crateId,
                name: crate.name,
                description: crate.description,
                price: crate.price,
                ivaPercentage: 0.04,
                capacity: crate.capacity,
                imageUrl: crate.imageUrl,
                isStarred: crate.isStarred,
                categoryId: crate.categoryId
            },
            products: []
        };
        weeklyOrder.crates.push(crateDetail);
        weeklyOrder = this.updateWeeklyOrderPrices(weeklyOrder);
        localStorage.setObject("weeklyOrder", weeklyOrder);
        return Promise.resolve(crateDetail);
    }

    addExtraProduct(product, quantity) {
        let userData = localStorage.getObject("userData");
        if (userData.isSubscribed) {
            return API.addExtraProduct(userData.userId, product.productId, quantity);
        }
        this.locallySubscribe();
        let weeklyOrder = localStorage.getObject("weeklyOrder");
        let productDetail;
        // Update quantity if product is already present
        weeklyOrder.extraProducts.forEach(extraProduct => {
            if (extraProduct.itemId == product.productId) {
                extraProduct.quantity = parseInt(extraProduct.quantity) + parseInt(quantity);
                productDetail = extraProduct;
            }
        });
        // Add product otherwise
        if (productDetail == undefined) {
            productDetail = {
                orderDetailId: this.getNextOrderDetailId(weeklyOrder),
                itemId: product.productId,
                name: product.name,
                description: product.description,
                imageUrl: product.imageUrl,
                quantity: quantity,
                capacity: null,
                price: product.price,
                unitName: product.unitName,
                unitMultiplier: product.unitMultiplier,
                ivaPercentage: product.ivaPercentage
            };
            weeklyOrder.extraProducts.push(productDetail);
        }
        weeklyOrder = this.updateWeeklyOrderPrices(weeklyOrder);
        localStorage.setObject("weeklyOrder", weeklyOrder);
        return Promise.resolve(productDetail);
    }

    editExtraProductQuantity(productId, quantity) {
        let userData = localStorage.getObject("userData");
        if (userData.isSubscribed) {
            return API.editExtraProductQuantity(userData.userId, productId, quantity);
        }
        let weeklyOrder = localStorage.getObject("weeklyOrder");
        let productDetail;
        // Update quantity
        weeklyOrder.extraProducts.forEach(extraProduct => {
            if (extraProduct.itemId == productId) {
                extraProduct.quantity = quantity;
                productDetail = extraProduct;
            }
        });
        weeklyOrder = this.updateWeeklyOrderPrices(weeklyOrder);
        localStorage.setObject("weeklyOrder", weeklyOrder);
        return Promise.resolve(productDetail);
    }

    removeFromWeeklyOrder(orderDetailId) {
        let userData = localStorage.getObject("userData");
        if (userData.isSubscribed) {
            return API.removeFromWeeklyOrder(userData.userId, orderDetailId);
        }
        let weeklyOrder = localStorage.getObject("weeklyOrder");
        weeklyOrder.crates = weeklyOrder.crates.filter(crate => crate.orderDetailId != orderDetailId);
        weeklyOrder.extraProducts = weeklyOrder.extraProducts.filter(product => product.orderDetailId != orderDetailId);
        weeklyOrder = this.updateWeeklyOrderPrices(weeklyOrder);
        localStorage.setObject("weeklyOrder", weeklyOrder);
        return Promise.resolve(null);
    }

    addProductToCrate(orderDetailId, product, quantity) {
        let userData = localStorage.getObject("userData");
        if (userData.isSubscribed) {
            return API.addProductToCrate(userData.userId, orderDetailId, product.productId, quantity);
        }
        let weeklyOrder = localStorage.getObject("weeklyOrder");
        let crate = weeklyOrder.crates.filter(crate => crate.orderDetailId == orderDetailId)[0];
        let productDetail;
        // Update quantity if product is already present
        crate.products.forEach(crateProduct => {
            if (crateProduct.product.productId == product.productId) {
                crateProduct.quantity = parseInt(crateProduct.quantity) + parseInt(quantity);
                productDetail = crateProduct;
            }
        });
        // Add product otherwise
        if (productDetail == undefined) {
            productDetail = {
                product: {
                    productId: product.productId,
                    name: product.name,
                    description: product.description,
                    price: product.price,
                    unitName: product.unitName,
                    unitMultiplier: product.unitMultiplier,
                    ivaPercentage: product.ivaPercentage,
                    imageUrl: product.imageUrl,
                    isStarred: product.isStarred,
                    categoryId: product.categoryId
                },
                quantity: quantity,
                maximum: product.maxQuantity
            }
            crate.products.push(productDetail);
        }
        localStorage.setObject("weeklyOrder", weeklyOrder);
        return Promise.resolve(productDetail);
    }

    editProductCrateQuantity(orderDetailId, productId, quantity) {
        let userData = localStorage.getObject("userData");
        if (userData.isSubscribed) {
            return API.editProductCrateQuantity(userData.userId, orderDetailId, productId, quantity);
        }
        let weeklyOrder = localStorage.getObject("weeklyOrder");
        let crate = weeklyOrder.crates.filter(crate => crate.orderDetailId == orderDetailId)[0];
        let productDetail;
        // Update quantity if product is already present
        crate.products.forEach(crateProduct => {
            if (crateProduct.product.productId == productId) {
                crateProduct.quantity = quantity;
                productDetail = crateProduct;
            }
        });
        localStorage.setObject("weeklyOrder", weeklyOrder);
        return Promise.resolve(productDetail);
    }

    removeProductFromCrate(orderDetailId, productId) {
        let userData = localStorage.getObject("userData");
        if (userData.isSubscribed) {
            return API.removeProductFromCrate(userData.userId, orderDetailId, productId);
        }
        let weeklyOrder = localStorage.getObject("weeklyOrder");
        let crate = weeklyOrder.crates.filter(crate => crate.orderDetailId == orderDetailId)[0];
        crate.products = crate.products.filter(product => product.product.productId != productId);
        localStorage.setObject("weeklyOrder", weeklyOrder);
        return Promise.resolve(null);
    }

}

var APIUtils = Object.freeze(new APIUtilsClass());

