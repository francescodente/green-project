<?php
$page = basename($_SERVER['PHP_SELF']);
?>

<nav id="menu">
    <div class="container">
        <div id="menu-left">
            <button id="menu-toggle" class="btn icon ripple d-lg-none" title="Menu"><i class="mdi mdi-menu"></i></button>
            <a href="index.php" class="menu-logo"><img src="images/logo/fruitracers_logo_small.png"></a>
        </div>
        <div id="menu-middle">
            <a href="index.php" id="menu-logo" class="d-lg-none"><img src="images/logo/fruitracers_logo_muted.png"></a>
            <a href="index.php#home" class="menu-item ripple" data-sections="['home']">
                <i class="mdi mdi-home d-lg-none"></i>
                <span>Home</span>
            </a>
            <a href="index.php#who" class="menu-item ripple" data-sections="['who']">
                <i class="mdi mdi-book-open-page-variant d-lg-none"></i>
                <span>Chi siamo</span>
            </a>
            <a href="index.php#contacts" class="menu-item ripple" data-sections="['contacts']">
                <i class="mdi mdi-account-box d-lg-none"></i>
                <span>Contatti</span>
            </a>
            <div class="divider dark d-lg-none"></div>
            <a href="index.php#companies" class="menu-item ripple" data-sections="['companies']">
                <i class="mdi mdi-map-marker d-lg-none"></i>
                <span>Aziende</span>
            </a>
            <a href="categories.php" class="menu-item ripple" data-sections="['categories', 'products']">
                <i class="mdi mdi-food-apple d-lg-none"></i>
                <span>Prodotti</span>
            </a>
            <div class="divider dark d-lg-none"></div>
            <h6 class="d-lg-none">Account</h6>
            <a href="cart.php" class="menu-item ripple d-lg-none" data-sections="['cart']">
                <i class="mdi mdi-cart"></i>
                <span>Carrello</span>
            </a>
            <a href="account-user-data.php" class="menu-item ripple d-lg-none" data-sections="['account-user-data']">
                <i class="mdi mdi-account-circle"></i>
                <span>I miei dati</span>
            </a>
            <a href="account-client-orders.php" class="menu-item ripple d-lg-none" data-sections="['account-client-orders']">
                <i class="mdi mdi-book-open"></i>
                <span>Ordini</span>
            </a>
            <a href="account-business-orders.php" class="menu-item ripple d-lg-none" data-sections="['account-business-orders']">
                <i class="mdi mdi-book-open"></i>
                <span>Ordini</span>
            </a>
            <a href="account-delivery-orders.php" class="menu-item ripple d-lg-none" data-sections="['account-delivery-orders']">
                <i class="mdi mdi-book-open"></i>
                <span>Ordini</span>
            </a>
            <a href="account-business-products.php" class="menu-item ripple d-lg-none" data-sections="['account-business-products']">
                <i class="mdi mdi-food-apple"></i>
                <span>Prodotti</span>
            </a>
            <a href="account-admin-management.php" class="menu-item ripple d-lg-none" data-sections="['account-admin-management']">
                <i class="mdi mdi-pound-box"></i>
                <span>Gestione</span>
            </a>
            <div class="divider dark d-lg-none"></div>
            <h6 class="d-lg-none">Altro</h6>
            <a href="faq.php" class="menu-item ripple d-lg-none" data-sections="['faq']">
                <i class="mdi mdi-help-circle"></i>
                <span>Aiuto</span>
            </a>
            <a href="privacy.php" class="menu-item ripple d-lg-none" data-sections="['privacy']">
                <i class="mdi mdi-lock"></i>
                <span>Privacy</span>
            </a>
            <a href="use-terms.php" class="menu-item ripple d-lg-none" data-sections="['use-terms']">
                <i class="mdi mdi-checkbook"></i>
                <span>Termini d'uso</span>
            </a>
        </div>
        <div id="menu-shade" class="d-lg-none"></div>
        <div id="menu-right">
            <a href="cart.php" class="btn icon ripple" title="Carrello"><i class="mdi mdi-cart"></i></a>
            <button class="btn icon ripple d-none d-lg-flex" title="Account" data-toggle="dropdown" data-target="#dropdown-account">
                <i class="mdi mdi-account-settings"></i>
            </button>
            <button class="btn icon ripple d-none d-lg-flex" title="Altro" data-toggle="dropdown" data-target="#dropdown-menu">
                <i class="mdi mdi-dots-vertical"></i>
            </button>
        </div>
    </div>
</nav>

<div id="dropdown-menu" class="dropdown menu fixed d-none d-lg-block">
    <ul>
        <li>
            <a href="faq.php" data-sections="['faq']"><i class="mdi dark mdi-help-circle"></i><span>Aiuto</span></a>
        </li>
        <li>
            <a href="privacy.php" data-sections="['privacy']"><i class="mdi dark mdi-lock"></i><span>Privacy</span></a>
        </li>
        <li>
            <a href="use-terms.php" data-sections="['use-terms']"><i class="mdi dark mdi-checkbook"></i><span>Termini d'uso</span></a>
        </li>
    </ul>
</div>

<div id="dropdown-account" class="dropdown menu fixed d-none d-lg-block">
    <ul>
        <li>
            <a href="account-user-data.php" data-sections="['account-user-data']">
                <i class="mdi dark mdi-account-circle"></i><span>I miei dati</span>
            </a>
        </li>
        <li>
            <a href="account-client-orders.php" data-sections="['account-client-orders']">
                <i class="mdi dark mdi-book-open"></i><span>Ordini</span>
            </a>
        </li>
        <li>
            <a href="account-business-orders.php" data-sections="['account-business-orders']">
                <i class="mdi dark mdi-book-open"></i><span>Ordini</span>
            </a>
        </li>
        <li>
            <a href="account-delivery-orders.php" data-sections="['account-delivery-orders']">
                <i class="mdi dark mdi-book-open"></i><span>Ordini</span>
            </a>
        </li>
        <li>
            <a href="account-business-products.php" data-sections="['account-business-products']">
                <i class="mdi dark mdi-food-apple"></i><span>Prodotti</span>
            </a>
        </li>
        <li>
            <a href="account-admin-management.php" data-sections="['account-admin-management']">
                <i class="mdi dark mdi-pound-box"></i><span>Gestione</span>
            </a>
        </li>
    </ul>
</div>
