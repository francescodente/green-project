<?php
$page = basename($_SERVER['PHP_SELF']);
?>

<div class="sticky-top" style="top: 64px;">
    <a id="user-data-tab" href="account-user-data.php" class="account-tab <?php echo $page == 'account-user-data.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-card-text"></i>
        <span>I miei dati</span>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
    <a id="user-data-tab" href="account-user-addresses.php" class="account-tab <?php echo $page == 'account-user-addresses.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-map-marker"></i>
        <span>Indirizzi</span>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
    <a id="weekly-delivery-preferences-tab" href="account-weekly-delivery-preferences.php" class="account-tab <?php echo $page == 'account-weekly-delivery-preferences.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-inbox-multiple"></i>
        <span>Cassette</span>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
    <a id="orders-tab" href="account-orders.php" class="account-tab <?php echo $page == 'account-orders.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-book-open"></i>
        <span>Ordini</span>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
    <a id="delivery-tab" href="account-delivery.php" class="account-tab <?php echo $page == 'account-delivery.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-truck-delivery"></i>
        <span>Consegne</span>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
    <a id="logout-tab" href="#" class="btn-logout account-tab">
        <i class="mdi dark mdi-logout-variant"></i>
        <span>Esci</span>
    </a>
</div>
