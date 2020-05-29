<?php require_once("routes.php"); ?>

<!DOCTYPE html>
<html lang="it">
<head>
    <?php require_once("layout/head.php"); ?>
    <title>Green Project - <?php echo $title; ?></title>
</head>
<body>

    <?php
    require_once("layout/menu.php");
    require_once($page);
    require_once("layout/footer.php");
    require_once("layout/resources.php")
    ?>

</body>
</html>