<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Ordini</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br>
                <h3 class="text-light">Ordini</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">
            <div id="business-orders" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">

                    <div class="nav nav-tabs nav-justified" id="nav-tab" role="tablist" style="margin-top: 7px;">
                        <a class="nav-item nav-link ripple active" id="nav-open-orders-tab" data-toggle="tab" href="#nav-open-orders" role="tab"
                           aria-controls="nav-open-orders" aria-selected="true">
                            IN CORSO
                        </a>
                        <a class="nav-item nav-link ripple" id="nav-order-history-tab" data-toggle="tab" href="#nav-order-history" role="tab"
                           aria-controls="nav-order-history" aria-selected="false">
                            CRONOLOGIA
                        </a>
                    </div>
                    <div class="tab-content my-4" id="nav-tabContent">

                        <!-- CURRENT ORDERS -->
                        <div class="tab-pane fade show active" id="nav-open-orders" role="tabpanel" aria-labelledby="nav-open-orders-tab">

                            <!-- <div class="empty-state m-5">
                                <img src="images/empty.png"/>
                                <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun ordine attivo</h6>
                                <p class="text-center text-dis-dark m-0">In questa sezione sono visualizzati i prodotti da consegnare al nostro fattorino.</p>
                            </div> -->

                            <h4 class="mb-3">Oggi</h4>

                            <!-- Order -->
                            <div class="order mb-4">
                                <div class="order-header container p-3" data-toggle="collapse" data-target="#order-1" aria-expanded="true">
                                    <div class="row">
                                        <div class="col-12 d-flex justify-content-between align-items-center">
                                            <div>
                                                <p class="text-sec-dark font-weight-bold mb-2">Ordine N° <span class="order-number">201905100001</span> del <span class="order-date">1 Gen 2020</span></p>
                                                <div class="d-flex align-items-center">
                                                    <i class="order-working mdi small mdi-cogs mr-2"></i>
                                                    <span class="order-working">In lavorazione</span><br/>
                                                </div>
                                            </div>
                                            <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#order-1" aria-expanded="true">
                                                <i class="mdi dark mdi-chevron-down"></i>
                                            </button>
                                        </div>
                                        <div class="col-12 pt-3 product-actions">
                                            <button class="mark-all-available btn outline ripple" data-toggle="modal" data-target="#modal-change-order-status">Disponibile</button>
                                        </div>
                                    </div>
                                </div>
                                <div id="order-1" class="order-content container collapse show">
                                    <div class="row">
                                        <!-- Order products -->
                                        <div class="table-responsive">
                                            <table class="table m-0">
                                                <tbody>

                                                    <tr class="valign-middle">
                                                        <td scope="row" class="nowrap">
                                                            <img class="product-image" src="images/example_product.jpg" style="height: 48px; width: 48px;"/>
                                                        </td>
                                                        <td style="white-space: nowrap;">
                                                            <span class="product-name">Product name</span><br/>
                                                            <div class="text-sec-dark">
                                                                <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                                            </div>
                                                        </td>
                                                        <td class="nowrap">
                                                            <button class="btn transparent ripple" data-toggle="modal" data-target="#modal-change-status">
                                                                <i class="leading-icon order-pending mdi small mdi-progress-clock"></i>
                                                                <span class="order-pending">In attesa</span><br/>
                                                                <i class="trailing-icon mdi small dark mdi-open-in-new"></i>
                                                            </button>
                                                        </td>
                                                    </tr>

                                                    <tr class="valign-middle">
                                                        <td scope="row" class="nowrap">
                                                            <img class="product-image" src="images/example_product.jpg" style="height: 48px; width: 48px;"/>
                                                        </td>
                                                        <td style="white-space: nowrap;">
                                                            <span class="product-name">Product name</span><br/>
                                                            <div class="text-sec-dark">
                                                                <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                                            </div>
                                                        </td>
                                                        <td class="nowrap">
                                                            <button class="btn transparent ripple" style="pointer-events: none;">
                                                                <i class="leading-icon order-ok mdi small mdi-check-circle-outline"></i>
                                                                <span class="order-ok">Disponibile</span><br/>
                                                            </button>
                                                        </td>
                                                    </tr>

                                                    <tr class="valign-middle">
                                                        <td scope="row" class="nowrap">
                                                            <img class="product-image" src="images/example_product.jpg" style="height: 48px; width: 48px;"/>
                                                        </td>
                                                        <td style="white-space: nowrap;">
                                                            <span class="product-name">Product name</span><br/>
                                                            <div class="text-sec-dark">
                                                                <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                                            </div>
                                                        </td>
                                                        <td class="nowrap">
                                                            <button class="btn transparent ripple" style="pointer-events: none;">
                                                                <i class="leading-icon order-canceled mdi small mdi-close-circle-outline"></i>
                                                                <span class="order-canceled">Non disponibile</span><br/>
                                                            </button>
                                                        </td>
                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="divider dark mb-4"></div>

                            <h4>Domani</h4>

                            <div class="divider dark mb-4"></div>

                            <h4>1 Marzo</h4>

                        </div>
                        <div class="tab-pane fade" id="nav-order-history" role="tabpanel" aria-labelledby="nav-order-history-tab">

                            <!-- ORDER HISTORY -->

                            <div class="empty-state m-5">
                                <img src="images/empty.png"/>
                                <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">La cronologia ordini è vuota</h6>
                                <p class="text-center text-dis-dark m-0">Gli ordini completati vengono mostrati qui.</p>
                            </div>

                            <div class="divider dark mb-4"></div>
                            <div class="d-flex justify-content-center w-100">
                                <ul class="pagination">
                                    <li><a href="#" class="btn icon ripple disabled" title="Pagina precedente"><i class="mdi dark mdi-chevron-left"></i></a></li>
                                    <li><a href="#" class="selected">1</a></li>
                                    <li><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">5</a></li>
                                    <li><a href="#" class="btn icon ripple" title="Pagina successiva"><i class="mdi dark mdi-chevron-right"></i></a></li>
                                </ul>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

    <?php include("modals-product.php"); ?>

    <!-- CHANGE ORDER STATUS -->
    <div id="modal-change-order-status" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-cogs"></i>
                    <button class="modal-close btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
                </div>
                <div class="modal-body">
                    <p class="m-0">
                        Contrassegnare questo ordine come disponibile?<br/>Tutti i prodotti con stato <b class="order-pending">In attesa</b> contenuti nell'ordine saranno contrassegnati come disponibili e l'ordine sarà pronto per il ritiro da parte del fattorino.<br/><b>Attenzione</b>: questa operazione è irreversibile.
                    </p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Conferma</button>
                </div>
            </div>
        </div>
    </div>

    <!-- CHANGE PRODUCT STATUS -->
    <div id="modal-change-status" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-cogs"></i>
                    <button class="modal-close btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
                </div>
                <div class="modal-body">
                    <h4 class="text-center mb-3">Seleziona lo stato del prodotto</h4>
                    <div class="d-flex flex-column justify-content-center">
                        <button class="btn accent ripple flex-grow-1 mb-2" data-dismiss="modal" data-toggle="modal" data-target="#modal-confirm-available">Disponibile</button>
                        <button class="btn outline ripple flex-grow-1" data-dismiss="modal"  data-toggle="modal" data-target="#modal-confirm-missing">Non disponibile</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- CONFIRM PRODUCT AVAILABILITY -->
    <div id="modal-confirm-available" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon order-ok mdi mdi-check-circle-outline"></i>
                    <button class="modal-close btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
                </div>
                <div class="modal-body">
                    <p class="m-0">
                        Contrassegnare questo prodotto come disponibile?<br/>Nel caso in cui la quantità effettivamente disponibile sia inferiore all'importo dell'ordine, è possibile modificarla.<br/><b>Attenzione</b>: questa operazione è irreversibile.
                    </p>
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
                    <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Conferma</button>
                </div>
            </div>
        </div>
    </div>

    <!-- CONFIRM PRODUCT UNAVAILABILITY -->
    <div id="modal-confirm-missing" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi dark mdi-close-circle-outline"></i>
                    <button class="modal-close btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
                </div>
                <div class="modal-body">
                    <p class="m-0">
                        Contrassegnare questo prodotto come non disponibile? Il prodotto sarà rimosso dall'ordine.<br/><b>Attenzione</b>: questa operazione è irreversibile.
                    </p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Conferma</button>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
