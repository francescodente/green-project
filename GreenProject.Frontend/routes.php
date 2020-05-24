<?php
$request = parse_url($_SERVER["REQUEST_URI"], PHP_URL_PATH);

switch ($request) {

    // Homepage
    case "/":
    case "":
    case "/home":
        $title = "Home";
        $page = "views/home.php";
        break;

    // Global routes
    case "/products":
        $title = "Prodotti";
        $page = "views/products.php";
        break;
    case "/help":
        $title = "Domande frequenti";
        $page = "views/help.php";
        break;
    case "/privacy-terms":
        $title = "Privacy e termini d'uso";
        $page = "views/privacy-terms.php";
        break;

    // Account specific routes
    case "/cart":
        $title = "Carrello";
        $page = "views/cart.php";
        break;
    case "/account/user-data":
        $title = "I miei dati";
        $page = "views/account-user-data.php";
        break;
    case "/account/addresses":
        $title = "I miei indirizzi";
        $page = "views/account-user-addresses.php";
        break;
    case "/account/orders":
        $title = "I miei ordini";
        $page = "views/account-orders.php";
        break;
    case "/account/subscription":
        $title = "Il mio ordine settimanale";
        $page = "views/account-weekly-delivery-preferences.php";
        break;
    case "/account/delivery":
        $title = "Consegne";
        $page = "views/account-delivery.php";
        break;

    // Management routes
    case "/management/products":
        $title = "Anagrafica prodotti";
        $page = "views/management-products.php";
        break;
    case "/management/products/edit":
        $title = "Anagrafica prodotto";
        $page = "views/management-product-edit.php";
        break;
    case "/management/reports":
        $title = "File di riepilogo";
        $page = "views/management-reports.php";
        break;

    // 404 handling
    default:
        http_response_code(404);
        $title = "404";
        $page = "views/404.php";
        break;
}

$title = "Sito in lavorazione";
?>
