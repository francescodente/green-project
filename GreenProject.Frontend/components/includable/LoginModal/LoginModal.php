<div id="modal-login" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <i class="modal-top-icon mdi mdi-account-circle"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <form id="form-login" class="modal-body">

                <h4 class="text-center my-3">Login</h4>

                <!-- E-MAIL -->
                <div class="text-input">
                    <input id="login-email" type="email" name="email" placeholder=" " required/>
                    <label for="login-email">E-mail</label>
                </div>

                <!-- PASSWORD -->
                <div class="text-input">
                    <input id="login-password" type="password" name="password" placeholder=" " required/>
                    <label for="login-password">Password</label>
                </div>

                <p id="login-failed-error" class="error-message text-center text-small text-error-dark my-3" style="display: none;">E-mail o password errate.</p>
                <p id="generic-login-error" class="error-message text-center text-small text-error-dark my-3" style="display: none;">Si è verificato un errore.</p>

                <div id="login-loader" class="loader text-center my-3">
                    <?php include("components/includable/Loader.php"); ?>
                </div>

                <div class="d-flex justify-content-between align-items-center">
                    <!-- KEEP LOGIN -->
                    <!-- <input id="keep-login" type="checkbox" class="checkbox" name="keep-login" value="1"/>
                    <label for="keep-login" class="my-2">Ricordami</label><br/> -->

                    <a href="#" class="text-sec-dark text-small" data-toggle="modal" data-target="#modal-pwd-recovery" data-dismiss="modal">Password dimenticata?</a>
                </div>

                <div class="text-center">
                    <button type="submit" class="btn-login btn accent ripple my-3">Accedi</button>
                </div>

                <p class="text-center text-sec-dark m-0">Non hai un account? <a href="#" data-toggle="modal" data-target="#modal-sign-up" data-dismiss="modal">Registrati ora</a></p>

            </form>
        </div>
    </div>
</div>

<script defer src="/components/includable/LoginModal/LoginModal.js"></script>
