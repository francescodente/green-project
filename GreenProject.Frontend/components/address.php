<!-- ADDRESS CARD -->
<div data-template-name="AddressCard" data-class="address-item d-flex justify-content-between align-items-center p-2" class="d-none">
    <div class="d-flex flex-column">
        <div class="d-flex align-items-center">
            <div class="thumb flex-shrink-0" style="background-image: url('images/map-thumb.png');">
                <i class="mdi mdi-map-marker"></i>
            </div>
            <p class="address-string mb-0"></p>
        </div>
        <div style="margin-left: 64px;">
            <div class="d-flex align-items-center mb-1">
                <i class="mdi small dark mdi-account mr-2"></i>
                <span class="address-name text-sec-dark"></span>
            </div>
            <div class="d-flex align-items-center">
                <i class="mdi small dark mdi-phone mr-2"></i>
                <span class="address-telephone text-sec-dark"></span>
            </div>
        </div>
    </div>
    <div class="dropdown mb-auto">
        <button class="btn icon ripple" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            <i class="mdi dark mdi-dots-vertical"></i>
        </button>
        <div class="dropdown-menu dropdown-menu-right">
            <a href="#" class="address-set-default dropdown-item">
                <i class="mdi dark mdi-star"></i>
                <span>Imposta predefinito</span>
            </a>
            <a href="#" class="address-show-delete-modal dropdown-item">
                <i class="mdi dark mdi-delete"></i>
                <span>Elimina</span>
            </a>
        </div>
    </div>
</div>

<!-- DELETE ADDRESS MODAL -->
<div data-template-name="DeleteAddressModal" data-class="modal-address-delete modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-delete-empty"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Sei sicuro di voler eliminare questo indirizzo?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button class="address-delete btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Ok</button>
            </div>
        </div>
    </div>
</div>

<!-- ADDRESS RICH RADIO BUTTON -->
<div data-template-name="AddressRadio" class="d-none">
    <input type="radio" class="rich-radio" name="delivery-address"/>
    <label class="address-item d-flex flex-column p-2">
        <div class="d-flex align-items-center">
            <div class="thumb flex-shrink-0" style="background-image: url('images/map-thumb.png');">
                <i class="mdi mdi-map-marker"></i>
            </div>
            <p class="address-string mb-0"></p>
        </div>
        <div style="margin-left: 64px;">
            <div class="d-flex align-items-center mb-1">
                <i class="mdi small dark mdi-account mr-2"></i>
                <span class="address-name text-sec-dark"></span>
            </div>
            <div class="d-flex align-items-center">
                <i class="mdi small dark mdi-phone mr-2"></i>
                <span class="address-telephone text-sec-dark"></span>
            </div>
        </div>
    </label>
</div>

<!-- SET DEFAULT ADDRESS MODAL -->
<div data-template-name="SetDefaultAddressModal" data-class="modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-help-circle-outline"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Impostare questo indirizzo come predefinito per gli acquisti futuri?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">No</button>
                <button class="address-set-default btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Sì</button>
            </div>
        </div>
    </div>
</div>
