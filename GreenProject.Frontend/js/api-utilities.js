/************************\
|   STORAGE EXTENSIONS   |
\************************/

Storage.prototype.setObject = function(key, value) {
    this.setItem(key, JSON.stringify(value));
};

Storage.prototype.getObject = function(key) {
    var value = this.getItem(key);
    return JSON.parse(value);
};

/********************************\
|   WRAPPERS FOR API FUNCTIONS   |
\********************************/

function saveCurrentUserInfo() {
    return new Promise(function(resolve, reject) {
        getCurrentUserInfo()
        .done(function(data) {
            localStorage.setObject("userData", data);
            resolve(data);
        })
        .fail(function(jqXHR) {
            reject(jqXHR);
        });
    });
}

function getOrUpdateCategories() {
    const UPDATE_INTERVAL_MINUTES = 5;
    return new Promise(function(resolve, reject) {
        let now = Date.now();
        let categories = localStorage.getObject("categories");
        if (categories != null && parseInt((now - categories.expiration) / 60000) < UPDATE_INTERVAL_MINUTES) {
            resolve(categories);
        }
        getCategories()
        .done(function(data) {
            data.expiration = now;
            localStorage.setObject("categories", data);
            resolve(data);
        })
        .fail(function(jqXHR) {
            reject(jqXHR);
        });
    });
}

function getOrUpdateZones() {
    const UPDATE_INTERVAL_MINUTES = 5;
    return new Promise(function(resolve, reject) {
        let now = Date.now();
        let zones = localStorage.getObject("zones");
        if (zones != null && parseInt((now - zones.expiration) / 60000) < UPDATE_INTERVAL_MINUTES) {
            resolve(zones);
        }
        getZones()
        .done(function(data) {
            zones = {
                children: data,
                expiration: now
            };
            localStorage.setObject("zones", zones);
            resolve(zones);
        })
        .fail(function(jqXHR) {
            reject(jqXHR);
        });
    });
}
