<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Prodotti</title>
</head>
<body>
    <div>

        <?php include("menu.php"); ?>

        <section id="categories" class="parallax-container header d-flex justify-content-center align-items-center" data-section="categories">
            <div class="text-center">
                <h1 class="text-light">PRODOTTI</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/products.jpg"></div>
        </section>
        <section id="categories-content" class="container py-4" data-section="categories">
            <div class="row">
                <?php
                for ($i = 0; $i < 9; $i++) {
                    ?>
                    <div class="col-12 col-md-6 col-lg-4">
                        <a href="products.php" class="card category d-flex flex-column mb-4">
                            <div class="category-header p-3">
                                <h5 class="category-name font-weight-bold text-center my-2">Category</h5>
                            </div>
                            <div class="card-image">
                                <div class="fixed-ratio fr-4-3" style="background-image: url('#');"></div>
                            </div>
                        </div>
                    </a>
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