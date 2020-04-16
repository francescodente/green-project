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
        .fail(function(data) {
            reject(data);
        });
    });
}