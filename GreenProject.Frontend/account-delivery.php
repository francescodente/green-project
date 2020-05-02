<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Consegne</title>
</head>
<body class="req-login">

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br/>
                <h3 class="text-light">Consegne</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">
            <div id="account-delivery" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">

                    <div class="chip-container d-flex flex-wrap mb-2">
                        <a href="#" class="chip px-2 selected">
                            <span>Oggi</span>
                        </a>
                        <a href="#" class="chip px-2">
                            <span>Domani</span>
                        </a>
                        <a href="#" class="chip px-2">
                            <span>1 Marzo</span>
                        </a>
                    </div>

                    <div class="dropdown select mb-3">
                        <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                            <input id="cap-select-toggle" type="text" placeholder=" " readonly/>
                            <label for="cap-select-toggle">CAP</label>
                        </div>
                        <div class="dropdown-menu" aria-labelledby="select-toggle">
                            <input id="cap-toggle" type="checkbox" class="checkbox toggle-all" data-toggle-all="cap-select"/>
                            <label for="cap-toggle">All</label>
                            <input id="cap1" type="checkbox" class="checkbox" name="cap-select" value="1"/>
                            <label for="cap1">First option</label>
                            <input id="cap2" type="checkbox" class="checkbox" name="cap-select" value="2"/>
                            <label for="cap2">Second option</label>
                            <input id="cap3" type="checkbox" class="checkbox" name="cap-select" value="3"/>
                            <label for="cap3">Third option</label>
                            <input id="cap4" type="checkbox" class="checkbox" name="cap-select" value="4"/>
                            <label for="cap4">Fourth option</label>
                            <input id="cap5" type="checkbox" class="checkbox" name="cap-select" value="5"/>
                            <label for="cap5">Fifth option</label>
                        </div>
                    </div>

                    <!-- <div class="empty-state m-5">
                        <img src="images/empty.png"/>
                        <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun prodotto da ritirare</h6>
                        <p class="text-center text-dis-dark m-0">In questa sezione sono visualizzati i fornitori da visitare per il carico di ogni giorno.</p>
                    </div> -->

                    <!-- Order -->
                    <div class="order mb-4">
                        <div class="order-header container p-3" data-toggle="collapse" data-target="#order-1" aria-expanded="true">
                            <div class="row">
                                <div class="col-12 d-flex justify-content-between align-items-center">
                                    <div>
                                        <p class="text-sec-dark font-weight-bold mb-2">Ordine N° <span class="order-number">201905100001</span> del <span class="order-date">1 Gen 2020</span> (<span class="product-count">3</span> prodotti)</p>
                                        <div class="d-flex align-items-center mb-1">
                                            <i class="mdi dark small mdi-account mr-2"></i>
                                            <a href=# class="show-client-info text-sec-dark" data-toggle="modal" data-target="#modal-client-info-1">Name Surname</a>
                                        </div>
                                        <div class="d-flex align-items-center">
                                            <i class="mdi dark small mdi-map-marker mr-2"></i>
                                            <span class="text-sec-dark"><a href="#" class="order-delivery-address text-sec-dark">Viale della Via 123, 47522 - Cesena (FC)</a></span>
                                        </div>
                                    </div>
                                    <button class="btn-collapse btn icon ripple flex-shrink-0" data-toggle="collapse" data-target="#order-1" aria-expanded="false" data-tooltip="tooltip" title="Mostra">
                                        <i class="mdi dark mdi-chevron-down"></i>
                                    </button>
                                </div>
                                <div class="col-12 pt-3 order-actions">
                                    <button class="order-ship btn outline ripple w-100" data-toggle="modal" data-target="#modal-order-shipped">Spedisci</button>
                                </div>
                            </div>
                        </div>
                        <div id="order-1" class="order-content container collapse">
                            <div class="row">
                                <!-- Order products -->
                                <div class="product-group-table products table-responsive">
                                    <table class="table m-0">
                                        <tbody>
                                            <?php
                                            for ($i = 0; $i < 3; $i++) {
                                                ?>
                                                <tr>
                                                    <td class="nowrap">
                                                        <img class="product-image img-fluid" src="images/example_product.jpg"/>
                                                    </td>
                                                    <td style="padding-right: 12px;">
                                                        <p class="product-name m-0">Product name</p>
                                                        <div class="text-sec-dark d-flex justify-content-between">
                                                            <span class="product-weight">0Kg</span>
                                                            <span class="product-price">0.00€</span>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <?php
                                            }
                                            ?>
                                        </tbody>
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
                                                <td class="nowrap">
                                                    <span class="subtotal">0,00€</span><br/>
                                                    <span class="iva">0,00€</span><br/>
                                                    <span class="shipping">0,00€</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>TOTALE</td>
                                                <td class="nowrap"><span class="total">0,00€</span></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("resources.php") ?>

    <!-- USER INFO -->
    <div id="modal-client-info-1" class="modal-client-info modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top d-flex justify-content-center">
                    <i class="modal-top-icon mdi mdi-account-circle"></i>
                    <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi">
                        <i class="mdi dark mdi-close"></i>
                    </button>
                </div>
                <div class="modal-body">

                    <h4 class="text-center mb-3">Name Surname</h4>

                    <div class="d-flex align-items-center mb-2">
                        <i class="mdi dark mdi-email mr-3"></i>
                        <span>
                            <span class="text-sec-dark" style="font-size: 14px;">Email</span><br/>
                            <a href="mailto:info@fruitracers.com" target="_top">mail@domain.com</a>
                        </span>
                    </div>

                    <div class="d-flex align-items-center mb-2">
                        <i class="mdi dark mdi-phone mr-3"></i>
                        <span>
                            <span class="text-sec-dark" style="font-size: 14px;">Telefono</span><br/>
                            <a href="tel:123-456-7890">+391234567890</a>
                        </span>
                    </div>

                    <div class="d-flex align-items-center">
                        <i class="mdi dark mdi-map-marker mr-3"></i>
                        <span>
                            <span class="text-sec-dark" style="font-size: 14px;">Indirizzo</span><br/>
                            <a href="#" class="order-delivery-address">Viale della Via 123, 47522 - Cesena (FC)</a>
                        </span>
                    </div>


                </div>
            </div>
        </div>
    </div>

    <div id="modal-order-shipped" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-truck-delivery-outline"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Contrassegnare questo ordine come <strong>spedito</strong>?<br/>Il cliente sarà notificato del cambio di stato.</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Conferma</button>
                </div>
            </div>
        </div>
    </div>

    <div id="modal-order-completed" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-truck-check-outline"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Contrassegnare questo ordine come <strong>completato</strong>?</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Conferma</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function() {
            $(document).on("click", ".order-ship, .order-deliver, .show-client-info", function(event) {
                event.stopPropagation();
            });
        });
    </script>

</body>
</html>
