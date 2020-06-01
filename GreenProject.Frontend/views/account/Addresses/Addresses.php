<main class="content req-norole">

    <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
        <div class="container text-center">
            <h1 class="text-light">ACCOUNT</h1>
            <br/>
            <h3 class="text-light">Indirizzi</h3>
        </div>
        <div class="parallax shade" data-parallax-image="/images/account.jpg"></div>
    </section>
    <section id="account-content" class="container py-4">
        <div id="user-addresses" class="row">

            <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                <?php include("components/includable/AccountTabs.php"); ?>
            </div>

            <div id="account-content-col" class="col-12 col-lg-9">

                <div class="col-12">
                    <div class="addresses-no-results empty-state m-5 d-none">
                        <img src="/images/empty.png" alt="Nessun indirizzo"/>
                        <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun indirizzo</h6>
                        <p class="text-center text-dis-dark m-0">
                            In questa pagina sono elencati i tuoi indirizzi.
                        </p>
                    </div>
                </div>

                <div class="col-12">
                    <div class="addresses-error empty-state m-5 d-none">
                        <i class="mdi mdi-emoticon-sad-outline"></i>
                        <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Oops! Qualcosa è andato storto</h6>
                        <p class="text-center text-dis-dark m-0">
                            C'è stato un errore, ti preghiamo di riprovare.
                        </p>
                    </div>
                </div>

                <div class="address-list"></div>

                <button class="address-add address-item ripple d-flex flex-column p-2" data-toggle="modal" data-target="#modal-new-address">
                    <div class="d-flex align-items-center">
                         <div class="thumb flex-shrink-0">
                            <i class="mdi mdi-map-marker-plus"></i>
                        </div>
                        <p class="mb-0">Nuovo indirizzo</p>
                    </div>
                </button>

            </div>
        </div>
    </section>

</main>

<?php include("components/includable/NewAddressModal/NewAddressModal.php"); ?>

<script defer src="/views/account/Addresses/Addresses.js"></script>
