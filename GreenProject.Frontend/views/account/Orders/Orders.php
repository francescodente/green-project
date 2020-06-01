<main class="content req-norole">

    <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
        <div class="container text-center">
            <h1 class="text-light">ACCOUNT</h1>
            <br/>
            <h3 class="text-light">Ordini</h3>
        </div>
        <div class="parallax shade" data-parallax-image="/images/account.jpg"></div>
    </section>
    <section id="account-content" class="container py-4">
        <div id="client-orders" class="row">

            <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                <?php include("components/includable/AccountTabs.php"); ?>
            </div>
            <div id="account-content-col" class="col-12 col-lg-9">

                <div class="order-list">

                    <div class="orders-no-results empty-state m-5 d-none">
                        <img src="/images/empty.png" alt="Nessun ordine"/>
                        <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Non hai effettuato ordini</h6>
                        <p class="text-center text-dis-dark m-0">Visualizza il nostro <a href="/home#products_">catalogo</a> e comincia con gli acquisti!</p>
                    </div>

                    <div class="orders-error empty-state m-5 d-none">
                        <i class="mdi mdi-emoticon-sad-outline"></i>
                        <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Oops! Qualcosa è andato storto</h6>
                        <p class="text-center text-dis-dark m-0">
                            C'è stato un errore, ti preghiamo di riprovare.
                        </p>
                    </div>

                </div>

                <div class="divider dark mb-4"></div>
                <div class="d-flex justify-content-center w-100">
                    <ul id="orders-pagination" class="pagination">
                        <li><a href="#" class="page-prev btn icon ripple" data-tooltip="tooltip" title="Pagina precedente">
                            <i class="mdi dark mdi-chevron-left"></i>
                        </a></li>
                        <div class="pages d-flex align-items-center"><li class="d-none"><a href="#">1</a></li></div>
                        <li><a href="#" class="page-next btn icon ripple" data-tooltip="tooltip" title="Pagina successiva">
                            <i class="mdi dark mdi-chevron-right"></i>
                        </a></li>
                    </ul>
                </div>

            </div>
        </div>
    </section>

</main>

<script defer src="/views/account/Orders/Orders.js"></script>
