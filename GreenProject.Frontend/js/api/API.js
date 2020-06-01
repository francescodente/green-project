class APIClass {

    constructor() {
        if (!!APIClass.API) {
            return APIClass.API;
        }
        APIClass.API = this;

        this.protocol = location.protocol + "//";
        this.serverAddress = location.hostname == "localhost" ? "localhost:5000" : "api." + location.host;
        this.apiVer = "v1";
        this.basePath = this.protocol + this.serverAddress + "/";
        this.apiPath = this.basePath + "api/" + this.apiVer + "/";

        this.isTokenRefreshing = false;
        this.tokenPromise = Promise.resolve(null);
    }

    ajax(method, path, data, token) {
        let url = this.apiPath + path;
        return new Promise(function(resolve, reject) {
            $.ajax({
                headers: {
                    "authorization" : "bearer " + token,
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                },
                xhrFields: {
                    withCredentials: true
                },
                method: method,
                url: url,
                data: data
            })
            .done(function(data, textStatus, jqXHR) { resolve(data) })
            .fail(function (jqXHR) { reject(jqXHR) });
        });
    }

    async request(method, path, data) {
        let authData = await APIUtils.getOrRefreshAuth();
        let token = authData == null ? "" : authData.token;
        return await this.ajax(method, path, data, token);
    }

    get(url, data) {
        return this.request("GET", url, data);
    }

    put(url, data) {
        return this.request("PUT", url, JSON.stringify(data));
    }

    post(url, data) {
        return this.request("POST", url, JSON.stringify(data));
    }

    del(url, data) {
        return this.request("DELETE", url, data);
    }

    // Addresses

    getAddresses(userId) {
        return this.get("customers/" + userId + "/addresses");
    }

    createAddress(userId, address) {
        return this.post("customers/" + userId + "/addresses", address);
    }

    deleteAddress(userId, addressId) {
        return this.del("customers/" + userId + "/addresses/" + addressId);
    }

    setDefaultAddress(userId, addressId) {
        let data = { addressId: addressId };
        return this.put("customers/" + userId + "/addresses/default", data);
    }

    // Authentication

    authToken(data) {
        return this.post("auth/token", data);
    }

    refreshToken(accessToken) {
        console.log(accessToken);
        let data = { token: accessToken };
        return this.ajax("POST", "auth/refresh", JSON.stringify(data), "");
    }

    changePsw(oldPsw, newPsw) {
        let data = {
            oldPassword: oldPsw,
            newPassword: newPsw
        }
        return this.post("auth/changepsw", data);
    }

    signup(data) {
        return this.post("auth/register", data);
    }

    logout() {
        localStorage.clear();
    }

    sendActivation(email) {
        let data = { email: email };
        return this.post("auth/reactivate", data);
    }

    activate(token) {
        let data = { token: token };
        return this.post("auth/confirm", data);
    }

    passwordRecovery(email) {
        let data = { email: email };
        return this.post("auth/passwordrecovery", data);
    }

    passwordRecoveryAccept(token, newPassword) {
        let data = {
            token: token,
            newPassword: newPassword
        };
        return this.post("auth/passwordrecovery/accept", data);
    }

    // Cart

    getCart(userId) {
        return this.get("customers/" + userId + "/cart");
    }

    getCartSize(userId) {
        return this.get("customers/" + userId + "/cart/size");
    }

    addToCart(userId, productId, quantity) {
        let data = {
            productId: productId,
            quantity: quantity
        };
        return this.post("customers/" + userId + "/cart/details", data);
    }

    editCartQuantity(userId, productId, quantity) {
        let data = {
            productId: productId,
            quantity: quantity
        };
        return this.put("customers/" + userId + "/cart/details", data);
    }

    removeFromCart(userId, productId) {
        return this.del("customers/" + userId + "/cart/details/" + productId);
    }

    confirmCart(userId, data) {
        return this.put("customers/" + userId + "/cart/confirm", data);
    }


    // Categories

    getCategories() {
        return this.get("categories");
    }

    // Crates

    getCrates(pageNumber = 0, pageSize = 30) {
        let searchParams = new URLSearchParams();
        searchParams.append("PageNumber", pageNumber);
        searchParams.append("PageSize", pageSize);
        return this.get("crates?" + searchParams.toString());
    }

    createCrate() {

    }

    editCrate() {

    }

    deleteCrate() {

    }

    getCrateCompatibilities(crateId) {
        return this.get("crates/" + crateId + "/compatibilities");
    }

    // Images

    createProductImage() {

    }

    deleteProductImage() {

    }

    createCategoryImage() {

    }

    deleteCategoryImage() {

    }

    // Orders

    getCustomerOrders(userId, pageNumber = 0, pageSize = 30) {
        let searchParams = new URLSearchParams();
        searchParams.append("PageNumber", pageNumber);
        searchParams.append("PageSize", pageSize);
        return this.get("customers/" + userId + "/orders?" + searchParams.toString());
    }

    getOrders(dateFrom, dateTo, zipCodes, states, pageNumber = 0, pageSize = 30) {
        let searchParams = new URLSearchParams();
        searchParams.append("From", dateFrom);
        searchParams.append("To", dateTo);
        searchParams.append("PageNumber", pageNumber);
        searchParams.append("PageSize", pageSize);
        searchParams.append("InculdeCanceled", false);
        searchParams.append("IgnoreCompleted", true);
        searchParams.append("IgnorePending", false);
        zipCodes.forEach(zipCode => {
            searchParams.append("ZipCodes", zipCode);
        });
        states.forEach(state => {
            searchParams.append("States", state);
        });
        return this.get("orders?" + searchParams.toString());
    }

    changeOrderState(orderId, orderState) {
        let data = { newState: orderState };
        return this.put("orders/" + orderId + "/state", data);
    }

    // Products

    getProducts(categories, pageNumber = 0, pageSize = 30, isStarred = null) {
        let searchParams = new URLSearchParams();
        if (categories) {
            if (categories[0] == 1) {
                return this.getCrates(pageNumber, pageSize);
            }
            categories.forEach(category => {
                searchParams.append("Categories", category);
            });
        }
        searchParams.append("PageNumber", pageNumber);
        searchParams.append("PageSize", pageSize);
        if (isStarred != null) {
            searchParams.append("Starred", isStarred);
        }
        return this.get("products?" + searchParams.toString());
    }

    createProduct() {

    }

    editProduct() {

    }

    deleteProduct() {

    }

    // Reports

    getOrdersReport(date) {

    }

    getProductsReport(date) {

    }

    getSupplierOrderReport(date) {

    }

    getRevenueReport(date) {

    }

    // Roles

    setPersonRole(userId, data) {
        return this.put("users/" + userId + "/roles/person", data);
    }

    deletePersonRole(userId) {
        return this.del("users/" + userId + "/roles/person");
    }

    // Users

    getUserInfo(userId) {
        return this.get("users/" + userId);
    }

    deleteUser() {

    }

    // Weekly orders

    subscribe(userId, data) {
        return this.post("customers/" + userId + "/weeklyorder/subscription", data);
    }

    editSubscription(userId, data) {
        return this.put("customers/" + userId + "/weeklyorder", data);
    }

    unsubscribe(userId) {
        return this.del("customers/" + userId + "/weeklyorder/subscription");
    }

    skipWeeklyOrder(userId) {
        let weeks = 1;
        return this.put("customers/" + userId + "/weeklyorder/skip", weeks);
    }

    getWeeklyOrder(userId) {
        return this.get("customers/" + userId + "/weeklyorder");
    }

    addWeeklyCrate(userId, crateId) {
        let data = { crateId: crateId };
        return this.post("customers/" + userId + "/weeklyorder/crates", data);
    }

    addExtraProduct(userId, productId, quantity) {
        let data = {
            productId: productId,
            quantity: quantity
        };
        return this.post("customers/" + userId + "/weeklyorder/extras", data);
    }

    editExtraProductQuantity(userId, productId, quantity) {
        let data = {
            productId: productId,
            quantity: quantity
        };
        return this.put("customers/" + userId + "/weeklyorder/extras", data);
    }

    removeFromWeeklyOrder(userId, orderDetailId) {
        return this.del("customers/" + userId + "/weeklyorder/details/" + orderDetailId);
    }

    addProductToCrate(userId, orderDetailId, productId, quantity) {
        let data = {
            productId: productId,
            quantity: quantity
        };
        return this.post("customers/" + userId + "/weeklyorder/crates/" + orderDetailId + "/subproducts", data);
    }

    editProductCrateQuantity(userId, orderDetailId, productId, quantity) {
        let data = {
            productId: productId,
            quantity: quantity
        };
        return this.put("customers/" + userId + "/weeklyorder/crates/" + orderDetailId + "/subproducts", data);
    }

    removeProductFromCrate(userId, orderDetailId, productId) {
        return this.del("customers/" + userId + "/weeklyorder/crates/" + orderDetailId + "/subproducts/" + productId);
    }


    // Zones

    getZones() {
        return this.get("zones");
    }

    getZoneSchedule(zipCode) {
        return this.get("zones/" + zipCode + "/schedule");
    }

}

var API = new APIClass();
