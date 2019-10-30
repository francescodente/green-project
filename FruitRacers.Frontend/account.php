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

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center" data-section="account">
            <div class="text-center">
                <h1 class="text-light">ACCOUNT</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4" data-section="account">
            <div class="row">
                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <a id="user-data-tab" href="account.php?tab=user-data" class="account-tab <?php echo $tab == 'user-data' ? 'selected' : '' ?>">
                        <i class="mdi dark mdi-account-circle"></i>
                        <p class="m-0">I miei dati</p>
                        <i class="mdi dark mdi-chevron-right"></i>
                    </a>
                    <a id="client-orders-tab" href="account.php?tab=client-orders" class="account-tab <?php echo $tab == 'client-orders' ? 'selected' : '' ?>">
                        <i class="mdi dark mdi-book-open"></i>
                        <p class="m-0">Ordini</p>
                        <i class="mdi dark mdi-chevron-right"></i>
                    </a>
                    <a id="business-orders-tab" href="account.php?tab=business-orders" class="account-tab <?php echo $tab == 'business-orders' ? 'selected' : '' ?>">
                        <i class="mdi dark mdi-book-open"></i>
                        <p class="m-0">Ordini</p>
                        <i class="mdi dark mdi-chevron-right"></i>
                    </a>
                    <a id="delivery-orders-tab" href="account.php?tab=delivery-orders" class="account-tab <?php echo $tab == 'delivery-orders' ? 'selected' : '' ?>">
                        <i class="mdi dark mdi-book-open"></i>
                        <p class="m-0">Ordini</p>
                        <i class="mdi dark mdi-chevron-right"></i>
                    </a>
                    <a id="business-products-tab" href="account.php?tab=business-products" class="account-tab <?php echo $tab == 'business-products' ? 'selected' : '' ?>">
                        <i class="mdi dark mdi-food-apple"></i>
                        <p class="m-0">Prodotti</p>
                        <i class="mdi dark mdi-chevron-right"></i>
                    </a>
                    <a id="admin-management-tab" href="account.php?tab=admin-management" class="account-tab <?php echo $tab == 'admin-management' ? 'selected' : '' ?>">
                        <i class="mdi dark mdi-pound-box"></i>
                        <p class="m-0">Gestione</p>
                        <i class="mdi dark mdi-chevron-right"></i>
                    </a>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">
                    <?php include("account-" . $tab . ".php");  ?>
                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>
    <script src="js/account-user-data.js"></script>
    <script src="js/account-client-orders.js"></script>

    <?php include("modal-pwd-change.php"); ?>
    <?php include("modal-address-management.php"); ?>
    <?php include("modal-product.php"); ?>

</body>
</html>