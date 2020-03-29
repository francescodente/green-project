<?php
$page = basename($_SERVER['PHP_SELF']);
?>

<div class="sticky-top" style="top: 64px;">
    <a id="user-data-tab" href="account-user-data.php" class="account-tab <?php echo $page == 'account-user-data.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-card-text"></i>
        <p class="m-0">I miei dati</p>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
    <a id="user-data-tab" href="account-user-addresses.php" class="account-tab <?php echo $page == 'account-user-addresses.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-map-marker"></i>
        <p class="m-0">Indirizzi</p>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
    <a id="weekly-delivery-preferences-tab" href="account-weekly-delivery-preferences.php" class="account-tab <?php echo $page == 'account-weekly-delivery-preferences.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-inbox-multiple"></i>
        <p class="m-0">Cassette</p>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
    <a id="orders-tab" href="account-orders.php" class="account-tab <?php echo $page == 'account-orders.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-book-open"></i>
        <p class="m-0">Ordini</p>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
    <a id="delivery-tab" href="account-delivery.php" class="account-tab <?php echo $page == 'account-delivery.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-truck-delivery"></i>
        <p class="m-0">Consegne</p>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
</div>
