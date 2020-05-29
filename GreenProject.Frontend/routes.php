<?php
$request = parse_url($_SERVER["REQUEST_URI"], PHP_URL_PATH);

switch ($request) {

    // Homepage
    case "/":
    case "":
    case "/home":
        $title = "Home";
        $page = "views/Home/Home.php";
        break;

    // Global routes
    case "/products":
        $title = "Prodotti";
        $page = "views/Products/Products.php";
        break;
    case "/help":
        $title = "Domande frequenti";
        $page = "views/Help/Help.php";
        break;
    case "/privacy-terms":
        $title = "Privacy e termini d'uso";
        $page = "views/PrivacyTerms/PrivacyTerms.php";
        break;

    // Account specific routes
    case "/cart":
        $title = "Carrello";
        $page = "views/account/Cart/Cart.php";
        break;
    case "/account/user-data":
        $title = "I miei dati";
        $page = "views/account/Data/Data.php";
        break;
    case "/account/addresses":
        $title = "I miei indirizzi";
        $page = "views/account/Addresses/Addresses.php";
        break;
    case "/account/orders":
        $title = "I miei ordini";
        $page = "views/account/Orders/Orders.php";
        break;
    case "/account/subscription":
        $title = "Il mio ordine settimanale";
        $page = "views/account/Subscription/Subscription.php";
        break;
    case "/account/delivery":
        $title = "Consegne";
        $page = "views/account/Delivery/Delivery.php";
        break;

    // Management routes
    case "/management/products":
        $title = "Anagrafica prodotti";
        $page = "views/management/Products/Products.php";
        break;
    case "/management/products/edit":
        $title = "Anagrafica prodotto";
        $page = "views/management/Products/EditProduct/EditProduct.php";
        break;
    case "/management/reports":
        $title = "File di riepilogo";
        $page = "views/management/Reports/Reports.php";
        break;

    // 404 handling
    default:
        http_response_code(404);
        $title = "404";
        $page = "views/404/404.php";
        break;
}

$title = "Sito in lavorazione";
?>
