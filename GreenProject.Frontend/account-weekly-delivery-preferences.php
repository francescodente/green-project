<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Consegna settimanale</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br>
                <h3 class="text-light">Consegna settimanale</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">
            <div id="user-data" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">

                    <h4>Cassette</h4>
                    <div class="weekly-delivery crates card flat">
                        <div class="weekly-product crate">
                            <div class="crate-header bg-primary-dark d-flex align-items-center p-2">
                                <img class="product-image img-fluid mr-3" src="images/example_product.jpg"/>
                                <div class="d-flex flex-column">
                                    <p class="product-name m-0">Cassetta 10 Kg</p>
                                    <p class="text-sec-dark m-0">9.5 Kg su 10 - 0.00€</p>
                                </div>
                            </div>
                            <div class="crate-products">
                                <div class="product p-2">
                                    crate-product
                                </div>
                            </div>
                        </div>
                    </div>

                    <h4>Altri prodotti</h4>
                    <div class="weekly-delivery products card flat">
                        <div class="weekly-product product p-2">
                            product
                        </div>
                    </div>

                </div>

            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

</body>
</html>
