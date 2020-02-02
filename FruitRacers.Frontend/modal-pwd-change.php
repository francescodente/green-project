<div id="modal-pwd-change" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <i class="modal-top-icon mdi mdi-key-variant"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <form class="modal-body">

                <h4 class="text-center my-3">Cambio password</h4>

                <!-- OLD PASSWORD -->
                <div class="text-input">
                    <input id="old-password" type="password" name="old-password" placeholder=" "/>
                    <label for="old-password">Password attuale</label>
                </div>

                <!-- NEW PASSWORD -->
                <div class="text-input">
                    <input id="new-password" type="password" name="new-password" placeholder=" "/>
                    <label for="new-password">Nuova password</label>
                </div>

                <!-- CONFIRM NEW PASSWORD -->
                <div class="text-input">
                    <input id="confirm-new-password" type="password" name="confirm-password" placeholder=" "/>
                    <label for="confirm-new-password">Conferma password</label>
                </div>

                <span class="text-error-dark mb-2 d-none">Error message</span>

                <div class="text-center">
                    <button id="submit-change-password" type="submit" class="btn accent ripple mt-3">Salva</button>
                </div>

            </form>
        </div>
    </div>
</div>