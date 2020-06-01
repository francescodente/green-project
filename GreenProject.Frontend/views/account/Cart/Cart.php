<main class="content req-norole">

    <section id="cart" class="parallax-container header d-flex justify-content-center align-items-center">
        <div class="container text-center">
            <h1 class="text-light">CARRELLO</h1>
        </div>
        <div class="parallax shade" data-parallax-image="/images/cart.jpg"></div>
    </section>
    <section id="cart-content" class="container py-4">

        <div class="cart-empty empty-state m-5 d-none">
            <img src="/images/empty.png" alt="Carrello vuoto"/>
            <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Il carrello è vuoto</h6>
            <p class="text-center text-dis-dark m-0">Visualizza il nostro <a href="/home#products_">catalogo</a> e comincia con gli acquisti!</p>
        </div>

        <div class="cart-not-empty row">
            <div class="col-12 col-lg-8">

                <!-- PRODUCTS -->
                <h4 class="mb-4">Prodotti</h4>

                <div id="cart-products" class="product-group-table products table-wrapper table-responsive">
                    <table class="table"><tbody></tbody></table>
                </div>

                <div class="divider dark mt-5 mb-4"></div>

                <?php include("components/includable/OrderPreferences/OrderPreferences.php"); ?>

                <div class="divider dark d-lg-none mt-4"></div>
            </div>
            <div class="col-12 col-lg-4">

                <div class="sticky-top" style="top: 72px;">

                    <!-- ORDER SUMMARY -->
                    <h4 class="mt-4 mt-lg-0 mb-4">Riepilogo</h4>
                    <div class="summary-products">
                        <div class="product-summary d-flex justify-content-between d-none">
                            <span class="product-name"></span><span class="product-price"></span>
                        </div>
                    </div>
                    <div class="divider dark my-3"></div>
                    <div class="summary-additions">
                        <div class="d-flex justify-content-between text-sec-dark">
                            <span>SUBTOTALE</span><span class="subtotal"></span>
                        </div>
                        <div class="d-flex justify-content-between text-sec-dark">
                            <span>IVA</span><span class="iva"></span>
                        </div>
                        <div class="d-flex justify-content-between text-sec-dark">
                            <span>SPEDIZIONE</span><span class="shipping"></span>
                        </div>
                    </div>
                    <div class="divider dark my-3"></div>
                    <div class="summary-total">
                        <div class="d-flex justify-content-between">
                            <span>TOTALE</span><span class="total"></span>
                        </div>
                    </div>
                    <button class="confirm-cart btn accent ripple w-100 d-flex justify-content-center mt-4">Acquista</button>

                </div>

            </div>
        </div>
    </section>

</main>

<div id="order-placed-modal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-bookmark-check"></i>
            </div>
            <div class="modal-body">
                <h4>Il tuo ordine è stato registrato!</h4>
                <p class="mb-2">Abbiamo preso in carico il tuo ordine.<br/>Puoi controllarne lo stato alla sezione <a href="/account/orders">Ordini</a> del tuo account.</p>
                <p class="m-0">Grazie per aver scelto Green Project!</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <a href="/home" class="btn outline ripple" style="width: 160px;">Chiudi</a>
            </div>
        </div>
    </div>
</div>

<?php include("components/includable/NewAddressModal/NewAddressModal.php"); ?>

<script defer src="/views/account/Cart/Cart.js"></script>
