<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Prodotti</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="products" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">PRODOTTI</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/products.jpg"></div>
        </section>
        <section id="products-content" class="container py-4">
            <div class="row">
                <div id="filters-col" class="col-12 col-lg-3 d-none">
                    <div class="sticky-top" style="top: 72px;">
                        <input id="c1" type="checkbox" class="checkbox toggle-all" data-toggle-all="categories"/>
                        <label for="c1" class="mt-2">Category</label><br/>
                        <div class="pl-4">
                            <input id="sc1" type="checkbox" class="checkbox" name="categories" value="sc1" checked/>
                            <label for="sc1">Subcategory 1</label><br/>
                            <input id="sc2" type="checkbox" class="checkbox" name="categories" value="sc2" checked/>
                            <label for="sc2">Subcategory 2</label><br/>
                            <input id="sc3" type="checkbox" class="checkbox" name="categories" value="sc3" checked/>
                            <label for="sc3">Subcategory 3</label><br/>
                            <input id="sc4" type="checkbox" class="checkbox" name="categories" value="sc4" checked/>
                            <label for="sc4">Subcategory 4</label><br/>
                        </div>
                        <br/>
                        <button class="apply-filter btn accent ripple w-100 mb-4">Applica</button>
                    </div>
                </div>
                <div id="results-col" class="col-12 container" data-children-class="col-6 col-md-4 col-lg-3">
                    <div class="row">
                        <div class="col-12 d-flex justify-content-between align-items-center mb-4">
                            <button class="toggle-filters btn transparent ripple ripple-accent">
                                <i class="mdi dark mdi-filter"></i>
                                <span class="text-sec-dark">Filtra</span>
                            </button>
                            <p class="text-dis-dark m-0">0 risultati</p>
                        </div>

                        <?php
                        for ($i = 0; $i < 24; $i++) {
                            ?>
                            <div class="col-6 col-md-4 col-lg-3">
                                <div class="card product-card mb-4">
                                    <a href="#" class="fixed-ratio fr-1-1 img-hover-zoom" data-toggle="modal" data-target="#modal-product">
                                        <img class="card-bg" src="images/example_product.jpg"/>
                                        <div class="cover"><button class="btn round outline light">Visualizza</button></div>
                                    </a>
                                    <div class="card-body">
                                        <h5 class="product-name mb-0">Product name</h5>
                                        <div class="d-flex justify-content-between align-items-center">
                                            <span class="text-sec-dark">1<span class="product-unit">Kg</span> - <span class="product-price">00,00</span>€</span>
                                            <button class="add-to-cart btn icon ripple" data-toggle="modal" data-target="#modal-product-add" title="Aggiungi al carrello">
                                                <i class="mdi dark mdi-cart-plus"></i>
                                            </button>
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
                    <li><a href="#" class="btn icon ripple disabled" title="Pagina precedente"><i class="mdi dark mdi-chevron-left"></i></a></li>
                    <li><a href="#" class="selected">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#" class="btn icon ripple" title="Pagina successiva"><i class="mdi dark mdi-chevron-right"></i></a></li>
                </ul>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("resources.php"); ?>
    <script src="js/products.js"></script>

    <?php include("modals-product.php"); ?>

</body>
</html>