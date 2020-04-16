<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Home</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <!-- HOME -->
        <section id="home" class="parallax-container d-flex justify-content-center align-items-center" data-section="home">
            <div class="container">

                <div class="row justify-content-center">
                    <div class="col-12 col-md-8 col-lg-6 mb-5 mb-md-0">
                        <a href="index.php"><img class="img-fluid" src="images/logo/greenproject_logo_light.png"></a>
                    </div>
                </div>

                <div class="row mt-5">
                    <div class="col-12 text-center">
                        <div class="d-none d-md-block">
                            <h2 class="font-weight-bold text-light mb-4">ESCLUSIVA! Cassette settimanali personalizzabili</h2>
                            <p class="lead text-light">Componi la tua cassetta settimanale con frutta e verdura fresca, di stagione e a KM 0.</p>
                            <p class="lead font-weight-bold text-light mb-5">Tutte le settimane a casa tua.</p>
                        </div>
                        <div class="d-block d-md-none">
                            <h4 class="font-weight-bold text-light mb-4">ESCLUSIVA!<br/>Cassette settimanali personalizzabili</h4>
                            <p class="lead text-light mb-5">Tutte le settimane a casa tua.</p>
                        </div>
                        <a href="products.php" class="btn accent ripple px-4">Scegli il tuo formato</a>
                    </div>
                </div>

            </div>
            <div class="bottom-content mb-4">
                <button class="btn round outline light ripple req-logout" data-toggle="modal" data-target="#modal-login">Accedi o registrati</button>
            </div>
            <div class="parallax shade" data-parallax-image="images/home.jpg"></div>
        </section>
        <!-- TUTORIAL -->
        <section id="products" class="container pt-4" data-section="products">
            <span id="products_" class="anchor"></span>
            <div class="row category-list" data-children-class="col-12 col-md-4">
                <div class="col-12 text-center mb-4">
                    <h2 class="h-variant-2 m-0">CATALOGO</h2>
                </div>

                <div id="categories-loader" class="loader col-12 text-center my-5">
                    <?php include("loader.php"); ?>
                </div>

                <div class="col-12">
                    <div class="cat-error empty-state m-5 d-none">
                        <i class="mdi mdi-emoticon-sad-outline"></i>
                        <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Oops! Qualcosa è andato storto</h6>
                        <p class="text-center text-dis-dark m-0">
                            C'è stato un errore, ti preghiamo di riprovare.
                        </p>
                    </div>
                </div>

            </div>
        </section>

        <!-- ABOUT -->
        <section id="about" class="parallax-container header d-flex justify-content-center align-items-center" data-section="about">
            <div class="text-center">
                <h1 class="text-light">CHI SIAMO</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/about.jpg"></div>
        </section>
        <section id="about-content" class="container pt-5 pb-4" data-section="about">
            <div class="row">
                <div class="col-12 col-md-6 d-flex justofy-content-center align-items-center mb-4">
                    <a href="index.php"><img class="img-fluid" src="images/logo/greenproject_logo_caption.png"/></a>
                </div>
                <div class="col-12 col-md-6 d-flex flex-column justify-content-center mb-4">
                    <p>Green Project SS.</p>
                    <p><span class="font-weight-bold">Un'azienda agricola</span> sita nelle pianure di Cesena.</p>
                    <p>Coltiviamo ortaggi di stagione <span class="font-weight-bold">nel rispetto della stagionalità e dell'ambiente</span>.</p>
                    <p>Il nostro progetto è nato per portare sulle tavole degli italiani <span class="font-weight-bold">prodotti di qualità</span>:</p>
                    <p>dall'idea alla pratica <span class="font-weight-bold">oggi consegnamo in tutto il territorio romagnolo</span>.</p>
                    <p class="mb-4">Valorizzare le aziende del territorio e <span class="font-weight-bold">creare un legame tra produttore e consumatore</span> sono le nostre priorità.</p>
                    <div>
                        <a href="products.php" class="btn accent ripple">Guarda cosa coltiviamo</a>
                    </div>
                </div>
            </div>
        </section>

        <!-- CONTACTS -->
        <section id="contacts" class="parallax-container header d-flex justify-content-center align-items-center" data-section="contacts">
            <div class="text-center">
                <h1 class="text-light">CONTATTI</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/contacts.jpg"></div>
        </section>
        <section id="contacts-content" class="container py-4" data-section="contacts">
            <div class="row">
                <div class="col-12 text-center mb-4">
                    <h4>Sede legale</h4>
                    <p class="mb-2">Via Scanello 840, 47522 Cesena (FC)</p>

                    <div class="d-flex justify-content-center align-items-center mb-1">
                        <i class="mdi small dark mdi-email mr-2"></i>
                        <p class="m-0">Email aziendale: <a href="mailto:greenproject4@outlook.com" target="_top" class="text-sec-dark">greenproject4@outlook.com</a></p>
                    </div>
                    <div class="d-flex justify-content-center align-items-center">
                        <i class="mdi small dark mdi-email-check mr-2"></i>
                        <p class="m-0">Email PEC: <a href="mailto:greenprojectss@pec.it" target="_top" class="text-sec-dark">greenprojectss@pec.it</a></p>
                    </div>
                </div>
                <div class="col-12 col-md-4">
                    <div class="px-5 px-md-4 mb-3">
                        <div class="fixed-ratio fr-1-1">
                            <img class="img-fluid" src="images/about/about_filippo_casali.jpg"/>
                        </div>
                    </div>
                    <p class="font-weight-bold text-center mb-2">Filippo Casali</p>
                    <h6 class="h-variant text-sec-dark text-center mb-2">Responsabile commerciale e agronomico</h6>
                    <div class="d-flex justify-content-center align-items-center mb-4 mb-md-3">
                        <i class="mdi small dark mdi-phone mr-2"></i>
                        <p class="m-0">Tel <a href="tel:+39 3472365334" class="text-sec-dark">+39 3472365334</a></p>
                    </div>
                </div>
                <div class="col-12 col-md-4">
                    <div class="px-5 px-md-4 mb-3">
                        <div class="fixed-ratio fr-1-1">
                            <img class="img-fluid" src="images/about/about_samuele_lombardi.jpg"/>
                        </div>
                    </div>
                    <p class="font-weight-bold text-center mb-2">Samuele Lombardi</p>
                    <h6 class="h-variant text-sec-dark text-center mb-2">Responsabile operativo</h6>
                    <div class="d-flex justify-content-center align-items-center mb-4 mb-md-3">
                        <i class="mdi small dark mdi-phone mr-2"></i>
                        <p class="m-0">Tel <a href="tel:+39 3476947664" class="text-sec-dark">+39 3476947664</a></p>
                    </div>
                </div>
                <div class="col-12 col-md-4">
                    <div class="px-5 px-md-4 mb-3">
                        <div class="fixed-ratio fr-1-1">
                            <img class="img-fluid" src="images/about/about_riccardo_brandolini.jpg"/>
                        </div>
                    </div>
                    <p class="font-weight-bold text-center mb-2">Riccardo Brandolini</p>
                    <h6 class="h-variant text-sec-dark text-center mb-2">Responsabile amministrativo</h6>
                    <div class="d-flex justify-content-center align-items-center mb-4 mb-md-3">
                        <i class="mdi small dark mdi-phone mr-2"></i>
                        <p class="m-0">Tel <a href="tel:+39 3466437646" class="text-sec-dark">+39 3466437646</a></p>
                    </div>
                </div>
                <div class="col-12 mt-4 mb-3">
                    <div class="card mx-md-4">
                        <iframe id="map" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d91588.9084965435!2d12.184926789999617!3d44.16269790452731!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x132cbba957aaafab%3A0xf89d75ec2fa34f1!2sAz.%20Agricola%20Green%20Project!5e0!3m2!1sit!2sit!4v1585413590976!5m2!1sit!2sit" frameborder="0" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
                    </div>
                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("resources.php") ?>

    <script>
        // Get categories
        $("#categories-loader").show();
        var categories = [];
        getCategories()
        .done(function(data) {
            data.children.forEach((json) => {
                categories.push(new Category(json));
            });
            fillBootstrapRow($(".category-list"), categories);
        })
        .fail(function(data) {
            $(".cat-error").removeClass("d-none");
        })
        .always(function(data) {
            $("#categories-loader").hide();
        });
    </script>

</body>
</html>