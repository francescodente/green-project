<main class="content req-norole">

    <section id="account" class="parallax-container header d-flex justify-content-center align-items-center">
        <div class="container text-center">
            <h1 class="text-light">ACCOUNT</h1>
            <br/>
            <h3 class="text-light">Consegna settimanale</h3>
        </div>
        <div class="parallax shade" data-parallax-image="/images/account.jpg"></div>
    </section>
    <section id="account-content" class="container py-4">

        <div class="row">

            <div id="account-tabs-col" class="d-none d-lg-block col-lg-3">
                <?php include("components/includable/AccountTabs.php"); ?>
            </div>

            <div class="weekly-delivery-not-subscribed col-12 col-lg-9 d-none">
                <div class="empty-state m-5">
                    <img src="/images/empty.png" alt="Utente non abbonato"/>
                    <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Non sei abbonato al nostro servizio di consegna settimanale.</h6>
                    <p class="text-center text-dis-dark m-0">Visualizza le nostre <a href="/products?Categories=1">cassette</a> e scegli quelle che fanno per te!<br/>Dopo averne selezionata almeno una, torna a questa pagina per decidere quali prodotti inserirvi.</p>
                </div>
            </div>

            <div id="account-content-col" class="user-weekly-delivery col-12 col-lg-9">

                <div id="subscribed-alert" class="alert alert-accent mb-3" role="alert">
                    <p class="summary-preferences text-dis-dark m-0">
                        La prossima consegna include <span class="crate-count"></span><span class="alert-and font-weight-normal d-none"> e </span><span class="product-count"></span>, per un totale di <span class="total"></span>.<br/>Sarà effettuata in data <span class="delivery-date"></span> all'indirizzo <span class="delivery-address"></span> con modalità di pagamento <span class="payment-method">alla consegna</span>.<br/>Ti ricordiamo che è possibile modificare le preferenze del tuo ordine settimanale solo fino a <span>24 ore</span> prima del giorno di consegna prestabilito.
                    </p>
                </div>

                <div id="locally-subscribed-alert" class="alert alert-accent mb-3" role="alert">
                    <p class="summary-preferences text-dis-dark m-0">
                        Scegli i prodotti da includere nel tuo abbonamento settimanale!<br/>
                        Quando hai finito, seleziona modalità di pagamento e indirizzo di consegna, quindi abbonati cliccando sull'apposito tasto a fondo pagina.
                    </p>
                </div>

                <h4 class="mb-2">Cassette</h4>
                <p class="text-sec-dark mb-4">
                    Di seguito sono riportate le cassette alle quali sei abbonato.<br/>Riceverai questi prodotti ogni settimana a casa tua!
                </p>

                <div class="weekly-crates">
                    <div class="no-weekly-crates product-group-table products table-wrapper table-responsive" style="display: none;">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td colspan="4" class="p-0">
                                        <a href="/products?Categories=1" class="btn add-product ripple">
                                            <div class="add-product-icon mr-3">
                                                <i class="mdi dark mdi-plus"></i>
                                            </div>
                                            <span class="text-sec-dark">Aggiungi una cassetta</span>
                                        </a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

                <h4 class="mt-4 bb-2">Altri prodotti</h4>
                <p class="text-sec-dark mb-4">
                    Solo per la prossima consegna, riceverai i seguenti prodotti in aggiunta alle cassette a cui sei abbonato.
                </p>
                <div class="product-group-table products table-wrapper table-responsive">
                    <table class="weekly-extras table">
                        <tbody>
                            <tr>
                                <td colspan="4" class="p-0">
                                    <button class="btn add-product ripple" data-toggle="modal" data-target="#modal-weekly-product-add">
                                        <div class="add-product-icon mr-3">
                                            <i class="mdi dark mdi-plus"></i>
                                        </div>
                                        <span class="text-sec-dark">Aggiungi un prodotto</span>
                                    </button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <h4 class="my-4">Riepilogo</h4>

                <div class="summary-products table-wrapper table-responsive">
                    <table class="table">
                        <tbody>
                            <tr class="text-sec-dark">
                                <td>
                                    SUBTOTALE<br/>
                                    IVA<br/>
                                    SPEDIZIONE
                                </td>
                                <td class="nowrap text-right">
                                    <span class="subtotal"></span><br/>
                                    <span class="iva"></span><br/>
                                    <span class="shipping"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>TOTALE</td>
                                <td class="nowrap"><span class="total"></span></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="divider dark mt-5 mb-4"></div>

                <?php include("components/includable/OrderPreferences/OrderPreferences.php"); ?>

                <div class="divider dark my-4"></div>

                <!-- SUBSCRIPTION OPTIONS -->
                <div id="subscription-options">
                    <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#weekly-order-skip" aria-expanded="false">
                        <h4 class="m-0">Opzioni abbonamento</h4>
                        <button type="button" class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#weekly-order-skip" aria-expanded="false" data-tooltip="tooltip" title="Mostra">
                            <i class="mdi dark mdi-chevron-down"></i>
                        </button>
                    </div>
                    <div id="weekly-order-skip" class="collapse">
                        <div class="pt-4"></div>

                        <h5>Salta una consegna</h5>
                        <p class="text-sec-dark mb-2">
                            Sei in vacanza? Nessun problema! Puoi saltare la prossima consegna cliccando il tasto sottostante.
                        </p>
                        <button class="btn accent ripple mb-4" data-toggle="modal" data-target="#modal-skip-delivery">Salta una consegna</button>

                        <h5>Cancella abbonamento</h5>
                        <p class="text-sec-dark mb-2">
                            Se vuoi annullare la prossima consegna e disdire l'abbonamento settimanale clicca il tasto sottostante.<br/> Speriamo di rivederti presto!
                        </p>
                        <button class="btn accent ripple" data-toggle="modal" data-target="#modal-delete-subscription">Cancella abbonamento</button>

                    </div>
                </div>

                <div class="text-center">
                    <button class="confirm-subscription btn accent ripple px-5">Abbonati</button>
                </div>

            </div>

        </div>
    </section>

</main>

<div id="modal-skip-delivery" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-help-circle-outline"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Sei sicuro di voler saltare la consegna settimanale prevista per il giorno <span class="delivery-date font-weight-bold">1 Gen 2020</span>?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button class="skip-delivery btn accent ripple flex-grow-1" style="width: 100px;">Conferma</button>
            </div>
        </div>
    </div>
</div>

<div id="modal-delete-subscription" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-help-circle-outline"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Sei sicuro di voler disdire il tuo abbonamento?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="width: 100px;">Annulla</button>
                <button class="delete-subscription btn accent ripple flex-grow-1" style="width: 100px;">Conferma</button>
            </div>
        </div>
    </div>
</div>

<div id="modal-weekly-product-add" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" role="document">
        <div class="modal-content" style="width: 500px; min-height: 500px;">
            <div class="modal-top">
                <h5 class="m-0">Seleziona un prodotto</h5>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi">
                    <i class="mdi dark mdi-close"></i>
                </button>
            </div>
            <div class="modal-body p-0">

                <div id="starred-products-loader" class="loader text-center my-5">
                    <?php include("components/includable/Loader.php"); ?>
                </div>

                <div class="starred-products-no-results empty-state my-5 d-none">
                    <img src="/images/empty.png" alt="Nessun prodotto"/>
                    <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun prodotto</h6>
                    <p class="text-center text-dis-dark m-0">
                        Sembra che tutti i prodotti in elenco siano già nel tuo ordine 😮
                    </p>
                </div>

                <div class="starred-products product-group-table products table-wrapper table-responsive">
                    <table class="table">
                        <tbody></tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

<div id="missing-crate-modal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-information-outline"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">Inserisci almeno una cassetta per procedere con la creazione dell'ordine.</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple" data-dismiss="modal" style="width: 160px;">Ok</button>
            </div>
        </div>
    </div>
</div>

<div id="non-full-crate-modal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-information-outline"></i>
            </div>
            <div class="modal-body">
                <p class="m-0">C'è ancora spazio in alcune delle cassette nel tuo ordine.<br/>Vuoi procedere comunque?</p>
            </div>
            <div class="modal-bottom bg-primary d-flex">
                <button class="btn outline ripple flex-grow-1" data-dismiss="modal" style="flex-basis: 100px;">No</button>
                <button class="confirm-subscription skip-full-crate-check btn accent ripple flex-grow-1" style="flex-basis: 100px;">Sì</button>
            </div>
        </div>
    </div>
</div>

<div id="subscription-successful-modal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-bookmark-check"></i>
            </div>
            <div class="modal-body">
                <h4>Congratulazioni, ti sei abbonato al nostro servizio di consegna settimanale!</h4>
                <p class="mb-2">
                    Pui visitare questa pagina ogni settimana per modificare il contenuto del tuo ordine.
                </p>
                <p class="m-0">Grazie per aver scelto Green Project!</p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <a href="/account/subscription" class="btn outline ripple" style="width: 160px;">Chiudi</a>
            </div>
        </div>
    </div>
</div>

<?php include("components/includable/NewAddressModal/NewAddressModal.php"); ?>

<script defer src="/js/collapse-state-keeper.js"></script>
<script defer src="/views/account/Subscription/Subscription.js"></script>
