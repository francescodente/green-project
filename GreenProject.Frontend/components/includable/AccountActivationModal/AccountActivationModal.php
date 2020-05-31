<div id="modal-account-activation" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <i class="modal-top-icon mdi mdi-account-circle"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <div class="modal-body">

                <h4 class="text-center my-3">Benvenuto su Green Project!</h4>

                <p>
                    Ciao <span class="email font-weight-bold"></span>,<br/>
                    ti abbiamo inviato una e-mail contenente il link per l'attivazione del tuo account.
                </p>

                <p>Non hai ricevuto il messaggio di attivazione?</p>

                <div id="account-activation-loader" class="loader text-center mt-3">
                    <?php include("components/includable/Loader.php"); ?>
                </div>

                <div class="text-center">
                    <button class="resend-activation btn accent ripple mt-3">Re-invia</button>
                </div>

            </div>
        </div>
    </div>
</div>

<script defer src="/components/includable/AccountActivationModal/AccountActivationModal.js"></script>