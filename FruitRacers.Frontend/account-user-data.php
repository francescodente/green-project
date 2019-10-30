<h4 class="mb-4">Generali</h4>

<h6>E-mail *</h6>
<div class="text-input mb-3">
    <input id="email" type="email" name="email" value="user@domain.com" disabled/>
    <button type="button" class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>Password *</h6>
<div class="text-input mb-3">
    <input id="password" type="password" name="password" value="aaaaaaaa" disabled/>
    <button class="btn icon ripple" title="Modifica" data-toggle="modal" data-target="#modal-pwd-change">
        <i class="mdi dark mdi-pencil"></i>
    </button>
</div>

<h6>Telefono</h6>
<div class="text-input mb-3">
    <input id="telephone" type="text" name="telephone" value="123 456 7890" disabled/>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>Consensi</h6>
<input id="c1" type="checkbox" class="checkbox" name="cookie-consent" value="1" checked/>
<label for="c1">Consenso all'uso dei cookie</label><br>
<input id="c2" type="checkbox" class="checkbox" name="marketing-consent" value="1" checked/>
<label for="c2">Consenso alla ricezione di informazioni di marketing</label><br>

<div class="divider dark my-4"></div>

<h4 class="mb-4">Dati personali</h4>

<h6>Codice fiscale **</h6>
<div class="text-input mb-3">
    <input id="cf" type="text" name="cf" disabled/>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>Nome **</h6>
<div class="text-input mb-3">
    <input id="first-name" type="text" name="first-name" disabled/>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>Cognome **</h6>
<div class="text-input mb-3">
    <input id="last-name" type="text" name="last-name" disabled/>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>Data di nascita</h6>
<div class="text-input mb-3">
    <input id="birth-date" type="text" name="birth-date" disabled/>
    <label></label>
    <span>gg/mm/aaaa</span>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>Sesso</h6>
<input id="r1" type="radio" class="radio" name="gender" value="male" checked/>
<label for="r1">Maschio</label><br>
<input id="r2" type="radio" class="radio" name="gender" value="female"/>
<label for="r2">Femmina</label><br>
<input id="r3" type="radio" class="radio" name="gender" value="other"/>
<label for="r3" class="mb-2">Altro</label>

<div class="divider dark my-4"></div>

<div class="d-flex justify-content-between mb-3">
    <h4 class="m-0">Indirizzi</h4>
    <button class="btn icon ripple" title="Modifica" data-toggle="modal" data-target="#modal-address-management">
        <i class="mdi dark mdi-pencil"></i>
    </button>
</div>


<div class="address d-flex align-items-center">
    <div class="thumb" style="background-image: url('images/map-thumb.png');">
        <i class="mdi mdi-map-marker"></i>
    </div>
    <p class="m-0">Viale della Via 123, 47522 - Cesena (FC)</p>
</div>
<div class="address d-flex align-items-center">
    <div class="thumb" style="background-image: url('images/map-thumb.png');">
        <i class="mdi mdi-map-marker"></i>
    </div>
    <p class="m-0">Altra Via 999, 47522 - Cesena (FC)</p>
</div>

<div class="divider dark my-4"></div>

<h4 class="mb-4">Dati aziendali</h4>

<h6>Numero di partita IVA</h6>
<div class="text-input mb-3">
    <input id="vat-number" type="text" name="vat-number" disabled/>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>Nome della società</h6>
<div class="text-input mb-3">
    <input id="company-name" type="text" name="company-name" disabled/>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>SDI</h6>
<div class="text-input mb-3">
    <input id="sdi" type="text" name="sdi" disabled/>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>Indirizzo PEC</h6>
<div class="text-input mb-3">
    <input id="pec" type="text" name="pec" disabled/>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>Forma legale</h6>
<div class="text-input mb-3">
    <input id="legal-form" type="text" name="legal-form" disabled/>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<h6>Descrizione</h6>
<div class="text-area">
    <textarea id="description" disabled></textarea>
    <button class="edit btn icon ripple" title="Modifica">
        <i class="mdi dark mdi-pencil"></i>
        <i class="mdi dark mdi-content-save d-none"></i>
    </button>
</div>

<div class="divider dark my-4"></div>

<p class="text-sec-dark">
    I campi contrassegnati da * sono obbligatori.<br>
    I campi contrassegnati da ** sono necessari per effettuare acquisti.
</p>
