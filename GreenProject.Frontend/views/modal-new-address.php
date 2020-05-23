<form id="modal-new-address" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-top d-flex justify-content-center">
                <div class="address-thumb" style="background-image: url('images/map-thumb.png');">
                    <i class="mdi large mdi-map-marker"></i>
                </div>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi"><i class="mdi dark mdi-close"></i></button>
            </div>
            <div class="modal-body container">

                <h4 class="text-center mt-3 mb-2">Nuovo indirizzo</h4>

                <div class="row justify-content-center">
                    <div id="address-form-loader" class="loader text-center my-3">
                        <?php include("loader.php"); ?>
                    </div>
                </div>

                <div class="form-fields row no-gutters">

                    <!-- Province, city, ZIP code -->
                    <div class="col-12">
                        <div id="select-province" class="dropdown select">
                            <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                <input id="province-select-toggle" type="text" placeholder=" " readonly/>
                                <label for="province-select-toggle">Provincia</label>
                            </div>
                            <div class="dropdown-menu w-100" aria-labelledby="select-toggle"></div>
                            <div class="select-item-template d-none">
                                <input id="select-province-tmp" type="radio" class="radio" name="select-province" data-required="true"/>
                                <label for="select-province-tmp"></label>
                            </div>
                        </div>
                    </div>
                    <div class="col-7">
                        <div id="select-city" class="dropdown select mr-3">
                            <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                <input id="city-select-toggle" type="text" placeholder=" " readonly/>
                                <label for="city-select-toggle">Città</label>
                            </div>
                            <div class="dropdown-menu w-100" aria-labelledby="select-toggle"></div>
                            <div class="select-item-template d-none">
                                <input id="select-city-tmp" type="radio" class="radio" name="select-city" data-required="true"/>
                                <label for="select-city-tmp"></label>
                            </div>
                        </div>
                    </div>
                    <div class="col-5">
                        <div id="select-zipcode" class="dropdown select">
                            <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                <input id="cap-select-toggle" type="text" placeholder=" " readonly/>
                                <label for="cap-select-toggle">CAP</label>
                            </div>
                            <div class="dropdown-menu w-100" aria-labelledby="select-toggle"></div>
                            <div class="select-item-template d-none">
                                <input id="select-zipcode-tmp" type="radio" class="radio" name="select-zipcode" data-required="true"/>
                                <label for="select-zipcode-tmp"></label>
                            </div>
                        </div>
                    </div>

                    <!-- Street and house number -->
                    <div class="col-7">
                        <div class="text-input mr-3">
                            <input id="street" type="text" placeholder=" " required/>
                            <label for="street">Via</label>
                        </div>
                    </div>
                    <div class="col-5">
                        <div class="text-input">
                            <input id="house-number" type="number" placeholder=" " required/>
                            <label for="house-number">Civico</label>
                        </div>
                    </div>

                    <!-- Name and telephone -->
                    <div class="text-input w-100">
                        <input id="address-name" type="text" placeholder=" " required/>
                        <label for="address-name">Nome</label>
                    </div>
                    <div class="text-input w-100">
                        <input id="address-telephone" type="tel" placeholder=" " required/>
                        <label for="address-telephone">Telefono</label>
                    </div>

                </div>

            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button type="button" class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button type="submit" class="submit-address btn accent ripple flex-grow-1" style="width: 100px;" disabled>Salva</button>
            </div>
        </div>
    </div>
</form>

<script defer src="js/views/modal-new-address.js"></script>
