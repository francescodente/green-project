<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Prodotti</title>
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
            <ol class="breadcrumb mb-4">
                <li class="breadcrumb-item"><a href="companies.php">Partner</a></li>
                <li class="breadcrumb-item"><a href="company.php">Company name</a></li>
                <li class="breadcrumb-item active">Category</li>
            </ol>
            <div class="row">
                <div id="filters-col" class="col-12 col-lg-3 d-none">
                    <input id="c1" type="checkbox" class="checkbox toggle-all" data-toggle="c1"/>
                    <label for="c1" class="mt-2">Category</label><br>
                    <div class="pl-4">
                        <input id="sc1" type="checkbox" class="checkbox" name="categories" value="sc1" data-toggled-by="c1" checked/>
                        <label for="sc1">Subcategory 1</label><br>
                        <input id="sc2" type="checkbox" class="checkbox" name="categories" value="sc2" data-toggled-by="c1" checked/>
                        <label for="sc2">Subcategory 2</label><br>
                        <input id="sc3" type="checkbox" class="checkbox" name="categories" value="sc3" data-toggled-by="c1" checked/>
                        <label for="sc3">Subcategory 3</label><br>
                        <input id="sc4" type="checkbox" class="checkbox" name="categories" value="sc4" data-toggled-by="c1" checked/>
                        <label for="sc4">Subcategory 4</label><br>
                    </div>
                    <br>
                    <button class="apply-filter btn accent ripple w-100 mb-3 mb-lg-0">Applica</button>
                    <br>
                </div>
                <div id="results-col" class="col-12 container" data-children-class="col-6 col-md-4 col-lg-3">
                    <div class="row">
                        <div class="col-12 d-flex justify-content-between align-items-center mb-4">
                            <div class="d-flex align-items-center">
                                <button class="toggle-filters btn icon ripple" title="Mostra filtri">
                                    <i class="mdi dark mdi-filter d-none d-lg-block"></i>
                                    <i class="mdi dark mdi-filter d-block d-lg-none"></i>
                                </button>
                                <span class="toggle-filters-label text-sec-dark ml-2">Mostra filtri</span>
                            </div>
                            <p class="text-dis-dark m-0">0 risultati</p>
                        </div>
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

    <?php include("scripts.php"); ?>

    <?php include("components/objects.php") ?>

    <script src="js/filter.js"></script>
    <script src="js/products.js"></script>

    <?php include("modals-product.php"); ?>

</body>
</html>