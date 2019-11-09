<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Home</title>
</head>
<body>
    <div>

        <?php include("menu.php"); ?>

        <!-- HOME -->
        <section id="home" class="parallax-container d-flex justify-content-center align-items-center" data-section="home">
            <div class="container">
                <div class="row">
                    <div class="col-0 col-lg-3"></div>
                    <div class="col-12 col-lg-6">
                        <a href="index.php"><img class="img-fluid" src="images/logo/fruitracers_logo_muted_shadow.png"></a>
                    </div>
                    <div class="col-0 col-lg-3"></div>
                </div>
            </div>
            <div class="bottom-content mb-4">
                <button class="btn round light ripple" data-toggle="modal" data-target="#modal-login">Accedi o registrati</button>
            </div>
            <div class="parallax shade" data-parallax-image="images/home.jpg"></div>
        </section>
        <section id="highlights" class="container py-4" data-section="home">
            <h2 class="text-center m-0 mb-4">PRODOTTI IN EVIDENZA</h2>
            <div class="row">
                <?php
                for ($i = 0; $i < 8; $i++) {
                    ?>
                    <div class="col-6 col-md-4 col-lg-3">
                        <div class="card product mb-4" data-toggle="modal" data-target="#modal-product">
                            <div class="card-image">
                                <div class="product-image fixed-ratio fr-1-1" style="background-image: url('images/example_product.jpg');"></div>
                            </div>
                            <div class="card-content p-3">
                                <div class="product-info">
                                    <h6 class="product-name font-weight-bold mb-1">Product name</h6>
                                    <a href="#" class="company-name" data-toggle="modal" data-target="#modal-company">Company name</a>
                                </div>
                                <div class="product-price d-flex justify-content-between align-items-center mt-2">
                                    <span class="text-sec-dark">€00,00 / kg</span>
                                    <button class="add-to-cart btn icon ripple"><i class="mdi dark mdi-cart-plus" title="Aggiungi al carrello"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <?php
                }
                ?>
            </div>
        </section>

        <!-- Chi siamo -->
        <section id="who" class="parallax-container header d-flex justify-content-center align-items-center" data-section="who">
            <div class="text-center">
                <h1 class="text-light">CHI SIAMO</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/who.jpg"></div>
        </section>
        <section id="who-content" class="container py-4" data-section="who">
            <div class="row">
                <div class="col">
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </p>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </p>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </p>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </p>
                </div>
            </div>
        </section>

        <!-- Contatti -->
        <section id="contacts" class="parallax-container header d-flex justify-content-center align-items-center" data-section="contacts">
            <div class="text-center">
                <h1 class="text-light">CONTATTI</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/contacts.jpg"></div>
        </section>
        <section id="contacts-content" class="container py-4" data-section="contacts">
            <div class="row">
                <div class="col-12 col-md-6 mb-4 mb-md-0">
                    <h4 class="mb-3">Modulo di contatto</h4>
                    <p class="text-sec-dark">
                        Vuoi diventare un fornitore? Hai bisogno d'aiuto per un ordine?
                        Per qualsiasi necessità puoi contattarci compilando il modulo sottostante. Ti risponderemo alla e-mail indicata nel più breve tempo possibile.
                    </p>
                    <form>

                        <div class="text-input mb-2">
                            <input id="email" type="email"/>
                            <label for="email">Email</label>
                        </div>

                        <div class="select-input mb-2">
                            <label for="select-example">
                                <button type="button"></button>
                                <i class="mdi dark mdi-menu-swap"></i>
                            </label>
                            <ul id="select-example" role="listbox" name="select-example">
                                <li id="s1" value="s1" role="option" tabindex="-1" aria-selected="true" class="active">Motivo</li>
                                <li id="s2" value="s2" role="option" tabindex="-1" aria-selected="false">Option 2</li>
                                <li id="s3" value="s3" role="option" tabindex="-1" aria-selected="false">Option 3</li>
                                <li id="s4" value="s4" role="option" tabindex="-1" aria-selected="false">Option 4</li>
                                <li id="s5" value="s5" role="option" tabindex="-1" aria-selected="false">Option 5</li>
                                <li id="s6" value="s6" role="option" tabindex="-1" aria-selected="false">Option 6</li>
                                <li id="s7" value="s7" role="option" tabindex="-1" aria-selected="false">Option 7</li>
                                <li id="s8" value="s8" role="option" tabindex="-1" aria-selected="false">Option 8</li>
                                <li id="s9" value="s9" role="option" tabindex="-1" aria-selected="false">Option 9</li>
                            </ul>
                        </div>

                        <div class="text-area mb-2">
                            <textarea id="textarea"></textarea>
                            <label for="textarea">Testo</label>
                        </div>

                        <div class="text-right">
                            <button class="btn accent ripple">
                                <p>Invia</p>
                                <i class="mdi light mdi-send"></i>
                            </button>
                        </div>

                    </form>
                </div>
                <div class="col-12 col-md-6">
                    <h4 class="mb-3">Altri contatti</h4>
                    <div class="d-flex align-items-center mb-2">
                        <i class="mdi dark mdi-email mr-2"></i>
                        <h5 class="m-0">E-mail</h5>
                    </div>
                    <p class="text-dark mb-3">
                        <a href="mailto:info@fruitracers.com" target="_top">info@fruitracers.com</a><br>
                        <a href="mailto:support@fruitracers.com" target="_top">support@fruitracers.com</a>
                    </p>
                    <div class="d-flex align-items-center mb-2">
                        <i class="mdi dark mdi-email-check mr-2"></i>
                        <h5 class="m-0">PEC</h5>
                    </div>
                    <p class="text-dark mb-3"><a href="mailto:pec@fruitracers.com" target="_top">pec@fruitracers.com</a></p>
                    <div class="d-flex align-items-center mb-2">
                        <i class="mdi dark mdi-phone mr-2"></i>
                        <h5 class="m-0">Telefono</h5>
                    </div>
                    <p>+39 123 456 7890</p>
                </div>
            </div>
        </section>

        <!-- Dove trovarci -->
        <section id="companies" class="parallax-container header d-flex justify-content-center align-items-center" data-section="companies">
            <div class="text-center">
                <h1 class="text-light">AZIENDE</h1>
            </div>
            <div class="bottom-content mb-4">
                <a href="companies.php" class="btn round light ripple">Visualizza tutte</a>
            </div>
            <div class="parallax shade" data-parallax-image="images/companies.jpg"></div>
        </section>
        <section id="companies-summary" class="container py-4" data-section="companies">
            <div class="container">
                <div class="row">
                    <div id="map-parent" class="col-12 col-md-7">
                        <div class="fixed-ratio fr-4-3">
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d91609.89225232352!2d12.192423981391768!3d44.14917995506394!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x132ca4d41ed493c1%3A0xbee0ab1075577a47!2sCesena%20FC!5e0!3m2!1sit!2sit!4v1571049543493!5m2!1sit!2sit" id="map" frameborder="0"></iframe>
                        </div>
                    </div>
                    <div id="companies-list" class="col-12 col-md-5 mt-4 mt-md-0">
                        <a class="company d-flex align-items-center mb-2" href="#" data-toggle="modal" data-target="#modal-company">
                            <img class="company-image" src="images/example_product.jpg"/>
                            <div class="d-flex flex-column w-100">
                                <p class="company-name mb-1">Company name</p>
                                <p class="company-address text-sec-dark m-0">Viale della Via 123, 47522 Cesena (FC)</p>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>
    <!-- <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap" async defer></script> -->

    <?php include("modals-authentication.php"); ?>
    <?php include("modal-generic.php"); ?>
    <?php include("modals-product-company.php"); ?>

    <?php include("cookie.php"); ?>

</body>
</html>