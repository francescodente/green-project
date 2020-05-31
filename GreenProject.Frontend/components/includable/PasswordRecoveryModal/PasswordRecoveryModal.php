<div id="modal-pwd-recovery" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <button class="modal-back btn icon ripple" data-tooltip="tooltip" title="Indietro" data-toggle="modal" data-target="#modal-login" data-dismiss="modal"><i class="mdi dark mdi-arrow-left"></i></button>
                <i class="modal-top-icon mdi mdi-key-variant"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <form id="form-pwd-recovery-modal" class="modal-body">

                <h4 class="text-center my-3">Recupero password</h4>

                <p>Inserisci l'indirizzo e-mail associato al tuo account.<br/>Riceverai una e-mail contenente un link per reimpostare la password.</p>

                <!-- E-MAIL -->
                <div class="text-input">
                    <input id="recovery-email" type="email" name="email" placeholder=" " required/>
                    <label for="recovery-email">E-mail</label>
                </div>

                <div id="pwd-recovery-modal-loader" class="loader text-center mt-3">
                    <?php include("components/includable/Loader.php"); ?>
                </div>

                <div class="text-center">
                    <button type="submit" class="send-pwd-recovery btn accent ripple mt-3">Invia</button>
                </div>

            </form>
        </div>
    </div>
</div>

<script defer src="/components/includable/PasswordRecoveryModal/PasswordRecoveryModal.js"></script>
