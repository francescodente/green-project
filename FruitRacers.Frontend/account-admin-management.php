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
                <h3 class="text-light">Gestione</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">
            <div id="admin-managements" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">

                    Gestione

                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

    <?php include("modals-product.php"); ?>

</body>
</html>
