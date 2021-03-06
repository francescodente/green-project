<main class="content req-login">

    <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
        <div class="container text-center">
            <h1 class="text-light">ACCOUNT</h1>
            <br/>
            <h3 class="text-light">I miei dati</h3>
        </div>
        <div class="parallax shade" data-parallax-image="/images/account.jpg"></div>
    </section>
    <section id="account-content" class="container py-4">
        <div id="user-data" class="row">

            <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                <?php include("components/includable/AccountTabs.php"); ?>
            </div>

            <div id="account-content-col" class="col-12 col-lg-9">

                <!-- GENERAL -->
                <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#user-data-general" aria-expanded="true">
                    <h4 class="m-0">Generali</h4>
                    <span id="general" class="anchor"></span>
                    <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#user-data-general" aria-expanded="true" data-tooltip="tooltip" title="Nascondi">
                        <i class="mdi dark mdi-chevron-down"></i>
                    </button>
                </div>

                <div id="user-data-general" class="collapse show">
                    <div class="pt-3"></div>

                    <h6>E-mail</h6>
                    <div class="text-input mb-3">
                        <input id="email" type="email" name="email" value="" disabled/>
                    </div>

                    <h6>Password</h6>
                    <div class="text-input mb-3">
                        <input id="password" type="password" name="password" value="aaaaaaaa" disabled/>
                        <button class="btn icon ripple" data-toggle="modal" data-target="#modal-pwd-change" data-tooltip="tooltip" title="Modifica">
                            <i class="mdi dark mdi-pencil"></i>
                        </button>
                    </div>

                    <div class="req-norole">

                        <h6>Consensi</h6>
                        <input id="marketing-consent" type="checkbox" class="checkbox" name="marketing-consent" value="1"/>
                        <label for="marketing-consent">Consenso alla ricezione di informazioni di marketing</label><br/>

                    </div>

                </div>

                <div class="divider dark my-4"></div>

                <div class="req-norole">

                    <!-- PERSONAL -->
                    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#form-user-data-personal" aria-expanded="true">
                        <h4 class="m-0">Dati personali</h4>
                        <span id="personal" class="anchor"></span>
                        <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#form-user-data-personal" aria-expanded="true" data-tooltip="tooltip" title="Nascondi">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>

                    <form id="form-user-data-personal" class="collapse show">
                        <div class="pt-3"></div>

                        <h6>Codice fiscale o P. IVA *</h6>
                        <div class="text-input mb-3">
                            <input id="code" type="text" name="code" disabled required/>
                            <span class="error">Formato non valido</span>
                        </div>

                        <h6>Nome *</h6>
                        <div class="text-input mb-3">
                            <input id="first-name" type="text" name="first-name" disabled required/>
                        </div>

                        <h6>Cognome *</h6>
                        <div class="text-input mb-3">
                            <input id="last-name" type="text" name="last-name" disabled required/>
                        </div>

                        <h6>Data di nascita</h6>
                        <div class="text-input mb-3">
                            <input id="birth-date" type="text" name="birth-date" maxlength="10" disabled/>
                            <label></label>
                            <span>gg/mm/aaaa</span>
                            <span class="error">Data non valida</span>
                        </div>

                        <h6>Sesso</h6>
                        <div style="position: relative;">
                            <input id="r1" type="radio" class="radio" name="gender" value="Male" disabled/>
                            <label for="r1">Maschio</label><br/>
                            <input id="r2" type="radio" class="radio" name="gender" value="Female" disabled/>
                            <label for="r2">Femmina</label><br/>
                            <input id="r3" type="radio" class="radio" name="gender" value="Other" disabled/>
                            <label for="r3" class="mb-2">Altro</label>
                        </div>

                        <div class="user-data-form-options justify-content-end mt-3" style="display: flex;">
                            <button type="button" class="delete-form btn outline ripple mr-2 flex-grow-1 flex-md-grow-0" style="flex-basis: 120px;" data-toggle="modal" data-target="#modal-person-role-delete">
                                <span class="text-sec-dark">Cancella</span><i class="mdi dark mdi-delete"></i>
                            </button>
                            <button type="button" class="edit-form btn accent ripple flex-grow-1 flex-md-grow-0"  style="flex-basis: 120px;">
                                <span class="text-light">Modifica</span><i class="mdi light mdi-pencil"></i>
                            </button>
                        </div>

                        <div class="user-data-form-controls justify-content-end mt-3 d-none" style="display: flex;">
                            <button type="button" class="cancel-form-edits btn outline ripple mr-2 flex-grow-1 flex-md-grow-0" style="flex-basis: 120px;">
                                <span class="text-sec-dark">Annulla</span><i class="mdi dark mdi-arrow-left"></i>
                            </button>
                            <button type="submit" class="save-form btn accent ripple flex-grow-1 flex-md-grow-0"  style="flex-basis: 120px;">
                                <span class="text-light">Salva</span><i class="mdi light mdi-content-save"></i>
                            </button>
                        </div>

                    </form>

                    <div class="divider dark my-4"></div>

                </div>

                <p class="text-sec-dark">I campi contrassegnati da * sono necessari per effettuare acquisti.</p>

            </div>
        </div>
    </section>

</main>

<div id="modal-person-role-delete" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-delete-empty"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Vuoi davvero eliminare le tue informazioni personali?<br/>Senza questi dati non ?? possibile effettuare ordini.</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button id="delete-user-data-personal" class="btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Elimina</button>
            </div>
        </div>
    </div>
</div>

<div id="modal-marketing-consent-delete" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-delete-empty"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Disattivando la ricezione di informazioni di marketing, non saremo pi?? in grado di inviarti newsletter e codici sconto!<br/>Vuoi procedere comunque?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">No</button>
                <button id="delete-marketing-consent" class="btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">S??</button>
            </div>
        </div>
    </div>
</div>

<?php include("components/includable/PasswordChangeModal/PasswordChangeModal.php"); ?>

<script defer src="/js/validators/CFValidator.js"></script>
<script defer src="/js/validators/PIValidator.js"></script>
<script defer src="/views/account/Data/Data.js"></script>
