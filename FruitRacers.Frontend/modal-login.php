<div id="modal-login" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content d-flex flex-column">
            <div class="modal-top">
                <button class="btn icon ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
                <i id="login-header-icon" class="mdi mdi-account-circle"></i>
            </div>
            <form class="modal-body">

                <h4 class="text-center my-3">Login</h4>

                <!-- E-MAIL -->
                <div class="text-input">
                    <input id="email" type="email"/>
                    <label for="email">Email</label>
                </div>

                <!-- PASSWORD -->
                <div class="text-input">
                    <input id="password" type="password"/>
                    <label for="password">Password</label>
                </div>

                <div class="d-flex justify-content-between align-items-center">
                    <!-- KEEP LOGIN -->
                    <input id="keep-login" type="checkbox" class="checkbox" name="keep-login" value="1" />
                    <label for="keep-login" class="my-2">Ricordami</label><br>

                    <a href="#" class="text-sec-dark">Password dimenticata?</a>
                </div>

                <button id="submit-login" class="btn accent ripple my-3">Accedi</button>

                <p class="text-center text-sec-dark m-0">Non hai un account? <a href="#">Registrati ora</a></p>

            </form>
        </div>
    </div>
</div>