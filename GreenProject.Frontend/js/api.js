var protocol = "http://"
var serverAddress = "localhost:5000";
var apiVer = "v1";
var basePath = protocol + serverAddress + "/";
var apiPath = basePath + "api/" + apiVer + "/";

function getBasePath() {
    return basePath;
}

function getApiPath() {
    return apiPath;
}

function ajax(method, url, data) {
    // TODO add some token renewal method
    let authData = localStorage.getObject("authData");
    let token = authData != null ? authData.token : "";
    return $.ajax({
        headers: {
            "authorization" : "bearer " + token,
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        method: method,
        url: getApiPath() + url,
        data: data
    });
}

function get(url, data) {
    return ajax("GET", url, data);
}

function put(url, data) {
    return ajax("PUT", url, JSON.stringify(data));
}

function post(url, data) {
    return ajax("POST", url, JSON.stringify(data));
}

function del(url, data) {
    return ajax("DELETE", url, data);
}

// Addresses

function getAddresses(userId) {
    return get("customers/" + userId + "/addresses");
}

function createAddress(userId, address) {
    return post("customers/" + userId + "/addresses", address);
}

function deleteAddress(userId, addressId) {
    return del("customers/" + userId + "/addresses/" + addressId);
}

function setDefaultAddress(userId, addressId) {
    return put("customers/" + userId + "/addresses/default", addressId);
}

// Authentication

function authToken(data) {
    return post("auth/token", data);
}

function renewToken() {

}

function changePsw() {

}

function signup(data) {
    return post("auth/register", data);
}

function logout() {
    localStorage.clear();
}

// Cart

function getCart(userId) {
    return get("customers/" + localStorage.getObject("authData").userId + "/cart");
}

function addToCart(userId, productId, quantity) {
    let data = {
        productId: productId,
        quantity: quantity
    };
    return post("customers/" + localStorage.getObject("authData").userId + "/cart/details", data);
}

function editCartQuantity(userId, productId, quantity) {
    let data = {
        productId: productId,
        quantity: quantity
    };
    return put("customers/" + localStorage.getObject("authData").userId + "/cart/details", data);
}

function removeFromCart(userId, productId) {
    return del("customers/" + localStorage.getObject("authData").userId + "/cart/details/" + productId);
}

function confirmCart(userId, data) {
    return put("customers/" + localStorage.getObject("authData").userId + "/cart/confirm", data);
}


// Categories

function getCategories() {
    return get("categories");
}

// Crates

function getCrates(pageNumber = 0, pageSize = 30) {
    let searchParams = new URLSearchParams();
    searchParams.append("PageNumber", pageNumber);
    searchParams.append("PageSize", pageSize);
    return get("crates?" + searchParams.toString());
}

function createCrate() {

}

function editCrate() {

}

function deleteCrate() {

}

function getCrateCompatibilities() {

}

// Images

function createProductImage() {

}

function deleteProductImage() {

}

function createCategoryImage() {

}

function deleteCategoryImage() {

}

// Products

function getProducts(categories, pageNumber = 0, pageSize = 30) {
    if (categories[0] == 1) {
        return getCrates(pageNumber, pageSize);
    }
    let searchParams = new URLSearchParams();
    searchParams.append("PageNumber", pageNumber);
    searchParams.append("PageSize", pageSize);
    categories.forEach(category => {
        searchParams.append("Categories", category);
    });
    return get("products?" + searchParams.toString());
}

function createProduct() {

}

function editProduct() {

}

function deleteProduct() {

}

// Roles

function setPersonRole(userId, data) {
    return put("users/" + userId + "/roles/person", data);
}

function deletePersonRole(userId) {
    return del("users/" + userId + "/roles/person");
}

// Users

function getCurrentUserInfo() {
    return get("users/" + localStorage.getObject("authData").userId);
}

function deleteUser() {

}

// Zones

function getZones() {
    return get("zones");
}

function getZoneSchedule() {

}
