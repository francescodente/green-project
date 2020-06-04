<div class="sticky-top" style="top: 64px;">
    <a id="user-data-tab" href="/account/user-data"
        class="account-tab <?php echo $request == '/account/user-data' ? 'selected' : '' ?>"
        title="I miei dati"
    >
        <i class="mdi dark mdi-account mr-3"></i>
        <span class="flex-grow-1 text-truncate">I miei dati</span>
        <i class="mdi dark mdi-chevron-right ml-3"></i>
    </a>
    <a id="user-data-tab" href="/account/addresses"
        class="account-tab req-norole <?php echo $request == '/account/addresses' ? 'selected' : '' ?>"
        title="Indirizzi"
    >
        <i class="mdi dark mdi-map-marker mr-3"></i>
        <span class="flex-grow-1 text-truncate">Indirizzi</span>
        <i class="mdi dark mdi-chevron-right ml-3"></i>
    </a>
    <a id="weekly-delivery-preferences-tab" href="/account/subscription"
        class="account-tab req-norole <?php echo $request == '/account/subscription' ? 'selected' : '' ?>"
        title="Cassette"
    >
        <i class="mdi dark mdi-inbox-multiple mr-3"></i>
        <span class="flex-grow-1 text-truncate">Cassette</span>
        <i class="mdi dark mdi-chevron-right ml-3"></i>
    </a>
    <a id="orders-tab" href="/account/orders"
        class="account-tab req-norole <?php echo $request == '/account/orders' ? 'selected' : '' ?>"
        title="Ordini"
    >
        <i class="mdi dark mdi-book-open mr-3"></i>
        <span class="flex-grow-1 text-truncate">Ordini</span>
        <i class="mdi dark mdi-chevron-right ml-3"></i>
    </a>
    <a id="delivery-tab" href="/account/delivery"
        class="account-tab req-delivery <?php echo $request == '/account/delivery' ? 'selected' : '' ?>"
        title="Consegne"
    >
        <i class="mdi dark mdi-truck-delivery mr-3"></i>
        <span class="flex-grow-1 text-truncate">Consegne</span>
        <i class="mdi dark mdi-chevron-right ml-3"></i>
    </a>
    <a id="logout-tab" href="#"
        class="btn-logout account-tab"
        title="Esci"
    >
        <i class="mdi dark mdi-logout-variant mr-3"></i>
        <span class="flex-grow-1 text-truncate">Esci</span>
    </a>
</div>
