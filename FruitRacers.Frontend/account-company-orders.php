<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Account</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="content">

        <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
            <div class="container text-center">
                <h1 class="text-light">ACCOUNT</h1>
                <br>
                <h3 class="text-light">Ordini</h3>
            </div>
            <div class="parallax shade" data-parallax-image="images/account.jpg"></div>
        </section>
        <section id="account-content" class="container py-4">
            <div id="business-orders" class="row">

                <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                    <?php include("account-tabs.php"); ?>
                </div>
                <div id="account-content-col" class="col-12 col-lg-9">

                    <div class="nav nav-tabs nav-justified" id="nav-tab" role="tablist" style="margin-top: 7px;">
                        <a class="nav-item nav-link ripple active" id="nav-open-orders-tab" data-toggle="tab" href="#nav-open-orders" role="tab"
                           aria-controls="nav-open-orders" aria-selected="true">
                            IN CORSO
                        </a>
                        <a class="nav-item nav-link ripple" id="nav-order-history-tab" data-toggle="tab" href="#nav-order-history" role="tab"
                           aria-controls="nav-order-history" aria-selected="false">
                            CRONOLOGIA
                        </a>
                    </div>
                    <div class="tab-content my-4" id="nav-tabContent">
                        <div class="tab-pane show active" id="nav-open-orders" role="tabpanel" aria-labelledby="nav-open-orders-tab">
                            <p>
                                Et et consectetur ipsum labore excepteur est proident excepteur ad velit occaecat qui minim occaecat veniam. Fugiat veniam incididunt anim aliqua enim pariatur veniam sunt est aute sit dolor anim. Velit non irure adipisicing aliqua ullamco irure incididunt irure non esse consectetur nostrud minim non minim occaecat. Amet duis do nisi duis veniam non est eiusmod tempor incididunt tempor dolor ipsum in qui sit. Exercitation mollit sit culpa nisi culpa non adipisicing reprehenderit do dolore. Duis reprehenderit occaecat anim ullamco ad duis occaecat ex.
                            </p>
                        </div>
                        <div class="tab-pane" id="nav-order-history" role="tabpanel" aria-labelledby="nav-order-history-tab">
                            <p>
                                Nulla est ullamco ut irure incididunt nulla Lorem Lorem minim irure officia enim reprehenderit. Magna duis labore cillum sint adipisicing exercitation ipsum. Nostrud ut anim non exercitation velit laboris fugiat cupidatat. Commodo esse dolore fugiat sint velit ullamco magna consequat voluptate minim amet aliquip ipsum aute laboris nisi. Labore labore veniam irure irure ipsum pariatur mollit magna in cupidatat dolore magna irure esse tempor ad mollit. Dolore commodo nulla minim amet ipsum officia consectetur amet ullamco voluptate nisi commodo ea sit eu.
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </section>

    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>
    <script src="js/account-client-orders.js"></script>

    <?php include("modals-product.php"); ?>

</body>
</html>
