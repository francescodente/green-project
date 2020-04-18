<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - Errore</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="error" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ERRORE <?php if (isset($_GET["status"])) echo " " . $_GET["status"]; ?></h1>
                <h4 class="text-light"><?php if (isset($_GET["statusText"])) echo " " . $_GET["statusText"]; ?></h4>
            </div>
            <div class="parallax shade" data-parallax-image="images/error.jpg"></div>
        </section>
        <section id="error-content" class="container py-4">
            <div class="row">
                <div class="col-12 text-center">
                    <h1>Oops!</h1>
                    <p class="lead text-sec-dark">Ci dispace molto, ma si è verificato un errore.</p>
                    <a href="index.php" class="btn accent ripple px-3">Torna alla homepage</a>

                    <i class="mdi text-dis-dark mdi-campfire d-block mt-4 mb-5" style="height: 256px; font-size: 256px; line-height: 256px;"></i>

                    <p class="err-code text-sec-dark">
                        <?php if (isset($_GET["errCode"])) echo $_GET["errCode"]; ?>
                    </p>
                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("resources.php"); ?>

</body>
</html>