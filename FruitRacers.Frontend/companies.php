<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Aziende</title>
</head>
<body>
    <div>

        <?php include("menu.php"); ?>

        <section id="companies" class="parallax-container header d-flex justify-content-center align-items-center" data-section="companies">
            <div class="container text-center">
                <h1 class="text-light">AZIENDE</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/companies.jpg"></div>
        </section>
        <section id="companies-content" class="container py-4" data-section="companies">
            <div class="row justify-content-center">
                <?php
                for ($i = 0; $i < 8; $i++) {
                    ?>
                    <div class="col-12 col-md-6">
                        <div class="card company d-flex flex-column mb-4">
                            <div class="company-header p-3">
                                <h5 class="company-name font-weight-bold text-center my-2">Company name</h5>
                            </div>
                            <div class="card-image">
                                <div class="fixed-ratio fr-4-3" style="background-image: url('images/default_company.png');"></div>
                            </div>
                            <div class="card-content p-3">
                                <a href="#" class="company-address text-sec-dark">Viale della Via 123, Cesena (FC)</a>
                                <p class="company-description mt-3">
                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                </p>
                            </div>
                            <div class="company-links d-flex justify-content-center p-3">
                                <a href="products.php" class="company-products btn accent ripple">Visualizza i prodotti</a>
                            </div>
                        </div>
                    </div>
                    <?php
                }
                ?>
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

</body>
</html>