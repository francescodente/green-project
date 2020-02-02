<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Carrello</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="cart" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">CARRELLO</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/cart.jpg"></div>
        </section>
        <section id="cart-content" class="container py-4">

            <!-- <div class="empty-state m-5">
                <img src="images/empty.png"/>
                <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Il carrello è vuoto</h6>
                <p class="text-center text-dis-dark m-0">Visualizza l'elenco del nostri <a href="companies.php">partner</a> per cominciare con gli acquisti!</p>
            </div> -->

            <form class="row">
                <div class="col-12 col-lg-8">

                    <!-- PRODUCTS -->
                    <h4>Prodotti</h4>

                    <h5 class="mt-3"><a href="company.php" class="company-name">Azienda</a></h5>
                    <div class="product card flat mb-4">
                        <div class="d-flex align-items-center">
                            <div style="width: 80px;">
                                <a href="#" class="d-block fixed-ratio fr-1-1" data-toggle="modal" data-target="#modal-product">
                                    <img class="card-bg" src="images/example_product.jpg"/>
                                </a>
                            </div>
                            <div class="flex-grow-1 d-flex align-items-center justify-content-between px-3 py-2">
                                <div>
                                    <p class="product-name m-0">Product name</p>
                                    <p class="text-sec-dark m-0">
                                        <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                    </p>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-cart-add" title="Cambia quantità">
                                        <i class="mdi dark mdi-plus-minus"></i>
                                    </button>
                                    <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-cart-delete" title="Rimuovi">
                                        <i class="mdi dark mdi-delete"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="product card flat mb-4">
                        <div class="d-flex align-items-center">
                            <div style="width: 80px;">
                                <a href="#" class="d-block fixed-ratio fr-1-1" data-toggle="modal" data-target="#modal-product">
                                    <img class="card-bg" src="images/example_product.jpg"/>
                                </a>
                            </div>
                            <div class="flex-grow-1 d-flex align-items-center justify-content-between px-3 py-2">
                                <div>
                                    <p class="product-name m-0">Product name</p>
                                    <p class="text-sec-dark m-0">
                                        <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                    </p>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-cart-add" title="Cambia quantità">
                                        <i class="mdi dark mdi-plus-minus"></i>
                                    </button>
                                    <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-cart-delete" title="Rimuovi">
                                        <i class="mdi dark mdi-delete"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <h5 class="mt-3"><a href="company.php" class="company-name">Azienda</a></h5>
                    <div class="product card flat mb-4">
                        <div class="d-flex align-items-center">
                            <div style="width: 80px;">
                                <a href="#" class="d-block fixed-ratio fr-1-1" data-toggle="modal" data-target="#modal-product">
                                    <img class="card-bg" src="images/example_product.jpg"/>
                                </a>
                            </div>
                            <div class="flex-grow-1 d-flex align-items-center justify-content-between px-3 py-2">
                                <div>
                                    <p class="product-name m-0">Product name</p>
                                    <p class="text-sec-dark m-0">
                                        <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                    </p>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-cart-add" title="Cambia quantità">
                                        <i class="mdi dark mdi-plus-minus"></i>
                                    </button>
                                    <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-cart-delete" title="Rimuovi">
                                        <i class="mdi dark mdi-delete"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
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
                        <textarea id="notes" class="w-100" placeholder=" "></textarea>
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
    <?php include("modals-product.php"); ?>

    <div id="modal-cart-delete" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-delete-empty"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Sei sicuro di voler rimuovere questo prodotto dal carrello?</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Rimuovi</button>
                </div>
            </div>
        </div>
    </div>

</body>
</html>