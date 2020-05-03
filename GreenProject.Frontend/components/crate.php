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
            <button class="subscribe btn icon ripple" data-tooltip="tooltip" title="Abbonati">
                <i class="mdi dark mdi-bookmark-plus-outline"></i>
            </button>
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
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi"><i class="mdi light mdi-close"></i></button>
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
                <button class="subscribe btn icon ripple" data-tooltip="tooltip" title="Abbonati">
                <i class="mdi dark mdi-bookmark-plus-outline"></i>
            </button>
            </div>
        </div>
    </div>
</div>

<!-- WEEKLY ENTRY -->
<table class="d-none">
    <tr data-template-name="CrateWeeklyEntry" data-class="bg-primary-dark" class="d-none">
        <th class="nowrap">
            <a href="#" class="crate-modal-link">
                <img class="crate-image img-fluid" src="images/default_product.png"/>
            </a>
        </th>
        <th>
            <p class="crate-name text-sec-dark m-0"></p>
            <p class="text-sec-dark font-weight-normal m-0">
                <span class="capacity"></span> <span class="crate-um">Kg</span> - <span class="price"></span>
            </p>
        </th>
        <th class="nowrap actions">
            <div class="dropdown">
                <button class="btn icon ripple" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="mdi dark mdi-dots-vertical"></i>
                </button>
                <div class="dropdown-menu">
                    <a href="#" type="button" class="show-remove-modal dropdown-item">Elimina</a>
                </div>
            </div>
        </th>
    </tr>
</table>

<!-- REMOVE MODAL -->
<div data-template-name="CrateRemoveModal" data-class="modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-delete-empty"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Sei sicuro di voler rimuovere questa cassetta dalla tua consegna settimanale?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button class="remove-from-preferences btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Rimuovi</button>
            </div>
        </div>
    </div>
</div>
