<!-- CUSTOMER ORDER -->
<div data-template-name="OrderCard" data-class="order mb-4" class="d-none">
    <div class="order-header area-collapse d-flex justify-content-between align-items-center p-3" data-toggle="collapse" data-target="#order-OID" aria-expanded="true">
        <div>
            <p class="text-sec-dark font-weight-bold mb-2">Ordine N° <span class="order-number"></span> del <span class="order-date"></span></p>
            <div class="order-state d-flex align-items-center m-0"></div>
        </div>
        <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#order-OID" aria-expanded="true" data-tooltip="tooltip" title="Nascondi">
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
                    <button class="btn-collapse btn icon ripple d-lg-none" data-toggle="collapse" data-target="#order-details-OID" aria-expanded="false" data-tooltip="tooltip" title="Mostra">
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

<!-- DELIVERY ORDER -->
<div data-template-name="DeliveryOrderCard" data-class="order mb-4" class="d-none">
    <div class="order-header area-collapse container p-3" data-toggle="collapse" data-target="#order-OID" aria-expanded="true">
        <div class="row">
            <div class="col-12 d-flex justify-content-between align-items-center">
                <div>
                    <p class="text-sec-dark font-weight-bold mb-2">Ordine N° <span class="order-number"></span> (<span class="product-count"></span> <span class="product-count-label-1">prodotto</span><span class="product-count-label">prodotti</span>)</p>
                    <div class="order-state d-flex align-items-center mb-2"></div>
                    <div class="d-flex align-items-center mb-1">
                        <i class="mdi dark small mdi-account mr-2"></i>
                        <a href=# class="show-client-modal client-name text-sec-dark"></a>
                    </div>
                    <div class="d-flex align-items-center">
                        <i class="mdi dark small mdi-map-marker mr-2"></i>
                        <span class="text-sec-dark"><a href="#" target="_blank" class="address text-sec-dark"></a></span>
                    </div>
                </div>
                <button class="btn-collapse btn icon ripple flex-shrink-0" data-toggle="collapse" data-target="#order-OID" aria-expanded="false" data-tooltip="tooltip" title="Mostra">
                    <i class="mdi dark mdi-chevron-down"></i>
                </button>
            </div>
            <div class="col-12 pt-3 order-actions">
                <button class="show-shipped-modal btn outline ripple w-100">Spedisci</button>
                <button class="show-completed-modal btn outline ripple w-100">Consegna</button>
            </div>
        </div>
    </div>
    <div id="order-OID" class="order-content container collapse">
        <div class="row">
            <div class="product-group-table products table-responsive">
                <table class="table m-0">
                    <tbody class="order-products-list"></tbody>
                </table>
            </div>
            <div class="divider dark m-0"></div>
            <div class="summary-products table-responsive">
                <table class="table mb-0">
                    <tbody>
                        <tr class="text-sec-dark">
                            <td>
                                SUBTOTALE<br/>
                                IVA<br/>
                                SPEDIZIONE
                            </td>
                            <td class="nowrap text-right">
                                <span class="subtotal"></span><br/>
                                <span class="iva"></span><br/>
                                <span class="shipping"></span>
                            </td>
                        </tr>
                        <tr>
                            <td>TOTALE</td>
                            <td class="nowrap"><span class="total"></span></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<!-- SHIPPED MODAL -->
<div data-template-name="OrderShippedModal" data-class="modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-truck-delivery-outline"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Contrassegnare questo ordine come <strong>spedito</strong>?<br/>Il cliente sarà notificato del cambio di stato.</p>
                <div class="loader text-center mt-3">
                    <?php include("loader.php"); ?>
                </div>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button class="set-state-shipped btn accent ripple flex-grow-1" style="width: 100px;">Conferma</button>
            </div>
        </div>
    </div>
</div>

<!-- COMPLETED MODAL -->
<div data-template-name="OrderCompletedModal" data-class="modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-truck-check-outline"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Contrassegnare questo ordine come <strong>completato</strong>?</p>
                <div class="loader text-center mt-3">
                    <?php include("loader.php"); ?>
                </div>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button class="set-state-completed btn accent ripple flex-grow-1" style="width: 100px;">Conferma</button>
            </div>
        </div>
    </div>
</div>

<!-- USER INFO -->
<div data-template-name="ClientInfoModal" data-class="modal-client-info modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top d-flex justify-content-center">
                <i class="modal-top-icon mdi mdi-account-circle"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi">
                    <i class="mdi dark mdi-close"></i>
                </button>
            </div>
            <div class="modal-body">
                <h4 class="client-name text-center mb-3"></h4>
                <!-- <div class="d-flex align-items-center mb-2">
                    <i class="mdi dark mdi-email mr-3"></i>
                    <span>
                        <span class="text-sec-dark" style="font-size: 14px;">Email</span><br/>
                        <a href="mailto:info@fruitracers.com" target="_top">mail@domain.com</a>
                    </span>
                </div> -->
                <div class="d-flex align-items-center mb-2">
                    <i class="mdi dark mdi-phone mr-3"></i>
                    <span>
                        <span class="text-sec-dark" style="font-size: 14px;">Telefono</span><br/>
                        <a href="#" class="telephone"></a>
                    </span>
                </div>
                <div class="d-flex align-items-center">
                    <i class="mdi dark mdi-map-marker mr-3"></i>
                    <span>
                        <span class="text-sec-dark" style="font-size: 14px;">Indirizzo</span><br/>
                        <a href="#" class="address"></a>
                    </span>
                </div>
            </div>
        </div>
    </div>
</div>
