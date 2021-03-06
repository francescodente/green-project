<div id="resources">

    <div id="scripts" class="d-none">
        <script src="https://code.jquery.com/jquery-3.3.1.min.js" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.25.3/moment.min.js" integrity="sha256-C66CaAImteEKZPYvgng9j10J/45e9sAuZyfPYCwp4gE=" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.25.3/locale/it.min.js" integrity="sha256-1eZdOmxw6+0vJZqhjId77ptpga7b1U+oA17eikVRqks=" crossorigin="anonymous"></script>
        <script src="/js/universal-parallax.js"></script>
        <script src="/js/ripple.js"></script>
        <script src="/js/components.js"></script>
        <script src="/js/ui.js"></script>
        <script src="/js/menu.js"></script>
        <script src="/js/main.js"></script>
        <script src="/js/api/API.js"></script>
        <script src="/js/api/APIUtils.js"></script>
        <script src="/js/utils.js"></script>
        <script src="/js/cookies.js"></script>
        <script src="/js/authentication-guard.js"></script>
    </div>

    <?php
    include("components/instantiable/imports.php");
    include("components/includable/LoginModal/LoginModal.php");
    include("components/includable/SignupModal/SignupModal.php");
    include("components/includable/PasswordRecoveryModal/PasswordRecoveryModal.php");
    include("components/includable/AccountActivationModal/AccountActivationModal.php");
    include("components/includable/CookieBanner/CookieBanner.php");
    ?>

    <div id="sizer">
        <div class="d-block d-sm-none d-md-none d-lg-none d-xl-none" data-size="xs"></div>
        <div class="d-none d-sm-block d-md-none d-lg-none d-xl-none" data-size="sm"></div>
        <div class="d-none d-sm-none d-md-block d-lg-none d-xl-none" data-size="md"></div>
        <div class="d-none d-sm-none d-md-none d-lg-block d-xl-none" data-size="lg"></div>
        <div class="d-none d-sm-none d-md-none d-lg-none d-xl-block" data-size="xl"></div>
    </div>

</div>

<?php include("components/includable/LoadingModal.php"); ?>
