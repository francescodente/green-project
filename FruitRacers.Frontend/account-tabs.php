<?php
$page = basename($_SERVER['PHP_SELF']);
?>

<a id="user-data-tab" href="account-user-data.php" class="account-tab <?php echo $page == 'account-user-data.php' ? 'selected' : '' ?>">
    <i class="mdi dark mdi-card-text"></i>
    <p class="m-0">I miei dati</p>
    <i class="mdi dark mdi-chevron-right"></i>
</a>
<a id="client-orders-tab" href="account-client-orders.php" class="account-tab <?php echo $page == 'account-client-orders.php' ? 'selected' : '' ?>">
    <i class="mdi dark mdi-book-open"></i>
    <p class="m-0">Ordini</p>
    <i class="mdi dark mdi-chevron-right"></i>
</a>
<a id="business-orders-tab" href="account-company-orders.php" class="account-tab <?php echo $page == 'account-company-orders.php' ? 'selected' : '' ?>">
    <i class="mdi dark mdi-book-open"></i>
    <p class="m-0">Ordini</p>
    <i class="mdi dark mdi-chevron-right"></i>
</a>
<a id="delivery-orders-tab" href="account-delivery-orders.php" class="account-tab <?php echo $page == 'account-delivery-orders.php' ? 'selected' : '' ?>">
    <i class="mdi dark mdi-book-open"></i>
    <p class="m-0">Ordini</p>
    <i class="mdi dark mdi-chevron-right"></i>
</a>
<a id="business-products-tab" href="account-company-products.php" class="account-tab <?php echo $page == 'account-company-products.php' ? 'selected' : '' ?>">
    <i class="mdi dark mdi-food-apple"></i>
    <p class="m-0">Prodotti</p>
    <i class="mdi dark mdi-chevron-right"></i>
</a>
<a id="admin-management-tab" href="account-admin-management.php" class="account-tab <?php echo $page == 'account-admin-management.php' ? 'selected' : '' ?>">
    <i class="mdi dark mdi-pound-box"></i>
    <p class="m-0">Gestione</p>
    <i class="mdi dark mdi-chevron-right"></i>
</a>
