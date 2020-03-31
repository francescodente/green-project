<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Consegna settimanale</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br>
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

                    <h4 class="mb-2">Cassette</h4>
                    <p class="text-sec-dark mb-4">
                        Di seguito sono riportate le cassette alle quali sei abbonato.<br/>Riceverai questi prodotti ogni settimana a casa tua!
                    </p>
                    <div class="weekly-group table-wrapper table-responsive">
                        <table class="table">
                            <thead>
                                <tr class="bg-primary-dark">
                                    <th class="nowrap">
                                        <img class="product-image img-fluid" src="images/example_crate.jpg"/>
                                    </th>
                                    <th>
                                        <p class="product-name m-0">Cassetta 10Kg</p>
                                        <p class="text-sec-dark m-0">
                                            <span class="product-quantity">9.5/10</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                        </p>
                                    </th>
                                    <th class="nowrap actions">
                                        <div class="d-flex justify-content-end">
                                            <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-cart-delete" title="Rimuovi">
                                                <i class="mdi dark mdi-close"></i>
                                            </button>
                                        </div>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="nowrap">
                                        <img class="product-image img-fluid" src="images/example_product.jpg"/>
                                    </td>
                                    <td>
                                        <p class="product-name m-0">Product name</p>
                                        <p class="product-weight text-sec-dark m-0">0.5Kg</p>
                                    </td>
                                    <td class="nowrap actions">
                                        <div class="d-flex justify-content-end">
                                            <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-cart-add" title="Modifica quantità">
                                                <i class="mdi dark mdi-pencil"></i>
                                            </button>
                                            <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-cart-delete" title="Rimuovi">
                                                <i class="mdi dark mdi-close"></i>
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="nowrap">
                                        <img class="product-image img-fluid" src="images/example_product.jpg"/>
                                    </td>
                                    <td>
                                        <p class="product-name m-0">Product name</p>
                                        <p class="product-weight text-sec-dark m-0">0.5Kg</p>
                                    </td>
                                    <td class="nowrap actions">
                                        <div class="d-flex justify-content-end">
                                            <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-cart-add" title="Modifica quantità">
                                                <i class="mdi dark mdi-pencil"></i>
                                            </button>
                                            <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-cart-delete" title="Rimuovi">
                                                <i class="mdi dark mdi-close"></i>
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="p-0">
                                        <button class="btn add-product ripple">
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
                    <div class="weekly-group products table-wrapper table-responsive">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="nowrap">
                                        <img class="product-image img-fluid" src="images/example_product.jpg"/>
                                    </td>
                                    <td>
                                        <p class="product-name m-0">Product name</p>
                                        <p class="text-sec-dark m-0">
                                            <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                        </p>
                                    </td>
                                    <td class="nowrap actions">
                                        <div class="d-flex justify-content-end">
                                            <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-cart-add" title="Modifica quantità">
                                                <i class="mdi dark mdi-pencil"></i>
                                            </button>
                                            <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-cart-delete" title="Rimuovi">
                                                <i class="mdi dark mdi-close"></i>
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="nowrap">
                                        <img class="product-image img-fluid" src="images/example_product.jpg"/>
                                    </td>
                                    <td>
                                        <p class="product-name m-0">Product name</p>
                                        <p class="text-sec-dark m-0">
                                            <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                        </p>
                                    </td>
                                    <td class="nowrap actions">
                                        <div class="d-flex justify-content-end">
                                            <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-cart-add" title="Modifica quantità">
                                                <i class="mdi dark mdi-pencil"></i>
                                            </button>
                                            <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-cart-delete" title="Rimuovi">
                                                <i class="mdi dark mdi-close"></i>
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="p-0">
                                        <button class="btn add-product ripple">
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

                    <p class="summary-preferences text-sec-dark mb-4">
                        La prossima consegna sarà effettuata il giorno <span class="delivery-date font-weight-bold">1 Gen 2020</span> all'indirizzo <span class="delivery-address font-weight-bold">Viale della Via 123, 47522 Cesena (FC)</span> con modalità di pagamento <span class="payment-method font-weight-bold">alla consegna</span>.<br/>Di seguito è possibile modificare le preferenze dell'ordine.
                    </p>

                    <div class="divider dark my-4"></div>

                    <?php include("order-preferences.php"); ?>

                </div>

            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

    <?php include("modals-address-management.php"); ?>

</body>
</html>
