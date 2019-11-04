<?php
$tab = isset($_GET["tab"]) ? $_GET["tab"] : "user-data";
?>

<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Account</title>
</head>
<body>
    <div>

        <?php include("menu.php"); ?>

        <section id="account-tabs" class="parallax-container header d-flex justify-content-center align-items-center" data-section="account">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-tabs-content" class="container py-4" data-section="account">
            <div class="row justify-content-center">
                <div id="account-tabs-col" class="col-6 col-md-4 col-lg-3">
                    <a href="account.php?tab=user-data" class="card account-tab d-flex flex-column mb-4">
                        <div class="card-header">
                            <div class="fixed-ratio fr-1-1"></div>
                            <div class="header-content">
                                <i class="header-icon mdi mdi-account-circle"></i>
                            </div>
                        </div>
                        <div class="category-header p-3">
                            <h5 class="category-name font-weight-bold text-center my-2">I miei dati</h5>
                        </div>
                    </a>
                </div>
                <div id="account-tabs-col" class="col-6 col-md-4 col-lg-3">
                    <a href="account.php?tab=client-orders" class="card account-tab d-flex flex-column mb-4">
                        <div class="card-header">
                            <div class="fixed-ratio fr-1-1"></div>
                            <div class="header-content">
                                <i class="header-icon mdi mdi-book-open"></i>
                            </div>
                        </div>
                        <div class="category-header p-3">
                            <h5 class="category-name font-weight-bold text-center my-2">Ordini</h5>
                        </div>
                    </a>
                </div>
                <div id="account-tabs-col" class="col-6 col-md-4 col-lg-3">
                    <a href="account.php?tab=business-orders" class="card account-tab d-flex flex-column mb-4">
                        <div class="card-header">
                            <div class="fixed-ratio fr-1-1"></div>
                            <div class="header-content">
                                <i class="header-icon mdi mdi-book-open"></i>
                            </div>
                        </div>
                        <div class="category-header p-3">
                            <h5 class="category-name font-weight-bold text-center my-2">Ordini</h5>
                        </div>
                    </a>
                </div>
                <div id="account-tabs-col" class="col-6 col-md-4 col-lg-3">
                    <a href="account.php?tab=delivery-orders" class="card account-tab d-flex flex-column mb-4">
                        <div class="card-header">
                            <div class="fixed-ratio fr-1-1"></div>
                            <div class="header-content">
                                <i class="header-icon mdi mdi-book-open"></i>
                            </div>
                        </div>
                        <div class="category-header p-3">
                            <h5 class="category-name font-weight-bold text-center my-2">Ordini</h5>
                        </div>
                    </a>
                </div>
                <div id="account-tabs-col" class="col-6 col-md-4 col-lg-3">
                    <a href="account.php?tab=business-products" class="card account-tab d-flex flex-column mb-4">
                        <div class="card-header">
                            <div class="fixed-ratio fr-1-1"></div>
                            <div class="header-content">
                                <i class="header-icon mdi mdi-food-apple"></i>
                            </div>
                        </div>
                        <div class="category-header p-3">
                            <h5 class="category-name font-weight-bold text-center my-2">Prodotti</h5>
                        </div>
                    </a>
                </div>
                <div id="account-tabs-col" class="col-6 col-md-4 col-lg-3">
                    <a href="account.php?tab=admin-management" class="card account-tab d-flex flex-column mb-4">
                        <div class="card-header">
                            <div class="fixed-ratio fr-1-1"></div>
                            <div class="header-content">
                                <i class="header-icon mdi mdi-pound-box"></i>
                            </div>
                        </div>
                        <div class="category-header p-3">
                            <h5 class="category-name font-weight-bold text-center my-2">Gestione</h5>
                        </div>
                    </a>
                </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

</body>
</html>