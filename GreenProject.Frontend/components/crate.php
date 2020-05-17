<!-- CRATE ITEM -->
<div data-template-name="CrateCard" data-class="card product-card mb-4" class="d-none">
    <a href="#" class="crate-modal-link fixed-ratio fr-1-1 img-hover-zoom">
        <img class="crate-image card-bg" src="images/default_product.png"/>
        <div class="cover"><button class="btn round outline light">Visualizza</button></div>
    </a>
    <div class="card-body">
        <h5 class="crate-name mb-0"></h5>
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
                    <h4 class="crate-name mb-1"></h4>
                    <p class="crate-description text-sec-dark mb-2"></p>
                    <p class="m-0"><span class="capacity"></span> Kg - <span class="price"></span></p>
                </div>
            </div>
            <div class="card-footer d-flex flex-column">
                <button class="subscribe btn accent ripple">Abbonati</button>
            </div>
        </div>
    </div>
</div>

<!-- WEEKLY ENTRY -->
<table class="d-none">
    <tr data-template-name="CrateWeeklyEntry" data-class="area-collapse bg-primary-dark" data-toggle="collapse" data-target="#collapse-ODID" class="d-none">
        <th class="nowrap">
            <img class="crate-image img-fluid" src="images/default_product.png"/>
        </th>
        <th>
            <p class="crate-name text-sec-dark m-0"></p>
            <p class="text-sec-dark font-weight-normal m-0">
                <span class="capacity"></span> <span class="crate-um">Kg</span> - <span class="price"></span>
            </p>
        </th>
        <td class="nowrap actions" style="border-top: none!important;">
            <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#collapse-ODID" aria-expanded="false">
                <i class="mdi mdi-chevron-down"></i>
            </button>
            <div class="dropdown">
                <button class="btn icon ripple" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-boundary="viewport">
                    <i class="mdi dark mdi-dots-vertical"></i>
                </button>
                <div class="dropdown-menu dropdown-menu-right">
                    <a href="#" type="button" class="show-remove-modal dropdown-item">Elimina</a>
                </div>
            </div>
        </td>
    </tr>
</table>

<!-- ORDER ENTRY -->
<div data-template-name="CrateOrderEntry" data-class="product d-flex align-items-center" class="d-none">
    <a href="#" class="crate-modal-link">
        <img class="crate-image" src="images/default_product.png"/>
    </a>
    <div class="d-flex flex-column w-100">
        <p class="crate-name m-0"></p>
        <div class="d-flex justify-content-between">
            <span class="text-sec-dark"><span class="capacity"></span> <span class="crate-um">Kg</span></span>
            <span class="price text-sec-dark"></span>
        </div>
    </div>
</div>

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
