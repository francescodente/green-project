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

                    <div class="divider dark my-4"></div>

                    <h4 class="mb-2">Classificazione</h4>

                    <div class="container p-0">

                        <div class="row no-gutters">

                            <div class="col-12 col-md-4">
                                <div class="dropdown select">
                                    <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                        <input id="category-1-select-toggle" type="text" placeholder=" " readonly/>
                                        <label for="category-1-select-toggle">Categoria 1</label>
                                    </div>
                                    <div class="dropdown-menu" aria-labelledby="category-1-select-toggle" style="width: 100%;">
                                        <input id="cat1-1" type="radio" class="radio" name="category-1" value="1"/>
                                        <label for="cat1-1">First category</label>
                                        <input id="cat1-2" type="radio" class="radio" name="category-1" value="2"/>
                                        <label for="cat1-2">Second category</label>
                                        <input id="cat1-3" type="radio" class="radio" name="category-1" value="3"/>
                                        <label for="cat1-3">Third category</label>
                                        <input id="cat1-4" type="radio" class="radio" name="category-1" value="4"/>
                                        <label for="cat1-4">Fourth category</label>
                                        <input id="cat1-5" type="radio" class="radio" name="category-1" value="5"/>
                                        <label for="cat1-5">Fifth category</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-md-4">
                                <div class="dropdown select ml-md-3">
                                    <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                        <input id="category-2-select-toggle" type="text" placeholder=" " readonly/>
                                        <label for="category-2-select-toggle">Categoria 2</label>
                                    </div>
                                    <div class="dropdown-menu" aria-labelledby="category-2-select-toggle" style="width: 100%;">
                                        <input id="cat2-1" type="radio" class="radio" name="category-2" value="1"/>
                                        <label for="cat2-1">First category</label>
                                        <input id="cat2-2" type="radio" class="radio" name="category-2" value="2"/>
                                        <label for="cat2-2">Second category</label>
                                        <input id="cat2-3" type="radio" class="radio" name="category-2" value="3"/>
                                        <label for="cat2-3">Third category</label>
                                        <input id="cat2-4" type="radio" class="radio" name="category-2" value="4"/>
                                        <label for="cat2-4">Fourth category</label>
                                        <input id="cat2-5" type="radio" class="radio" name="category-2" value="5"/>
                                        <label for="cat2-5">Fifth category</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-md-4">
                                <div class="dropdown select ml-md-3">
                                    <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                        <input id="category-3-select-toggle" type="text" placeholder=" " readonly/>
                                        <label for="category-3-select-toggle">Categoria 3</label>
                                    </div>
                                    <div class="dropdown-menu" aria-labelledby="category-3-select-toggle" style="width: 100%;">
                                        <input id="cat3-1" type="radio" class="radio" name="category-3" value="1"/>
                                        <label for="cat3-1">First category</label>
                                        <input id="cat3-2" type="radio" class="radio" name="category-3" value="2"/>
                                        <label for="cat3-2">Second category</label>
                                        <input id="cat3-3" type="radio" class="radio" name="category-3" value="3"/>
                                        <label for="cat3-3">Third category</label>
                                        <input id="cat3-4" type="radio" class="radio" name="category-3" value="4"/>
                                        <label for="cat3-4">Fourth category</label>
                                        <input id="cat3-5" type="radio" class="radio" name="category-3" value="5"/>
                                        <label for="cat3-5">Fifth category</label>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>

                    <div class="divider dark my-4"></div>

                    <h4 class="mb-3">Prezzo</h4>

                    <!-- Price for private clients -->
                    <div class="d-flex align-items-center mb-2">
                        <h6 class="m-0">Clienti privati</h6>
                        <button class="btn icon ripple ml-2" style="height: 28px; width: 28px;" data-toggle="popover" data-placement="right"
                        title="Aiuto" data-html="true" data-content="Il <b>prezzo</b> va specificato in relazione all'unità di misura selezionata. Se questo campo non viene valorizzato, il prodotto non sarà disponibile per i clienti privati.<br>Il <b>moltiplicatore</b> limita l'acquisto a multipli della quantità inserita. Ad esempio, per un prodotto acquistabile a pezzi un moltiplicatore di valore 10 consente ai clienti di acquistare 10 o 20 pezzi, ma non 15.">
                            <i class="mdi dark mdi-help-circle"></i>
                        </button>
                    </div>
                    <div class="container p-0">
                        <div class="row no-gutters">
                            <div class="col-4">
                                <div class="dropdown select m-0">
                                    <div class="text-input m-0" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                        <input id="client-um-select-toggle" type="text" placeholder=" " readonly/>
                                        <label for="client-um-select-toggle">UM</label>
                                    </div>
                                    <div class="dropdown-menu" aria-labelledby="client-um-select-toggle" style="width: 100%;">
                                        <input id="umc1" type="radio" class="radio" name="client-um" value="KG" checked/>
                                        <label for="umc1">Chilogrammi [KG]</label>
                                        <input id="umc2" type="radio" class="radio" name="client-um" value="g"/>
                                        <label for="umc2">Grammi [g]</label>
                                        <input id="umc3" type="radio" class="radio" name="client-um" value="PZ"/>
                                        <label for="umc3">Pezzi [PZ]</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="text-input my-0 ml-3">
                                    <input id="client-price" type="number" data-type="currency" name="client-price" min="0" placeholder=" ">
                                    <label for="client-price">Prezzo</label>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="text-input my-0 ml-3">
                                    <input id="min-client" type="number" name="min-client" min="1" placeholder=" ">
                                    <label for="min-client">Moltiplicatore</label>
                                    <button class="inc btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-up"></i></button>
                                    <button class="dec btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-down"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Price for business clients -->
                    <div class="d-flex align-items-center mt-3 mb-2">
                        <h6 class="m-0">Clienti con P. IVA</h6>
                        <button class="btn icon ripple ml-2" style="height: 28px; width: 28px;" data-toggle="popover" data-placement="right"
                        title="Aiuto" data-html="true" data-content="Il <b>prezzo</b> va specificato in relazione all'unità di misura selezionata. Se questo campo non viene valorizzato, il prodotto non sarà disponibile per i clienti con P. IVA.<br>Il <b>moltiplicatore</b> limita l'acquisto a multipli della quantità inserita. Ad esempio, per un prodotto acquistabile a pezzi un moltiplicatore di valore 10 consente ai clienti di acquistare 10 o 20 pezzi, ma non 15.">
                            <i class="mdi dark mdi-help-circle"></i>
                        </button>
                    </div>
                    <div class="container p-0">
                        <div class="row no-gutters">
                            <div class="col-4">
                                <div class="dropdown select m-0">
                                    <div class="text-input m-0" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                        <input id="business-um-select-toggle" type="text" placeholder=" " readonly/>
                                        <label for="business-um-select-toggle">UM</label>
                                    </div>
                                    <div class="dropdown-menu" aria-labelledby="business-um-select-toggle" style="width: 100%;">
                                        <input id="umb1" type="radio" class="radio" name="business-um" value="KG" checked/>
                                        <label for="umb1">Chilogrammi [KG]</label>
                                        <input id="umb2" type="radio" class="radio" name="business-um" value="g"/>
                                        <label for="umb2">Grammi [g]</label>
                                        <input id="umb3" type="radio" class="radio" name="business-um" value="PZ"/>
                                        <label for="umb3">Pezzi [PZ]</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="text-input my-0 ml-3">
                                    <input id="business-price" type="number" data-type="currency" name="business-price" min="0" placeholder=" ">
                                    <label for="business-price">Prezzo</label>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="text-input my-0 ml-3">
                                    <input id="min-business" type="number" name="min-business" min="1" placeholder=" ">
                                    <label for="min-business">Moltiplicatore</label>
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
