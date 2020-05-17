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
                        <a href="#" class="date-old chip px-2">
                            <span>Precedenti</span>
                        </a>
                        <a href="#" class="date-0 chip px-2 selected">
                            <span>Oggi</span>
                        </a>
                        <a href="#" class="date-1 chip px-2">
                            <span>Domani</span>
                        </a>
                        <a href="#" class="date-2 chip px-2">
                            <span></span>
                        </a>
                        <a href="#" class="date-3 chip px-2">
                            <span></span>
                        </a>
                        <a href="#" class="date-4 chip px-2">
                            <span></span>
                        </a>
                    </div>

                    <div id="select-zipcode" class="dropdown select mb-3">
                        <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                            <input id="cap-select-toggle" type="text" placeholder=" " readonly/>
                            <label for="cap-select-toggle">CAP</label>
                        </div>
                        <div class="dropdown-menu" aria-labelledby="select-toggle">
                            <input id="select-zipcode-toggle" type="checkbox" class="checkbox toggle-all" data-toggle-all="select-zipcode"/>
                            <label for="select-zipcode-toggle" class="toggle-all">Tutti</label>
                        </div>
                        <div class="select-item-template d-none">
                            <input id="select-zipcode-tmp" type="checkbox" class="checkbox" name="select-zipcode" data-required="true"/>
                            <label for="select-zipcode-tmp"></label>
                        </div>
                    </div>

                    <div class="order-list">

                        <div class="orders-no-results empty-state m-5 d-none">
                            <img src="images/empty.png" alt="Nessun ordine"/>
                            <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun ordine</h6>
                            <p class="text-center text-dis-dark m-0">La ricerca non ha restituito alcun risultato.</p>
                        </div>

                        <div class="orders-error empty-state m-5 d-none">
                            <i class="mdi mdi-emoticon-sad-outline"></i>
                            <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Oops! Qualcosa è andato storto</h6>
                            <p class="text-center text-dis-dark m-0">
                                C'è stato un errore, ti preghiamo di riprovare.
                            </p>
                        </div>

                    </div>

                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>
    <?php include("resources.php") ?>
    <script src="js/pages/account-delivery.js"></script>

</body>
</html>
