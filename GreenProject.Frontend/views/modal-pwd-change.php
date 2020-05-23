<div id="modal-pwd-change" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <i class="modal-top-icon mdi mdi-key-variant"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi">
                    <i class="mdi dark mdi-close"></i>
                </button>
                <button class="modal-close btn-logout btn icon dark ripple d-none" data-tooltip="tooltip" title="Logout">
                    <i class="mdi dark mdi-logout-variant"></i>
                </button>
            </div>
            <form id="form-pwd-change" class="modal-body">

                <h4 class="text-center my-3">Cambio password</h4>

                <p class="change-pwd-msg text-center text-sec-dark d-none">
                    È necessario cambiare la password.
                </p>

                <!-- OLD PASSWORD -->
                <div class="text-input">
                    <input id="old-password" type="password" name="old-password" placeholder=" " required/>
                    <label for="old-password">Password attuale</label>
                </div>

                <!-- NEW PASSWORD -->
                <div class="text-input">
                    <input id="new-password" type="password" name="new-password" placeholder=" " required/>
                    <label for="new-password">Nuova password</label>
                </div>

                <!-- CONFIRM NEW PASSWORD -->
                <div class="text-input">
                    <input id="confirm-new-password" type="password" name="confirm-password" placeholder=" " required/>
                    <label for="confirm-new-password">Conferma password</label>
                </div>

                <p id="pwd-change-error-same-pwd" class="error-message text-small text-error-dark my-3" style="display: none;">La nuova password non può essere identica a quella attuale.</p>
                <p id="pwd-change-error-not-matching" class="error-message text-small text-error-dark my-3" style="display: none;">Le due password non corrispondono.</p>
                <p id="pwd-change-error-not-compliant" class="error-message text-small text-error-dark my-3" style="display: none;">La password deve essere composta da almeno 8 caratteri.</p>
                <p id="pwd-change-error-auth-failed" class="error-message text-small text-error-dark my-3" style="display: none;">Password errata.</p>

                <div id="change-pwd-loader" class="loader text-center my-3">
                    <?php include("loader.php"); ?>
                </div>

                <div class="text-center">
                    <button id="submit-change-password" type="submit" class="btn accent ripple mt-3">Conferma</button>
                </div>

            </form>
        </div>
    </div>
</div>

<script defer src="js/views/modal-pwd-change.js"></script>
