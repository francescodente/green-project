<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Company name</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="company" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <img class="company-logo card-bg mb-3" src="images/default_company.png"/>
                <h1 class="company-name text-light mb-2">Company name</h1>
                <a href="#" class="company-address text-sec-light">Viale della Via 123, Cesena (FC)</a>
            </div>
            <div class="parallax shade" data-parallax-image="images/example_product.jpg"></div>
        </section>
        <section id="company-content" class="container py-4">
            <h4>Informazioni</h4>
            <p class="company-description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </p>
            <h4 class="mt-4 mb-3">Prodotti</h4>
            <div class="row">
                <?php
                for ($i = 0; $i < 2; $i++) {
                    ?>
                    <div class="col-12 col-md-6 px-5">
                        <a href="products.php" class="card hover-shadow fixed-ratio fr-1-1 img-hover-zoom mb-4">
                            <img class="card-bg" src="images/example_product.jpg"/>
                            <div class="card-image-content text-light">
                                <h2>CATEGORY</h2>
                            </div>
                        </a>
                    </div>
                    <?php
                }
                ?>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

</body>
</html>