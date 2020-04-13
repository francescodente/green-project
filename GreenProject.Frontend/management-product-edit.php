<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Anagrafica prodotto</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="management" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">GESTIONE</h1>
                <br/>
                <h3 class="text-light">Anagrafica prodotto</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="management-content" class="container py-4">

            <form class="edit-product row">
                <div class="col-12">

                    <h4 class="text-center mb-3">Immagine</h4>

                    <!-- Image -->
                    <div class="edit-product-img mx-auto mb-4" style="border: 1px solid rgba(0, 0, 0, 0.08);">
                        <img class="card-bg" src="images/default_product.png"/>
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
                        <input id="product-name" type="text" name="product-name" placeholder=" " required/>
                        <label for="product-name">Nome del prodotto</label>
                    </div>

                    <!-- Description -->
                    <div class="text-area">
                        <textarea id="product-description" type="text" name="product-description" placeholder=" "></textarea>
                        <label for="product-description">Descrizione</label>
                    </div>

                    <div class="divider dark my-4"></div>

                    <h4 class="mb-3">Classificazione</h4>
                    <div class="container p-0">
                        <div class="row no-gutters" style="margin: -8px;">
                            <div class="col-12 col-md-4">
                                <div class="dropdown select my-1 mx-2">
                                    <div class="text-input m-0" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                        <input id="category-1-select-toggle" type="text" placeholder=" " readonly/>
                                        <label for="category-1-select-toggle">Categoria 1</label>
                                    </div>
                                    <div class="dropdown-menu" aria-labelledby="category-1-select-toggle" style="width: 100%;">
                                        <input id="cat1-1" type="radio" class="radio" name="category-1" value="1" required/>
                                        <label for="cat1-1">First category</label>
                                        <input id="cat1-2" type="radio" class="radio" name="category-1" value="2" required/>
                                        <label for="cat1-2">Second category</label>
                                        <input id="cat1-3" type="radio" class="radio" name="category-1" value="3" required/>
                                        <label for="cat1-3">Third category</label>
                                        <input id="cat1-4" type="radio" class="radio" name="category-1" value="4" required/>
                                        <label for="cat1-4">Fourth category</label>
                                        <input id="cat1-5" type="radio" class="radio" name="category-1" value="5" required/>
                                        <label for="cat1-5">Fifth category</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-md-4">
                                <div class="dropdown select my-1 mx-2">
                                    <div class="text-input m-0" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
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
                                <div class="dropdown select my-1 mx-2">
                                    <div class="text-input m-0" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
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

                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <h4 class="m-0">Prezzo</h4>
                        <button class="btn icon ripple" style="height: 28px; width: 28px;" data-toggle="popover" data-placement="right"
                        title="Aiuto" data-html="true" data-content="Il prezzo va specificato in relazione all'unità di misura selezionata e al moltiplicatore inserito.<br/>Esempio:<br/>- Unità di misura: Kg<br/>- Moltiplicatore: 1.5<br/>- Prezzo: 1€<br/>Significa che 1.5Kg di prodotto costano 1€ e che il prodotto è acquistabile in multipli di 1.5Kg.">
                            <i class="mdi dark mdi-help-circle"></i>
                        </button>
                    </div>
                    <div class="container p-0">
                        <div class="row no-gutters" style="margin: -8px;">
                            <div class="col-4">
                                <div class="dropdown select my-1 mx-2">
                                    <div class="text-input m-0" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                        <input id="client-um-select-toggle" type="text" placeholder=" " readonly/>
                                        <label for="client-um-select-toggle">UM</label>
                                    </div>
                                    <div class="dropdown-menu" aria-labelledby="client-um-select-toggle" style="width: 100%;">
                                        <input id="umc1" type="radio" class="radio" name="client-um" value="KG" required/>
                                        <label for="umc1">Chilogrammi [KG]</label>
                                        <input id="umc2" type="radio" class="radio" name="client-um" value="g" required/>
                                        <label for="umc2">Grammi [g]</label>
                                        <input id="umc3" type="radio" class="radio" name="client-um" value="PZ" required/>
                                        <label for="umc3">Pezzi [PZ]</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="text-input my-1 mx-2">
                                    <input id="min-client" type="number" name="min-client" min="1" placeholder=" " required/>
                                    <label for="min-client">Moltiplicatore</label>
                                    <button type="button" class="inc btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-up"></i></button>
                                    <button type="button" class="dec btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-down"></i></button>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="text-input my-1 mx-2">
                                    <input id="client-price" type="number" data-type="currency" name="client-price" min="0" placeholder=" " required/>
                                    <label for="client-price">Prezzo</label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="divider dark my-4"></div>

                    <h4 class="mb-2">Cassette</h4>

                    <p>Per ogni taglio di cassetta, riporta la quantità massima in Kg di questo prodotto che è possibile inserirvi.<br/>Se la quantità è 0 o il campo è vuoto, non sarà possibile inserire questo prodotto nella cassetta corrispondente.</p>

                    <div class="container p-0">
                        <div class="row no-gutters" style="margin: -8px;">
                            <div class="col-12 col-md-6">
                                <div class="text-input my-1 mx-2">
                                    <input id="min-crate12" type="number" name="min-crate12" min="0" step="0.5" placeholder=" "/>
                                    <label for="min-crate12">Cassetta 1-2 persone (4Kg)</label>
                                </div>
                            </div>
                            <div class="col-12 col-md-6">
                                <div class="text-input my-1 mx-2">
                                    <input id="min-crate23" type="number" name="min-crate23" min="0" step="0.5" placeholder=" "/>
                                    <label for="min-crate23">Cassetta 2-3 persone (5Kg)</label>
                                </div>
                            </div>
                            <div class="col-12 col-md-6">
                                <div class="text-input my-1 mx-2">
                                    <input id="min-crate34" type="number" name="min-crate34" min="0" step="0.5" placeholder=" "/>
                                    <label for="min-crate34">Cassetta 3-4 persone (6.5Kg)</label>
                                </div>
                            </div>
                            <div class="col-12 col-md-6">
                                <div class="text-input my-1 mx-2">
                                    <input id="min-crate45" type="number" name="min-crate45" min="0" step="0.5" placeholder=" "/>
                                    <label for="min-crate45">Cassetta 4-5 persone (9.5Kg)</label>
                                </div>
                            </div>
                            <div class="col-12 col-md-6">
                                <div class="text-input my-1 mx-2">
                                    <input id="min-crate67" type="number" name="min-crate67" min="0" step="0.5" placeholder=" "/>
                                    <label for="min-crate67">Cassetta 6-7 persone (16.5Kg)</label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="divider dark my-4"></div>

                    <h4 class="mb-2">Prodotto in rilievo</h4>
                    <p>I prodotti in rilievo verranno proposti ai clienti come aggiunta alle loro cassette settimanali.</p>
                    <input id="c1" type="checkbox" class="checkbox" name="product-starred" value="1"/>
                    <label for="c1">Contrassegna come prodotto in rilievo</label>


                    <div class="divider dark my-4"></div>

                    <div class="d-flex justify-content-between">
                        <a href="management-products.php" class="btn outline ripple flex-grow-1 flex-md-grow-0 mr-2" style="width: 160px;">
                            <i class="mdi dark mdi-arrow-left"></i>
                            <span class="text-sec-dark">Annulla</span>
                        </a>
                        <button type="submit" class="btn accent ripple flex-grow-1 flex-md-grow-0" style="width: 160px;">
                            <span class="text-light">Salva</span>
                            <i class="mdi light mdi-content-save"></i>
                        </button>
                    </div>

                </div>
            </form>

        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

</body>
</html>
