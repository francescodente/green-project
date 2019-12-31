<?php
$page = basename($_SERVER['PHP_SELF']);
?>

<header class="top-bar">
    <div class="container">

        <div class="top-bar-left">
            <button class="menu-toggle btn icon ripple d-lg-none" title="Menu"><i class="mdi dark mdi-menu"></i></button>
            <a href="index.php" class="top-bar-logo"><img src="images/logo/fruitracers_logo_small_shadow.png"></a>
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
            <a href="companies.php" class="menu-item ripple d-none d-lg-flex">
                <span>Partner</span>
            </a>
        </div>

        <div class="top-bar-right">
            <a href="cart.php" class="btn icon ripple" title="Carrello"><i class="mdi dark mdi-cart"></i></a>
            <button class="btn icon ripple d-none d-lg-flex" title="Account" data-toggle="dropdown" data-target="#dropdown-account">
                <i class="mdi dark mdi-account-circle"></i>
            </button>
            <button class="btn icon ripple d-none d-lg-flex" title="Altro" data-toggle="dropdown" data-target="#dropdown-menu">
                <i class="mdi dark mdi-dots-vertical"></i>
            </button>
        </div>

    </div>
</header>

<nav class="menu bg-primary d-lg-none">
    <div class="menu-container">

        <div class="menu-header bg-primary-dark">
            <a href="index.php"><img src="images/logo/fruitracers_logo_small.png"></a>
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

        <button class="menu-item ripple" data-toggle="submenu" data-target="#components-submenu">
            <i class="mdi mdi-account-circle"></i>
            <span>Account</span>
            <i class="mdi expand dark mdi-chevron-down"></i>
        </button>
        <div id="components-submenu" class="submenu">
            <a href="account-user-data.php" class="menu-item ripple">
                <i class="mdi mdi-account-card-details"></i>
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
                <i class="mdi mdi-pound-box"></i>
                <span>Gestione</span>
            </a>
        </div>
        <a href="cart.php" class="menu-item ripple">
            <i class="mdi mdi-cart"></i>
            <span>Carrello</span>
        </a>

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

<div id="dropdown-menu" class="dropdown fixed d-none d-lg-block">
    <ul>
        <li>
            <a href="faq.php" class="menu-item">
                <i class="mdi dark mdi-help-circle"></i><span>Aiuto</span>
            </a>
        </li>
        <li>
            <a href="privacy-terms.php" class="menu-item">
                <i class="mdi dark mdi-checkbook"></i><span>Privacy e termini</span>
            </a>
        </li>
    </ul>
</div>

<div id="dropdown-account" class="dropdown fixed d-none d-lg-block">
    <ul>
        <li>
            <a href="account-user-data.php" class="menu-item">
                <i class="mdi dark mdi-account-card-details"></i><span>I miei dati</span>
            </a>
        </li>
        <li>
            <a href="account-client-orders.php" class="menu-item">
                <i class="mdi dark mdi-book-open"></i><span>Ordini</span>
            </a>
        </li>
        <li>
            <a href="account-company-orders.php" class="menu-item">
                <i class="mdi dark mdi-book-open"></i><span>Ordini</span>
            </a>
        </li>
        <li>
            <a href="account-delivery-orders.php" class="menu-item">
                <i class="mdi dark mdi-book-open"></i><span>Ordini</span>
            </a>
        </li>
        <li>
            <a href="account-company-products.php" class="menu-item">
                <i class="mdi dark mdi-food-apple"></i><span>Prodotti</span>
            </a>
        </li>
        <li>
            <a href="account-admin-management.php" class="menu-item">
                <i class="mdi dark mdi-pound-box"></i><span>Gestione</span>
            </a>
        </li>
    </ul>
</div>
