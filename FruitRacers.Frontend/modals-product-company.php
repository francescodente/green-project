<!-- PRODUCT -->
<div id="modal-product" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="card-header-image fixed-ratio fr-4-3">
                <img class="product-image card-bg" src="images/example_product.jpg"/>
                <div class="image-shade-top"></div>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" title="Chiudi"><i class="mdi light mdi-close"></i></button>
            </div>
            <div class="card-body">
                <div class="product-info">
                    <h4 class="product-name mb-1">Product name</h4>
                    <a href="#" class="company-name d-inline-block mb-2" data-switch-to="#modal-company">Company name</a>
                    <p class="product-description m-0">
                        Some quick example text to build on the component and make up the bulk of the component's content.
                    </p>
                </div>
            </div>
            <div class="card-footer d-flex justify-content-between align-items-center">
                <p class="product-price text-sec-dark m-0">€00,00 / kg</p>
                <button class="add-to-cart btn icon ripple"><i class="mdi dark mdi-cart-plus" title="Aggiungi al carrello"></i></button>
            </div>
        </div>
    </div>
</div>

<!-- COMPANY -->
<div id="modal-company" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top p-3">
                <h5 class="company-name font-weight-bold text-center my-2">Company name</h5>
                <button class="btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <div class="modal-body p-0">
                <div class="card-image">
                    <div class="fixed-ratio fr-4-3" style="background-image: url('#');"></div>
                </div>
                <div class="card-content p-3">
                    <a href="#" class="company-address text-sec-dark">Viale della Via 123, Cesena (FC)</a>
                    <p class="company-description mt-3">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </p>
                </div>
                <div class="company-links d-flex justify-content-center p-3">
                    <a href="products.php" class="company-products btn accent ripple">Visualizza i prodotti</a>
                </div>
            </div>
        </div>
    </div>
</div>
