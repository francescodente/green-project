<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Ordini</title>
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

                    <div class="orders">

                        <!-- <div class="empty-state m-5">
                            <img src="images/empty.png"/>
                            <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Non hai effettuato ordini</h6>
                            <p class="text-center text-dis-dark m-0">Visualizza l'elenco del nostri <a href="companies.php">partner</a> per cominciare con gli acquisti!</p>
                        </div> -->

                        <div class="order mb-4">
                            <div class="order-header area-collapse d-flex justify-content-between align-items-center p-3" data-toggle="collapse" data-target="#order-1" aria-expanded="true">
                                <div>
                                    <p class="text-sec-dark font-weight-bold mb-2">Ordine N° <span class="order-number">201905100001</span> del <span class="order-date">1 Gen 2020</span></p>
                                    <div class="d-flex align-items-center m-0">
                                        <i class="order-pending mdi small mdi-progress-clock mr-2"></i>
                                        <span class="order-pending">In attesa</span>
                                    </div>
                                </div>
                                <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#order-1" aria-expanded="true">
                                    <i class="mdi dark mdi-chevron-down"></i>
                                </button>
                            </div>
                            <div id="order-1" class="order-content container collapse show">
                                <div class="row">
                                    <div class="products-col col-12 col-lg-6 pt-3 pb-4 pb-lg-3">
                                        <h5>Prodotti</h5>
                                        <div class="order-products-list mr-2">
                                            <?php
                                            for ($i = 0; $i < 3; $i++) {
                                                ?>
                                                <div class="product d-flex align-items-center">
                                                    <a href="#" data-toggle="modal" data-target="#modal-product">
                                                        <img class="product-image" src="images/example_product.jpg"/>
                                                    </a>
                                                    <div class="d-flex flex-column w-100">
                                                        <p class="product-name m-0">Product name</p>
                                                        <div class="d-flex justify-content-between">
                                                            <span class="text-sec-dark"><span class="product-quantity">1</span><span class="product-unit"> Kg</span></span>
                                                            <span class="product-price text-sec-dark">0,00€</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <?php
                                            }
                                            ?>
                                        </div>
                                        <div class="cost-summary mx-2">
                                            <div class="divider dark my-3"></div>
                                            <div class="d-flex justify-content-between text-sec-dark">
                                                <span>SUBTOTALE</span>
                                                <span><span class="subtotal">0,00</span>€</span>
                                            </div>
                                            <div class="d-flex justify-content-between text-sec-dark">
                                                <span>IVA</span>
                                                <span><span class="vat">0,00</span>€</span>
                                            </div>
                                            <div class="d-flex justify-content-between text-sec-dark">
                                                <span>SPEDIZIONE</span>
                                                <span><span class="shipping">0,00</span>€</span>
                                            </div>
                                            <div class="divider dark my-3"></div>
                                            <div class="d-flex justify-content-between mt-2">
                                                <span>TOTALE</span>
                                                <span><span class="total">0,00</span>€</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="details-col col-12 col-lg-6 pt-3 pb-4 pb-lg-3 d-flex flex-column">
                                        <div class="area-collapse d-flex justify-content-between align-items-center mb-2" data-toggle="collapse" data-target="#order-details-1" aria-expanded="false">
                                            <h5 class="m-0">Dettagli</h5>
                                            <button class="btn-collapse btn icon ripple d-lg-none" data-toggle="collapse" data-target="#order-details-1" aria-expanded="false" title="Mostra">
                                                <i class="mdi dark mdi-chevron-down"></i>
                                            </button>
                                        </div>
                                        <div id="order-details-1" class="collapse mt-2 mx-2 flex-grow-1">
                                            <h6 class="text-sec-dark mb-1"><i class="mdi small mdi-calendar-clock mr-2"></i>CONSEGNA</h6>
                                            <p><span class="selected-date">1 Gen 2020</span> alle <span class="selected-time-slot">14:00 - 14:30</span></p>
                                            <h6 class="text-sec-dark mb-1"><i class="mdi small mdi-map-marker mr-2"></i>INDIRIZZO</h6>
                                            <p class="address">Viale della Via 123, 47522 Cesena (FC)</p>
                                            <h6 class="text-sec-dark mb-1"><i class="mdi small mdi-credit-card mr-2"></i>PAGAMENTO</h6>
                                            <p class="payment-method">Alla consegna</p>
                                            <h6 class="text-sec-dark mb-1"><i class="mdi small mdi-lead-pencil mr-2"></i>NOTE</h6>
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

    <?php include("modals-product.php"); ?>

</body>
</html>
