<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Carrello</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="cart" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">CARRELLO</h1>
            </div>
            <div class="parallax shade" data-parallax-image="images/cart.jpg"></div>
        </section>
        <section id="cart-content" class="container py-4">

            <!-- <div class="empty-state m-5">
                <img src="images/empty.png"/>
                <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Il carrello è vuoto</h6>
                <p class="text-center text-dis-dark m-0">Visualizza l'elenco del nostri <a href="companies.php">partner</a> per cominciare con gli acquisti!</p>
            </div> -->

            <form class="row">
                <div class="col-12 col-lg-8">

                    <!-- PRODUCTS -->
                    <h4 class="mb-4">Prodotti</h4>

                    <div id="cart-products" class="product-group-table products table-wrapper table-responsive">
                        <table class="table">
                            <tbody>
                                <?php
                                for ($i = 0; $i < 3; $i++) {
                                    ?>
                                    <tr>
                                        <td class="nowrap">
                                            <img class="product-image img-fluid" src="images/example_product.jpg"/>
                                        </td>
                                        <td>
                                            <p class="product-name m-0">Product name</p>
                                            <p class="text-sec-dark m-0">
                                                <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                            </p>
                                        </td>
                                        <td class="nowrap actions">
                                            <div class="d-flex justify-content-end">
                                                <button type="button" class="btn icon ripple mr-2" data-toggle="modal" data-target="#modal-product-add" title="Modifica quantità">
                                                    <i class="mdi dark mdi-pencil"></i>
                                                </button>
                                                <button type="button" class="btn icon ripple" data-toggle="modal" data-target="#modal-cart-delete" title="Rimuovi">
                                                    <i class="mdi dark mdi-close"></i>
                                                </button>
                                            </div>
                                        </td>
                                    </tr>
                                    <?php
                                }
                                ?>
                            </tbody>
                        </table>
                    </div>

                    <div class="divider dark mt-5 mb-4"></div>

                    <?php include("order-preferences.php"); ?>

                    <div class="divider dark d-lg-none mt-4"></div>
                </div>
                <div class="col-12 col-lg-4">

                    <div class="sticky-top" style="top: 72px;">

                        <!-- ORDER SUMMARY -->
                        <h4 class="mt-4 mt-lg-0 mb-4">Riepilogo</h4>
                        <div class="summary-products">
                            <div class="product-1 d-flex justify-content-between">
                                <span>Prodotto 1</span>
                                <span><span>0,00</span>€</span>
                            </div>
                            <div class="product-2 d-flex justify-content-between">
                                <span>Prodotto 1</span>
                                <span><span>0,00</span>€</span>
                            </div>
                        </div>
                        <div class="divider dark my-3"></div>
                        <div class="summary-additions">
                            <div class="d-flex justify-content-between text-sec-dark">
                                <span>SUBTOTALE</span>
                                <span><span class="subtotal">0,00</span>€</span>
                            </div>
                            <div class="d-flex justify-content-between text-sec-dark">
                                <span>IVA</span>
                                <span><span class="vat">0,00</span>€</span>
                            </div>
                            <div class="d-flex justify-content-between text-sec-dark">
                                <span>SPEDIZIONE</span>
                                <span><span class="shipping">0,00</span>€</span>
                            </div>
                        </div>
                        <div class="divider dark my-3"></div>
                        <div class="summary-total">
                            <div class="d-flex justify-content-between">
                                <span>TOTALE</span>
                                <span><span class="total">0,00</span>€</span>
                            </div>
                        </div>
                        <button class="btn accent ripple w-100 d-flex justify-content-center mt-4">Acquista</button>

                    </div>

                </div>
            </form>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("resources.php"); ?>

    <?php include("modals-address-management.php"); ?>
    <?php include("modals-product.php"); ?>

    <div id="modal-cart-delete" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-delete-empty"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Sei sicuro di voler rimuovere questo prodotto dal carrello?</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Rimuovi</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        $('.area-collapse[data-target="#order-delivery-address"]').click();
    </script>

</body>
</html>