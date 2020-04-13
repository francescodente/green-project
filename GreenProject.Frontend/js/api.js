var serverAddress = "localhost:5000";
var apiVer = "v1";
var basePath = "http://" + serverAddress + "/api/" + apiVer + "/";

function getBasePath() {
    return basePath;
}

function ajax(method, url, data) {
    return $.ajax({
        headers: {
            "authorization" : "bearer TOKEN",
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        method: method,
        url: getBasePath() + url,
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

}

function createAddress(userId, address) {

}

function deleteAddress(userId, addressId) {

}

// Authentication

function authToken(data) {
    return post("auth/token", data);
}

function renewUserAuth() {

}

function changePsw() {

}

function signup(data) {
    return post("auth/register", data);
}

function logout() {
    sessionStorage.clear();
}

// Cart

function getCart() {

}

function editCartOptions() {

}

function addToCart() {

}

function editCartQuantity() {

}


function removeFromCart() {

}

function createOrder() {

}


// Categories

function getCategories() {

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

function createSupplierLogo() {

}

function deleteSupplierLogo() {

}

function createSupplierBackground() {

}

function deleteSupplierBackground() {

}

// Products

function getProducts(categories, pageNumber = 0, pageSize = 30) {
    return get("products");
}

function createProduct() {

}

function editProduct() {

}

function deleteProduct() {

}

// Roles



// Suppliers

function getSuppliers() {

}

// Support

function sendSupportRequest() {

}

// TimeSlots

function getTimeSlots() {

}

function addTimeSlotOverride() {

}

// Users

function getUsers() {

}

function deleteUsers() {

}
