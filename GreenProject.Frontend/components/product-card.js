function ProductCard(product) {
    product.html = getTemplate("ProductCard");
    $(product.html).find(".product-name").html(product.name);
    product.addToCart = addToCart;
    product.showModal = showModal;
    return product;
}

function addToCart() {
    console.log("add to cart " + this.productId);
}

function showModal() {
    console.log("show modal " + this.productId);
}
