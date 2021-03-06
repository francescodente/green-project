<main class="content">

    <section id="products" class="parallax-container header d-flex justify-content-center align-items-center">
        <div class="container text-center">
            <h1 class="text-light">PRODOTTI</h1>
            <br/>
            <h3 class="category-name text-light"></h3>
        </div>
        <div class="parallax shade" data-parallax-image="/images/products.jpg"></div>
    </section>
    <section id="products-content" class="container py-4">
        <div class="row">
            <!-- <div id="filters-col" class="col-12 col-lg-3 d-none">
                <div class="product-filters sticky-top pt-2" style="top: 72px;">
                    <input id="c1" type="checkbox" class="checkbox toggle-all" data-toggle-all="categories"/>
                    <label for="c1">Category</label><br/>
                    <div class="pl-4">
                        <input id="sc1" type="checkbox" class="checkbox" name="categories" value="sc1" checked/>
                        <label for="sc1">Subcategory 1</label><br/>
                        <div class="pl-4">
                            <input id="sc5" type="checkbox" class="checkbox" name="categories" value="sc5" checked/>
                            <label for="sc5">Subcategory 5</label><br/>
                        </div>
                        <input id="sc2" type="checkbox" class="checkbox" name="categories" value="sc2" checked/>
                        <label for="sc2">Subcategory 2</label><br/>
                        <input id="sc3" type="checkbox" class="checkbox" name="categories" value="sc3" checked/>
                        <label for="sc3">Subcategory 3</label><br/>
                        <input id="sc4" type="checkbox" class="checkbox" name="categories" value="sc4" checked/>
                        <label for="sc4">Subcategory 4</label><br/>
                    </div>
                    <br/>
                    <button class="apply-filter btn accent ripple w-100 mb-4">Applica</button>
                </div>
            </div> -->
            <div id="results-col" class="col-12 container">
                <div class="product-list row" data-children-class="col-6 col-md-4 col-lg-3 d-flex">
                    <!-- <div class="col-12 d-flex justify-content-between align-items-center mb-4">
                        <button class="toggle-filters btn transparent ripple ripple-accent">
                            <i class="mdi dark mdi-filter"></i>
                            <span class="text-sec-dark">Filtra</span>
                        </button>
                        <p class="text-dis-dark m-0"><span class="products-count">0</span> risultati</p>
                    </div> -->

                    <div class="col-12">
                        <div class="search-no-results empty-state m-5 d-none">
                            <i class="mdi mdi-feature-search-outline"></i>
                            <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Nessun risultato</h6>
                            <p class="text-center text-dis-dark m-0">
                                La ricerca effettuata non ha restituito risultati.
                            </p>
                        </div>
                    </div>

                    <div class="col-12">
                        <div class="search-error empty-state m-5 d-none">
                            <i class="mdi mdi-emoticon-sad-outline"></i>
                            <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">Oops! Qualcosa ?? andato storto</h6>
                            <p class="text-center text-dis-dark m-0">
                                C'?? stato un errore, ti preghiamo di riprovare.
                            </p>
                        </div>
                    </div>

                </div>

                <div class="divider dark mb-4"></div>

                <div class="d-flex justify-content-center">
                    <ul id="products-pagination" class="pagination">
                        <li><a href="#" class="page-prev btn icon ripple" data-tooltip="tooltip" title="Pagina precedente">
                            <i class="mdi dark mdi-chevron-left"></i>
                        </a></li>
                        <div class="pages d-flex align-items-center"><li class="d-none"><a href="#">1</a></li></div>
                        <li><a href="#" class="page-next btn icon ripple" data-tooltip="tooltip" title="Pagina successiva">
                            <i class="mdi dark mdi-chevron-right"></i>
                        </a></li>
                    </ul>
                </div>
            </div>
        </div>
    </section>

</main>

<div id="crate-added-modal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content" style="width: 360px;">
            <div class="modal-top text-center">
                <i class="modal-top-icon mdi mdi-information-outline"></i>
            </div>
            <div class="modal-body">
                <p class="info-text m-0">
                    Hai aggiunto una cassetta alla tua consegna settimanale!<br/>
                    Passa alla sezione <a href="/account/subscription">Cassette</a> per selezionarne il contenuto.
                </p>
            </div>
            <div class="modal-bottom bg-primary d-flex justify-content-center">
                <button class="btn outline ripple" data-dismiss="modal" style="width: 160px;">Ok</button>
            </div>
        </div>
    </div>
</div>

<script defer src="/views/Products/Products.js"></script>
