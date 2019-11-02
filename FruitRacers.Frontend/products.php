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
                <div id="filters-col" class="col-12 col-lg-3 d-none">
                    <h5>Categorie</h5>
                    <input id="c1" type="checkbox" class="checkbox toggle-all" data-toggle="c1"/>
                    <label for="c1" class="mt-2">Categoria 1</label><br>
                    <div class="pl-4">
                        <input id="sc1" type="checkbox" class="checkbox" name="categories" value="sc1" data-toggled-by="c1" checked/>
                        <label for="sc1">Sottocategoria 1</label><br>
                        <input id="sc2" type="checkbox" class="checkbox" name="categories" value="sc2" data-toggled-by="c1" checked/>
                        <label for="sc2">Sottocategoria 2</label><br>
                        <input id="sc3" type="checkbox" class="checkbox" name="categories" value="sc3" data-toggled-by="c1" checked/>
                        <label for="sc3">Sottocategoria 3</label><br>
                        <input id="sc4" type="checkbox" class="checkbox" name="categories" value="sc4" data-toggled-by="c1" checked/>
                        <label for="sc4">Sottocategoria 4</label><br>
                    </div>
                    <input id="c2" type="checkbox" class="checkbox toggle-all" data-toggle="c2"/>
                    <label for="c2" class="mt-2">Categoria 2</label><br>
                    <div class="pl-4">
                        <input id="sc5" type="checkbox" class="checkbox" name="categories" value="sc5" data-toggled-by="c2" checked/>
                        <label for="sc5">Sottocategoria 5</label><br>
                    </div>
                    <input id="c3" type="checkbox" class="checkbox toggle-all" data-toggle="c3"/>
                    <label for="c3" class="mt-2">Categoria 3</label><br>
                    <div class="pl-4">
                        <input id="sc6" type="checkbox" class="checkbox" name="categories" value="sc6" data-toggled-by="c3" checked/>
                        <label for="sc6">Sottocategoria 6</label><br>
                        <input id="sc7" type="checkbox" class="checkbox" name="categories" value="sc7" data-toggled-by="c3"/>
                        <label for="sc7">Sottocategoria 7</label><br>
                        <input id="sc8" type="checkbox" class="checkbox" name="categories" value="sc8" data-toggled-by="c3"/>
                        <label for="sc8">Sottocategoria 8</label><br>
                    </div>
                    <br>
                    <div class="divider dark"></div>
                    <br>
                    <h5>Aziende</h5>
                    <input id="co1" type="checkbox" class="checkbox" name="companies" value="co1" checked/>
                    <label for="co1" class="mt-2">Azienda 1</label><br>
                    <input id="co2" type="checkbox" class="checkbox" name="companies" value="co2" checked/>
                    <label for="co2" class="mt-2">Azienda 2</label><br>
                    <input id="co3" type="checkbox" class="checkbox" name="companies" value="co3" checked/>
                    <label for="co3" class="mt-2">Azienda 3</label><br>
                    <input id="co4" type="checkbox" class="checkbox" name="companies" value="co4" checked/>
                    <label for="co4" class="mt-2">Azienda 4</label><br>
                    <br>
                    <button class="apply-filter btn accent ripple w-100 d-flex justify-content-center">Applica</button>
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

    <?php include("modals-product-company.php"); ?>

</body>
</html>