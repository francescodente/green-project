<div data-template-name="OrderCard" data-class="order mb-4" class="d-none">
    <div class="order-header area-collapse d-flex justify-content-between align-items-center p-3" data-toggle="collapse" data-target="#order-OID" aria-expanded="true">
        <div>
            <p class="text-sec-dark font-weight-bold mb-2">Ordine N° <span class="order-number"></span> del <span class="order-date"></span></p>
            <div class="order-state d-flex align-items-center m-0"></div>
        </div>
        <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#order-OID" aria-expanded="true">
            <i class="mdi dark mdi-chevron-down"></i>
        </button>
    </div>
    <div id="order-OID" class="order-content container collapse show">
        <div class="row">
            <div class="products-col col-12 col-lg-6 pt-3 pb-4 pb-lg-3">
                <h5>Prodotti</h5>
                <div class="order-products-list mr-2"></div>
                <div class="cost-summary mx-2">
                    <div class="divider dark my-3"></div>
                    <div class="d-flex justify-content-between text-sec-dark">
                        <span>SUBTOTALE</span><span class="subtotal"></span>
                    </div>
                    <div class="d-flex justify-content-between text-sec-dark">
                        <span>IVA</span><span class="iva"></span>
                    </div>
                    <div class="d-flex justify-content-between text-sec-dark">
                        <span>SPEDIZIONE</span><span class="shipping"></span>
                    </div>
                    <div class="divider dark my-3"></div>
                    <div class="d-flex justify-content-between mt-2">
                        <span>TOTALE</span><span class="total"></span>
                    </div>
                </div>
            </div>
            <div class="details-col col-12 col-lg-6 pt-3 pb-4 pb-lg-3 d-flex flex-column">
                <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#order-details-OID" aria-expanded="false">
                    <h5 class="m-0">Dettagli</h5>
                    <button class="btn-collapse btn icon ripple d-lg-none" data-toggle="collapse" data-target="#order-details-OID" aria-expanded="false" title="Mostra">
                        <i class="mdi dark mdi-chevron-down"></i>
                    </button>
                </div>
                <div id="order-details-OID" class="collapse mt-3 mx-2 flex-grow-1">
                    <div class="d-flex align-items-center mb-1">
                        <i class="mdi small dark mdi-calendar-clock mr-2"></i>
                        <h6 class="h-variant text-sec-dark m-0">Consegna</h6>
                    </div>
                    <p class="delivery-date"></p>
                    <div class="d-flex align-items-center mb-1">
                        <i class="mdi small dark mdi-map-marker mr-2"></i>
                        <h6 class="h-variant text-sec-dark m-0">Indirizzo</h6>
                    </div>
                    <p class="address"></p>
                    <div class="d-flex align-items-center mb-1">
                        <i class="mdi small dark mdi-credit-card mr-2"></i>
                        <h6 class="h-variant text-sec-dark m-0">Pagamento</h6>
                    </div>
                    <p class="payment-method">Alla consegna</p>
                    <div class="d-flex align-items-center mb-1">
                        <i class="mdi small dark mdi-lead-pencil mr-2"></i>
                        <h6 class="h-variant text-sec-dark m-0">Note</h6>
                    </div>
                    <p class="notes m-0"></p>
                </div>
            </div>
        </div>
    </div>
</div>