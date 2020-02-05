<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Gestione prodotto</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br>
                <h3 class="text-light">Gestione prodotto</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">

            <div class="edit-product row">
                <div class="col-12">

                    <!-- Image -->
                    <div class="edit-product-img mx-auto mb-4">
                        <img class="card-bg" src="images/example_product.jpg"/>
                        <div>
                            <input id="product-image" type="file" name="product-image"/>
                            <label for="product-image" class="ripple">
                                <i class="mdi light mdi-upload mb-2"></i>
                                <span class="text-light">Seleziona</span>
                            </label>
                        </div>
                    </div>

                    <h4 class="mb-3">Informazioni anagrafiche</h4>

                    <!-- Name -->
                    <div class="text-input">
                        <input id="product-name" type="text" name="product-name" placeholder=" "/>
                        <label for="product-name">Nome del prodotto</label>
                    </div>

                    <!-- Description -->
                    <div class="text-area">
                        <textarea id="product-description" type="text" name="product-description" placeholder=" "></textarea>
                        <label for="product-description">Descrizione</label>
                    </div>

                    <!-- Category -->
                    <div class="dropdown select">
                        <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                            <input id="category-select-toggle" type="text" placeholder=" " readonly/>
                            <label for="category-select-toggle">Categoria</label>
                        </div>
                        <div class="dropdown-menu" aria-labelledby="category-select-toggle" style="width: 100%;">
                            <input id="cat1" type="radio" class="radio" name="category" value="1"/>
                            <label for="cat1">First category</label>
                            <input id="cat2" type="radio" class="radio" name="category" value="2"/>
                            <label for="cat2">Second category</label>
                            <input id="cat3" type="radio" class="radio" name="category" value="3"/>
                            <label for="cat3">Third category</label>
                            <input id="cat4" type="radio" class="radio" name="category" value="4"/>
                            <label for="cat4">Fourth category</label>
                            <input id="cat5" type="radio" class="radio" name="category" value="5"/>
                            <label for="cat5">Fifth category</label>
                        </div>
                    </div>

                    <div class="divider dark my-4"></div>

                    <div class="d-flex align-items-center mb-3">
                        <h4 class="m-0">Prezzo</h4>
                        <button class="btn icon ripple ml-3" style="height: 28px; width: 28px;" data-toggle="popover" data-placement="right"
                        title="Aiuto" data-html="true" data-content="È possibile specificare prezzo, unità di misura per la vendita e quantità minima acquistabile diversi per clienti privati e clienti muniti di partita IVA.<br>Qualora si desideri rendere un prodotto disponibile solo a una delle due categorie, è sufficiente lasciare vuoto il campo del prezzo dell'altra categoria.">
                            <i class="mdi dark mdi-help-circle"></i>
                        </button>
                    </div>


                    <!-- Price for private clients -->
                    <div class="container p-0">
                        <div class="row">
                            <div class="col-12 col-md-6 col-xl-8 my-1">
                                <div class="text-input m-0">
                                    <input id="client-price" type="number" name="client-price" min="0" placeholder=" ">
                                    <label for="client-price">Prezzo clienti privati</label>
                                    <button class="inc btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-up"></i></button>
                                    <button class="dec btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-down"></i></button>
                                </div>
                            </div>
                            <div class="col-6 col-md-3 col-xl-2 my-1">
                                <div class="dropdown select m-0">
                                    <div class="text-input m-0" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                        <input id="client-um-select-toggle" type="text" placeholder=" " readonly/>
                                        <label for="client-um-select-toggle">UM</label>
                                    </div>
                                    <div class="dropdown-menu" aria-labelledby="client-um-select-toggle" style="width: 100%;">
                                        <input id="um1" type="radio" class="radio" name="client-um" value="1"/>
                                        <label for="um1">UM1</label>
                                        <input id="um2" type="radio" class="radio" name="client-um" value="2"/>
                                        <label for="um2">UM2</label>
                                        <input id="um3" type="radio" class="radio" name="client-um" value="3"/>
                                        <label for="um3">UM3</label>
                                        <input id="um4" type="radio" class="radio" name="client-um" value="4"/>
                                        <label for="um4">UM4</label>
                                        <input id="um5" type="radio" class="radio" name="client-um" value="5"/>
                                        <label for="um5">UM5</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-md-3 col-xl-2 my-1">
                                <div class="text-input m-0">
                                    <input id="min-client" type="number" name="min-client" min="0" placeholder=" ">
                                    <label for="min-client">Quant. minima</label>
                                    <button class="inc btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-up"></i></button>
                                    <button class="dec btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-down"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Price for business clients -->
                    <div class="container p-0">
                        <div class="row">
                            <div class="col-12 col-md-6 col-xl-8 my-1">
                                <div class="text-input m-0">
                                    <input id="business-price" type="number" name="business-price" min="0" placeholder=" ">
                                    <label for="business-price">Prezzo grossista</label>
                                    <button class="inc btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-up"></i></button>
                                    <button class="dec btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-down"></i></button>
                                </div>
                            </div>
                            <div class="col-6 col-md-3 col-xl-2 my-1">
                                <div class="dropdown select m-0">
                                    <div class="text-input m-0" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                        <input id="business-um-select-toggle" type="text" placeholder=" " readonly/>
                                        <label for="business-um-select-toggle">UM</label>
                                    </div>
                                    <div class="dropdown-menu" aria-labelledby="business-um-select-toggle" style="width: 100%;">
                                        <input id="umb1" type="radio" class="radio" name="business-um" value="1"/>
                                        <label for="umb1">UM1</label>
                                        <input id="umb2" type="radio" class="radio" name="business-um" value="2"/>
                                        <label for="umb2">UM2</label>
                                        <input id="umb3" type="radio" class="radio" name="business-um" value="3"/>
                                        <label for="umb3">UM3</label>
                                        <input id="umb4" type="radio" class="radio" name="business-um" value="4"/>
                                        <label for="umb4">UM4</label>
                                        <input id="umb5" type="radio" class="radio" name="business-um" value="5"/>
                                        <label for="umb5">UM5</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-md-3 col-xl-2 my-1">
                                <div class="text-input m-0">
                                    <input id="min-business" type="number" name="min-business" min="0" placeholder=" ">
                                    <label for="min-business">Quant. minima</label>
                                    <button class="inc btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-up"></i></button>
                                    <button class="dec btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-down"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="divider dark my-4"></div>

                    <div class="d-flex justify-content-between">
                        <a href="account-company-products.php" type="button" class="btn outline ripple" style="width: 160px">
                            <i class="mdi dark mdi-arrow-left"></i>
                            <span class="text-sec-dark">Annulla</span>
                        </a>
                        <button type="button" class="btn accent ripple" style="width: 160px">
                            <span class="text-light">Salva</span>
                            <i class="mdi light mdi-content-save"></i>
                        </button>
                    </div>

                </div>
            </div>

        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

</body>
</html>
