<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Green Project - File di riepilogo</title>
</head>
<body class="req-login req-admin">

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="management" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">GESTIONE</h1>
                <br/>
                <h3 class="text-light">File di riepilogo</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="management-content" class="container py-4">
            <div id="management-reports" class="row">

                <div id="management-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("management-tabs.php"); ?>
                </div>
                <div id="management-content-col" class="col-12 col-lg-9">

                    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#reports-1" aria-expanded="true">
                        <h4 class="m-0">Ordini</h4>
                        <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#reports-1" aria-expanded="true" title="Mostra">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>
                    <div id="reports-1" class="collapse show">
                        <p class="pt-3 m-0">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                        </p>
                    </div>

                    <div class="divider dark my-4"></div>

                    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#reports-2" aria-expanded="true">
                        <h4 class="m-0">Prodotti</h4>
                        <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#reports-2" aria-expanded="true" title="Mostra">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>
                    <div id="reports-2" class="collapse show">
                        <p class="pt-3 m-0">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                        </p>
                    </div>

                    <div class="divider dark my-4"></div>

                    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#reports-3" aria-expanded="true">
                        <h4 class="m-0">Ordini fornitore</h4>
                        <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#reports-3" aria-expanded="true" title="Mostra">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>
                    <div id="reports-3" class="collapse show">
                        <p class="pt-3 m-0">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                        </p>
                    </div>

                    <div class="divider dark my-4"></div>

                    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#reports-4" aria-expanded="true">
                        <h4 class="m-0">Entrate</h4>
                        <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#reports-4" aria-expanded="true" title="Mostra">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>
                    <div id="reports-4" class="collapse show">
                        <p class="pt-3 m-0">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                        </p>
                    </div>

                </div>
            </div>

        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("resources.php"); ?>

</body>
</html>
