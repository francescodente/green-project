<main class="content">

    <section id="pwd-recovery" class="parallax-container header d-flex justify-content-center align-items-center">
        <div class="container text-center">
            <h1 class="text-light">RECUPERO PASSWORD</h1>
        </div>
        <div class="parallax shade" data-parallax-image="/images/pwd-recovery.jpg"></div>
    </section>
    <section id="pwd-recovery-content" class="container py-4">
        <div class="row">
            <form  id="form-pwd-recovery" class="col-12">

                <h4>Reimposta la tua password</h4>

                <p class="text-sec-dark">
                    Compila i campi sottostanti scegliendo una nuova password per il tuo account.
                </p>

                <h6>Password</h6>
                <div class="text-input mb-3">
                    <input id="new-password" type="password" name="password" required/>
                </div>

                <h6>Conferma password</h6>
                <div class="text-input mb-3">
                    <input id="confirm-new-password" type="password" name="password" required/>
                </div>

                <p id="pwd-recovery-error-not-matching" class="error-message text-small text-error-dark my-3" style="display: none;">Le due password non corrispondono.</p>
                <p id="pwd-recovery-error-not-compliant" class="error-message text-small text-error-dark my-3" style="display: none;">La password deve essere composta da almeno 8 caratteri.</p>
                <p id="pwd-recovery-token-error" class="error-message text-small text-error-dark my-3" style="display: none;">Il link utilizzato è scaduto o non valido. Puoi richiederne uno nuovo <a href="#" data-toggle="modal" data-target="#modal-pwd-recovery">qui</a>.</p>

                <button type="submit" class="submit-pwd-recovery btn accent ripple mt-3" style="width: 200px">Conferma</button>

            </form>
        </div>
    </section>

</main>

<div id="modal-password-recovery-success" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-information-outline"></i>
            </div>
            <div class="modal-body">
                <p class="info-text m-0">La password è stata cambiata con successo.</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <a href="/home" class="btn outline ripple" style="width: 160px;">Chiudi</a>
            </div>
        </div>
    </div>
</div>

<script defer src="/views/PasswordRecovery/PasswordRecovery.js"></script>
