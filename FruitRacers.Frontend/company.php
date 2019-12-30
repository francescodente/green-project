<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Prodotti</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="categories" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">PRODOTTI</h1>
            </div>
            <div class="bottom-content mb-4">
                <a href="products.php" class="btn round ripple light">Visualizza tutti i prodotti</a>
            </div>
            <div class="parallax shade" data-parallax-image="images/products.jpg"></div>
        </section>
        <section id="categories-content" class="container py-4">
            <?php
            for ($i = 0; $i < 2; $i++) {
                ?>
                <div class="row">
                    <div class="col-12">
                        <a href="products.php" class="card parent-category d-flex justify-content-center p-2 mb-4">
                            <h5 class="category-name font-weight-bold text-center my-2">CATEGORY</h5>
                        </a>
                    </div>
                </div>
                <div class="divider dark mb-4"></div>
                <div class="row">
                    <?php
                    for ($j = 0; $j < 6; $j++) {
                        ?>
                        <div class="col-6 col-lg-4">
                            <a href="products.php" class="card category d-flex flex-column mb-4">
                                <div class="category-header p-3">
                                    <h5 class="category-name font-weight-bold text-center my-2">Subcategory</h5>
                                </div>
                                <div class="card-image">
                                    <div class="fixed-ratio fr-1-1" style="background-image: url('images/example_product.jpg');"></div>
                                </div>
                            </a>
                        </div>
                        <?php
                    }
                    ?>
                </div>
                <?php
                if ($i != 1) {
                    ?>
                    <div class="divider dark mb-4"></div>
                    <?php
                }
            }
            ?>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

</body>
</html>