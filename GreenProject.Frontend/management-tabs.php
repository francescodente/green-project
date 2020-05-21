<?php
$page = basename($_SERVER['PHP_SELF']);
?>

<div class="sticky-top" style="top: 64px;">
    <a id="user-data-tab" href="management-products.php" class="account-tab <?php echo $page == 'management-products.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-sprout"></i>
        <span>Gestione catalogo</span>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
    <a id="user-data-tab" href="management-reports.php" class="account-tab <?php echo $page == 'management-reports.php' ? 'selected' : '' ?>">
        <i class="mdi dark mdi-file-delimited-outline"></i>
        <span>File di riepilogo</span>
        <i class="mdi dark mdi-chevron-right"></i>
    </a>
</div>
