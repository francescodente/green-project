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

                    <div class="address-item default d-flex justify-content-between align-items-center p-2">
                        <div class="d-flex flex-column">
                            <div class="d-flex align-items-center">
                                <div class="thumb flex-shrink-0" style="background-image: url('images/map-thumb.png');">
                                    <i class="mdi mdi-map-marker"></i>
                                </div>
                                <p class="mb-0">Viale della Via 123, 47522 - Cesena (FC)</p>
                            </div>
                            <div class="address-owner-info" style="margin-left: 64px;">
                                <div class="d-flex align-items-center mb-1">
                                    <i class="mdi small dark mdi-account mr-2"></i>
                                    <span class="text-sec-dark">Nome cognome</span>
                                </div>
                                <div class="d-flex align-items-center">
                                    <i class="mdi small dark mdi-phone mr-2"></i>
                                    <span class="text-sec-dark">+39 1234567890</span>
                                </div>
                            </div>
                        </div>
                        <div class="dropdown mb-auto">
                            <button class="btn icon ripple" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="mdi dark mdi-dots-vertical"></i>
                            </button>
                            <div class="dropdown-menu dropdown-menu-right">
                                <a href="#" class="dropdown-item" data-toggle="modal" data-target="#modal-address-delete">
                                    <i class="mdi dark mdi-delete"></i>
                                    <span>Elimina</span>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="address-item d-flex justify-content-between align-items-center p-2">
                        <div class="d-flex flex-column">
                            <div class="d-flex align-items-center">
                                <div class="thumb flex-shrink-0" style="background-image: url('images/map-thumb.png');">
                                    <i class="mdi mdi-map-marker"></i>
                                </div>
                                <p class="mb-0">Viale della Via 123, 47522 - Cesena (FC)</p>
                            </div>
                            <div style="margin-left: 64px;">
                                <div class="d-flex align-items-center mb-1">
                                    <i class="mdi small dark mdi-account mr-2"></i>
                                    <span class="text-sec-dark">Nome cognome</span>
                                </div>
                                <div class="d-flex align-items-center">
                                    <i class="mdi small dark mdi-phone mr-2"></i>
                                    <span class="text-sec-dark">+39 1234567890</span>
                                </div>
                            </div>
                        </div>
                        <div class="dropdown mb-auto">
                            <button class="btn icon ripple" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="mdi dark mdi-dots-vertical"></i>
                            </button>
                            <div class="dropdown-menu dropdown-menu-right">
                                <a href="#" class="dropdown-item">
                                    <i class="mdi dark mdi-star"></i>
                                    <span>Imposta predefinito</span>
                                </a>
                                <a href="#" class="dropdown-item" data-toggle="modal" data-target="#modal-address-delete">
                                    <i class="mdi dark mdi-delete"></i>
                                    <span>Elimina</span>
                                </a>
                            </div>
                        </div>
                    </div>

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

    <?php include("scripts.php"); ?>

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

</body>
</html>
