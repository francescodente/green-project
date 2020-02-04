var apiVer = "v1";

function ajax(type, url, data, success, fail, then) {
    $.ajax({
        headers: "authorization" : "bearer TOKEN",
        type: type,
        url: url,
        data: data
    })
    .success(function(data) {

    })
    .fail(function(data) {

    })
    .then(function(data) {

    });
}

function get(url, data, success, fail, then) {
    ajax("GET", url, data, success, fail, then);
}

function put(url, data, success, fail, then) {
    ajax("PUT", url, data, success, fail, then);
}

function post(url, data, success, fail, then) {
    ajax("POST", url, data, success, fail, then);
}

function delete(url, data, success, fail, then) {
    ajax("DELETE", url, data, success, fail, then);
}

// Addresses

function getAddresses(userId) {

}

function createAddress(userId, address) {

}

function deleteAddress(userId, addressId) {

}

// Authentication

function authUser() {

}

function renewUserAuth() {

}

function changePsw() {

}

function registerUser() {

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

function getProducts() {

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
