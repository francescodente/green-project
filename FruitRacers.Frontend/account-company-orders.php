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
                        <div class="tab-pane fade show active" id="nav-open-orders" role="tabpanel" aria-labelledby="nav-open-orders-tab">

                            <div class="empty-state m-5">
                                <img src="images/empty.png"/>
                                <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun ordine attivo</h6>
                                <p class="text-center text-dis-dark m-0">In questa sezione sono visualizzati i prodotti da consegnare al nostro fattorino.</p>
                            </div>

                        </div>
                        <div class="tab-pane fade" id="nav-order-history" role="tabpanel" aria-labelledby="nav-order-history-tab">

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

</body>
</html>
