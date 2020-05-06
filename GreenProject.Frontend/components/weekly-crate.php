<!-- WEEKLY CRATE ENTRY -->
<div data-template-name="WeeklyCrateTable" data-class="product-group-table table-wrapper table-responsive" class="d-none">
    <table class="table">
        <thead></thead>
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

<!-- ADD PRODUCT MODAL -->
<div data-template-name="WeeklyCrateAddProductModal" data-class="modal fade" class="d-none" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" role="document">
        <div class="modal-content" style="width: 500px;">
            <div class="modal-top">
                <h5 class="m-0">Seleziona un prodotto</h5>
                <button class="modal-close btn icon dark ripple" data-dismiss="modal" data-tooltip="tooltip" title="Chiudi">
                    <i class="mdi dark mdi-close"></i>
                </button>
            </div>
            <div class="modal-body p-0">

                <div class="compatible-products-loader loader text-center my-5">
                    <?php include("loader.php"); ?>
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