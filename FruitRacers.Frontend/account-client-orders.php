<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Account</title>
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
            <div id="client-orders" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">

                    <div class="d-flex justify-content-between align-items-center mb-4">
                        <h4 class="m-0">Ordini</h4>
                        <button class="btn icon ripple" disabled><i class="mdi"></i></button>
                    </div>

                    <div class="orders">

                        <div class="order mb-4">
                            <div class="order-header p-3">
                                <p class="m-0">Ordine N° <span class="order-number">201905100001</span> del <span class="order-date">1 Gen 2020</span></p>
                            </div>
                            <div class="container">
                                <div class="row">
                                    <div class="products-col col-12 col-lg-6 pt-3 pb-4 pb-lg-3">
                                        <h5>Prodotti</h5>
                                        <div class="order-products-list mr-2">
                                            <div class="product d-flex align-items-center mb-2">
                                                <a href="#" data-toggle="modal" data-target="#modal-product">
                                                    <img class="product-image" src="images/example_product.jpg"/>
                                                </a>
                                                <div class="d-flex flex-column w-100">
                                                    <p class="product-name m-0">Product name</p>
                                                    <div class="d-flex justify-content-between">
                                                        <span class="text-sec-dark"><span class="product-quantity">1</span><span class="product-unit">Kg</span></span>
                                                        <span class="product-price text-sec-dark">€0,00</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="product d-flex align-items-center mb-2">
                                                <a href="#" data-toggle="modal" data-target="#modal-product">
                                                    <img class="product-image" src="images/example_product.jpg"/>
                                                </a>
                                                <div class="d-flex flex-column w-100">
                                                    <p class="product-name m-0">Product name</p>
                                                    <div class="d-flex justify-content-between">
                                                        <span class="text-sec-dark"><span class="product-quantity">1</span><span class="product-unit">Kg</span></span>
                                                        <span class="product-price text-sec-dark">€0,00</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="product d-flex align-items-center mb-2">
                                                <a href="#" data-toggle="modal" data-target="#modal-product">
                                                    <img class="product-image" src="images/example_product.jpg"/>
                                                </a>
                                                <div class="d-flex flex-column w-100">
                                                    <p class="product-name m-0">Product name</p>
                                                    <div class="d-flex justify-content-between">
                                                        <span class="text-sec-dark"><span class="product-quantity">1</span><span class="product-unit">Kg</span></span>
                                                        <span class="product-price text-sec-dark">€0,00</span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="cost-summary mx-2">
                                            <div class="divider dark my-3"></div>
                                            <div class="d-flex justify-content-between text-sec-dark">
                                                <span>SUBTOTALE</span>
                                                <span>€<span class="subtotal">0,00</span></span>
                                            </div>
                                            <div class="d-flex justify-content-between text-sec-dark">
                                                <span>IVA</span>
                                                <span>€<span class="vat">0,00</span></span>
                                            </div>
                                            <div class="d-flex justify-content-between text-sec-dark">
                                                <span>SPEDIZIONE</span>
                                                <span>€<span class="shipping">0,00</span></span>
                                            </div>
                                            <div class="divider dark my-3"></div>
                                            <div class="d-flex justify-content-between mt-2">
                                                <span>TOTALE</span>
                                                <span>€<span class="total">0,00</span></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="details-col col-12 col-lg-6 pt-3 pb-4 pb-lg-3">
                                        <div class="d-flex justify-content-between align-items-center mb-2">
                                            <h5 class="m-0">Dettagli</h5>
                                            <button class="btn icon ripple d-lg-none" data-toggle="collapse" data-target="#order-details-1" aria-expanded="false" title="Mostra">
                                                <i class="mdi dark mdi-chevron-down"></i>
                                            </button>
                                        </div>
                                        <div id="order-details-1" class="collapse mt-3 mx-2">
                                            <h6 class="text-sec-dark mb-1"><i class="mdi mdi-progress-clock"></i> STATO</h6>
                                            <p class="order-state">Completato</p>
                                            <h6 class="text-sec-dark mb-1"><i class="mdi mdi-calendar-clock"></i> CONSEGNA</h6>
                                            <p><span class="selected-date">1 Gen 2020</span> alle <span class="selected-time-slot">14:00 - 14:30</span></p>
                                            <h6 class="text-sec-dark mb-1"><i class="mdi mdi-map-marker"></i> INDIRIZZO</h6>
                                            <p class="address">Viale della Via 123, 47522 Cesena (FC)</p>
                                            <h6 class="text-sec-dark mb-1"><i class="mdi mdi-credit-card"></i> PAGAMENTO</h6>
                                            <p class="payment-method">Alla consegna</p>
                                            <h6 class="text-sec-dark mb-1"><i class="mdi mdi-lead-pencil"></i> NOTE</h6>
                                            <p class="notes m-0">-</p>
                                        </div>
                                        <button class="btn accent ripple d-flex justify-content-center w-100 mt-4">ANNULLA ORDINE</button>
                                    </div>
                                </div>
                            </div>
                        </div>

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
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>
    <script src="js/account-client-orders.js"></script>

    <?php include("modals-product-company.php"); ?>

</body>
</html>
