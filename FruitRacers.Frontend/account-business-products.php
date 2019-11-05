<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Account</title>
</head>
<body>
    <div>

        <?php include("menu.php"); ?>

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center" data-section="account-business-products">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br>
                <h3 class="text-light">Prodotti</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4" data-section="account-business-products">
            <div id="business-products" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">

                    Prodotti

                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>
    <script src="js/account-client-orders.js"></script>

    <?php include("modals-product-company.php"); ?>
    <?php include("modal-generic.php"); ?>

</body>
</html>
