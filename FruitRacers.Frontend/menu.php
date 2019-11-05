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
            <a href="cart.php" class="menu-item ripple d-lg-none" data-sections="['cart']">
                <i class="mdi mdi-cart"></i>
                <span>Carrello</span>
            </a>
            <a href="account-tabs.php" class="menu-item ripple d-lg-none" data-sections="['account']">
                <i class="mdi mdi-account"></i>
                <span>Account</span>
            </a>
            <div class="divider dark d-lg-none"></div>
            <a href="faq.php" class="menu-item ripple d-lg-none" data-sections="['faq']">
                <i class="mdi mdi-help-circle"></i>
                <span>Aiuto</span>
            </a>
            <a href="privacy.php" class="menu-item ripple d-lg-none" data-sections="['privacy']">
                <i class="mdi mdi-lock"></i>
                <span>Privacy</span>
            </a>
        </div>
        <div id="menu-shade" class="d-lg-none"></div>
        <div id="menu-right">
            <a href="cart.php" class="btn icon ripple" title="Carrello"><i class="mdi mdi-cart"></i></a>
            <a href="account-tabs.php" class="btn icon ripple d-flex d-lg-none" title="Account"><i class="mdi mdi-account"></i></a>
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
    </ul>
</div>

<?php
$accountTab = isset($_GET["tab"]) ? $_GET["tab"] : "";
?>
<div id="dropdown-account" class="dropdown menu fixed d-none d-lg-block">
    <ul>
        <li>
            <a href="account.php?tab=user-data" <?php echo $accountTab == "user-data" ? "class='selected'" : "" ?>>
                <i class="mdi dark mdi-account-circle"></i><span>I miei dati</span>
            </a>
        </li>
        <li>
            <a href="account.php?tab=client-orders" <?php echo $accountTab == "client-orders" ? "class='selected'" : "" ?>>
                <i class="mdi dark mdi-book-open"></i><span>Ordini</span>
            </a>
        </li>
        <li>
            <a href="account.php?tab=business-orders" <?php echo $accountTab == "business-orders" ? "class='selected'" : "" ?>>
                <i class="mdi dark mdi-book-open"></i><span>Ordini</span>
            </a>
        </li>
        <li>
            <a href="account.php?tab=delivery-orders" <?php echo $accountTab == "delivery-orders" ? "class='selected'" : "" ?>>
                <i class="mdi dark mdi-book-open"></i><span>Ordini</span>
            </a>
        </li>
        <li>
            <a href="account.php?tab=business-products" <?php echo $accountTab == "business-products" ? "class='selected'" : "" ?>>
                <i class="mdi dark mdi-food-apple"></i><span>Prodotti</span>
            </a>
        </li>
        <li>
            <a href="account.php?tab=admin-management" <?php echo $accountTab == "admin-management" ? "class='selected'" : "" ?>>
                <i class="mdi dark mdi-pound-box"></i><span>Gestione</span>
            </a>
        </li>
    </ul>
</div>
