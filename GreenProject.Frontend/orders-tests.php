<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Test stati ordine</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="test" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">TEST STATI ORDINE</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/privacy.jpg"></div>
        </section>
        <section id="test-content" class="container py-4">
            <div class="row">
                <div class="col-12">

                    <h4>Ordini cliente</h4>
                    <i class="order-pending mdi mdi-progress-clock"></i>
                    <span class="order-pending">In attesa</span><br/>
                    <i class="order-working mdi mdi-cogs"></i>
                    <span class="order-working">In lavorazione</span><br/>
                    <i class="order-shipped mdi mdi-truck-delivery-outline"></i>
                    <span class="order-shipped">Spedito</span><br/>
                    <i class="order-ok mdi mdi-check-circle-outline"></i>
                    <span class="order-ok">Completato</span><br/>
                    <i class="order-canceled mdi mdi-close-circle-outline"></i>
                    <span class="order-canceled">Annullato</span><br/>

                    <h4>Ordini fornitore</h4>
                    <i class="order-pending mdi mdi-progress-clock"></i>
                    <span class="order-pending">In attesa</span><br/>
                    <i class="order-working mdi mdi-cogs"></i>
                    <span class="order-working">In lavorazione</span><br/>
                    <i class="order-ok mdi mdi-check-circle-outline"></i>
                    <span class="order-ok">Accettato</span><br/>
                    <i class="order-canceled mdi mdi-close-circle-outline"></i>
                    <span class="order-canceled">Rifiutato</span><br/>
                    <i class="order-shipped mdi mdi-truck-delivery-outline"></i>
                    <span class="order-shipped">Spedito</span><br/>

                    <div class="table-wrapper table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col" class="nowrap"></th>
                                    <th scope="col">Prodotto</th>
                                    <th scope="col" class="nowrap">Stato</th>
                                </tr>
                            </thead>
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
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

    <!-- CHANGE STATUS -->
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

    <!-- CONFIRM AVAILABLE -->
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

    <!-- CONFIRM MISSING -->
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