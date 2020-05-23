<main class="content req-login req-admin">

    <section id="management" class="parallax-container header d-flex justify-content-center align-items-center">
        <div class="container text-center">
            <h1 class="text-light">GESTIONE</h1>
            <br/>
            <h3 class="text-light">Anagrafica prodotti</h3>
        </div>
        <div class="parallax shade" data-parallax-image="/images/account.jpg"></div>
    </section>
    <section id="management-content" class="container py-4">
        <div id="management-products" class="row">

            <div id="management-tabs-col" class="d-none d-lg-block col-lg-3">
                <?php include("management-tabs.php"); ?>
            </div>
            <div id="management-content-col" class="col-12 col-lg-9">

                <div class="d-flex justify-content-between align-items-center mb-4">
                    <a href="/management/products/edit" class="btn outline ripple ripple-accent">
                        <i class="mdi accent mdi-plus"></i>
                        <span class="text-accent">Nuovo prodotto</span>
                    </a>
                    <p class="text-dis-dark m-0">0 prodotti</p>
                </div>

                <div class="product-group-table products table-wrapper table-responsive">
                    <table class="table">
                        <tbody>
                            <?php
                            for ($i = 0; $i < 18; $i++) {
                                 ?>
                                <tr>
                                    <td class="nowrap">
                                        <div class="position-relative">
                                            <img class="product-image img-fluid" src="/images/example_product.jpg"/>
                                            <div class="disabled-shade"></div>
                                        </div>
                                    </td>
                                    <td>
                                        <p class="product-name m-0">Product name</p>
                                        <p class="text-sec-dark m-0">
                                            <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                        </p>
                                    </td>
                                    <td class="nowrap actions">
                                        <div class="dropdown">
                                            <button class="btn icon ripple" data-toggle="dropdown" data-boundary="window" aria-haspopup="true" aria-expanded="false">
                                                <i class="mdi dark mdi-dots-vertical"></i>
                                            </button>
                                            <div class="dropdown-menu dropdown-menu-right">
                                                <a href="/management/products/edit" class="dropdown-item">Modifica</a>
                                                <a href="#" class="dropdown-item" data-toggle="modal" data-target="#modal-product-disable">Disabilita</a>
                                                <a href="#" class="dropdown-item" data-toggle="modal" data-target="#modal-product-delete">Elimina</a>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <?php
                            }
                            ?>

                            <tr>
                                <td class="nowrap">
                                    <div class="position-relative">
                                        <img class="product-image img-fluid" src="/images/example_product.jpg"/>
                                        <div class="disabled-shade"></div>
                                    </div>
                                </td>
                                <td>
                                    <p class="product-name m-0">Product name</p>
                                    <p class="text-sec-dark m-0">
                                        <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-total-price">0,00</span><span class="currency">€</span>
                                    </p>
                                </td>
                                <td class="nowrap actions">
                                    <button class="btn icon ripple" data-tooltip="tooltip" title="Prodotto in rilievo" data-toggle="tooltip"><i class="mdi mdi-star-outline"></i></button>
                                    <div class="dropdown">
                                        <button class="product-starred btn icon ripple" data-toggle="dropdown" data-boundary="window" aria-haspopup="true" aria-expanded="false">
                                            <i class="mdi dark mdi-dots-vertical"></i>
                                        </button>
                                        <div class="dropdown-menu dropdown-menu-right">
                                            <a href="/management/products/edit" class="dropdown-item">Modifica</a>
                                            <a href="#" class="dropdown-item" data-toggle="modal" data-target="#modal-product-disable">Disabilita</a>
                                            <a href="#" class="dropdown-item" data-toggle="modal" data-target="#modal-product-delete">Elimina</a>
                                        </div>
                                    </div>
                                </td>
                            </tr>

                            <tr class="product-disabled">
                                <td class="nowrap">
                                    <div class="position-relative">
                                        <img class="product-image img-fluid" src="/images/example_product.jpg"/>
                                        <div class="disabled-shade"></div>
                                    </div>
                                </td>
                                <td>
                                    <p class="product-name m-0">Product name</p>
                                    <p class="product-price text-sec-dark m-0">
                                        <span class="product-quantity">0</span> <span class="product-um">Kg</span> - <span class="product-price-value">0,00</span><span class="currency">€</span>
                                    </p>
                                </td>
                                <td class="nowrap actions">
                                    <div class="dropdown">
                                        <button class="btn icon ripple" data-toggle="dropdown" data-boundary="window" aria-haspopup="true" aria-expanded="false">
                                            <i class="mdi dark mdi-dots-vertical"></i>
                                        </button>
                                        <div class="dropdown-menu dropdown-menu-right">
                                            <a href="/management/products/edit" class="dropdown-item">Modifica</a>
                                            <a href="#" class="dropdown-item" data-toggle="toast" data-target="#toast-product-enabled">Abilita</a>
                                            <a href="#" class="dropdown-item" data-toggle="modal" data-target="#modal-product-delete">Elimina</a>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
    </section>

</main>

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
