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

                <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#reports-1" aria-expanded="true">
                    <h4 class="m-0">Ordini</h4>
                    <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#reports-1" aria-expanded="true" title="Mostra">
                        <i class="mdi dark mdi-chevron-down"></i>
                    </button>
                </div>
                <form id="reports-1" class="collapse show">
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

                <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#reports-2" aria-expanded="true">
                    <h4 class="m-0">Prodotti</h4>
                    <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#reports-2" aria-expanded="true" title="Mostra">
                        <i class="mdi dark mdi-chevron-down"></i>
                    </button>
                </div>
                <div id="reports-2" class="collapse show">
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
                </div>

                <div class="divider dark my-4"></div>

                <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#reports-3" aria-expanded="true">
                    <h4 class="m-0">Ordini fornitore</h4>
                    <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#reports-3" aria-expanded="true" title="Mostra">
                        <i class="mdi dark mdi-chevron-down"></i>
                    </button>
                </div>
                <div id="reports-3" class="collapse show">
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
                </div>

                <div class="divider dark my-4"></div>

                <div class="area-collapse d-flex justify-content-between align-items-center" data-toggle="collapse" data-target="#reports-4" aria-expanded="true">
                    <h4 class="m-0">Entrate</h4>
                    <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#reports-4" aria-expanded="true" title="Mostra">
                        <i class="mdi dark mdi-chevron-down"></i>
                    </button>
                </div>
                <div id="reports-4" class="collapse show">
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
                </div>

            </div>
        </div>

    </section>
</main>

<script defer src="/views/management/Reports/Reports.js"></script>
