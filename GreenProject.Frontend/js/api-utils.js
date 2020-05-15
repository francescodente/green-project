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
            API.getUserInfo(authData.userId)
            .then(function(data) {
                data.expiration = now;
                localStorage.setObject("userData", {
                    expiration: data.expiration,
                    isSubscribed: data.isSubscribed,
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

    get isCurrentUserSubscribed() {
        let userData = localStorage.getObject("userData");
        return userData.isSubscribed;
    }

    subscribe(userId, data) {
        API.subscribe(userId, data)
        .then(function(data) {
            // TODO send all locally stored items
        })
    }

    unsubscribe(userId) {

    }

    getWeeklyOrder(userId) {

    }

    addWeeklyCrate(userId, crateId) {

    }

    addExtraProduct(userId, productId, quantity) {

    }

    removeFromWeeklyOrder(userId, orderDetailId) {

    }

    editExtraProductQuantity(userId) {

    }

    addProductToWeeklyCrate(userId, orderDetailId, productId, quantity) {

    }

    removeProductFromWeeklyCrate(userId, orderDetailId, productId) {

    }

    editWeeklyCrateProductQuantity(userId, orderDetailId, productId, quantity) {

    }

}

var APIUtils = Object.freeze(new APIUtilsClass());

