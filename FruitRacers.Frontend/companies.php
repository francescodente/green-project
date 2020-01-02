<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Aziende</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="companies" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">PARTNER</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/companies.jpg"></div>
        </section>
        <section id="companies-content" class="container py-4">
            <div class="row justify-content-center">
                <?php
                for ($i = 0; $i < 8; $i++) {
                    ?>
                    <div class="col-12 col-lg-6">
                        <div class="card mb-4">
                            <div class="fixed-ratio fr-2-1">
                                <img class="card-bg company-image" src="images/example_product.jpg"/>
                            </div>
                            <div class="container">
                                <div class="row">
                                    <div class="col-3 col-md-2 col-lg-3" style="padding: 16px;">
                                        <div class="fixed-ratio fr-1-1">
                                            <img class="card-bg company-logo" src="images/default_company.png"/>
                                        </div>
                                    </div>
                                    <div class="col-9 col-md-10 col-lg-9 card-body d-flex flex-column justify-content-center">
                                        <h3 class="company-name">Company name</h3>
                                        <a href="#" class="company-address text-sec-dark">Viale della Via 123, Cesena (FC)</a>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer">
                                <a href="company.php" class="btn round accent ripple text-center w-100">Seleziona</a>
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