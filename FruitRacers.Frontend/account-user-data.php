<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Account</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br>
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
                    <div class="d-flex justify-content-between align-items-center pb-1">
                        <h4 class="m-0">Generali</h4>
                        <button class="btn icon ripple" data-toggle="collapse" data-target="#user-data-general" aria-expanded="true" title="Nascondi">
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

                        <h6>Telefono</h6>
                        <div class="text-input mb-3">
                            <input id="telephone" type="text" name="telephone" value="123 456 7890" disabled/>
                            <button type="button" class="edit-field btn icon ripple" title="Modifica"><i class="mdi dark mdi-pencil"></i></button>
                        </div>

                        <h6>Consensi</h6>
                        <input id="c1" type="checkbox" class="checkbox" name="cookie-consent" value="1" checked/>
                        <label for="c1">Consenso all'uso dei cookie</label><br>
                        <input id="c2" type="checkbox" class="checkbox" name="marketing-consent" value="1" checked/>
                        <label for="c2">Consenso alla ricezione di informazioni di marketing</label><br>

                    </div>

                    <div class="divider dark my-4"></div>

                    <div class="d-flex justify-content-between align-items-center pb-1">
                        <h4 class="m-0">Dati personali</h4>
                        <button class="btn icon ripple" data-toggle="collapse" data-target="#user-data-personal" aria-expanded="false" title="Mostra">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>

                    <form id="user-data-personal" class="collapse">
                        <div class="pt-3"></div>

                        <h6>Codice fiscale **</h6>
                        <div class="text-input mb-3">
                            <input id="cf" type="text" name="cf" disabled/>
                        </div>

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
                        <label for="r1">Maschio</label><br>
                        <input id="r2" type="radio" class="radio" name="gender" value="female" disabled/>
                        <label for="r2">Femmina</label><br>
                        <input id="r3" type="radio" class="radio" name="gender" value="other" disabled/>
                        <label for="r3" class="mb-2">Altro</label>

                        <div class="text-right mt-4">
                            <button type="button" class="delete-form btn outline ripple d-inline-flex justify-content-center" style="width: 120px">
                                <p>Cancella</p>
                                <i class="mdi dark mdi-delete"></i>
                            </button>
                            <button type="button" class="edit-form btn accent ripple d-inline-flex justify-content-center" style="width: 120px">
                                <p>Modifica</p>
                                <i class="mdi light mdi-pencil"></i>
                            </button>
                        </div>

                    </form>

                    <div class="divider dark my-4"></div>

                    <div class="d-flex justify-content-between align-items-center pb-1">
                        <h4 class="m-0">Indirizzi</h4>
                        <button class="btn icon ripple" data-toggle="collapse" data-target="#user-data-addresses" aria-expanded="false" title="Mostra">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>

                    <div id="user-data-addresses" class="collapse">
                        <div class="pt-3"></div>

                        <div class="address d-flex align-items-center">
                            <div class="thumb" style="background-image: url('images/map-thumb.png');">
                                <i class="mdi mdi-map-marker"></i>
                            </div>
                            <p class="m-0">Viale della Via 123, 47522 - Cesena (FC)</p>
                        </div>
                        <div class="address d-flex align-items-center">
                            <div class="thumb" style="background-image: url('images/map-thumb.png');">
                                <i class="mdi mdi-map-marker"></i>
                            </div>
                            <p class="m-0">Altra Via 999, 47522 - Cesena (FC)</p>
                        </div>
                        <button type="button" class="manage-addresses ripple d-flex align-items-center" data-toggle="modal" data-target="#modal-address-management">
                            <div class="thumb">
                                <i class="mdi dark mdi-map-marker"></i>
                            </div>
                            <div>
                                <p class="m-0">Gestisci indirizzi</p>
                            </div>
                        </button>

                    </div>

                    <div class="divider dark my-4"></div>

                    <div class="d-flex justify-content-between align-items-center pb-1">
                        <h4 class="m-0">Dati aziendali</h4>
                        <button class="btn icon ripple" data-toggle="collapse" data-target="#user-data-company" aria-expanded="false" title="Mostra">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>

                    <form id="user-data-company" class="collapse">
                        <div class="pt-3"></div>

                        <h6>Numero di partita IVA</h6>
                        <div class="text-input mb-3">
                            <input id="vat-number" type="text" name="vat-number" disabled/>
                        </div>

                        <h6>Nome della società</h6>
                        <div class="text-input mb-3">
                            <input id="company-name" type="text" name="company-name" disabled/>
                        </div>

                        <h6>SDI</h6>
                        <div class="text-input mb-3">
                            <input id="sdi" type="text" name="sdi" disabled/>
                        </div>

                        <h6>Indirizzo</h6>
                        <div class="text-input mb-3">
                            <input id="address" type="text" name="address" disabled/>
                        </div>

                        <h6>PEC</h6>
                        <div class="text-input mb-3">
                            <input id="pec" type="text" name="pec" disabled/>
                        </div>

                        <h6>Forma legale</h6>
                        <div class="text-input mb-3">
                            <input id="legal-form" type="text" name="legal-form" disabled/>
                        </div>

                        <h6>Descrizione</h6>
                        <div class="text-area">
                            <textarea id="description" disabled></textarea>
                        </div>

                        <div class="text-right mt-4">
                            <button type="button" class="delete-form btn outline ripple d-inline-flex justify-content-center" style="width: 120px">
                                <p>Cancella</p>
                                <i class="mdi dark mdi-delete"></i>
                            </button>
                            <button type="button" class="edit-form btn accent ripple d-inline-flex justify-content-center" style="width: 120px">
                                <p>Modifica</p>
                                <i class="mdi light mdi-pencil"></i>
                            </button>
                        </div>

                    </form>

                    <div class="divider dark my-4"></div>

                    <p class="text-sec-dark">
                        I campi contrassegnati da * sono obbligatori.<br>
                        I campi contrassegnati da ** sono necessari per effettuare acquisti.
                    </p>

                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>
    <script src="js/account-user-data.js"></script>

    <?php include("modal-pwd-change.php"); ?>
    <?php include("modal-address-management.php"); ?>

</body>
</html>
