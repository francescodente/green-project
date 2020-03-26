<?php
$page = basename($_SERVER['PHP_SELF']);
?>

<header class="top-bar">
    <div class="container">

        <div class="top-bar-left">
            <button class="menu-toggle btn icon ripple d-lg-none" title="Menu"><i class="mdi dark mdi-menu"></i></button>
            <a href="index.php" class="top-bar-logo"><img src="images/logo/greenproject_logo_small.png"></a>
            <a href="index.php" class="top-bar-logo light"><img src="images/logo/greenproject_logo_light_small.png"></a>
        </div>

        <div class="top-bar-center">
            <a href="index.php#home" class="menu-item ripple d-none d-lg-flex">
                <span>Home</span>
            </a>
            <a href="index.php#about" class="menu-item ripple d-none d-lg-flex">
                <span>Chi siamo</span>
            </a>
            <a href="index.php#contacts" class="menu-item ripple d-none d-lg-flex">
                <span>Contatti</span>
            </a>
        </div>

        <div class="top-bar-right">
            <div style="position: relative">
                <a href="cart.php" class="btn icon ripple" title="Carrello"><i class="mdi dark mdi-cart"></i></a>
                <span class="cart-badge badge">3</span>
            </div>

            <div class="dropdown d-none d-lg-block">
                <button id="dropdown-account" class="btn icon ripple" title="Account" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="mdi dark mdi-account-circle"></i>
                </button>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-account">
                    <a href="account-user-data.php" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-card-text"></i><span class="text-dark">I miei dati</span>
                    </a>
                    <a href="account-client-orders.php" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-book-open"></i><span class="text-dark">Ordini</span>
                    </a>
                    <a href="account-company-orders.php" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-book-open"></i><span class="text-dark">Ordini</span>
                    </a>
                    <a href="account-delivery-orders.php" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-book-open"></i><span class="text-dark">Ordini</span>
                    </a>
                    <a href="account-company-products.php" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-food-apple"></i><span class="text-dark">Prodotti</span>
                    </a>
                    <a href="#" class="dropdown-item">
                        <i class="mdi dark mdi-logout-variant"></i><span>Esci</span>
                    </a>
                </div>
            </div>

            <div class="dropdown d-none d-lg-block">
                <button id="dropdown-admin" class="btn icon ripple" title="Gestione" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="mdi dark mdi-pound-box"></i>
                </button>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-admin">
                    <a href="management-users.php" class="dropdown-item menu-item">Gestione utenti</a>
                    <a href="management-products.php" class="dropdown-item menu-item">Gestione prodotti</a>
                    <a href="management-orders.php" class="dropdown-item menu-item">Gestione ordini</a>
                    <a href="management-stats.php" class="dropdown-item menu-item">Dati e statistiche</a>
                    <a href="management-market-prices.php" class="dropdown-item menu-item">Prezzi di mercato</a>
                </div>
            </div>

            <div class="dropdown d-none d-lg-block">
                <button id="dropdown-menu" class="btn icon ripple" title="Altro" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="mdi dark mdi-dots-vertical"></i>
                </button>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-menu">
                    <a href="faq.php" class="dropdown-item menu-item">
                        <i class="mdi dark mdi-help-circle"></i><span class="text-dark">Aiuto</span>
                    </a>
                    <a href="privacy-terms.php" class="dropdown-item menu-item">
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
            <a href="index.php"><img src="images/logo/greenproject_logo_small.png"></a>
            <button class="menu-toggle btn icon ripple" title="Nascondi"><i class="mdi dark mdi-arrow-left"></i></button>
        </div>

        <a href="index.php#home" class="menu-item ripple">
            <i class="mdi mdi-home"></i>
            <span>Home</span>
        </a>
        <a href="index.php#about" class="menu-item ripple">
            <i class="mdi mdi-book-open-page-variant"></i>
            <span>Chi siamo</span>
        </a>
        <a href="index.php#contacts" class="menu-item ripple">
            <i class="mdi mdi-account-box"></i>
            <span>Contatti</span>
        </a>
        <a href="companies.php" class="menu-item ripple">
            <i class="mdi mdi-tractor"></i>
            <span>Partner</span>
        </a>

        <div class="divider dark"></div>

        <button class="menu-item ripple" data-toggle="submenu" data-target="#account-submenu">
            <i class="mdi mdi-account-circle"></i>
            <span>Account</span>
            <i class="mdi expand dark mdi-chevron-down"></i>
        </button>
        <div id="account-submenu" class="submenu">
            <a href="account-user-data.php" class="menu-item ripple">
                <i class="mdi mdi-card-text"></i>
                <span>I miei dati</span>
            </a>
            <a href="account-client-orders.php" class="menu-item ripple">
                <i class="mdi mdi-book-open"></i>
                <span>Ordini</span>
            </a>
            <a href="account-company-orders.php" class="menu-item ripple">
                <i class="mdi mdi-book-open"></i>
                <span>Ordini</span>
            </a>
            <a href="account-delivery-orders.php" class="menu-item ripple">
                <i class="mdi mdi-book-open"></i>
                <span>Ordini</span>
            </a>
            <a href="account-company-products.php" class="menu-item ripple">
                <i class="mdi mdi-food-apple"></i>
                <span>Prodotti</span>
            </a>
            <a href="account-admin-management.php" class="menu-item ripple">
                <i class="mdi mdi-logout-variant"></i>
                <span>Esci</span>
            </a>
        </div>
        <a href="cart.php" class="menu-item ripple">
            <i class="mdi mdi-cart"></i>
            <span>Carrello</span>
            <span class="cart-badge badge">3</span>
        </a>

        <button class="menu-item ripple" data-toggle="submenu" data-target="#admin-submenu">
            <i class="mdi mdi-pound-box"></i>
            <span>Gestione</span>
            <i class="mdi expand dark mdi-chevron-down"></i>
        </button>
        <div id="admin-submenu" class="submenu">
            <a href="management-users.php" class="menu-item">Gestione utenti</a>
                    <a href="management-products.php" class="menu-item">Gestione prodotti</a>
                    <a href="management-orders.php" class="menu-item">Gestione ordini</a>
                    <a href="management-stats.php" class="menu-item">Dati e statistiche</a>
                    <a href="management-market-prices.php" class="menu-item">Prezzi di mercato</a>
        </div>

        <div class="divider dark"></div>

        <a href="faq.php" class="menu-item ripple">
            <i class="mdi mdi-help-circle"></i>
            <span>Aiuto</span>
        </a>
        <a href="privacy-terms.php" class="menu-item ripple">
            <i class="mdi mdi-checkbook d-lg-none"></i>
            <span>Privacy e termini</span>
        </a>

    </div>
</nav>
<div class="menu-shade" class="d-lg-none"></div>