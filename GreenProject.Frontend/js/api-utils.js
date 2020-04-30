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
            .done(function(data) {
                $(".cart-badge").html(data != 0 ? data : "");
                resolve(data);
            })
            .fail(function(jqXHR) { reject(jqXHR) });
        });
    }

    getOrUpdateCurrentUserInfo() {
        const UPDATE_INTERVAL_MINUTES = 10;
        return new Promise(function(resolve, reject) {
            let authData = localStorage.getObject("authData");
            if (authData == null) reject(null);
            let now = Date.now();
            let userData = localStorage.getObject("userData");
            if (userData != null && parseInt((now - userData.expiration) / 60000) < UPDATE_INTERVAL_MINUTES) {
                resolve(userData);
                return;
            }
            API.getUserInfo(authData.userId)
            .done(function(data) {
                data.expiration = now;
                localStorage.setObject("userData", data);
                resolve(data);
            })
            .fail(function(jqXHR) { reject(jqXHR) });
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
            .done(function(data) {
                data.expiration = now;
                localStorage.setObject("categories", data);
                resolve(data);
            })
            .fail(function(jqXHR) { reject(jqXHR) });
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
            .done(function(data) {
                zones = {
                    children: data,
                    expiration: now
                };
                localStorage.setObject("zones", zones);
                resolve(zones);
            })
            .fail(function(jqXHR) { reject(jqXHR) });
        });
    }

}

var APIUtils = Object.freeze(new APIUtilsClass());

