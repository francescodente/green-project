<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - I miei dati</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br/>
                <h3 class="text-light">I miei dati</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">
            <div id="user-data" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>

                <div id="account-content-col" class="col-12 col-lg-9">

                    <!-- GENERAL -->
                    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#user-data-general" aria-expanded="true">
                        <h4 class="m-0">Generali</h4>
                        <span id="general" class="anchor"></span>
                        <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#user-data-general" aria-expanded="true" title="Nascondi">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>

                    <div id="user-data-general" class="collapse show">
                        <div class="pt-3"></div>

                        <h6>E-mail *</h6>
                        <div class="text-input mb-3">
                            <input id="email" type="email" name="email" value="user@domain.com" disabled/>
                            <button type="button" class="edit-field btn icon ripple" title="Modifica"><i class="mdi dark mdi-pencil"></i></button>
                        </div>

                        <h6>Password *</h6>
                        <div class="text-input mb-3">
                            <input id="password" type="password" name="password" value="aaaaaaaa" disabled/>
                            <button class="btn icon ripple" title="Modifica" data-toggle="modal" data-target="#modal-pwd-change">
                                <i class="mdi dark mdi-pencil"></i>
                            </button>
                        </div>

                        <h6>Telefono **</h6>
                        <div class="text-input mb-3">
                            <input id="telephone" type="text" name="telephone" value="123 456 7890" disabled/>
                            <button type="button" class="edit-field btn icon ripple" title="Modifica"><i class="mdi dark mdi-pencil"></i></button>
                        </div>

                        <h6>Consensi</h6>
                        <input id="c1" type="checkbox" class="checkbox" name="cookie-consent" value="1" checked/>
                        <label for="c1">Consenso all'uso dei cookie</label><br/>
                        <input id="c2" type="checkbox" class="checkbox" name="marketing-consent" value="1" checked/>
                        <label for="c2">Consenso alla ricezione di informazioni di marketing</label><br/>

                    </div>

                    <div class="divider dark my-4"></div>

                    <!-- PERSONAL -->
                    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#user-data-personal" aria-expanded="true">
                        <h4 class="m-0">Dati personali</h4>
                        <span id="personal" class="anchor"></span>
                        <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#user-data-personal" aria-expanded="true" title="Mostra">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>

                    <form id="user-data-personal" class="collapse show">
                        <div class="pt-3"></div>

                        <h6>Nome **</h6>
                        <div class="text-input mb-3">
                            <input id="first-name" type="text" name="first-name" disabled/>
                        </div>

                        <h6>Cognome **</h6>
                        <div class="text-input mb-3">
                            <input id="last-name" type="text" name="last-name" disabled/>
                        </div>

                        <h6>Data di nascita</h6>
                        <div class="text-input mb-3">
                            <input id="birth-date" type="text" name="birth-date" disabled/>
                            <label></label>
                            <span>gg/mm/aaaa</span>
                        </div>

                        <h6>Sesso</h6>
                        <input id="r1" type="radio" class="radio" name="gender" value="male" disabled checked/>
                        <label for="r1">Maschio</label><br/>
                        <input id="r2" type="radio" class="radio" name="gender" value="female" disabled/>
                        <label for="r2">Femmina</label><br/>
                        <input id="r3" type="radio" class="radio" name="gender" value="other" disabled/>
                        <label for="r3" class="mb-2">Altro</label>

                        <div class="text-right mt-4">
                            <button type="button" class="delete-form btn outline ripple" style="width: 120px">
                                <span class="text-sec-dark">Cancella</span>
                                <i class="mdi dark mdi-delete"></i>
                            </button>
                            <button type="button" class="edit-form btn accent ripple" style="width: 120px">
                                <span class="text-light">Modifica</span>
                                <i class="mdi light mdi-pencil"></i>
                            </button>
                        </div>

                    </form>

                    <div class="divider dark my-4"></div>

                    <p class="text-sec-dark">
                        I campi contrassegnati da * sono obbligatori.<br/>
                        I campi contrassegnati da ** sono necessari per effettuare acquisti.
                    </p>

                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("resources.php"); ?>
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
