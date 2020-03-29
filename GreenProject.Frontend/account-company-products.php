<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Prodotti</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br>
                <h3 class="text-light">Prodotti</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">
            <div id="business-products" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">
                    <div class="container">
                        <div class="row">

                            <div class="col-12 d-flex justify-content-between align-items-center mb-4">
                                <a href="edit-product.php" class="btn outline ripple ripple-accent">
                                    <i class="mdi accent mdi-plus mr-2"></i>
                                    <span class="text-accent">Nuovo prodotto</span>
                                </a>
                                <p class="text-dis-dark m-0">0 prodotti</p>
                            </div>

                            <?php
                            for ($i = 0; $i < 23; $i++) {
                                ?>
                                <div class="col-12 col-sm-6 col-md-4">
                                    <div class="card product-card mb-4">
                                        <div class="fixed-ratio fr-4-3">
                                            <img class="card-bg" src="images/example_product.jpg"/>
                                        </div>
                                        <div class="card-body">
                                            <h5 class="product-name mb-1">Product name</h5>
                                            <p class="category text-sec-dark mb-2">Category</p>
                                            <div class="d-flex align-items-center mb-1">
                                                <i class="mdi dark mdi-account mr-2"></i>
                                                <p class="m-0"><span><span class="product-price">00,00</span> €/<span class="product-unit">Kg</span></span></p>
                                            </div>
                                            <div class="d-flex align-items-center mb-3">
                                                <i class="mdi dark mdi-store mr-2"></i>
                                                <p class="m-0"><span><span class="product-price">00,00</span> €/<span class="product-unit">Kg</span></span></p>
                                            </div>

                                            <a href="edit-product.php" class="btn accent ripple w-100 mb-2">Modifica</a>
                                            <div class="d-flex">
                                                <button class="btn outline ripple flex-grow-1 mr-2" style="width: 10px;" data-toggle="modal" data-target="#modal-product-disable">Disabilita</button>
                                                <button class="btn outline ripple flex-grow-1" style="width: 10px;" data-toggle="modal" data-target="#modal-product-delete">Elimina</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <?php
                            }
                            ?>

                            <div class="col-12 col-sm-6 col-md-4">
                                <div class="card product-card disabled mb-4">
                                    <div class="fixed-ratio fr-4-3">
                                        <img class="card-bg" src="images/example_product.jpg"/>
                                        <div class="disabled-shade"></div>
                                    </div>
                                    <div class="card-body">
                                        <h5 class="product-name text-sec-dark mb-1">Product name</h5>
                                        <p class="category text-dis-dark mb-2">Category</p>
                                        <div class="d-flex align-items-center mb-1">
                                            <i class="mdi text-dis-dark mdi-account mr-2"></i>
                                            <p class="text-sec-dark m-0"><span><span class="product-price">00,00</span> €/<span class="product-unit">Kg</span></span></p>
                                        </div>
                                        <div class="d-flex align-items-center mb-3">
                                            <i class="mdi text-dis-dark mdi-store mr-2"></i>
                                            <p class="text-sec-dark m-0"><span><span class="product-price">00,00</span> €/<span class="product-unit">Kg</span></span></p>
                                        </div>

                                        <a href="edit-product.php" class="btn outline ripple w-100 mb-2">Modifica</a>
                                        <div class="d-flex">
                                            <button class="btn accent ripple flex-grow-1 mr-2" style="width: 10px;" data-toggle="toast" data-target="#toast-product-enabled">Abilita</button>
                                            <button class="btn outline ripple flex-grow-1" style="width: 10px;" data-toggle="modal" data-target="#modal-product-delete-disabled">Elimina</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>


    <div id="modal-product-delete" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-delete-empty"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Sei sicuro di voler eliminare questo prodotto?<br/>In caso contrario, è sempre possibile disabilitarlo.<br/>Il prodotto eliminato non sarà più acquistabile o visibile agli utenti, ma eventuali ordini che lo comprendono resteranno aperti.</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" data-toggle="toast" data-target="#toast-product-deleted" style="width: 100px;">Elimina</button>
                </div>
            </div>
        </div>
    </div>

    <div id="modal-product-delete-disabled" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-delete-empty"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Sei sicuro di voler eliminare questo prodotto?<br/>Il prodotto eliminato non sarà più acquistabile o visibile agli utenti, ma eventuali ordini che lo comprendono resteranno aperti.</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" data-toggle="toast" data-target="#toast-product-deleted" style="width: 100px;">Elimina</button>
                </div>
            </div>
        </div>
    </div>

    <div id="modal-product-disable" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-help-circle-outline"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Sei sicuro di voler disabilitare questo prodotto?<br/>Il prodotto non sarà più acquistabile o visibile agli utenti, ma eventuali ordini che lo comprendono resteranno aperti.</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" data-toggle="toast" data-target="#toast-product-disabled" style="width: 100px;">Disabilita</button>
                </div>
            </div>
        </div>
    </div>

    <div id="toast-product-disabled" class="toast container" style="display: none;">
        <div class="toast-content flex-grow-1 flex-md-grow-0">
            <p class="text-sec-light">Il prodotto è stato disabilitato.</p>
            <button class="toast-close btn transparent light ripple" data-dismiss="toast">Ok</button>
        </div>
    </div>

    <div id="toast-product-enabled" class="toast container" style="display: none;">
        <div class="toast-content flex-grow-1 flex-md-grow-0">
            <p class="text-sec-light">Il prodotto è stato abilitato.</p>
            <button class="toast-close btn transparent light ripple" data-dismiss="toast">Ok</button>
        </div>
    </div>

    <div id="toast-product-deleted" class="toast container" style="display: none;">
        <div class="toast-content flex-grow-1 flex-md-grow-0">
            <p class="text-sec-light">Il prodotto è stato eliminato.</p>
            <button class="toast-close btn transparent light ripple" data-dismiss="toast">Ok</button>
        </div>
    </div>

</body>
</html>
