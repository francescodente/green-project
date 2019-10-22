<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Prodotti</title>
</head>
<body>
    <div>

        <?php include("menu.php"); ?>

        <section id="products" class="parallax-container header d-flex justify-content-center align-items-center" data-section="products">
            <div class="text-center">
                <h1 class="text-light">PRODOTTI</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/products.jpg"></div>
        </section>
        <section id="products-content" class="container py-4" data-section="products">
            <div class="row">
                <div id="filters-col" class="col-3">
                    filters
                </div>
                <div id="results-col" class="col-9 container">
                    <div class="row">
                        <div class="col-12 d-flex justify-content-between align-items-center mb-4">
                            <button class="toggle-filters btn icon ripple" title="Nascondi filtri"><i class="mdi dark mdi-chevron-left"></i></button>
                            <p class="text-dis-dark m-0">0 risultati</p>
                        </div>
                        <?php
                        for ($i = 0; $i < 24; $i++) {
                            ?>
                            <div class="col-6 col-lg-4">
                                <div class="product-card mb-4">
                                    <div class="product-image">
                                        <a href="#">
                                            <div class="fixed-ratio fr-1-1" style="background-image: url('images/example_product.jpg');"></div>
                                        </a>
                                    </div>
                                    <div class="product-content p-3">
                                        <div class="product-info">
                                            <h6 class="product-name font-weight-bold mb-1">Product name</h6>
                                            <a href="#" class="company-name">Company name</a>
                                        </div>
                                        <div class="product-price d-flex justify-content-between align-items-center mt-2">
                                            <span class="text-sec-dark">€00,00 / kg</span>
                                            <button class="add-to-cart btn icon ripple"><i class="mdi dark mdi-cart"></i></button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <?php
                        }
                        ?>
                    </div>
                </div>
            </div>
            <div class="divider dark mb-4"></div>
            <div class="row justify-content-center">
                <ul class="pagination">
                    <li><a href="#" class="btn icon ripple disabled"><i class="mdi dark mdi-chevron-left"></i></a></li>
                    <li><a href="#" class="selected">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#" class="btn icon ripple"><i class="mdi dark mdi-chevron-right"></i></a></li>
                </ul>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>
    <script src="js/filter.js"></script>

</body>
</html>