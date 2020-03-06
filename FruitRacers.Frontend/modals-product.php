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
                    <a href="company.php" class="company-name d-inline-block mb-2">Company name</a>
                    <p class="product-description text-sec-dark m-0">
                        Some quick example text to build on the component and make up the bulk of the component's content.
                    </p>
                </div>
            </div>
            <div class="card-footer d-flex justify-content-between align-items-center">
                <p class="product-price m-0 ml-1">€00,00 / kg</p>
                <button class="add-to-cart btn icon ripple" data-dismiss="modal" data-toggle="modal" data-target="#modal-cart-add" title="Aggiungi al carrello">
                    <i class="mdi dark mdi-cart-plus"></i>
                </button>
            </div>
        </div>
    </div>
</div>

<!-- ADD TO CART -->
<div id="modal-cart-add" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-cart-plus"></i>
                <button class="modal-close btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <div class="modal-body">
                <h4 class="text-center">Seleziona la quantità</h4>
                <div class="d-flex align-items-center mb-2">
                    <button class="q-increase btn icon ripple mr-2" title="Diminuisci"><i class="mdi dark mdi-minus"></i></button>
                    <div class="text-input flex-grow-1">
                        <input id="product-quantity" class="w-100" type="text" value="1"/>
                        <span class="um">Kg</span>
                    </div>
                    <button class="q-increase btn icon ripple ml-2" title="Aumenta"><i class="mdi dark mdi-plus"></i></button>
                </div>
                <p class="text-center m-0"><span class="price">0,00</span><span class="currency">€</span></p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="modal-cancel btn accent ripple" data-dismiss="modal" style="width: 160px;">Ok</button>
            </div>
        </div>
    </div>
</div>
