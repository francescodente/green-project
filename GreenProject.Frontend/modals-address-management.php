<div id="modal-address-add" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <div class="address-thumb" style="background-image: url('images/map-thumb.png');">
                    <i class="mdi large mdi-map-marker"></i>
                </div>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <div class="modal-body container">

                <h4 class="text-center mt-3 mb-2">Nuovo indirizzo</h4>

                <div class="row no-gutters">

                    <!-- Province, city, ZIP code -->
                    <div class="col-12">
                        <div class="dropdown select">
                            <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                <input id="province-select-toggle" type="text" placeholder=" " readonly/>
                                <label for="province-select-toggle">Provincia</label>
                            </div>
                            <div class="dropdown-menu" aria-labelledby="select-toggle">
                                <input id="prov1" type="radio" class="radio" name="select-province" value="1"/>
                                <label for="prov1">First option</label>
                                <input id="prov2" type="radio" class="radio" name="select-province" value="2"/>
                                <label for="prov2">Second option</label>
                                <input id="prov3" type="radio" class="radio" name="select-province" value="3"/>
                                <label for="prov3">Third option</label>
                                <input id="prov4" type="radio" class="radio" name="select-province" value="4"/>
                                <label for="prov4">Fourth option</label>
                                <input id="prov5" type="radio" class="radio" name="select-province" value="5"/>
                                <label for="prov5">Fifth option</label>
                            </div>
                        </div>
                    </div>
                    <div class="col-7">
                        <div class="dropdown select mr-3">
                            <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                <input id="city-select-toggle" type="text" placeholder=" " readonly/>
                                <label for="city-select-toggle">Città</label>
                            </div>
                            <div class="dropdown-menu" aria-labelledby="select-toggle">
                                <input id="city1" type="radio" class="radio" name="select-city" value="1"/>
                                <label for="city1">First option</label>
                                <input id="city2" type="radio" class="radio" name="select-city" value="2"/>
                                <label for="city2">Second option</label>
                                <input id="city3" type="radio" class="radio" name="select-city" value="3"/>
                                <label for="city3">Third option</label>
                                <input id="city4" type="radio" class="radio" name="select-city" value="4"/>
                                <label for="city4">Fourth option</label>
                                <input id="city5" type="radio" class="radio" name="select-city" value="5"/>
                                <label for="city5">Fifth option</label>
                            </div>
                        </div>
                    </div>
                    <div class="col-5">
                        <div class="dropdown select">
                            <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                <input id="cap-select-toggle" type="text" placeholder=" " readonly/>
                                <label for="cap-select-toggle">CAP</label>
                            </div>
                            <div class="dropdown-menu" aria-labelledby="select-toggle">
                                <input id="cap1" type="radio" class="radio" name="select-cap" value="1"/>
                                <label for="cap1">First option</label>
                                <input id="cap2" type="radio" class="radio" name="select-cap" value="2"/>
                                <label for="cap2">Second option</label>
                                <input id="cap3" type="radio" class="radio" name="select-cap" value="3"/>
                                <label for="cap3">Third option</label>
                                <input id="cap4" type="radio" class="radio" name="select-cap" value="4"/>
                                <label for="cap5">Fourth option</label>
                                <input id="cap5" type="radio" class="radio" name="select-cap" value="5"/>
                                <label for="cap5">Fifth option</label>
                            </div>
                        </div>
                    </div>

                    <!-- Street and house number -->
                    <div class="col-7">
                        <div class="text-input mr-3">
                            <input id="street" type="text" placeholder=" "/>
                            <label for="street">Via</label>
                        </div>
                    </div>
                    <div class="col-5">
                        <div class="text-input">
                            <input id="house-number" type="text" placeholder=" "/>
                            <label for="house-number">Civico</label>
                        </div>
                    </div>

                </div>


                <div class="text-input">
                    <input id="name" type="text" placeholder=" "/>
                    <label for="name">Nome</label>
                </div>
                <div class="text-input">
                    <input id="phone" type="text" placeholder=" "/>
                    <label for="phone">Telefono</label>
                </div>


            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Salva</button>
            </div>
        </div>
    </div>
</div>

<div id="modal-address-delete" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-delete-empty"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Sei sicuro di voler eliminare questo indirizzo?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="modal-cancel btn outline ripple flex-grow-1" data-dismiss="modal" data-toggle="modal" data-target="#modal-address-management" style="width: 100px;">Annulla</button>
                <button class="modal-cancel btn accent ripple flex-grow-1" data-dismiss="modal" data-toggle="modal" data-target="#modal-address-management" style="width: 100px;">Ok</button>
            </div>
        </div>
    </div>
</div>
