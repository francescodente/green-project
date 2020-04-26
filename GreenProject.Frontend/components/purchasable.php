<!-- PRODUCT ITEM -->
<div data-template-name="ProductCard" data-class="card product-card mb-4" class="d-none">
    <a href="#" class="product-modal-link fixed-ratio fr-1-1 img-hover-zoom">
        <img class="product-image card-bg" src="images/default_product.png"/>
        <div class="cover"><button class="btn round outline light">Visualizza</button></div>
    </a>
    <div class="card-body">
        <h5 class="product-name mb-0">Product name</h5>
        <div class="d-flex justify-content-between align-items-center pt-2">
            <span class="text-sec-dark"><span class="multiplier"></span> <span class="unit"></span> - <span class="price"></span></span>
            <button class="show-quantity-modal btn icon ripple" title="Aggiungi al carrello">
                <i class="mdi dark mdi-cart-plus"></i>
            </button>
        </div>
    </div>
</div>

<!-- CRATE ITEM -->
<div data-template-name="CrateCard" data-class="card product-card mb-4" class="d-none">
    <a href="#" class="crate-modal-link fixed-ratio fr-1-1 img-hover-zoom">
        <img class="crate-image card-bg" src="images/default_product.png"/>
        <div class="cover"><button class="btn round outline light">Visualizza</button></div>
    </a>
    <div class="card-body">
        <h5 class="crate-name mb-0">Product name</h5>
        <div class="d-flex justify-content-between align-items-center pt-2">
            <span class="text-sec-dark"><span class="capacity"></span> Kg - <span class="price"></span></span>
            <button class="subscribe btn icon ripple" title="Abbonati">
                <i class="mdi dark mdi-bookmark-plus-outline"></i>
            </button>
        </div>
    </div>
</div>

<!-- PRODUCT MODAL -->
<div data-template-name="ProductDetailsModal" data-class="modal-product modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="card-header-image fixed-ratio fr-4-3">
                <img class="product-image card-bg" src="images/default_product.png"/>
                <div class="image-shade-top"></div>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" title="Chiudi"><i class="mdi light mdi-close"></i></button>
            </div>
            <div class="card-body">
                <div class="product-info">
                    <h4 class="product-name mb-1">Product name</h4>
                    <p class="product-description text-sec-dark m-0">
                        Some quick example text to build on the component and make up the bulk of the component's content.
                    </p>
                </div>
            </div>
            <div class="card-footer d-flex justify-content-between align-items-center">
                <p class="m-0 ml-1"><span class="multiplier"></span> <span class="unit"></span> - <span class="price"></span></p>
                <button class="show-quantity-modal btn icon ripple" data-dismiss="modal" title="Aggiungi al carrello">
                    <i class="mdi dark mdi-cart-plus"></i>
                </button>
            </div>
        </div>
    </div>
</div>

<!-- CRATE MODAL -->
<div data-template-name="CrateDetailsModal" data-class="modal-product modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="card-header-image fixed-ratio fr-4-3">
                <img class="crate-image card-bg" src="images/default_product.png"/>
                <div class="image-shade-top"></div>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" title="Chiudi"><i class="mdi light mdi-close"></i></button>
            </div>
            <div class="card-body">
                <div class="crate-info">
                    <h4 class="crate-name mb-1">Product name</h4>
                    <p class="crate-description text-sec-dark m-0">
                        Some quick example text to build on the component and make up the bulk of the component's content.
                    </p>
                </div>
            </div>
            <div class="card-footer d-flex justify-content-between align-items-center">
                <p class="m-0 ml-1"><span class="capacity"></span> Kg - <span class="price"></span></p>
                <button class="subscribe btn icon ripple" title="Abbonati">
                <i class="mdi dark mdi-bookmark-plus-outline"></i>
            </button>
            </div>
        </div>
    </div>
</div>

<!-- QUANTITY MODAL -->
<div data-template-name="ProductQuantityModal" data-class="modal-product-quantity modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-plus-box-outline"></i>
                <button class="modal-close btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <div class="modal-body">
                <h4 class="text-center">Seleziona la quantità</h4>
                <div class="d-flex align-items-center mx-3 mb-2">
                    <div class="text-input flex-grow-1">
                        <input type="number" name="quantity" min="1" placeholder=" " value="1">
                        <button class="inc btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-up"></i></button>
                        <button class="dec btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-down"></i></button>
                    </div>
                </div>
                <p class="text-center m-0"><span class="multiplier"></span> <span class="unit"></span> - <span class="price"></span></p>
                <div class="loader text-center mt-3">
                    <?php include("loader.php"); ?>
                </div>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="add-to-cart btn accent ripple" data-dismiss="modal" style="width: 160px;">Ok</button>
            </div>
        </div>
    </div>
</div>

<!-- REMOVE MODAL -->
<div data-template-name="ProductRemoveModal" data-class="modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-delete-empty"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Sei sicuro di voler rimuovere questo prodotto dal carrello?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button class="remove-from-cart btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Rimuovi</button>
            </div>
        </div>
    </div>
</div>

<!-- PRODUCT CART ENTRY -->
<table class="d-none">
    <tr data-template-name="ProductCartEntry" class="d-none">
        <td class="nowrap">
            <a href="#" class="product-modal-link">
                <img class="product-image img-fluid" src="images/default_product.png"/>
            </a>
        </td>
        <td>
            <p class="product-name m-0">Product name</p>
            <p class="text-sec-dark m-0">
                <span class="text-sec-dark"><span class="multiplier"></span> <span class="unit"></span> - <span class="price"></span></span>
            </p>
        </td>
        <td class="nowrap actions">
            <div class="d-flex justify-content-end">
                <button type="button" class="show-quantity-modal btn icon ripple mr-2" title="Modifica quantità">
                    <i class="mdi dark mdi-pencil"></i>
                </button>
                <button type="button" class="show-remove-modal btn icon ripple" data-toggle="modal" data-target="#modal-cart-delete" title="Rimuovi">
                    <i class="mdi dark mdi-close"></i>
                </button>
            </div>
        </td>
    </tr>
</table>

<!-- PRODUCT ORDER ENTRY -->
<div data-template-name="ProductOrderEntry" data-class="product d-flex align-items-center" class="d-none">
    <a href="#" class="product-modal-link">
        <img class="product-image" src="images/default_product.png"/>
    </a>
    <div class="d-flex flex-column w-100">
        <p class="product-name m-0"></p>
        <div class="d-flex justify-content-between">
            <span class="text-sec-dark"><span class="multiplier"></span> <span class="unit"></span></span>
            <span class="price text-sec-dark"></span>
        </div>
    </div>
</div>
