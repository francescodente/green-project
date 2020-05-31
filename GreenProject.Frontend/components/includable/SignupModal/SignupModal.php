<div id="modal-sign-up" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <button class="modal-back btn icon ripple" data-tooltip="tooltip" title="Indietro" data-toggle="modal" data-target="#modal-login" data-dismiss="modal"><i class="mdi dark mdi-arrow-left"></i></button>
                <i class="modal-top-icon mdi mdi-account-circle"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <form id="form-sign-up" method="POST" class="modal-body">

                <h4 class="text-center my-3">Registrazione</h4>

                <!-- E-MAIL -->
                <div class="text-input">
                    <input id="sign-up-email" type="email" name="email" placeholder=" " required/>
                    <label for="sign-up-email">E-mail</label>
                    <span id="sign-up-email-error" class="error">Email già in uso</span>
                </div>

                <!-- PASSWORD -->
                <div class="text-input">
                    <input id="sign-up-password" type="password" name="password" placeholder=" " required/>
                    <label for="sign-up-password">Password</label>
                </div>

                <!-- CONFIRM PASSWORD -->
                <div class="text-input">
                    <input id="confirm-password" type="password" name="confirm-password" placeholder=" " required/>
                    <label for="confirm-password">Conferma password</label>
                </div>

                <p id="sign-up-password-error" class="error-message text-small text-error-dark my-3" style="display: none;">Le due password non corrispondono.</p>

                <!-- PRIVACY CONSENT -->
                <input id="privacy-consent" type="checkbox" class="checkbox" name="privacy-consent" value="1" required/>
                <label for="privacy-consent" class="my-2">Ho letto <a href="/privacy-terms" target="_blank">privacy e termini d'uso</a></label><br/>

                <p id="generic-sign-up-error" class="error-message text-small text-error-dark my-3" style="display: none;">Si è verificato un errore.</p>

                <div id="sign-up-loader" class="loader text-center my-3">
                    <?php include("components/includable/Loader.php"); ?>
                </div>

                <div class="text-center">
                    <button type="submit" class="btn-sign-up btn accent ripple mt-3">Registrati</button>
                </div>

            </form>
        </div>
    </div>
</div>

<script defer src="/components/includable/SignupModal/SignupModal.js"></script>
