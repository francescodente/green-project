<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Consegne</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br>
                <h3 class="text-light">Consegne</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">
            <div id="delivery-orders" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">

                    <div class="nav nav-tabs nav-justified" id="nav-tab" role="tablist" style="margin-top: 7px;">
                        <a class="nav-item nav-link ripple active" id="nav-pickup-tab" data-toggle="tab" href="#nav-pickup" role="tab"
                           aria-controls="nav-pickup" aria-selected="true">
                            RITIRI
                        </a>
                        <a class="nav-item nav-link ripple" id="nav-delivery-tab" data-toggle="tab" href="#nav-delivery" role="tab"
                           aria-controls="nav-delivery" aria-selected="false">
                            CONSEGNE
                        </a>
                    </div>
                    <div class="tab-content my-4" id="nav-tabContent">
                        <div class="tab-pane fade show active" id="nav-pickup" role="tabpanel" aria-labelledby="nav-pickup-tab">

                            <div class="empty-state m-5">
                                <img src="images/empty.png"/>
                                <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun prodotto da ritirare</h6>
                                <p class="text-center text-dis-dark m-0">In questa sezione sono visualizzati i fornitori da visitare per il carico di ogni giorno.</p>
                            </div>

                        </div>
                        <div class="tab-pane fade" id="nav-delivery" role="tabpanel" aria-labelledby="nav-delivery-tab">

                            <div class="empty-state m-5">
                                <img src="images/empty.png"/>
                                <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessuna consegna da effettuare</h6>
                                <p class="text-center text-dis-dark m-0">Nessun ordine è pronto per la consegna.<br>Continua a caricare!</p>
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
