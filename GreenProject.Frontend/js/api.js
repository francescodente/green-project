class APIClass {

    constructor() {
        if (!!APIClass.API) {
            return APIClass.API;
        }
        APIClass.API = this;

        this.protocol = "http://"
        this.serverAddress = "localhost:5000";
        this.apiVer = "v1";
        this.basePath = this.protocol + this.serverAddress + "/";
        this.apiPath = this.basePath + "api/" + this.apiVer + "/";
    }

    async ajax(method, path, data) {
        let token = await APIUtils.getOrRefreshToken();
        let url = this.apiPath + path;
        return new Promise(function(resolve, reject) {
            $.ajax({
                headers: {
                    "authorization" : "bearer " + token,
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                },
                method: method,
                url: url,
                data: data
            })
            .done(function(data) { resolve(data) })
            .catch(function (jqXHR) { reject(jqXHR) });
        });
    }

    get(url, data) {
        return this.ajax("GET", url, data);
    }

    put(url, data) {
        return this.ajax("PUT", url, JSON.stringify(data));
    }

    post(url, data) {
        return this.ajax("POST", url, JSON.stringify(data));
    }

    del(url, data) {
        return this.ajax("DELETE", url, data);
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
        return this.put("customers/" + userId + "/addresses/default", addressId);
    }

    // Authentication

    authToken(data) {
        return this.post("auth/token", data);
    }

    refreshToken(data) {
        return this.post("auth/refresh", data);
    }

    changePsw() {

    }

    signup(data) {
        return this.post("auth/register", data);
    }

    logout() {
        localStorage.clear();
    }

    // Cart

    getCart(userId) {
        return this.get("customers/" + localStorage.getObject("authData").userId + "/cart");
    }

    getCartSize(userId) {
        return this.get("customers/" + localStorage.getObject("authData").userId + "/cart/size");
    }

    addToCart(userId, productId, quantity) {
        let data = {
            productId: productId,
            quantity: quantity
        };
        return this.post("customers/" + localStorage.getObject("authData").userId + "/cart/details", data);
    }

    editCartQuantity(userId, productId, quantity) {
        let data = {
            productId: productId,
            quantity: quantity
        };
        return this.put("customers/" + localStorage.getObject("authData").userId + "/cart/details", data);
    }

    removeFromCart(userId, productId) {
        return this.del("customers/" + localStorage.getObject("authData").userId + "/cart/details/" + productId);
    }

    confirmCart(userId, data) {
        return this.put("customers/" + localStorage.getObject("authData").userId + "/cart/confirm", data);
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

    getCrateCompatibilities() {

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
        return this.get("customers/" + localStorage.getObject("authData").userId + "/orders?" + searchParams.toString());
    }

    getOrders() {

    }

    changeOrderState() {

    }

    // Products

    getProducts(categories, pageNumber = 0, pageSize = 30) {
        if (categories[0] == 1) {
            return this.getCrates(pageNumber, pageSize);
        }
        let searchParams = new URLSearchParams();
        searchParams.append("PageNumber", pageNumber);
        searchParams.append("PageSize", pageSize);
        categories.forEach(category => {
            searchParams.append("Categories", category);
        });
        return this.get("products?" + searchParams.toString());
    }

    createProduct() {

    }

    editProduct() {

    }

    deleteProduct() {

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

    // Zones

    getZones() {
        return this.get("zones");
    }

    getZoneSchedule(zipCode) {
        return this.get("zones/" + zipCode + "/schedule");
    }

}

var API = Object.freeze(new APIClass());
