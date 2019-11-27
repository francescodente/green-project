<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Carrello</title>
</head>
<body>
    <div>

        <?php include("menu.php"); ?>

        <section id="cart" class="parallax-container header d-flex justify-content-center align-items-center" data-section="cart">
            <div class="container text-center">
                <h1 class="text-light">CARRELLO</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/cart.jpg"></div>
        </section>
        <section id="cart-content" class="container py-4" data-section="cart">
            <form class="row">
                <div class="col-12 col-lg-8">

                    <!-- PRODUCTS -->
                    <h4>Prodotti</h4>
                    <h5 class="mt-3"><a href="#" class="company-name" data-toggle="modal" data-target="#modal-company">Azienda</a></h5>
                    <div class="product d-flex align-items-center justify-content-between mb-2">
                        <div class="d-flex align-items-center">
                            <a href="#" data-toggle="modal" data-target="#modal-product">
                                <img class="product-image" src="images/example_product.jpg"/>
                            </a>
                            <p class="m-0">
                                <span class="product-name">Product name</span><br>
                                <span class="text-sec-dark">€<span class="product-total-price text-sec-dark">0,00</span></span>
                            </p>
                        </div>
                        <div class="product-quantity-section d-flex align-items-center">
                            <span>€<span class="product-unitary-price">0,00</span> × </span>
                            <div class="product-quantity-col d-flex flex-column align-items-center">
                                <div class="text-input">
                                    <input class="product-quantity" type="text" value="1"/>
                                </div>
                                <button type="button" class="inc-quantity btn icon ripple" title="Aumenta"><i class="mdi dark mdi-plus"></i></button>
                                <button type="button" class="dec-quantity btn icon ripple" title="Diminuisci"><i class="mdi dark mdi-minus"></i></button>
                            </div>
                            <span> <span class="product-unit">Kg</span></span>
                        </div>
                        <button type="button" class="delete-cart-product btn icon ripple" title="Rimuovi"><i class="mdi dark mdi-delete"></i></button>
                    </div>
                    <div class="product d-flex align-items-center justify-content-between mb-2">
                        <div class="d-flex align-items-center">
                            <a href="#" data-toggle="modal" data-target="#modal-product">
                                <img class="product-image" src="images/example_product.jpg"/>
                            </a>
                            <p class="m-0">
                                <span class="product-name">Product name</span><br>
                                <span class="text-sec-dark">€<span class="product-total-price text-sec-dark">0,00</span></span>
                            </p>
                        </div>
                        <div class="product-quantity-section d-flex align-items-center">
                            <span>€<span class="product-unitary-price">0,00</span> × </span>
                            <div class="product-quantity-col d-flex flex-column align-items-center">
                                <div class="text-input">
                                    <input class="product-quantity" type="text" value="1"/>
                                </div>
                                <button type="button" class="inc-quantity btn icon ripple" title="Aumenta"><i class="mdi dark mdi-plus"></i></button>
                                <button type="button" class="dec-quantity btn icon ripple" title="Diminuisci"><i class="mdi dark mdi-minus"></i></button>
                            </div>
                            <span> <span class="product-unit">Kg</span></span>
                        </div>
                        <button type="button" class="delete-cart-product btn icon ripple" title="Rimuovi"><i class="mdi dark mdi-delete"></i></button>
                    </div>
                    <h5 class="mt-3"><a href="#" class="company-name" data-toggle="modal" data-target="#modal-company">Azienda</a></h5>
                    <div class="product d-flex align-items-center justify-content-between mb-2">
                        <div class="d-flex align-items-center">
                            <a href="#" data-toggle="modal" data-target="#modal-product">
                                <img class="product-image" src="images/example_product.jpg"/>
                            </a>
                            <p class="m-0">
                                <span class="product-name">Product name</span><br>
                                <span class="text-sec-dark">€<span class="product-total-price text-sec-dark">0,00</span></span>
                            </p>
                        </div>
                        <div class="product-quantity-section d-flex align-items-center">
                            <span>€<span class="product-unitary-price">0,00</span> × </span>
                            <div class="product-quantity-col d-flex flex-column align-items-center">
                                <div class="text-input">
                                    <input class="product-quantity" type="text" value="1"/>
                                </div>
                                <button type="button" class="inc-quantity btn icon ripple" title="Aumenta"><i class="mdi dark mdi-plus"></i></button>
                                <button type="button" class="dec-quantity btn icon ripple" title="Diminuisci"><i class="mdi dark mdi-minus"></i></button>
                            </div>
                            <span> <span class="product-unit">Kg</span></span>
                        </div>
                        <button type="button" class="delete-cart-product btn icon ripple" title="Rimuovi"><i class="mdi dark mdi-delete"></i></button>
                    </div>


                    <!-- PAYMENT METHOD -->
                    <h4 class="mt-5 mb-4">Modalità di pagamento</h4>
                    <input id="pm1" type="radio" class="rich-radio" name="payment-method" value="1" checked/>
                    <label for="pm1" class="d-flex align-items-center">
                        <div class="thumb">
                            <i class="mdi dark mdi-cash-multiple"></i>
                        </div>
                        <div>
                            <p class="m-0">Pagamento alla consegna</p>
                        </div>
                    </label>
                    <input id="pm2" type="radio" class="rich-radio" name="payment-method" value="2" disabled/>
                    <label for="pm2" class="d-flex align-items-center">
                        <div class="thumb">
                            <i class="mdi dark mdi-credit-card"></i>
                        </div>
                        <div>
                            <p class="m-0">Ulteriori opzioni per il pagamento sono in arrivo!</p>
                        </div>
                    </label>

                    <!-- DELIVERY ADDRESS -->
                    <h4 class="mt-5 mb-4">Indirizzo di consegna</h4>
                    <input id="da1" type="radio" class="rich-radio" name="delivery-address" value="1" checked/>
                    <label for="da1" class="d-flex align-items-center">
                        <div class="thumb" style="background-image: url('images/map-thumb.png');">
                            <i class="mdi mdi-map-marker"></i>
                        </div>
                        <div>
                            <p class="m-0">Viale della Via 123, 47522 - Cesena (FC)</p>
                        </div>
                    </label>
                    <input id="da2" type="radio" class="rich-radio" name="delivery-address" value="2"/>
                    <label for="da2" class="d-flex align-items-center">
                        <div class="thumb" style="background-image: url('images/map-thumb.png');">
                            <i class="mdi mdi-map-marker"></i>
                        </div>
                        <div>
                            <p class="m-0">Altra Via 999, 47522 - Cesena (FC)</p>
                        </div>
                    </label>
                    <button type="button" class="manage-addresses ripple d-flex align-items-center" data-toggle="modal" data-target="#modal-address-management">
                        <div class="thumb">
                            <i class="mdi dark mdi-map-marker"></i>
                        </div>
                        <div>
                            <p class="m-0">Gestisci indirizzi</p>
                        </div>
                    </button>

                    <!-- DATE & TIME SLOT -->
                    <h4 class="mt-5 mb-4">Fascia oraria</h4>
                    <div class="d-flex align-items-center mb-2">
                        <p class="m-0"><span class="date">1 Gennaio 2020</span>, <span class="selected-time-slot">14:00 - 14:30</span></p>
                        <button type="button" class="btn icon ripple ml-3" title="Modifica" data-toggle="modal" data-target="#modal-time-slot"><i class="mdi dark mdi-calendar-edit"></i></button>
                    </div>

                    <!-- OTHER FIELDS -->
                    <h4 class="mt-5 mb-4">Altro</h4>
                    <div class="text-area">
                        <textarea id="notes" class="w-100"></textarea>
                        <label for="textarea">Note per la consegna</label>
                        <span>Inserisci qui il tuo buono sconto!</span>
                    </div>

                    <div class="divider dark d-lg-none mt-4"></div>
                </div>
                <div class="col-12 col-lg-4">

                    <!-- ORDER SUMMARY -->
                    <h4 class="mt-5 mt-lg-0 mb-4">Riepilogo</h4>
                    <div class="summary-products">
                        <div class="product-1 d-flex justify-content-between">
                            <span>Prodotto 1</span>
                            <span>€<span>0,00</span></span>
                        </div>
                        <div class="product-2 d-flex justify-content-between">
                            <span>Prodotto 1</span>
                            <span>€<span>0,00</span></span>
                        </div>
                    </div>
                    <div class="divider dark my-3"></div>
                    <div class="summary-additions">
                        <div class="d-flex justify-content-between">
                            <span>Subtotale</span>
                            <span>€<span class="subtotal">0,00</span></span>
                        </div>
                        <div class="d-flex justify-content-between">
                            <span>IVA</span>
                            <span>€<span class="vat">0,00</span></span>
                        </div>
                        <div class="d-flex justify-content-between">
                            <span>Spedizione</span>
                            <span>€<span class="shipping">0,00</span></span>
                        </div>
                    </div>
                    <div class="divider dark my-3"></div>
                    <div class="summary-total">
                        <div class="d-flex justify-content-between">
                            <span>Totale</span>
                            <span>€<span class="total">0,00</span></span>
                        </div>
                    </div>
                    <button class="btn accent ripple w-100 d-flex justify-content-center mt-4">Acquista</button>

                </div>
            </form>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

    <?php include("modal-address-management.php"); ?>
    <?php include("modal-time-slot.php"); ?>
    <?php include("modals-product-company.php"); ?>
    <?php include("modal-generic.php"); ?>

</body>
</html>