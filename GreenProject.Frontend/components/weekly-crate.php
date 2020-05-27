<!-- WEEKLY CRATE ENTRY -->
<div data-template-name="WeeklyCrateTable" data-class="product-group-table table-wrapper table-responsive" class="d-none">
    <div class="d-inline-flex flex-column" style="min-width: 100%;">
        <table class="table">
            <thead></thead>
        </table>
        <div id="collapse-ODID" class="collapse">
            <table class="table">
                <tbody class="crate-products">
                    <tr>
                        <td colspan="4" class="p-0">
                            <button class="btn add-product ripple">
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
    </div>
</div>

<!-- ADD PRODUCT MODAL -->
<div data-template-name="WeeklyCrateAddProductModal" data-class="modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" role="document">
        <div class="modal-content" style="width: 500px; min-height: 500px;">
            <div class="modal-top">
                <h5 class="m-0">Seleziona un prodotto</h5>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi">
                    <i class="mdi dark mdi-close"></i>
                </button>
            </div>
            <div class="modal-body p-0">

                <div class="compatible-products-loader loader text-center my-5">
                    <?php include("views/loader.php"); ?>
                </div>

                <div class="compatible-products-no-results empty-state my-5 d-none">
                    <img src="/images/empty.png" alt="Nessun prodotto"/>
                    <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun prodotto</h6>
                    <p class="text-center text-dis-dark m-0">
                        Sembra che tutti i prodotti in elenco siano già nel tuo ordine 😮
                    </p>
                </div>

                <div class="compatible-products product-group-table table-wrapper table-responsive">
                    <table class="table">
                        <tbody></tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>