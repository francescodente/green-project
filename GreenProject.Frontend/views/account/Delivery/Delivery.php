<main class="content req-login">

    <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
        <div class="container text-center">
            <h1 class="text-light">ACCOUNT</h1>
            <br/>
            <h3 class="text-light">Consegne</h3>
        </div>
        <div class="parallax shade" data-parallax-image="/images/account.jpg"></div>
    </section>
    <section id="account-content" class="container py-4">
        <div id="account-delivery" class="row">

            <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                <?php include("components/includable/AccountTabs.php"); ?>
            </div>
            <div id="account-content-col" class="col-12 col-lg-9">

                <div id="filters-collapse" class="collapse show">
                    <p class="text-sec-dark text-small mb-2">Data di consegna</p>
                    <div class="chip-container d-flex flex-wrap mb-2">
                        <div>
                            <input id="date-past" type="radio" class="chip-radio" name="delivery-date"/>
                            <label for="date-past" class="chip ripple px-3">Precedenti</label>
                        </div>
                        <div>
                            <input id="date-0" type="radio" class="chip-radio" name="delivery-date" checked/>
                            <label for="date-0" class="chip ripple px-3">Oggi</label>
                        </div>
                        <div>
                            <input id="date-1" type="radio" class="chip-radio" name="delivery-date"/>
                            <label for="date-1" class="chip ripple px-3">Domani</label>
                        </div>
                        <div>
                            <input id="date-2" type="radio" class="chip-radio" name="delivery-date"/>
                            <label for="date-2" class="chip ripple px-3"></label>
                        </div>
                        <div>
                            <input id="date-3" type="radio" class="chip-radio" name="delivery-date"/>
                            <label for="date-3" class="chip ripple px-3"></label>
                        </div>
                        <div>
                            <input id="date-4" type="radio" class="chip-radio" name="delivery-date"/>
                            <label for="date-4" class="chip ripple px-3"></label>
                        </div>
                    </div>

                    <p class="text-sec-dark text-small mb-2">Stato dell'ordine</p>
                    <div class="chip-container d-flex flex-wrap mb-2">
                        <div>
                            <input id="state-canceled" type="checkbox" class="chip-checkbox" name="order-state" value="1"/>
                            <label for="state-canceled" class="chip ripple px-3">Cancellato</label>
                        </div>
                        <div>
                            <input id="state-pending" type="checkbox" class="chip-checkbox" name="order-state" value="0"/>
                            <label for="state-pending" class="chip ripple px-3">In attesa</label>
                        </div>
                        <div>
                            <input id="state-shipped" type="checkbox" class="chip-checkbox" name="order-state" value="2"/>
                            <label for="state-shipped" class="chip ripple px-3">Spedito</label>
                        </div>
                        <div>
                            <input id="state-completed" type="checkbox" class="chip-checkbox" name="order-state" value="3"/>
                            <label for="state-completed" class="chip ripple px-3">Completato</label>
                        </div>
                    </div>

                    <div id="select-zipcode" class="dropdown select mb-3">
                        <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                            <input id="cap-select-toggle" type="text" placeholder=" " readonly/>
                            <label for="cap-select-toggle">CAP</label>
                        </div>
                        <div class="dropdown-menu" aria-labelledby="select-toggle">
                            <input id="select-zipcode-toggle" type="checkbox" class="checkbox toggle-all" data-toggle-all="select-zipcode"/>
                            <label for="select-zipcode-toggle" class="toggle-all">Tutti</label>
                        </div>
                        <div class="select-item-template d-none">
                            <input id="select-zipcode-tmp" type="checkbox" class="checkbox" name="select-zipcode" data-required="true"/>
                            <label for="select-zipcode-tmp"></label>
                        </div>
                    </div>

                    <button class="apply-filters btn accent ripple w-100 mb-4">Applica</button>

                </div>

                <button class="btn-collapse btn outline ripple w-100 mb-4" data-toggle="collapse" data-target="#filters-collapse" aria-expanded="true">
                    <i class="mdi dark mdi-chevron-down"></i>
                    <span class="text-sec-dark">Nascondi filtri</span>
                </button>

                <div class="order-list">

                    <div class="orders-no-results empty-state m-5 d-none">
                        <img src="/images/empty.png" alt="Nessun ordine"/>
                        <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun ordine</h6>
                        <p class="text-center text-dis-dark m-0">La ricerca non ha restituito alcun risultato.</p>
                    </div>

                    <div class="orders-error empty-state m-5 d-none">
                        <i class="mdi mdi-emoticon-sad-outline"></i>
                        <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Oops! Qualcosa è andato storto</h6>
                        <p class="text-center text-dis-dark m-0">
                            C'è stato un errore, ti preghiamo di riprovare.
                        </p>
                    </div>

                </div>

                <div class="orders-loader loader text-center mt-5 mb-4">
                    <?php include("components/includable/Loader.php"); ?>
                </div>

                <p class="no-more-results text-dis-dark text-center mb-2 d-none">Non sono presenti altri ordini.</p>

            </div>
        </div>
    </section>

</main>

<script defer src="/views/account/Delivery/Delivery.js"></script>
