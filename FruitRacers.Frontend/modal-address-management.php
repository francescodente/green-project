<div id="modal-address-management" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <i class="modal-top-icon mdi mdi-map-marker-multiple"></i>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <div class="modal-body">

                <h4 class="text-center mt-3 mb-4">Gestione indirizzi</h4>

                <div class="address d-flex align-items-center mb-2 selected">
                    <div class="thumb" style="background-image: url('images/map-thumb.png');">
                        <i class="mdi mdi-map-marker"></i>
                    </div>
                    <p class="m-0">Viale della Via 123, 47522 - Cesena (FC)</p>
                    <button class="delete-address btn icon ripple" title="Elimina" data-dismiss="modal" data-toggle="modal" data-target="#modal-address-delete">
                        <i class="mdi dark mdi-delete"></i>
                    </button>
                </div>
                <div class="address d-flex align-items-center mb-2">
                    <div class="thumb" style="background-image: url('images/map-thumb.png');">
                        <i class="mdi mdi-map-marker"></i>
                    </div>
                    <p class="m-0">Altra Via 999, 47522 - Cesena (FC)</p>
                    <button class="set-default-address btn icon ripple mr-2" title="Imposta come predefinito" >
                        <i class="mdi dark mdi-star-outline"></i>
                    </button>
                    <button class="delete-address btn icon ripple" title="Elimina" data-dismiss="modal" data-toggle="modal" data-target="#modal-address-delete">
                        <i class="mdi dark mdi-delete"></i>
                    </button>
                </div>

                <div class="new address d-flex align-items-center">
                    <div class="thumb">
                        <i class="mdi mdi-map-marker-plus"></i>
                    </div>
                    <input type="text" class="address-input" name="address" placeholder="Inserisci un nuovo indirizzo"/>
                    <button class="create-address btn icon ripple" title="Conferma"><i class="mdi dark mdi-check"></i></button>
                </div>

            </div>
        </div>
    </div>
</div>

<div id="modal-address-delete" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-help-circle-outline"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Sei sicuro di voler eliminare questo indirizzo?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="modal-cancel btn outline ripple text-center" data-dismiss="modal" data-toggle="modal" data-target="#modal-address-management" style="width: 160px;">Annulla</button>
                <button class="modal-cancel btn accent ripple text-center" data-dismiss="modal" data-toggle="modal" data-target="#modal-address-management" style="width: 160px;">Ok</button>
            </div>
        </div>
    </div>
</div>
