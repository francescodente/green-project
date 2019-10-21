<?php
$page = basename($_SERVER['PHP_SELF']);
?>

<nav id="menu">
    <div class="container">
        <div id="menu-left">
            <button id="menu-toggle" class="btn icon ripple d-lg-none"><i class="mdi mdi-menu"></i></button>
            <a href="index.php" class="logo-small"><img src="images/logo/fruitracers_logo_muted.png"></a>
        </div>
        <div id="menu-middle">
            <a href="index.php" id="menu-logo" class="d-lg-none"><img src="images/logo/fruitracers_logo_muted.png"></a>
            <a href="<?php echo $page == "index.php" ? "#home" : "index.php#home" ?>" class="menu-item ripple">
                <i class="mdi mdi-home d-lg-none"></i>
                <span>Home</span>
            </a>
            <a href="<?php echo $page == "index.php" ? "#who" : "index.php#who" ?>" class="menu-item ripple">
                <i class="mdi mdi-book-open-page-variant d-lg-none"></i>
                <span>Chi siamo</span>
            </a>
            <a href="<?php echo $page == "index.php" ? "#contacts" : "index.php#contacts" ?>" class="menu-item ripple">
                <i class="mdi mdi-account-box d-lg-none"></i>
                <span>Contatti</span>
            </a>
            <div class="divider dark d-lg-none"></div>
            <a href="<?php echo $page == "index.php" ? "#where" : "index.php#where" ?>" class="menu-item ripple">
                <i class="mdi mdi-map-marker d-lg-none"></i>
                <span>Aziende</span>
            </a>
            <a href="<?php echo $page == "catalog.php" ? "#catalog" : "catalog.php" ?>" class="menu-item ripple">
                <i class="mdi mdi-chevron-right d-lg-none"></i>
                <span>Catalogo</span>
            </a>
            <div class="divider dark d-lg-none"></div>
            <a href="#" class="menu-item ripple d-lg-none">
                <i class="mdi mdi-cart"></i>
                <span>Carrello</span>
            </a>
            <a href="#" class="menu-item ripple d-lg-none">
                <i class="mdi mdi-account"></i>
                <span>Account</span>
            </a>
        </div>
        <div id="menu-shade" class="d-lg-none"></div>
        <div id="menu-right">
            <a class="btn icon ripple" title="Carrello"><i class="mdi mdi-cart"></i></a>
            <a class="btn icon ripple" title="Account"><i class="mdi mdi-account"></i></a>
        </div>
    </div>
</nav>
