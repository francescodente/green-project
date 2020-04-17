<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Indirizzi</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br/>
                <h3 class="text-light">Indirizzi</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">
            <div id="user-addresses" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>

                <div id="account-content-col" class="col-12 col-lg-9">

                    <div class="col-12">
                        <div class="addresses-no-results empty-state m-5 d-none">
                            <img src="images/empty.png"/>
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

                    <button class="address-add address-item ripple d-flex flex-column p-2" data-toggle="modal" data-target="#modal-address-add">
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

    </div>

    <?php include("footer.php"); ?>

    <?php include("resources.php"); ?>

    <?php include("modals-address-management.php"); ?>

    <div id="modal-address-delete" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: 360px;">
                <div class="modal-top text-center">
                    <i class="modal-top-icon mdi mdi-delete-empty"></i>
                </div>
                <div class="modal-body">
                    <p class="m-0">Sei sicuro di voler eliminare questo indirizzo?</p>
                </div>
                <div class="modal-bottom bg-primary d-flex justify-content-center">
                    <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                    <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Ok</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        var addresses = [];

        // Show addresses
        showModal($("#modal-loading"));
        getAddresses(localStorage.getObject("userData").userId)
        .done(function(data) {
            if (data.addresses.length == 0) {
                $(".addresses-no-results").removeClass("d-none");
            } else {
                data.addresses.forEach(json => {
                    json.isDefaultAddress = json.addressId == data.defaultAddressId;
                    let address = new Address(json);
                    addresses.push(address);
                    if (address.isDefaultAddress) {
                        $(".address-list").prepend(address.html.main);
                    } else {
                        $(".address-list").append(address.html.main);
                    }
                });
            }
        })
        .fail(function(data) {
            $(".addresses-error").removeClass("d-none");
        })
        .always(function(data) {
            fadeOutModal($("#modal-loading"));
        });
    </script>

</body>
</html>
