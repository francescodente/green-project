<!-- LOGIN -->
<div id="modal-login" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content d-flex flex-column">
            <div class="modal-top">
                <i class="modal-header-icon mdi mdi-account-circle"></i>
                <button class="btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <form class="modal-body">

                <h4 class="text-center my-3">Login</h4>

                <!-- E-MAIL -->
                <div class="text-input">
                    <input id="login-email" type="email" name="email"/>
                    <label for="login-email">E-mail</label>
                </div>

                <!-- PASSWORD -->
                <div class="text-input">
                    <input id="login-password" type="password" name="password"/>
                    <label for="login-password">Password</label>
                </div>

                <span class="text-error-dark mb-2 d-none">E-mail o password errate</span>

                <div class="d-flex justify-content-between align-items-center">
                    <!-- KEEP LOGIN -->
                    <input id="keep-login" type="checkbox" class="checkbox" name="keep-login" value="1"/>
                    <label for="keep-login" class="my-2">Ricordami</label><br>

                    <a id="pwd-recovery-link" href="#" class="text-sec-dark">Password dimenticata?</a>
                </div>

                <button id="submit-login" type="submit" class="btn accent ripple my-3">Accedi</button>

                <p class="text-center text-sec-dark m-0">Non hai un account? <a id="sign-up-link" href="#">Registrati ora</a></p>

            </form>
        </div>
    </div>
</div>

<!-- SIGN-UP -->
<div id="modal-sign-up" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content d-flex flex-column">
            <div class="modal-top">
                <i class="modal-header-icon mdi mdi-account-circle"></i>
                <button class="back-to-login modal-back btn icon ripple" title="Indietro"><i class="mdi dark mdi-arrow-left"></i></button>
                <button class="btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <form class="modal-body">

                <h4 class="text-center my-3">Registrazione</h4>

                <!-- E-MAIL -->
                <div class="text-input">
                    <input id="sign-up-email" type="email" name="email"/>
                    <label for="sign-up-email">E-mail</label>
                    <span class="email-error d-none">Error message</span>
                </div>

                <!-- PASSWORD -->
                <div class="text-input">
                    <input id="sign-up-password" type="password" name="password"/>
                    <label for="sign-up-password">Password</label>
                    <span class="password-error d-none">Error message</span>
                </div>

                <!-- CONFIRM PASSWORD -->
                <div class="text-input">
                    <input id="confirm-password" type="password" name="confirm-password"/>
                    <label for="confirm-password">Conferma password</label>
                    <span class="confirm-password-error d-none">Error message</span>
                </div>

                <!-- PRIVACY CONSENT -->
                <input id="privacy-consent" type="checkbox" class="checkbox" name="privacy-consent" value="1"/>
                <label for="privacy-consent" class="my-2">Ho letto l'<a href="privacy.php" target="_blank">informativa sulla privacy</a></label><br>

                <!-- MARKETING CONSENT -->
                <input id="marketing-consent" type="checkbox" class="checkbox" name="marketing-consent" value="1"/>
                <label for="marketing-consent" class="my-2">Vorrei ricevere informazioni di marketing</label><br>

                <button id="submit-sign-up" type="submit" class="btn accent ripple mt-3">Registrati</button>

            </form>
        </div>
    </div>
</div>

<!-- PASSWORD RECOVERY -->
<div id="modal-pwd-recovery" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content d-flex flex-column">
            <div class="modal-top">
                <i class="modal-header-icon mdi mdi-key-variant"></i>
                <button class="back-to-login modal-back btn icon ripple" title="Indietro"><i class="mdi dark mdi-arrow-left"></i></button>
                <button class="btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <form class="modal-body">

                <h4 class="text-center my-3">Recupero password</h4>

                <p>Inserisci l'indirizzo e-mail associato al tuo account.<br>Riceverai una e-mail contenente una password provvisoria; per cambiarla, accedi alla sezione <b>I miei dati</b> della pagina <b>Account</b>.</p>

                <!-- E-MAIL -->
                <div class="text-input">
                    <input id="recovery-email" type="email" name="email"/>
                    <label for="recovery-email">E-mail</label>
                </div>

                <span class="text-error-dark mb-2 d-none">Error message</span>

                <button id="submit-reset-password" type="submit" class="btn accent ripple mt-3">Invia</button>

            </form>
        </div>
    </div>
</div>

<script src="js/modals-authentication.js"></script>
