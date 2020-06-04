<header class="top-bar">
    <div class="container">

        <div class="top-bar-left">
            <button class="menu-toggle btn icon ripple d-lg-none" title="Menu"><i class="mdi dark mdi-menu"></i></button>
            <a href="/home" class="top-bar-logo"><img src="/images/logo/greenproject_logo_small.png" alt="Logo Green Project"></a>
            <a href="/home" class="top-bar-logo light"><img src="/images/logo/greenproject_logo_light_small.png" alt="Logo Green Project"></a>
        </div>

        <div class="top-bar-center">
            <a href="/home#landing" class="menu-item ripple d-none d-lg-flex">
                <span>Home</span>
            </a>
            <a href="/home#products_" class="menu-item ripple d-none d-lg-flex">
                <span>Catalogo</span>
            </a>
            <a href="/home#about" class="menu-item ripple d-none d-lg-flex">
                <span>Chi siamo</span>
            </a>
            <a href="/home#contacts" class="menu-item ripple d-none d-lg-flex">
                <span>Contatti</span>
            </a>
        </div>

        <div class="top-bar-right">

            <button class="btn-login btn icon ripple req-logout" data-tooltip="tooltip" title="Accedi" data-toggle="modal" data-target="#modal-login"><i class="mdi dark mdi-login-variant"></i></button>

            <div style="position: relative;" class="req-norole">
                <a href="/cart" class="btn icon ripple" data-tooltip="tooltip" title="Carrello"><i class="mdi dark mdi-cart"></i></a>
                <span class="cart-badge badge"></span>
            </div>

            <div class="dropdown d-none d-lg-block req-login">
                <button id="dropdown-account" class="btn icon ripple" data-tooltip="tooltip" data-trigger="hover" title="Account" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="mdi dark mdi-account-circle"></i>
                </button>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-account">
                    <a href="/account/user-data" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-account"></i><span class="text-dark">I miei dati</span>
                    </a>
                    <a href="/account/addresses" class="dropdown-item menu-item req-norole">
                        <i class="mdi dark mdi-map-marker"></i><span class="text-dark">Indirizzi</span>
                    </a>
                    <a href="/account/subscription" class="dropdown-item menu-item req-norole">
                        <i class="mdi dark mdi-inbox-multiple"></i><span class="text-dark">Cassette</span>
                    </a>
                    <a href="/account/orders" class="dropdown-item menu-item req-norole">
                        <i class="mdi dark mdi-book-open"></i><span class="text-dark">Ordini</span>
                    </a>
                    <a href="/account/delivery" class="dropdown-item menu-item req-delivery">
                        <i class="mdi dark mdi-truck-delivery"></i><span class="text-dark">Consegne</span>
                    </a>
                    <a href="#" class="btn-logout dropdown-item">
                        <i class="mdi dark mdi-logout-variant"></i><span>Esci</span>
                    </a>
                </div>
            </div>

            <div class="dropdown d-none d-lg-block req-admin">
                <button id="dropdown-admin" class="btn icon ripple" data-tooltip="tooltip" data-trigger="hover" title="Gestione" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="mdi dark mdi-pound-box"></i>
                </button>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-admin">
                    <a href="/management/products" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-sprout"></i><span class="text-dark">Gestione catalogo</span>
                    </a>
                    <a href="/management/reports" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-file-delimited-outline"></i><span class="text-dark">File di riepilogo</span>
                    </a>
                </div>
            </div>

            <div class="dropdown d-none d-lg-block">
                <button id="dropdown-menu" class="btn icon ripple" data-tooltip="tooltip" data-trigger="hover" title="Altro" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="mdi dark mdi-dots-vertical"></i>
                </button>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-menu">
                    <a href="/help" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-help-circle"></i><span class="text-dark">Aiuto</span>
                    </a>
                    <a href="/privacy-terms" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-checkbook"></i><span class="text-dark">Privacy e termini</span>
                    </a>
                </div>
            </div>

        </div>

    </div>
</header>

<nav class="menu bg-primary d-lg-none">
    <div class="menu-container">

        <div class="menu-header bg-primary-dark">
            <a href="/home"><img src="/images/logo/greenproject_logo_small.png" alt="Logo Green Project"></a>
            <button class="menu-toggle btn icon ripple" title="Nascondi"><i class="mdi dark mdi-arrow-left"></i></button>
        </div>

        <a href="/home#landing" class="menu-item ripple">
            <i class="mdi mdi-home"></i>
            <span>Home</span>
        </a>
        <a href="/home#products_" class="menu-item ripple">
            <i class="mdi mdi-sprout"></i>
            <span>Catalogo</span>
        </a>
        <a href="/home#about" class="menu-item ripple">
            <i class="mdi mdi-book-open-page-variant"></i>
            <span>Chi siamo</span>
        </a>
        <a href="/home#contacts" class="menu-item ripple">
            <i class="mdi mdi-account-box"></i>
            <span>Contatti</span>
        </a>

        <div class="divider dark"></div>

        <a href="#" class="menu-item ripple req-logout" data-toggle="modal" data-target="#modal-login" onclick="toggleMenu(false);">
            <i class="mdi mdi-login-variant"></i>
            <span>Accedi</span>
        </a>

        <button class="menu-item ripple req-login" data-toggle="submenu" data-target="#account-submenu">
            <i class="mdi mdi-account-circle"></i>
            <span>Account</span>
            <i class="mdi expand dark mdi-chevron-down"></i>
        </button>
        <div id="account-submenu" class="submenu req-login">
            <a href="/account/user-data" class="menu-item">
                <i class="mdi dark mdi-account"></i><span class="text-dark">I miei dati</span>
            </a>
            <a href="/account/addresses" class="menu-item req-norole">
                <i class="mdi dark mdi-map-marker"></i><span class="text-dark">Indirizzi</span>
            </a>
            <a href="/account/subscription" class="menu-item req-norole">
                <i class="mdi dark mdi-inbox-multiple"></i><span class="text-dark">Cassette</span>
            </a>
            <a href="/account/orders" class="menu-item req-norole">
                <i class="mdi dark mdi-book-open"></i><span class="text-dark">Ordini</span>
            </a>
            <a href="/account/delivery" class="menu-item req-delivery">
                <i class="mdi dark mdi-truck-delivery"></i><span class="text-dark">Consegne</span>
            </a>
            <a href="#" class="btn-logout menu-item">
                <i class="mdi dark mdi-logout-variant"></i><span>Esci</span>
            </a>
        </div>
        <a href="/cart" class="menu-item ripple req-norole">
            <i class="mdi mdi-cart"></i>
            <span>Carrello</span>
            <span class="cart-badge badge"></span>
        </a>

        <button class="menu-item ripple req-admin" data-toggle="submenu" data-target="#admin-submenu">
            <i class="mdi mdi-pound-box"></i>
            <span>Gestione</span>
            <i class="mdi expand dark mdi-chevron-down"></i>
        </button>
        <div id="admin-submenu" class="submenu req-admin">
            <a href="/management/products" class="menu-item">
                <i class="mdi mdi-sprout"></i>
                <span>Gestione catalogo</span>
            </a>
            <a href="/management/reports" class="menu-item">
                <i class="mdi mdi-file-delimited-outline"></i>
                <span>File di riepilogo</span>
            </a>
        </div>

        <div class="divider dark"></div>

        <a href="/help" class="menu-item ripple">
            <i class="mdi mdi-help-circle"></i>
            <span>Aiuto</span>
        </a>
        <a href="/privacy-terms" class="menu-item ripple">
            <i class="mdi mdi-checkbook d-lg-none"></i>
            <span>Privacy e termini</span>
        </a>

    </div>
</nav>
<div class="menu-shade" class="d-lg-none"></div>
