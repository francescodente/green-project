<!-- LOGIN -->
<div id="modal-login" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <i class="modal-top-icon mdi mdi-account-circle"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
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

                <p id="login-failed-error" class="text-center text-small text-error-dark my-3 d-none">E-mail o password errate.</p>
                <p id="generic-login-error" class="text-center text-small text-error-dark my-3 d-none">Si è verificato un errore.</p>

                <div id="login-loader" class="loader text-center my-3">
                    <?php include("loader.php"); ?>
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

<!-- SIGN-UP -->
<div id="modal-sign-up" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <button class="modal-back btn icon ripple" title="Indietro" data-toggle="modal" data-target="#modal-login" data-dismiss="modal"><i class="mdi dark mdi-arrow-left"></i></button>
                <i class="modal-top-icon mdi mdi-account-circle"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <form id="form-sign-up" method="POST" class="modal-body">

                <h4 class="text-center my-3">Registrazione</h4>

                <!-- E-MAIL -->
                <div class="text-input">
                    <input id="sign-up-email" type="email" name="email" placeholder=" " required/>
                    <label for="sign-up-email">E-mail</label>
                    <span id="sign-up-email-error" class="error">Questo indirizzo è associato ad un altro account</span>
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

                <p id="sign-up-password-error" class="text-small text-error-dark my-3 d-none">Le due password non corrispondono.</p>

                <!-- PRIVACY CONSENT -->
                <input id="privacy-consent" type="checkbox" class="checkbox" name="privacy-consent" value="1" required/>
                <label for="privacy-consent" class="my-2">Ho letto <a href="privacy-terms.php" target="_blank">privacy e termini</a></label><br/>

                <!-- MARKETING CONSENT -->
                <input id="marketing-consent" type="checkbox" class="checkbox" name="marketing-consent" value="1"/>
                <label for="marketing-consent" class="my-2">Vorrei ricevere informazioni di marketing</label><br/>

                <p id="generic-sign-up-error" class="text-small text-error-dark my-3 d-none">Si è verificato un errore.</p>

                <div id="sign-up-loader" class="loader text-center my-3">
                    <?php include("loader.php"); ?>
                </div>

                <div class="text-center">
                    <button type="submit" class="btn-sign-up btn accent ripple mt-3">Registrati</button>
                </div>

            </form>
        </div>
    </div>
</div>

<!-- PASSWORD RECOVERY -->
<div id="modal-pwd-recovery" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <button class="modal-back btn icon ripple" title="Indietro" data-toggle="modal" data-target="#modal-login" data-dismiss="modal"><i class="mdi dark mdi-arrow-left"></i></button>
                <i class="modal-top-icon mdi mdi-key-variant"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <form id="form-pwd-recovery" class="modal-body">

                <h4 class="text-center my-3">Recupero password</h4>

                <p>Inserisci l'indirizzo e-mail associato al tuo account.<br/>Riceverai una e-mail contenente una password provvisoria; per cambiarla, accedi alla sezione <b>I miei dati</b> del tuo account.</p>

                <!-- E-MAIL -->
                <div class="text-input">
                    <input id="recovery-email" type="email" name="email" placeholder=" "/>
                    <label for="recovery-email">E-mail</label>
                </div>

                <span class="text-small text-error-dark mb-2 d-none">Error message</span>

                <div class="text-center">
                    <button type="submit" class="btn accent ripple mt-3">Invia</button>
                </div>

            </form>
        </div>
    </div>
</div>

<script>
    $(document).ready(function() {

        // LOGIN
        $("#form-login").submit(function(event) {
            event.preventDefault();
            $("#login-loader").show();
            $(".btn-login").prop("disabled", true);
            authToken({
                email: $("#login-email").val(),
                password: $("#login-password").val()
            })
            .done(function(data) {
                localStorage.setObject("authData", data);
                location.reload();
            })
            .fail(function(jqXHR) {
                let errCode = jqXHR.responseJSON.globalErrors[0].code;
                if (errCode == "Err.Auth.LoginFailed") {
                    $("#login-email").addClass("error");
                    $("#login-password").addClass("error");
                    $("#login-failed-error").removeClass("d-none");
                } else {
                    $("#generic-login-error").removeClass("d-none");
                }
                $("#login-loader").hide();
                $(".btn-login").prop("disabled", false);
            });
        });

        // REGISTRATION
        $("#form-sign-up").submit(function(event) {
            event.preventDefault();
            // Check password fields
            let password = $("#sign-up-password").val();
            if (password != $("#confirm-password").val()) {
                $("#sign-up-password").addClass("error");
                $("#confirm-password").addClass("error");
                $("#sign-up-password-error").removeClass("d-none");
                return;
            }
            // Perform registration
            $("#sign-up-loader").show();
            $(".btn-sign-up").prop("disabled", true);
            signup({
                user: {
                    email: $("#sign-up-email").val(),
                    marketingConsent: $("#marketing-consent").is(":checked")
                },
                password: password
            })
            .done(function(data) {
                console.log("done");
                console.log(data);
            })
            .fail(function(jqXHR) {
                console.log(jqXHR);
                let errCode = jqXHR.responseJSON.globalErrors[0].code;
                if (errCode == "Err.DuplicateField") {
                    $("#login-email").addClass("error");
                } else {
                    $("#generic-login-error").removeClass("d-none");
                }
                $("#sign-up-loader").hide();
            $(".btn-sign-up").prop("disabled", false);
            });
        });

    });
</script>
