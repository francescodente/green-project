<!-- PRODUCT ITEM -->
<div data-template-name="ProductCard" data-class="card product-card mb-4" class="d-none">
    <a href="#" class="product-modal-link fixed-ratio fr-1-1 img-hover-zoom">
        <img class="product-image card-bg" src="images/default_product.png"/>
        <div class="cover"><button class="btn round outline light">Visualizza</button></div>
    </a>
    <div class="card-body">
        <h5 class="product-name mb-0"></h5>
        <div class="d-flex justify-content-between align-items-center pt-2">
            <span class="text-sec-dark"><span class="multiplier"></span> <span class="unit"></span> - <span class="price"></span></span>
            <button class="show-quantity-modal btn icon ripple" data-tooltip="tooltip" title="Aggiungi al carrello">
                <i class="mdi dark mdi-cart-plus"></i>
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
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi"><i class="mdi light mdi-close"></i></button>
            </div>
            <div class="card-body">
                <div class="product-info">
                    <h4 class="product-name mb-1"></h4>
                    <p class="product-description text-sec-dark mb-2"></p>
                    <p class="m-0"><span class="multiplier"></span> <span class="unit"></span> - <span class="price"></span></p>
                </div>
            </div>
            <div class="card-footer">
                <div class="d-flex flex-column m-0">
                    <button class="show-quantity-modal btn accent ripple">Aggiungi al carrello</button>
                    <button class="req-subscription show-crate-quantity-modal btn outline ripple mt-2">Aggiungi all'ordine settimanale</button>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- CART QUANTITY MODAL -->
<div data-template-name="ProductQuantityModal" data-class="modal-product-quantity modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-plus-box-outline"></i>
                <button class="modal-close btn icon ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <div class="modal-body">
                <h4 class="text-center">Seleziona la quantità</h4>
                <div class="d-flex align-items-center mx-3 mb-2">
                    <div class="text-input flex-grow-1">
                        <input class="quantity" type="number" name="quantity" min="1" placeholder=" " value="1">
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

<!-- CRATE QUANTITY MODAL -->
<div data-template-name="ProductCrateQuantityModal" data-class="modal-product-quantity modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-plus-box-outline"></i>
                <button class="modal-close btn icon ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <div class="modal-body">
                <h4 class="text-center">Seleziona la quantità</h4>
                <div class="d-flex align-items-center mx-3 mb-2">
                    <div class="text-input flex-grow-1">
                        <input class="crate-quantity" type="number" name="quantity" min="1" placeholder=" " value="1">
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
                <button class="add-to-crate btn accent ripple" data-dismiss="modal" style="width: 160px;">Ok</button>
            </div>
        </div>
    </div>
</div>

<!-- CART REMOVE MODAL -->
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

<!-- CRATE REMOVE MODAL -->
<div data-template-name="ProductCrateRemoveModal" data-class="modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-delete-empty"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Sei sicuro di voler rimuovere questo prodotto dalla cassetta?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button class="remove-from-crate btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Rimuovi</button>
            </div>
        </div>
    </div>
</div>

<!-- CART ENTRY -->
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
                <button type="button" class="show-quantity-modal btn icon ripple mr-2" data-tooltip="tooltip" data-boundary="window" title="Modifica quantità">
                    <i class="mdi dark mdi-pencil"></i>
                </button>
                <button type="button" class="show-remove-modal btn icon ripple" data-tooltip="tooltip" data-boundary="window" title="Rimuovi">
                    <i class="mdi dark mdi-close"></i>
                </button>
            </div>
        </td>
    </tr>
</table>

<!-- ORDER ENTRY -->
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

<!-- PRODUCT IN CRATE ENTRY -->
<table class="d-none">
    <tr data-template-name="ProductInCrateEntry" class="d-none">
        <td class="nowrap">
            <img class="product-image img-fluid" src="images/default_product.png"/>
        </td>
        <td>
            <p class="product-name m-0">Product name</p>
            <p class="text-sec-dark m-0">
                <span class="text-sec-dark"><span class="multiplier"></span> <span class="unit"></span> - <span class="price"></span></span>
            </p>
        </td>
        <td class="nowrap actions">
            <div class="d-flex justify-content-end">
                <button type="button" class="show-crate-quantity-modal btn icon ripple mr-2" data-tooltip="tooltip" data-boundary="window" title="Modifica quantità">
                    <i class="mdi dark mdi-pencil"></i>
                </button>
                <button type="button" class="show-crate-remove-modal btn icon ripple" data-tooltip="tooltip" data-boundary="window" title="Rimuovi">
                    <i class="mdi dark mdi-close"></i>
                </button>
            </div>
        </td>
    </tr>
</table>

<!-- COMPATIBLE WITH CRATE ENTRY -->
<table class="d-none">
    <tr data-template-name="ProductCompatibleWithCrateEntry" class="d-none">
        <td class="p-0">
            <button class="show-crate-quantity-modal btn add-product ripple" data-dismiss="modal" data-toggle="modal" data-target="#modal-product-add">
                <img class="product-image img-fluid mr-3" src="images/default_product.png"/>
                <span class="product-name font-weight-normal"></span>
            </button>
        </td>
    </tr>
</table>

<!-- STARRED WEEKLY ENTRY -->
<table class="d-none">
    <tr data-template-name="StarredProductEntry" class="d-none">
        <td class="p-0">
            <button class="btn add-product ripple" data-dismiss="modal" data-toggle="modal" data-target="#modal-product-add">
                <img class="product-image img-fluid mr-3" src="images/default_product.png"/>
                <span class="product-name font-weight-normal mr-auto"></span>
                <span class="font-weight-normal text-sec-dark mr-3"><span class="multiplier font-weight-normal"></span> <span class="unit font-weight-normal"></span> - <span class="price font-weight-normal"></span></span>
            </button>
        </td>
    </tr>
</table>
