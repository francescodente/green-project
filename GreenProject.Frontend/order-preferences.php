<div id="order-preferences-loader" class="loader text-center my-5">
    <?php include("loader.php"); ?>
</div>

<div class="order-preferences-content">
    <!-- PAYMENT METHOD -->
    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#order-payment-method" aria-expanded="false">
        <h4 class="m-0">Modalità di pagamento</h4>
        <button type="button" class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#order-payment-method" aria-expanded="false" data-tooltip="tooltip" title="Mostra">
            <i class="mdi dark mdi-chevron-down"></i>
        </button>
    </div>
    <div id="order-payment-method" class="collapse">
        <div class="pt-4"></div>

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
        <button type="button" class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#order-delivery-address" aria-expanded="false" data-tooltip="tooltip" title="Mostra">
            <i class="mdi dark mdi-chevron-down"></i>
        </button>
    </div>
    <div id="order-delivery-address" class="collapse">
        <div class="pt-4"></div>

        <div class="addresses-no-results empty-state m-5 d-none">
            <img src="images/empty.png" alt="Nessun indirizzo"/>
            <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun indirizzo</h6>
            <p class="text-center text-dis-dark m-0">
                In questa sezione sono elencati i tuoi indirizzi.
            </p>
        </div>

        <div class="addresses-error empty-state m-5 d-none">
            <i class="mdi mdi-emoticon-sad-outline"></i>
            <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Oops! Qualcosa è andato storto</h6>
            <p class="text-center text-dis-dark m-0">
                C'è stato un errore, ti preghiamo di riprovare.
            </p>
        </div>

        <div class="address-list"></div>

        <div class="d-flex justify-content-end">
            <a href="account-user-addresses.php" class="btn outline ripple mr-2 flex-grow-1 flex-md-grow-0" style="flex-basis: 120px;">
                <span class="text-sec-dark">Gestisci</span>
                <i class="mdi dark mdi-map-marker"></i>
            </a>
            <button type="button" class="btn outline ripple flex-grow-1 flex-md-grow-0"  style="flex-basis: 120px;" data-toggle="modal" data-target="#modal-new-address">
                <span class="text-sec-dark">Aggiungi</span>
                <i class="mdi dark mdi-plus"></i>
            </button>
        </div>

    </div>

    <div class="divider dark my-4"></div>

    <!-- NOTES -->
    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#order-notes" aria-expanded="false">
        <h4 class="m-0">Note</h4>
        <button type="button" class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#order-notes" aria-expanded="false" data-tooltip="tooltip" title="Mostra">
            <i class="mdi dark mdi-chevron-down"></i>
        </button>
    </div>
    <div id="order-notes" class="collapse">
        <div class="pt-3"></div>
        <div class="text-area mb-0">
            <textarea id="notes" class="w-100" placeholder=" "></textarea>
            <span>Inserisci qui il tuo buono sconto!</span>
        </div>
        <div class="d-flex justify-content-end">
            <button id="save-notes" class="btn outline ripple req-weekly-delivery d-none" style="width: 120px;" disabled>
                <span class="text-sec-dark">Salva</span>
                <i class="mdi dark mdi-content-save"></i>
            </button>
        </div>
    </div>
</div>

<script defer src="js/pages/order-preferences.js"></script>
