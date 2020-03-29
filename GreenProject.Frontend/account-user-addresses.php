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
                <br>
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

                    <!-- ADDRESSES -->
                    <div class="area-collapse d-flex justify-content-between align-items-center pb-1" data-toggle="collapse" data-target="#user-data-addresses" aria-expanded="true">
                        <h4 class="m-0">Indirizzi</h4>
                        <span id="addresses" class="anchor"></span>
                        <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#user-data-addresses" aria-expanded="true" title="Mostra">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>

                    <div id="user-data-addresses" class="collapse show address-management">
                        <div class="pt-3"></div>

                        <div class="address d-flex align-items-center mb-2 selected">
                            <div class="thumb" style="background-image: url('images/map-thumb.png');">
                                <i class="mdi mdi-map-marker"></i>
                            </div>
                            <p class="m-0">Viale della Via 123, 47522 - Cesena (FC)</p>
                            <button class="delete-address btn icon ripple" title="Elimina" data-dismiss="modal" data-toggle="modal" data-target="#modal-address-delete">
                                <i class="mdi dark mdi-delete"></i>
                            </button>
                        </div>
                        <div class="address d-flex align-items-center mb-2">
                            <div class="thumb" style="background-image: url('images/map-thumb.png');">
                                <i class="mdi mdi-map-marker"></i>
                            </div>
                            <p class="m-0">Altra Via 999, 47522 - Cesena (FC)</p>
                            <button class="set-default-address btn icon ripple mr-2" title="Imposta come predefinito" >
                                <i class="mdi dark mdi-star-outline"></i>
                            </button>
                            <button class="delete-address btn icon ripple" title="Elimina" data-dismiss="modal" data-toggle="modal" data-target="#modal-address-delete">
                                <i class="mdi dark mdi-delete"></i>
                            </button>
                        </div>

                        <div class="new address d-flex align-items-center">
                            <div class="thumb">
                                <i class="mdi mdi-map-marker-plus"></i>
                            </div>
                            <input type="text" class="address-input" name="address" placeholder="Inserisci un nuovo indirizzo"/>
                            <button class="create-address btn icon ripple" title="Conferma"><i class="mdi dark mdi-check"></i></button>
                        </div>

                    </div>

                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>
    <script src="js/account-user-data.js"></script>

    <?php include("modal-pwd-change.php"); ?>

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

</body>
</html>
