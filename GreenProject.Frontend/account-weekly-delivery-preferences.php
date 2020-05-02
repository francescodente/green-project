<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Consegna settimanale</title>
</head>
<body class="req-login">

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br/>
                <h3 class="text-light">Consegna settimanale</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">
            <div id="user-weekly-delivery" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">

                    <div class="alert alert-accent" role="alert">
                        <p class="summary-preferences text-sec-dark m-0">
                            La prossima consegna include <span class="crate-count">1</span> cassette e <span class="product-count">2</span> prodotti sfusi, per un totale di <span class="total">0.00€</span>.<br/>Sarà effettuata il giorno <span class="delivery-date">1 Gen 2020</span> all'indirizzo <span class="delivery-address">Viale della Via 123, 47522 Cesena (FC)</span> con modalità di pagamento <span class="payment-method">alla consegna</span>.<br/>Ti ricordiamo che è possibile modificare le preferenze del tuo ordine settimanale solo fino a <span>48 ore</span> prima della consegna prestabilita.
                        </p>
                    </div>

                    <h4 class="mb-2">Cassette</h4>
                    <p class="text-sec-dark mb-4">
                        Di seguito sono riportate le cassette alle quali sei abbonato.<br/>Riceverai questi prodotti ogni settimana a casa tua!
                    </p>
                    <div class="product-group-table table-wrapper table-responsive">
                        <table class="table">
                            <thead>
                                <tr class="bg-primary-dark">
                                    <th class="nowrap">
                                        <a href="#" data-toggle="modal" data-target="#modal-product">
                                            <img class="product-image img-fluid" src="images/example_crate.jpg"/>
                                        </a>
                                    </th>
                                    <th>
                                        <p class="product-name text-sec-dark m-0">Cassetta 10Kg</p>
                                        <p class="text-sec-dark font-weight-normal m-0">
                                            <span class="product-quantity">9.5/10</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                        </p>
                                    </th>
                                    <th class="nowrap actions">
                                        <div class="dropdown">
                                            <button class="btn icon ripple" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                <i class="mdi dark mdi-dots-vertical"></i>
                                            </button>
                                            <div class="dropdown-menu">
                                                <a href="#" class="dropdown-item" data-toggle="modal" data-target="#modal-product-remove">Elimina</a>
                                            </div>
                                        </div>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="nowrap">
                                        <a href="#" data-toggle="modal" data-target="#modal-product">
                                            <img class="product-image img-fluid" src="images/example_product.jpg"/>
                                        </a>
                                    </td>
                                    <td>
                                        <p class="product-name m-0">Product name</p>
                                        <p class="product-weight text-sec-dark m-0">0.5Kg</p>
                                    </td>
                                    <td class="nowrap actions">
                                        <div class="d-flex justify-content-end">
                                            <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-product-add" data-tooltip="tooltip" title="Modifica quantità">
                                                <i class="mdi dark mdi-pencil"></i>
                                            </button>
                                            <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-product-remove" data-tooltip="tooltip" title="Rimuovi">
                                                <i class="mdi dark mdi-close"></i>
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="nowrap">
                                        <a href="#" data-toggle="modal" data-target="#modal-product">
                                            <img class="product-image img-fluid" src="images/example_product.jpg"/>
                                        </a>
                                    </td>
                                    <td>
                                        <p class="product-name m-0">Product name</p>
                                        <p class="product-weight text-sec-dark m-0">0.5Kg</p>
                                    </td>
                                    <td class="nowrap actions">
                                        <div class="d-flex justify-content-end">
                                            <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-product-add" data-tooltip="tooltip" title="Modifica quantità">
                                                <i class="mdi dark mdi-pencil"></i>
                                            </button>
                                            <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-product-remove" data-tooltip="tooltip" title="Rimuovi">
                                                <i class="mdi dark mdi-close"></i>
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="p-0">
                                        <button class="btn add-product ripple" data-toggle="modal" data-target="#modal-weekly-product-add">
                                            <div class="add-product-icon mr-3">
                                                <i class="mdi dark mdi-plus"></i>
                                            </div>
                                            <span class="text-sec-dark">Aggiungi un prodotto</span>
                                        </button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <h4 class="mt-4 bb-2">Altri prodotti</h4>
                    <p class="text-sec-dark mb-4">
                        Solo per la prossima consegna, riceverai i seguenti prodotti in aggiunta alle cassette a cui sei abbonato.
                    </p>
                    <div class="product-group-table products table-wrapper table-responsive">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="nowrap">
                                        <a href="#" data-toggle="modal" data-target="#modal-product">
                                            <img class="product-image img-fluid" src="images/example_product.jpg"/>
                                        </a>
                                    </td>
                                    <td>
                                        <p class="product-name m-0">Product name</p>
                                        <p class="text-sec-dark m-0">
                                            <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                        </p>
                                    </td>
                                    <td class="nowrap actions">
                                        <div class="d-flex justify-content-end">
                                            <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-product-add" data-tooltip="tooltip" title="Modifica quantità">
                                                <i class="mdi dark mdi-pencil"></i>
                                            </button>
                                            <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-product-remove" data-tooltip="tooltip" title="Rimuovi">
                                                <i class="mdi dark mdi-close"></i>
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="nowrap">
                                        <a href="#" data-toggle="modal" data-target="#modal-product">
                                            <img class="product-image img-fluid" src="images/example_product.jpg"/>
                                        </a>
                                    </td>
                                    <td>
                                        <p class="product-name m-0">Product name</p>
                                        <p class="text-sec-dark m-0">
                                            <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                        </p>
                                    </td>
                                    <td class="nowrap actions">
                                        <div class="d-flex justify-content-end">
                                            <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-product-add" data-tooltip="tooltip" title="Modifica quantità">
                                                <i class="mdi dark mdi-pencil"></i>
                                            </button>
                                            <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-product-remove" data-tooltip="tooltip" title="Rimuovi">
                                                <i class="mdi dark mdi-close"></i>
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="p-0">
                                        <button class="btn add-product ripple" data-toggle="modal" data-target="#modal-weekly-product-add">
                                            <div class="add-product-icon mr-3">
                                                <i class="mdi dark mdi-plus"></i>
                                            </div>
                                            <span class="text-sec-dark">Aggiungi un prodotto</span>
                                        </button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <h4 class="my-4">Riepilogo</h4>

                    <div class="summary-products table-wrapper table-responsive">
                        <table class="table">
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

                    <div class="divider dark mt-5 mb-4"></div>

                    <?php include("order-preferences.php"); ?>

                    <div class="divider dark my-4"></div>

                    <!-- SUBSCRIPTION OPTIONS -->
                    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#weekly-order-skip" aria-expanded="false">
                        <h4 class="m-0">Opzioni abbonamento</h4>
                        <button type="button" class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#weekly-order-skip" aria-expanded="false" data-tooltip="tooltip" title="Nascondi">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>
                    <div id="weekly-order-skip" class="collapse">
                        <div class="pt-4"></div>

                        <h5>Salta una consegna</h5>
                        <p class="text-sec-dark mb-2">
                            Sei in vacanza? Nessun problema! Puoi saltare la prossima consegna cliccando il tasto sottostante.
                        </p>
                        <button class="btn accent ripple mb-4" data-toggle="modal" data-target="#modal-skip-delivery">Salta una consegna</button>

                        <h5>Cancella abbonamento</h5>
                        <p class="text-sec-dark mb-2">
                            Se vuoi annullare la prossima consegna e disdire l'abbonamento settimanale clicca il tasto sottostante.<br/> Speriamo di rivederti presto!
                        </p>
                        <button class="btn accent ripple" data-toggle="modal" data-target="#modal-delete-subscription">Cancella abbonamento</button>

                    </div>

                </div>

            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("resources.php"); ?>

    <?php include("modal-new-address.php"); ?>

    <div id="modal-product-remove" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-delete-empty"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Sei sicuro di voler rimuovere questo prodotto dalla consegna settimanale?</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Rimuovi</button>
                </div>
            </div>
        </div>
    </div>

    <div id="modal-skip-delivery" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-help-circle-outline"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Sei sicuro di voler annullare la consegna settimanale prevista per il giorno <span class="delivery-date font-weight-bold">1 Gen 2020</span>?<br/>Se confermi, la prossima consegna sarà effettuata il giorno <span class="delivery-date-new font-weight-bold">8 Gen 2020</span>.</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Conferma</button>
                </div>
            </div>
        </div>
    </div>

    <div id="modal-delete-subscription" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-help-circle-outline"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Sei sicuro di voler disdire il tuo abbonamento?</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Conferma</button>
                </div>
            </div>
        </div>
    </div>

    <div id="modal-weekly-product-add" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" role="document">
            <div class="modal-content" style="width: 500px;">
                <div class="modal-top">
                    <h5 class="m-0">Seleziona un prodotto</h5>
                    <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi">
                        <i class="mdi dark mdi-close"></i>
                    </button>
                </div>
                <div class="modal-body p-0">
                    <div class="product-group-table products table-wrapper table-responsive">
                        <table class="table">
                            <tbody>
                                <?php
                                for ($i = 0; $i < 20; $i++) {
                                    ?>
                                    <tr>
                                        <td colspan="4" class="p-0">
                                            <button class="btn add-product ripple" data-dismiss="modal" data-toggle="modal" data-target="#modal-product-add">
                                                <img class="product-image img-fluid mr-3" src="images/example_product.jpg"/>
                                                <span class="font-weight-normal mr-auto">Product name</span>
                                                <span class="font-weight-normal text-sec-dark mr-3">0.00€/Kg</span>
                                            </button>
                                        </td>
                                    </tr>
                                    <?php
                                }
                                ?>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
