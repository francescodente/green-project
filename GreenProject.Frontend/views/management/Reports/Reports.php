<main class="content req-admin">

    <section id="management" class="parallax-container header d-flex justify-content-center align-items-center">
        <div class="container text-center">
            <h1 class="text-light">GESTIONE</h1>
            <br/>
            <h3 class="text-light">File di riepilogo</h3>
        </div>
        <div class="parallax shade" data-parallax-image="/images/account.jpg"></div>
    </section>
    <section id="management-content" class="container py-4">
        <div id="management-reports" class="row">

            <div id="management-tabs-col" class="d-none d-lg-block col-lg-3">
                <?php include("components/includable/ManagementTabs.php"); ?>
            </div>
            <div id="management-content-col" class="col-12 col-lg-9">

                <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#report-orders" aria-expanded="true">
                    <h4 class="m-0">Ordini</h4>
                    <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#report-orders" aria-expanded="true" title="Nascondi">
                        <i class="mdi dark mdi-chevron-down"></i>
                    </button>
                </div>
                <form id="report-orders" class="report-form collapse show">
                    <div class="pt-3"></div>
                    <h6>Data</h6>
                    <div class="text-input mb-3">
                        <input type="text" name="date" maxlength="10" required/>
                        <label></label>
                        <span>gg/mm/aaaa</span>
                        <span class="error">Data non valida</span>
                    </div>
                    <div class="text-right">
                        <button type="submit" class="btn accent ripple">
                            <span class="text-light">Genera report</span>
                            <i class="mdi mdi-download"></i>
                        </button>
                    </div>
                </form>

                <div class="divider dark my-4"></div>

                <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#report-products" aria-expanded="true">
                    <h4 class="m-0">Prodotti</h4>
                    <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#report-products" aria-expanded="true" title="Nascondi">
                        <i class="mdi dark mdi-chevron-down"></i>
                    </button>
                </div>
                <form id="report-products" class="report-form collapse show">
                    <div class="pt-3"></div>
                    <h6>Data</h6>
                    <div class="text-input mb-3">
                        <input type="text" name="date" maxlength="10" required/>
                        <label></label>
                        <span>gg/mm/aaaa</span>
                        <span class="error">Data non valida</span>
                    </div>
                    <div class="text-right">
                        <button type="submit" class="btn accent ripple">
                            <span class="text-light">Genera report</span>
                            <i class="mdi mdi-download"></i>
                        </button>
                    </div>
                </form>

                <div class="divider dark my-4"></div>

                <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#report-supplier-order" aria-expanded="true">
                    <h4 class="m-0">Ordini fornitore</h4>
                    <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#report-supplier-order" aria-expanded="true" title="Nascondi">
                        <i class="mdi dark mdi-chevron-down"></i>
                    </button>
                </div>
                <form id="report-supplier-order" class="report-form collapse show">
                    <div class="pt-3"></div>


                    <div class="container p-0">
                        <div class="row no-gutters">
                            <div class="col-12 col-lg-6 pr-lg-2">
                                <h6>Data</h6>
                                <div class="text-input mb-3">
                                    <input type="text" name="date" maxlength="10" required/>
                                    <label></label>
                                    <span>gg/mm/aaaa</span>
                                    <span class="error">Data non valida</span>
                                </div>
                            </div>
                            <div class="col-12 col-lg-6 pl-lg-2">
                                <h6>Categorie</h6>
                                <div id="select-categories" class="dropdown select mb-3">
                                    <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                                        <input type="text" placeholder=" " readonly/>
                                    </div>
                                    <div class="dropdown-menu w-100" aria-labelledby="select-toggle">
                                        <input id="select-categories-toggle" type="checkbox" class="checkbox toggle-all" data-toggle-all="select-categories"/>
                                        <label for="select-categories-toggle" class="toggle-all">Tutte</label>
                                    </div>
                                    <div class="select-item-template d-none">
                                        <input id="select-categories-tmp" type="checkbox" class="checkbox" name="select-categories"/>
                                        <label for="select-categories-tmp"></label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="text-right">
                        <button type="submit" class="btn accent ripple">
                            <span class="text-light">Genera report</span>
                            <i class="mdi mdi-download"></i>
                        </button>
                    </div>
                </form>

                <div class="divider dark my-4"></div>

                <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#report-revenue" aria-expanded="true">
                    <h4 class="m-0">Entrate</h4>
                    <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#report-revenue" aria-expanded="true" title="Nascondi">
                        <i class="mdi dark mdi-chevron-down"></i>
                    </button>
                </div>
                <form id="report-revenue" class="report-form collapse show">
                    <div class="pt-3"></div>
                    <h6>Mese</h6>
                    <div class="text-input mb-3">
                        <input type="text" name="month" maxlength="10" required/>
                        <label></label>
                        <span>mm/aaaa</span>
                        <span class="error">Data non valida</span>
                    </div>
                    <div class="text-right">
                        <button type="submit" class="btn accent ripple">
                            <span class="text-light">Genera report</span>
                            <i class="mdi mdi-download"></i>
                        </button>
                    </div>
                </form>

            </div>
        </div>

    </section>
</main>

<script defer src="/views/management/Reports/Reports.js"></script>
