<?php require_once("routes.php"); ?>

<!DOCTYPE html>
<html lang="it">
<head>
    <?php require_once("head.php"); ?>
    <title>Green Project - <?php echo $title; ?></title>
</head>
<body>

    <?php
    require_once("menu.php");
    require_once($page);
    require_once("footer.php");
    require_once("resources.php")
    ?>

</body>
</html>