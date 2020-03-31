<!-- PAYMENT METHOD -->
<div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#order-payment-method" aria-expanded="false">
    <h4 class="m-0">Modalità di pagamento</h4>
    <button type="button" class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#order-payment-method" aria-expanded="false" title="Nascondi">
        <i class="mdi dark mdi-chevron-down"></i>
    </button>
</div>
<div id="order-payment-method" class="collapse">
    <div class="pt-3"></div>

    <input id="pm1" type="radio" class="rich-radio" name="payment-method" value="1" checked/>
    <label for="pm1" class="payment-item d-flex align-items-center p-2">
        <div class="thumb flex-shrink-0">
            <i class="mdi dark mdi-cash-multiple"></i>
        </div>
        <div>
            <p class="m-0">Pagamento alla consegna</p>
        </div>
    </label>
    <input id="pm2" type="radio" class="rich-radio" name="payment-method" value="2" disabled/>
    <label for="pm2" class="payment-item d-flex align-items-center p-2 m-0">
        <div class="thumb flex-shrink-0">
            <i class="mdi dark mdi-credit-card"></i>
        </div>
        <div>
            <p class="m-0">Ulteriori opzioni per il pagamento sono in arrivo!</p>
        </div>
    </label>

</div>

<div class="divider dark my-4"></div>

<!-- DELIVERY ADDRESS -->
<div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#order-delivery-address" aria-expanded="false">
    <h4 class="m-0">Indirizzo di consegna</h4>
    <button type="button" class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#order-delivery-address" aria-expanded="false" title="Nascondi">
        <i class="mdi dark mdi-chevron-down"></i>
    </button>
</div>
<div id="order-delivery-address" class="collapse">
    <div class="pt-3"></div>

    <input id="da1" type="radio" class="rich-radio" name="delivery-address" value="1" checked/>
    <label for="da1" class="address-item d-flex flex-column p-2" data-toggle="modal" data-target="#modal-address-default">
        <div class="d-flex align-items-center">
            <div class="thumb flex-shrink-0" style="background-image: url('images/map-thumb.png');">
                <i class="mdi mdi-map-marker"></i>
            </div>
            <p class="mb-0">Viale della Via 123, 47522 - Cesena (FC)</p>
        </div>
        <div style="margin-left: 64px;">
            <div class="d-flex align-items-center mb-1">
                <i class="mdi small dark mdi-account mr-2"></i>
                <span class="text-sec-dark">Nome cognome</span>
            </div>
            <div class="d-flex align-items-center">
                <i class="mdi small dark mdi-phone mr-2"></i>
                <span class="text-sec-dark">+39 1234567890</span>
            </div>
        </div>
    </label>
    <input id="da2" type="radio" class="rich-radio" name="delivery-address" value="2"/>
    <label for="da2" class="address-item d-flex flex-column p-2" data-toggle="modal" data-target="#modal-address-default">
        <div class="d-flex align-items-center">
             <div class="thumb flex-shrink-0" style="background-image: url('images/map-thumb.png');">
                <i class="mdi mdi-map-marker"></i>
            </div>
            <p class="mb-0">Viale della Via 123, 47522 - Cesena (FC)</p>
        </div>
        <div style="margin-left: 64px;">
            <div class="d-flex align-items-center mb-1">
                <i class="mdi small dark mdi-account mr-2"></i>
                <span class="text-sec-dark">Nome cognome</span>
            </div>
            <div class="d-flex align-items-center">
                <i class="mdi small dark mdi-phone mr-2"></i>
                <span class="text-sec-dark">+39 1234567890</span>
            </div>
        </div>
    </label>
    <div class="d-flex justify-content-end">
        <a href="account-user-addresses.php" class="btn outline ripple mr-2 flex-grow-1 flex-md-grow-0">
            <span class="text-sec-dark">Gestisci</span>
            <i class="mdi dark mdi-map-marker"></i>
        </a>
        <button type="button" class="btn outline ripple flex-grow-1 flex-md-grow-0" data-toggle="modal" data-target="#modal-address-add">
            <span class="text-sec-dark">Aggiungi</span>
            <i class="mdi dark mdi-plus"></i>
        </button>
    </div>

</div>

<div class="divider dark my-4"></div>

<!-- NOTES -->
<div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#order-notes" aria-expanded="false">
    <h4 class="m-0">Note</h4>
    <button type="button" class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#order-notes" aria-expanded="false" title="Nascondi">
        <i class="mdi dark mdi-chevron-down"></i>
    </button>
</div>
<div id="order-notes" class="collapse">
    <div class="pt-3"></div>

    <div class="text-area mb-0">
        <textarea id="notes" class="w-100" placeholder=" "></textarea>
        <span>Inserisci qui il tuo buono sconto!</span>
    </div>

</div>

<!-- Set default address modal -->
<div id="modal-address-default" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-help-circle-outline"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Impostare questo indirizzo come predefinito per gli acquisti futuri?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">No</button>
                <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Sì</button>
            </div>
        </div>
    </div>
</div>
