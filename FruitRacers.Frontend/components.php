<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Framework - Components</title>
</head>
<body>

    <?php include("menu.php"); ?>

    <div class="container-fluid">
        <div class="row">
            <div class="col-12 col-md-6 bg-primary py-4">

                <!------------------------->
                <!--   BTN TRANSPARENT   -->
                <!------------------------->
                <h1 class="mb-3">btn transparent</h1>

                <!-- Text only -->
                <a href="#" class="btn transparent ripple">Button</a>
                <button class="btn transparent ripple text-accent ripple-accent">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn transparent ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <span class="text-sec-dark">Button</span>
                </a>
                <button class="btn transparent ripple ripple-accent">
                    <i class="mdi accent mdi-content-save"></i>
                    <span class="text-accent">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn transparent ripple" disabled>
                    <i class="mdi dark mdi-content-save"></i>
                    <span class="text-sec-dark">Disabled</span>
                </button>

                <!--------------------->
                <!--   BTN OUTLINE   -->
                <!--------------------->
                <h1 class="mt-5 mb-3">btn outline</h1>

                <!-- Text only -->
                <a href="#" class="btn outline ripple">Button</a>
                <button class="btn outline ripple text-accent ripple-accent">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn outline ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <span class="text-sec-dark">Button</span>
                </a>
                <button class="btn outline ripple ripple-accent">
                    <i class="mdi accent mdi-content-save"></i>
                    <span class="text-accent">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn outline ripple" disabled>
                    <i class="mdi dark mdi-content-save"></i>
                    <span class="text-sec-dark">Disabled</span>
                </button>

                <!-------------------->
                <!--   BTN ACCENT   -->
                <!-------------------->
                <h1 class="mt-5 mb-3">btn accent</h1>

                <!-- Text only -->
                <a href="#" class="btn accent ripple">Button</a>
                <button class="btn accent ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn accent ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </a>
                <button class="btn accent ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn accent ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Disabled</span>
                </button>

                <!------------------------------->
                <!--   BTN ROUND TRANSPARENT   -->
                <!------------------------------->
                <h1 class="mt-5 mb-3">btn round transparent</h1>

                <!-- Text only -->
                <a href="#" class="btn round transparent ripple">Button</a>
                <button class="btn round transparent ripple text-accent ripple-accent">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round transparent ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <span class="text-sec-dark">Button</span>
                </a>
                <button class="btn round transparent ripple ripple-accent">
                    <i class="mdi accent mdi-content-save"></i>
                    <span class="text-accent">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn round transparent ripple" disabled>
                    <i class="mdi dark mdi-content-save"></i>
                    <span class="text-sec-dark">Disabled</span>
                </button>

                <!--------------------------->
                <!--   BTN ROUND OUTLINE   -->
                <!--------------------------->
                <h1 class="mt-5 mb-3">btn round outline</h1>

                <!-- Text only -->
                <a href="#" class="btn round outline ripple">Button</a>
                <button class="btn round outline ripple text-accent ripple-accent">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round outline ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <span class="text-sec-dark">Button</span>
                </a>
                <button class="btn round outline ripple ripple-accent">
                    <i class="mdi accent mdi-content-save"></i>
                    <span class="text-accent">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn round outline ripple" disabled>
                    <i class="mdi dark mdi-content-save"></i>
                    <span class="text-sec-dark">Disabled</span>
                </button>

                <!-------------------------->
                <!--   BTN ROUND ACCENT   -->
                <!-------------------------->
                <h1 class="mt-5 mb-3">btn round accent</h1>

                <!-- Text only -->
                <a href="#" class="btn round accent ripple">Button</a>
                <button class="btn round accent ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round accent ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </a>
                <button class="btn round accent ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn round accent ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Disabled</span>
                </button>

                <!------------------>
                <!--   BTN ICON   -->
                <!------------------>
                <h1 class="mt-5 mb-3">btn icon</h1>

                <a href="#" class="btn icon ripple"><i class="mdi dark mdi-content-save"></i></a>
                <button class="btn icon ripple"><i class="mdi dark mdi-content-save"></i></button>
                <button class="btn icon ripple" disabled><i class="mdi dark mdi-content-save"></i></button>

                <!----------------->
                <!--   BTN FAB   -->
                <!----------------->
                <h1 class="mt-5 mb-3">btn fab</h1>

                <a href="#" class="btn fab ripple"><i class="mdi light mdi-content-save"></i></a>
                <button class="btn fab ripple"><i class="mdi light mdi-content-save"></i></button>
                <button class="btn fab ripple" disabled><i class="mdi light mdi-content-save"></i></button>

                <!-------------------->
                <!--   FILE INPUT   -->
                <!-------------------->
                <h1 class="mt-5 mb-3">file input</h1>

                <label class="file-input ripple">
                    <input type="file"/>
                    <i class="mdi mdi-upload"></i>
                    <span>File input</span>
                    <span class="count d-none"><i class="mdi mdi-check"></i></span>
                </label>

                <label class="file-input ripple">
                    <input type="file" multiple/>
                    <i class="mdi dark mdi-upload"></i>
                    <span>Multiple file input</span>
                    <span class="count d-none">1</span>
                </label>

                <label class="file-input ripple disabled">
                    <input type="file" disabled/>
                    <i class="mdi mdi-upload"></i>
                    <span>Disabled file input</span>
                    <span class="count d-none"><i class="mdi mdi-check"></i></span>
                </label>

                <!--------------->
                <!--   RADIO   -->
                <!--------------->
                <h1 class="mt-5 mb-3">radio</h1>

                <h6>Title</h6>
                <input id="r1" type="radio" class="radio" name="radio-example" value="1" checked/>
                <label for="r1">First option</label><br>
                <input id="r2" type="radio" class="radio" name="radio-example" value="2"/>
                <label for="r2">Second option</label><br>
                <input id="r3" type="radio" class="radio" name="radio-example" value="3" disabled/>
                <label for="r3">Third option (disabled)</label>

                <!--------------->
                <!--   CHECK   -->
                <!--------------->
                <h1 class="mt-5 mb-3">check</h1>

                <h6>Title</h6>
                <input id="c-toggle" type="checkbox" class="checkbox toggle-all" data-toggle-all="checkbox-example"/>
                <label for="c-toggle">All</label><br>
                <input id="c1" type="checkbox" class="checkbox" name="checkbox-example" value="1" checked/>
                <label for="c1">First option</label><br>
                <input id="c2" type="checkbox" class="checkbox" name="checkbox-example" value="2"/>
                <label for="c2">Second option</label><br>
                <input id="c3" type="checkbox" class="checkbox" name="checkbox-example-dis" value="3" disabled/>
                <label for="c3">Third option (disabled)</label>

                <!---------------->
                <!--   SWITCH   -->
                <!---------------->
                <h1 class="mt-5 mb-3">switch</h1>

                <input id="s1" type="checkbox" class="switch" name="switch-example" checked>
                <label for="s1">Switch <span class="on">On</span><span class="off">Off</span></label><br>
                <input id="s2" type="checkbox" class="switch" name="switch-example" disabled>
                <label for="s2">Switch <span class="on">On</span><span class="off">Off</span> (disabled)</label>

                <!---------------->
                <!--   SELECT   -->
                <!---------------->
                <h1 class="mt-5 mb-3">select</h1>

                <div class="dropdown select" style="width: 300px;">
                    <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                        <input id="select-toggle" type="text" placeholder=" " readonly/>
                        <label for="select-toggle">Select</label>
                    </div>
                    <div class="dropdown-menu" aria-labelledby="select-toggle">
                        <input id="sel1" type="radio" class="radio" name="select-example" value="1"/>
                        <label for="sel1">First option</label>
                        <input id="sel2" type="radio" class="radio" name="select-example" value="2"/>
                        <label for="sel2">Second option</label>
                        <input id="sel3" type="radio" class="radio" name="select-example" value="3"/>
                        <label for="sel3">Third option</label>
                        <input id="sel4" type="radio" class="radio" name="select-example" value="4"/>
                        <label for="sel4">Fourth option</label>
                        <input id="sel5" type="radio" class="radio" name="select-example" value="5"/>
                        <label for="sel5">Fifth option</label>
                    </div>
                </div>

                <div class="dropdown select" style="width: 300px;">
                    <div class="text-input" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                        <input id="multi-select-toggle" type="text" placeholder=" " readonly/>
                        <label for="multi-select-toggle">Multiple select</label>
                    </div>
                    <div class="dropdown-menu" aria-labelledby="multi-select-toggle">
                        <input id="msel1" type="checkbox" class="checkbox" name="multi-select-example" value="1"/>
                        <label for="msel1">First option</label>
                        <input id="msel2" type="checkbox" class="checkbox" name="multi-select-example" value="2"/>
                        <label for="msel2">Second option</label>
                        <input id="msel3" type="checkbox" class="checkbox" name="multi-select-example" value="3"/>
                        <label for="msel3">Third option</label>
                        <input id="msel4" type="checkbox" class="checkbox" name="multi-select-example" value="4"/>
                        <label for="msel4">Fourth option</label>
                        <input id="msel5" type="checkbox" class="checkbox" name="multi-select-example" value="5"/>
                        <label for="msel5">Fifth option</label>
                    </div>
                </div>

                <div class="dropdown select" style="width: 300px;">
                    <div class="text-input disabled" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="trailing-icon arrow mdi dark mdi-menu-down"></i>
                        <input id="select-toggle-dis" type="text" placeholder=" " readonly disabled/>
                        <label for="select-toggle-dis">Disabled select</label>
                    </div>
                    <div class="dropdown-menu" aria-labelledby="select-toggle-dis">
                        <input id="dsel1" type="radio" class="radio" name="select-example-dis" value="1" disabled/>
                        <label for="dsel1">First option</label>
                    </div>
                </div>

                <!-------------------->
                <!--   RICH RADIO   -->
                <!-------------------->
                <h1 class="mt-5 mb-3">rich radio</h1>

                <input id="rr1" type="radio" class="rich-radio" name="rich-radio-example" value="1" checked/>
                <label for="rr1" class="container-fluid px-0 py-2">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-8">
                                Column for option 1
                            </div>
                            <div class="col-4">
                                Another column
                            </div>
                        </div>
                    </div>
                </label>
                <input id="rr2" type="radio" class="rich-radio" name="rich-radio-example" value="2"/>
                <label for="rr2" class="container-fluid px-0 py-2">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-8">
                                Column for option 2
                            </div>
                            <div class="col-4">
                                Another column
                            </div>
                        </div>
                    </div>
                </label>
                <input id="rr3" type="radio" class="rich-radio" name="rich-radio-example" value="3" disabled/>
                <label for="rr3" class="container-fluid px-0 py-2">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-8">
                                Column for option 3
                            </div>
                            <div class="col-4">
                                Another column
                            </div>
                        </div>
                    </div>
                </label>

                <!--------------------->
                <!--   RICH SWITCH   -->
                <!--------------------->
                <h1 class="mt-5 mb-3">rich switch</h1>

                <div class="rich-switch-container">
                    <input id="rs1" type="radio" class="rich-switch" name="rich-switch-example" value="1" checked/>
                    <label for="rs1" class="ripple">First option</label><br>
                    <input id="rs2" type="radio" class="rich-switch" name="rich-switch-example" value="2"/>
                    <label for="rs2" class="ripple">Second option</label><br>
                    <input id="rs3" type="radio" class="rich-switch" name="rich-switch-example" value="3"/>
                    <label for="rs3" class="ripple">Third option</label><br>
                </div>

                <!---------------------->
                <!--   REVIEW STARS   -->
                <!---------------------->
                <h1 class="mt-5 mb-3">review stars</h1>

                <div class="review-stars">
                    <input type ="radio" id="star5" name="rating" value="5"/>
                    <label for="star5" title="5 stelle" class="ripple">
                        <i class="unchecked mdi dark mdi-star-outline"></i>
                        <i class="checked mdi dark mdi-star"></i>
                    </label>
                    <input type ="radio" id="star4" name="rating" value="4"/>
                    <label for="star4" title="4 stelle" class="ripple">
                        <i class="unchecked mdi dark mdi-star-outline"></i>
                        <i class="checked mdi dark mdi-star"></i>
                    </label>
                    <input type ="radio" id="star3" name="rating" value="3"/>
                    <label for="star3" title="3 stelle" class="ripple">
                        <i class="unchecked mdi dark mdi-star-outline"></i>
                        <i class="checked mdi dark mdi-star"></i>
                    </label>
                    <input type ="radio" id="star2" name="rating" value="2"/>
                    <label for="star2" title="2 stelle" class="ripple">
                        <i class="unchecked mdi dark mdi-star-outline"></i>
                        <i class="checked mdi dark mdi-star"></i>
                    </label>
                    <input type ="radio" id="star1" name="rating" value="1" checked/>
                    <label for="star1" title="1 stella" class="ripple">
                        <i class="unchecked mdi dark mdi-star-outline"></i>
                        <i class="checked mdi dark mdi-star"></i>
                    </label>
                </div>

                <!----------------->
                <!--   DIVIDER   -->
                <!----------------->
                <h1 class="mt-5 mb-3">divider</h1>

                <div class="divider dark"></div>

                <!-------------------->
                <!--   TEXT FIELD   -->
                <!-------------------->
                <h1 class="mt-5 mb-3">text field</h1>

                <div style="width: 300px;">

                    <div class="text-input">
                        <input id="email" type="email" value="prova" placeholder=" "/>
                        <label for="email">Email</label>
                    </div>

                    <div class="text-input">
                        <i class="leading-icon mdi dark mdi-key"></i>
                        <i class="trailing-icon mdi dark mdi-eye"></i>
                        <input id="password" type="password" placeholder=" "/>
                        <label for="password">Password</label>
                    </div>

                    <div class="text-input">
                        <input id="text1" type="text" placeholder=" " maxlength="20"/>
                        <label for="text1">Text</label>
                        <span>Hint message</span>
                        <span class="counter">0 / 20</span>
                    </div>

                    <div class="text-input">
                        <input id="text2" type="text" class="valid" value="value" placeholder=" "/>
                        <label for="text2">Valid</label>
                    </div>

                    <div class="text-input">
                        <input id="text3" type="text" class="error" value="value" placeholder=" "/>
                        <label for="text3">Error</label>
                        <span>Error message</span>
                    </div>

                    <div class="text-input">
                        <input id="number" type="number" name="number" min="-10" max="10" step="2" placeholder=" ">
                        <label for="number">Number</label>
                        <button class="inc btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-up"></i></button>
                        <button class="dec btn icon ripple" tabindex="-1"><i class="mdi dark mdi-menu-down"></i></button>
                    </div>

                    <div class="text-input">
                        <i class="leading-icon mdi small dark mdi-currency-eur"></i>
                        <input id="currency" type="number" data-type="currency" name="currency" min="0" step="0.01" placeholder=" ">
                        <label for="currency">Currency</label>
                    </div>

                    <div class="text-input">
                        <input id="text4" type="text"  placeholder=" " disabled/>
                        <label for="text4">Disabled</label>
                    </div>


                </div>

                <!------------------->
                <!--   TEXT AREA   -->
                <!------------------->
                <h1 class="mt-5 mb-3">text area</h1>

                <div style="width: 300px;">

                    <div class="text-area">
                        <textarea id="textarea" placeholder=" "></textarea>
                        <label for="textarea">Text area</label>
                    </div>

                    <div class="text-area">
                        <textarea id="textarea" placeholder=" " disabled></textarea>
                        <label for="textarea">Disabled Text area</label>
                    </div>

                </div>

                <!-------------------->
                <!--   PAGINATION   -->
                <!-------------------->
                <h1 class="mt-5 mb-3">pagination</h1>

                <ul class="pagination">
                    <li><a href="#" class="btn icon ripple disabled" title="Prima pagina"><i class="mdi dark mdi-page-first"></i></a></li>
                    <li><a href="#" class="btn icon ripple disabled" title="Pagina precedente"><i class="mdi dark mdi-chevron-left"></i></a></li>
                    <li><a href="#" class="selected">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#" class="btn icon ripple" title="Pagina successiva"><i class="mdi dark mdi-chevron-right"></i></a></li>
                    <li><a href="#" class="btn icon ripple" title="Ultima pagina"><i class="mdi dark mdi-page-last"></i></a></li>
                </ul>

                <!-------------------->
                <!--   BREADCRUMB   -->
                <!-------------------->
                <h1 class="mt-5 mb-3">breadcrumb</h1>

                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Library</li>
                </ol>

                <!-------------------->
                <!--   SEARCH BAR   -->
                <!-------------------->
                <h1 class="mt-5 mb-3">search bar</h1>

                <div class="search-bar" style="width: 360px;">
                    <button class="search btn icon ripple" title="Cerca"><i class="mdi dark mdi-magnify"></i></button>
                    <input type="text" placeholder="Cerca..."/>
                    <button class="clear btn icon ripple" title="Cancella"><i class="mdi dark mdi-close"></i></button>
                </div>

                <!------------------>
                <!--   COLLAPSE   -->
                <!------------------>
                <h1 class="mt-5 mb-3">collapse</h1>

                <button class="btn-collapse btn icon ripple" data-toggle="collapse" data-target="#collapse-example" aria-expanded="false" title="Mostra">
                    <i class="mdi dark mdi-chevron-down"></i>
                </button>
                <div id="collapse-example" class="collapse">
                    <p class="m-0">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </p>
                </div>

                <!------------------>
                <!--   DROPDOWN   -->
                <!------------------>
                <h1 class="mt-5 mb-3">dropdown</h1>

                <div class="dropdown">
                    <button class="btn outline ripple" id="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="text-sec-dark">Dropdown</span>
                        <i class="arrow mdi dark mdi-menu-down"></i>
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdown-toggle">
                        <a href="#" class="dropdown-item">Action</a>
                        <a href="#" class="dropdown-item">Another action</a>
                        <a href="#" class="dropdown-item">Something else here</a>
                        <a href="#" class="dropdown-item">
                            <i class="mdi dark mdi-content-save"></i>
                            <span>Icon to the left</span>
                        </a>
                        <a href="#" class="dropdown-item">
                            <span>Icon to the right</span>
                            <i class="mdi dark mdi-content-save"></i>
                        </a>
                    </div>
                </div>
                <div class="dropright">
                    <button class="btn outline" id="dropdown-toggle2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="text-sec-dark">Dropright</span>
                        <i class="arrow mdi dark mdi-menu-right"></i>
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdown-toggle2">
                        <h6 class="h-variant text-sec-dark">Header</h6>
                        <a href="#" class="dropdown-item">Action</a>
                        <a href="#" class="dropdown-item">Another action</a>
                        <div class="divider dark"></div>
                        <h6 class="h-variant text-sec-dark">Another header</h6>
                        <a href="#" class="dropdown-item">Something else here</a>
                    </div>
                </div>
                <div class="dropleft">
                    <button class="btn outline" id="dropdown-toggle3" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="arrow mdi dark mdi-menu-left"></i>
                        <span class="text-sec-dark">Dropleft</span>
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdown-toggle3">
                        <a href="#" class="dropdown-item disabled" tab-index="-1" aria-disabled="true">Disabled action</a>
                        <a href="#" class="dropdown-item disabled" tab-index="-1" aria-disabled="true">
                            <i class="mdi dark mdi-content-save"></i>
                            <span>Disabled action with icon</span>
                        </a>
                    </div>
                </div>
                <div class="dropup">
                    <button class="btn outline" id="dropdown-toggle4" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="text-sec-dark">Dropup</span>
                        <i class="arrow mdi dark mdi-menu-up"></i>
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdown-toggle4">
                        <a href="#" class="dropdown-item">Action</a>
                        <a href="#" class="dropdown-item active">Another action</a>
                        <a href="#" class="dropdown-item">Something else here</a>
                    </div>
                </div>

                <!----------------->
                <!--   LOADING   -->
                <!----------------->
                <h1 class="mt-5 mb-3">loading</h1>

                <div class="loader">
                    <svg version="1.1" id="loader-1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" width="40px" height="40px" viewBox="0 0 50 50" style="enable-background:new 0 0 50 50;" xml:space="preserve">
                        <path fill="#000" d="M43.935,25.145c0-10.318-8.364-18.683-18.683-18.683c-10.318,0-18.683,8.365-18.683,18.683h4.068c0-8.071,6.543-14.615,14.615-14.615c8.072,0,14.615,6.543,14.615,14.615H43.935z">
                        <animateTransform attributeType="xml"
                                          attributeName="transform"
                                          type="rotate"
                                          from="0 25 25"
                                          to="360 25 25"
                                          dur="1s"
                                          repeatCount="indefinite"/>
                        </path>
                    </svg>
                </div>

                <!--------------------->
                <!--   EMPTY STATE   -->
                <!--------------------->
                <h1 class="mt-5 mb-3">empty-state</h1>

                <div class="empty-state m-5">
                    <!-- <img src="images/empty.png"/> -->
                    <i class="mdi mdi-feature-search-outline"></i>
                    <h6 class="text-center text-sec-dark font-weight-bold mt-3 mb-2">No results</h6>
                    <p class="text-center text-dis-dark m-0">
                        Some quick example text to build on the component and make up the bulk of the component's content.
                    </p>
                </div>

                <!----------------->
                <!--   POPOVER   -->
                <!----------------->
                <h1 class="mt-5 mb-3">popover</h1>

                <button class="btn outline ripple" data-toggle="popover" data-placement="top"
                        title="Popover title" data-content="Popover content here">
                    Top popover
                </button>
                <button class="btn outline ripple" data-toggle="popover" data-placement="bottom"
                        title="Popover title" data-content="Popover content here">
                    Bottom popover
                </button>
                <button class="btn outline ripple" data-toggle="popover" data-placement="left"
                        title="Popover title" data-content="Popover content here">
                    Left popover
                </button>
                <button class="btn outline ripple" data-toggle="popover" data-placement="right"
                        title="Popover title" data-content="Popover content here">
                    Right popover
                </button>

                <!----------------->
                <!--   TOOLTIP   -->
                <!----------------->
                <h1 class="mt-5 mb-3">tooltip</h1>

                <button class="btn outline ripple" data-toggle="tooltip" data-placement="top"
                        title="Tooltip">
                    Top tooltip
                </button>
                <button class="btn outline ripple" data-toggle="tooltip" data-placement="bottom"
                        title="Tooltip">
                    Bottom tooltip
                </button>
                <button class="btn outline ripple" data-toggle="tooltip" data-placement="left"
                        title="Tooltip">
                    Left tooltip
                </button>
                <button class="btn outline ripple" data-toggle="tooltip" data-placement="right"
                        title="Tooltip">
                    Right tooltip
                </button>

                <!-------------->
                <!--   CHIP   -->
                <!-------------->
                <h1 class="mt-5 mb-3">chip</h1>

                <div class="chip-container d-flex flex-wrap">
                    <div class="chip">
                        <span>Chip text</span>
                    </div>
                    <div class="chip">
                        <span>Chip text</span>
                        <button class="btn icon ripple"><i class="mdi dark mdi-close"></i></button>
                    </div>
                    <div class="chip selected">
                        <i class="mdi dark mdi-check"></i>
                        <span>Chip text</span>
                    </div>
                    <button class="chip">
                        <img src="images/chip.jpg"/>
                        <span>Chip text</span>
                    </button>
                    <div class="chip">
                        <i class="mdi dark mdi-account-circle"></i>
                        <span>Chip text</span>
                        <button class="btn icon ripple"><i class="mdi dark mdi-close"></i></button>
                    </div>
                    <a href="#" class="chip">
                        <img src="images/chip.jpg"/>
                        <span>Chip text</span>
                        <button class="btn icon ripple"><i class="mdi dark mdi-close"></i></button>
                    </a>
                </div>

                <!------------------>
                <!--   PROGRESS   -->
                <!------------------>
                <h1 class="mt-5 mb-3">progress</h1>

                <div class="progress mb-3">
                    <div class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <div class="progress mb-3">
                    <div class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <div class="progress mb-3">
                    <div class="progress-bar" role="progressbar" style="width: 50%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <div class="progress mb-3">
                    <div class="progress-bar" role="progressbar" style="width: 75%" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <div class="progress">
                    <div class="progress-bar" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                </div>

                <!---------------->
                <!--   SLIDER   -->
                <!---------------->
                <h1 class="mt-5 mb-3">slider</h1>

                <div class="slider-container">
                    <input id="slider-example" class="slider" type="range" min="1" max="100" value="50"/>
                    <span class="slider-progress"></span>
                    <span class="slider-tooltip">50</span>
                </div>
                <div class="slider-container">
                    <input id="slider-example-dis" class="slider" type="range" min="1" max="100" value="50" disabled/>
                    <span class="slider-progress"></span>
                    <span class="slider-tooltip">50</span>
                </div>

            </div>
            <div class="col-12 col-md-6 bg-dark-primary py-4">

                <!------------------------->
                <!--   BTN TRANSPARENT   -->
                <!------------------------->
                <h1 class="text-light mb-3">btn transparent</h1>

                <!-- Text only -->
                <a href="#" class="btn transparent light ripple">Button</a>
                <button class="btn transparent light ripple text-accent ripple-accent">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn transparent light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </a>
                <button class="btn transparent light ripple ripple-accent">
                    <i class="mdi accent mdi-content-save"></i>
                    <span class="text-accent">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn transparent light ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Disabled</span>
                </button>

                <!--------------------->
                <!--   BTN OUTLINE   -->
                <!--------------------->
                <h1 class="text-light mt-5 mb-3">btn outline</h1>

                <!-- Text only -->
                <a href="#" class="btn outline light ripple">Button</a>
                <button class="btn outline light ripple text-accent ripple-accent">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn outline light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </a>
                <button class="btn outline light ripple ripple-accent">
                    <i class="mdi accent mdi-content-save"></i>
                    <span class="text-accent">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn outline light ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Disabled</span>
                </button>

                <!-------------------->
                <!--   BTN ACCENT   -->
                <!-------------------->
                <h1 class="text-light mt-5 mb-3">btn accent</h1>

                <!-- Text only -->
                <a href="#" class="btn accent dark ripple">Button</a>
                <button class="btn accent light ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn accent dark ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </a>
                <button class="btn accent dark ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn accent dark ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Disabled</span>
                </button>

                <!------------------------------->
                <!--   BTN ROUND TRANSPARENT   -->
                <!------------------------------->
                <h1 class="text-light mt-5 mb-3">btn round transparent</h1>

                <!-- Text only -->
                <a href="#" class="btn round transparent light ripple">Button</a>
                <button class="btn round transparent light ripple text-accent ripple-accent">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round transparent light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </a>
                <button class="btn round transparent light ripple ripple-accent">
                    <i class="mdi accent mdi-content-save"></i>
                    <span class="text-accent">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn round transparent light ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Disabled</span>
                </button>

                <!--------------------------->
                <!--   BTN ROUND OUTLINE   -->
                <!--------------------------->
                <h1 class="text-light mt-5 mb-3">btn round outline</h1>

                <!-- Text only -->
                <a href="#" class="btn round outline light ripple">Button</a>
                <button class="btn round outline light ripple text-accent ripple-accent">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round outline light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </a>
                <button class="btn round outline light ripple ripple-accent">
                    <i class="mdi accent mdi-content-save"></i>
                    <span class="text-accent">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn round outline light ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Disabled</span>
                </button>

                <!-------------------------->
                <!--   BTN ROUND ACCENT   -->
                <!-------------------------->
                <h1 class="text-light mt-5 mb-3">btn round accent</h1>

                <!-- Text only -->
                <a href="#" class="btn round accent dark ripple">Button</a>
                <button class="btn round accent ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round accent dark ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </a>
                <button class="btn round accent dark ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Button</span>
                </button>

                <!-- Disabled -->
                <button class="btn round accent dark ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <span class="text-light">Disabled</span>
                </button>

                <!------------------>
                <!--   BTN ICON   -->
                <!------------------>
                <h1 class="text-light mt-5 mb-3">btn icon</h1>

                <a href="#" class="btn icon light ripple"><i class="mdi light mdi-content-save"></i></a>
                <button class="btn icon light ripple"><i class="mdi light mdi-content-save"></i></button>
                <button class="btn icon light ripple" disabled><i class="mdi light mdi-content-save"></i></button>

                <!----------------->
                <!--   BTN FAB   -->
                <!----------------->
                <h1 class="text-light mt-5 mb-3">btn fab</h1>

                <a href="#" class="btn fab dark ripple"><i class="mdi light mdi-content-save"></i></a>
                <button class="btn fab dark ripple"><i class="mdi light mdi-content-save"></i></button>
                <button class="btn fab dark ripple" disabled><i class="mdi light mdi-content-save"></i></button>

                <!-------------------->
                <!--   FILE INPUT   -->
                <!-------------------->
                <h1 class="text-light mt-5 mb-3">file input</h1>

                <label class="file-input ripple">
                    <input type="file"/>
                    <i class="mdi mdi-upload"></i>
                    <span>File input</span>
                    <span class="count d-none"><i class="mdi mdi-check"></i></span>
                </label>

                <label class="file-input ripple">
                    <input type="file" multiple/>
                    <i class="mdi dark mdi-upload"></i>
                    <span>Multiple file input</span>
                    <span class="count d-none">1</span>
                </label>

                <label class="file-input ripple dark disabled">
                    <input type="file" disabled/>
                    <i class="mdi mdi-upload"></i>
                    <span>Disabled file input</span>
                    <span class="count d-none"><i class="mdi mdi-check"></i></span>
                </label>

                <!--------------->
                <!--   RADIO   -->
                <!--------------->
                <h1 class="text-light mt-5 mb-3">radio</h1>

                <h6 class="text-light">Title</h6>
                <input id="rd1" type="radio" class="radio light" name="radio-example2" value="1" checked/>
                <label for="rd1">First option</label><br>
                <input id="rd2" type="radio" class="radio light" name="radio-example2" value="2"/>
                <label for="rd2">Second option</label><br>
                <input id="rd3" type="radio" class="radio light" name="radio-example2" value="3" disabled/>
                <label for="rd3">Third option (disabled)</label>

                <!--------------->
                <!--   CHECK   -->
                <!--------------->
                <h1 class="text-light mt-5 mb-3">check</h1>

                <h6 class="text-light">Title</h6>
                <input id="cd-toggle" type="checkbox" class="checkbox light toggle-all" data-toggle-all="checkbox-example2"/>
                <label for="cd-toggle">All</label><br>
                <input id="cd1" type="checkbox" class="checkbox light" name="checkbox-example2" value="1" checked/>
                <label for="cd1">First option</label><br>
                <input id="cd2" type="checkbox" class="checkbox light" name="checkbox-example2" value="2"/>
                <label for="cd2">Second option</label><br>
                <input id="cd3" type="checkbox" class="checkbox light" name="checkbox-example2-dis" value="3" disabled/>
                <label for="cd3">Third option (disabled)</label>

                <!---------------->
                <!--   SWITCH   -->
                <!---------------->
                <h1 class="text-light mt-5 mb-3">switch</h1>

                <input id="sd1" type="checkbox" class="switch light" name="switch-example2" checked>
                <label for="sd1">Switch <span class="on">On</span><span class="off">Off</span></label><br>
                <input id="sd2" type="checkbox" class="switch light" name="switch-example2" disabled>
                <label for="sd2">Switch <span class="on">On</span><span class="off">Off</span> (disabled)</label>

                <!---------------->
                <!--   SELECT   -->
                <!---------------->
                <h1 class="text-light mt-5 mb-3">select</h1>

                <div class="dropdown select" style="width: 300px;">
                    <div class="text-input dark" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="trailing-icon arrow mdi light mdi-menu-down"></i>
                        <input id="select-toggled" type="text" placeholder=" " readonly/>
                        <label for="select-toggled">Select</label>
                    </div>
                    <div class="dropdown-menu dark" aria-labelledby="select-toggle">
                        <input id="sel1d" type="radio" class="radio light" name="select-exampled" value="1"/>
                        <label for="sel1d">First option</label>
                        <input id="sel2d" type="radio" class="radio light" name="select-exampled" value="2"/>
                        <label for="sel2d">Second option</label>
                        <input id="sel3d" type="radio" class="radio light" name="select-exampled" value="3"/>
                        <label for="sel3d">Third option</label>
                        <input id="sel4d" type="radio" class="radio light" name="select-exampled" value="4"/>
                        <label for="sel4d">Fourth option</label>
                        <input id="sel5d" type="radio" class="radio light" name="select-exampled" value="5"/>
                        <label for="sel5d">Fifth option</label>
                    </div>
                </div>

                <div class="dropdown select" style="width: 300px;">
                    <div class="text-input dark" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="trailing-icon arrow mdi light mdi-menu-down"></i>
                        <input id="multi-select-toggled" type="text" placeholder=" " readonly/>
                        <label for="multi-select-toggled">Multiple select</label>
                    </div>
                    <div class="dropdown-menu dark" aria-labelledby="multi-select-toggle">
                        <input id="msel1d" type="checkbox" class="checkbox light" name="multi-select-exampled" value="1"/>
                        <label for="msel1d">First option</label>
                        <input id="msel2d" type="checkbox" class="checkbox light" name="multi-select-exampled" value="2"/>
                        <label for="msel2d">Second option</label>
                        <input id="msel3d" type="checkbox" class="checkbox light" name="multi-select-exampled" value="3"/>
                        <label for="msel3d">Third option</label>
                        <input id="msel4d" type="checkbox" class="checkbox light" name="multi-select-exampled" value="4"/>
                        <label for="msel4d">Fourth option</label>
                        <input id="msel5d" type="checkbox" class="checkbox light" name="multi-select-exampled" value="5"/>
                        <label for="msel5d">Fifth option</label>
                    </div>
                </div>

                <div class="dropdown select" style="width: 300px;">
                    <div class="text-input dark disabled" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="trailing-icon arrow mdi light mdi-menu-down"></i>
                        <input id="select-toggled-dis" type="text" placeholder=" " readonly disabled/>
                        <label for="select-toggled-dis">Select</label>
                    </div>
                    <div class="dropdown-menu dark" aria-labelledby="select-toggle-dis">
                        <input id="dsel1d" type="radio" class="radio" name="select-exampled-dis" value="1" disabled/>
                        <label for="dsel1d">First option</label>
                    </div>
                </div>

                <!-------------------->
                <!--   RICH RADIO   -->
                <!-------------------->
                <h1 class="text-light mt-5 mb-3">rich radio</h1>

                <input id="rrd1" type="radio" class="rich-radio light" name="rich-radio-example2" value="1" checked/>
                <label for="rrd1" class="container-fluid px-0 py-2 text-light">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-8">
                                Column for option 1
                            </div>
                            <div class="col-4">
                                Another column
                            </div>
                        </div>
                    </div>
                </label>
                <input id="rrd2" type="radio" class="rich-radio light" name="rich-radio-example2" value="2"/>
                <label for="rrd2" class="container-fluid px-0 py-2 text-light">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-8">
                                Column for option 2
                            </div>
                            <div class="col-4">
                                Another column
                            </div>
                        </div>
                    </div>
                </label>
                <input id="rrd3" type="radio" class="rich-radio light" name="rich-radio-example2" value="3" disabled/>
                <label for="rrd3" class="container-fluid px-0 py-2 text-light">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-8">
                                Column for option 3
                            </div>
                            <div class="col-4">
                                Another column
                            </div>
                        </div>
                    </div>
                </label>

                <!--------------------->
                <!--   RICH SWITCH   -->
                <!--------------------->
                <h1 class="text-light mt-5 mb-3">rich switch</h1>

                <div class="rich-switch-container dark">
                    <input id="rsd1" type="radio" class="rich-switch dark" name="rich-switch-example2" value="1" checked/>
                    <label for="rsd1" class="ripple">First option</label><br>
                    <input id="rsd2" type="radio" class="rich-switch dark" name="rich-switch-example2" value="2"/>
                    <label for="rsd2" class="ripple">Second option</label><br>
                    <input id="rsd3" type="radio" class="rich-switch dark" name="rich-switch-example2" value="3"/>
                    <label for="rsd3" class="ripple">Third option</label><br>
                </div>

                <!---------------------->
                <!--   REVIEW STARS   -->
                <!---------------------->
                <h1 class="text-light mt-5 mb-3">review stars</h1>

                <div class="review-stars light">
                    <input type ="radio" id="stard5" name="ratingd" value="5"/>
                    <label for="stard5" title="5 stelle" class="ripple light">
                        <i class="unchecked mdi light mdi-star-outline"></i>
                        <i class="checked mdi light mdi-star"></i>
                    </label>
                    <input type ="radio" id="stard4" name="ratingd" value="4"/>
                    <label for="stard4" title="4 stelle" class="ripple light">
                        <i class="unchecked mdi light mdi-star-outline"></i>
                        <i class="checked mdi light mdi-star"></i>
                    </label>
                    <input type ="radio" id="stard3" name="ratingd" value="3"/>
                    <label for="stard3" title="3 stelle" class="ripple light">
                        <i class="unchecked mdi light mdi-star-outline"></i>
                        <i class="checked mdi light mdi-star"></i>
                    </label>
                    <input type ="radio" id="stard2" name="ratingd" value="2"/>
                    <label for="stard2" title="2 stelle" class="ripple light">
                        <i class="unchecked mdi light mdi-star-outline"></i>
                        <i class="checked mdi light mdi-star"></i>
                    </label>
                    <input type ="radio" id="stard1" name="ratingd" value="1" checked/>
                    <label for="stard1" title="1 stella" class="ripple light">
                        <i class="unchecked mdi light mdi-star-outline"></i>
                        <i class="checked mdi light mdi-star"></i>
                    </label>
                </div>

                <!----------------->
                <!--   DIVIDER   -->
                <!----------------->
                <h1 class="text-light mt-5 mb-3">divider</h1>

                <div class="divider light"></div>

                <!-------------------->
                <!--   TEXT FIELD   -->
                <!-------------------->
                <h1 class="text-light mt-5 mb-3">text field</h1>

                <div style="width: 300px;">

                    <div class="text-input dark">
                        <input id="emaild" type="email" value="prova" placeholder=" "/>
                        <label for="emaild">Email</label>
                    </div>

                    <div class="text-input dark">
                        <i class="leading-icon mdi light mdi-key"></i>
                        <i class="trailing-icon mdi light mdi-eye"></i>
                        <input id="passwordd" type="password" placeholder=" "/>
                        <label for="passwordd">Password</label>
                    </div>

                    <div class="text-input dark">
                        <input id="textd1" type="text" placeholder=" " maxlength="20" />
                        <label for="textd1">Text</label>
                        <span>Hint message</span>
                        <span class="counter">0 / 20</span>
                    </div>

                    <div class="text-input dark">
                        <input id="textd2" type="text" class="valid" value="value" placeholder=" "/>
                        <label for="textd2">Valid</label>
                    </div>

                    <div class="text-input dark">
                        <input id="textd3" type="text" class="error" value="value" placeholder=" "/>
                        <label for="textd3">Error</label>
                        <span>Error message</span>
                    </div>

                    <div class="text-input dark">
                        <input id="numberd" type="number" name="numberd" min="-10" max="10" step="2" placeholder=" ">
                        <label for="numberd">Number</label>
                        <button class="inc btn icon light ripple" tabindex="-1"><i class="mdi light mdi-menu-up"></i></button>
                        <button class="dec btn icon light ripple" tabindex="-1"><i class="mdi light mdi-menu-down"></i></button>
                    </div>

                    <div class="text-input dark">
                        <i class="leading-icon mdi small light mdi-currency-eur"></i>
                        <input id="currencyd" type="number" data-type="currency" name="currencyd" min="0" step="0.01" placeholder=" ">
                        <label for="currencyd">Currency</label>
                    </div>

                    <div class="text-input dark">
                        <input id="textd4" type="text" placeholder=" " disabled/>
                        <label for="textd4">Disabled</label>
                    </div>

                </div>

                <!------------------->
                <!--   TEXT AREA   -->
                <!------------------->
                <h1 class="text-light mt-5 mb-3">text area</h1>

                <div style="width: 300px;">

                    <div class="text-area dark">
                        <textarea id="textarea" placeholder=" "></textarea>
                        <label for="textarea">Text area</label>
                    </div>

                    <div class="text-area dark">
                        <textarea id="textarea" placeholder=" " disabled></textarea>
                        <label for="textarea">Disabled Text area</label>
                    </div>

                </div>

                <!-------------------->
                <!--   PAGINATION   -->
                <!-------------------->
                <h1 class="text-light mt-5 mb-3">pagination</h1>

                <ul class="pagination light">
                    <li><a href="#" class="btn icon light ripple disabled" title="Prima pagina"><i class="mdi light mdi-page-first"></i></a></li>
                    <li><a href="#" class="btn icon light ripple disabled" title="Pagina precedente"><i class="mdi light mdi-chevron-left"></i></a></li>
                    <li><a href="#" class="selected">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#" class="btn icon light ripple" title="Pagina successiva"><i class="mdi light mdi-chevron-right"></i></a></li>
                    <li><a href="#" class="btn icon light ripple" title="Ultima pagina"><i class="mdi light mdi-page-last"></i></a></li>
                </ul>

                <!-------------------->
                <!--   BREADCRUMB   -->
                <!-------------------->
                <h1 class="text-light mt-5 mb-3">breadcrumb</h1>

                <ol class="breadcrumb light">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Library</li>
                </ol>

                <!-------------------->
                <!--   SEARCH BAR   -->
                <!-------------------->
                <h1 class="text-light mt-5 mb-3">search bar</h1>

                <div class="search-bar dark" style="width: 360px;">
                    <button class="search btn icon ripple" title="Cerca"><i class="mdi light mdi-magnify"></i></button>
                    <input type="text" placeholder="Cerca..."/>
                    <button class="clear btn icon ripple" title="Cancella"><i class="mdi light mdi-close"></i></button>
                </div>

                <!------------------>
                <!--   COLLAPSE   -->
                <!------------------>
                <h1 class="text-light mt-5 mb-3">collapse</h1>

                <button class="btn-collapse btn icon light ripple" data-toggle="collapse" data-target="#collapse-example2" aria-expanded="false" title="Mostra">
                    <i class="mdi light mdi-chevron-down"></i>
                </button>
                <div id="collapse-example2" class="collapse">
                    <p class="text-light m-0">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </p>
                </div>

                <!------------------>
                <!--   DROPDOWN   -->
                <!------------------>
                <h1 class="text-light mt-5 mb-3">dropdown</h1>

                <div class="dropdown">
                    <button class="btn outline light" id="dropdown-toggled" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="text-light">Dropdown</span>
                        <i class="arrow mdi light mdi-menu-down"></i>
                    </button>
                    <div class="dropdown-menu dark" aria-labelledby="dropdown-toggled">
                        <a href="#" class="dropdown-item">Action</a>
                        <a href="#" class="dropdown-item">Another action</a>
                        <a href="#" class="dropdown-item">Something else here</a>
                        <a href="#" class="dropdown-item">
                            <i class="mdi light mdi-content-save"></i>
                            <span>Icon to the left</span>
                        </a>
                        <a href="#" class="dropdown-item">
                            <span>Icon to the right</span>
                            <i class="mdi light mdi-content-save"></i>
                        </a>
                    </div>
                </div>
                <div class="dropright">
                    <button class="btn outline light" id="dropdown-toggled2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="text-light">Dropright</span>
                        <i class="arrow mdi light mdi-menu-right"></i>
                    </button>
                    <div class="dropdown-menu dark" aria-labelledby="dropdown-toggled2">
                        <h6 class="h-variant text-sec-light">Header</h6>
                        <a href="#" class="dropdown-item">Action</a>
                        <a href="#" class="dropdown-item">Another action</a>
                        <div class="divider light"></div>
                        <h6 class="h-variant text-sec-light">Another header</h6>
                        <a href="#" class="dropdown-item">Something else here</a>
                    </div>
                </div>
                <div class="dropleft">
                    <button class="btn outline light" id="dropdown-toggled3" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="arrow mdi light mdi-menu-left"></i>
                        <span class="text-light">Dropleft</span>
                    </button>
                    <div class="dropdown-menu dark" aria-labelledby="dropdown-toggled3">
                        <a href="#" class="dropdown-item disabled" tab-index="-1" aria-disabled="true">Disabled action</a>
                        <a href="#" class="dropdown-item disabled" tab-index="-1" aria-disabled="true">
                            <i class="mdi light mdi-content-save"></i>
                            <span>Disabled action with icon</span>
                        </a>
                    </div>
                </div>
                <div class="dropup">
                    <button class="btn outline light" id="dropdown-toggled4" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="text-light">Dropup</span>
                        <i class="arrow mdi light mdi-menu-up"></i>
                    </button>
                    <div class="dropdown-menu dark" aria-labelledby="dropdown-toggled4">
                        <a href="#" class="dropdown-item">Action</a>
                        <a href="#" class="dropdown-item active">Another action</a>
                        <a href="#" class="dropdown-item">Something else here</a>
                    </div>
                </div>

                <!----------------->
                <!--   LOADING   -->
                <!----------------->
                <h1 class="text-light mt-5 mb-3">loading</h1>

                <div class="loader light">
                    <svg version="1.1" id="loader-1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" width="40px" height="40px" viewBox="0 0 50 50" style="enable-background:new 0 0 50 50;" xml:space="preserve">
                        <path fill="#000" d="M43.935,25.145c0-10.318-8.364-18.683-18.683-18.683c-10.318,0-18.683,8.365-18.683,18.683h4.068c0-8.071,6.543-14.615,14.615-14.615c8.072,0,14.615,6.543,14.615,14.615H43.935z">
                        <animateTransform attributeType="xml"
                                          attributeName="transform"
                                          type="rotate"
                                          from="0 25 25"
                                          to="360 25 25"
                                          dur="1s"
                                          repeatCount="indefinite"/>
                        </path>
                    </svg>
                </div>

                <!--------------------->
                <!--   EMPTY STATE   -->
                <!--------------------->
                <h1 class="text-light mt-5 mb-3">empty-state</h1>

                <div class="empty-state dark m-5">
                    <!-- <img src="images/empty.png"/> -->
                    <i class="mdi mdi-feature-search-outline"></i>
                    <h6 class="text-center text-sec-light font-weight-bold mt-3 mb-2">No results</h6>
                    <p class="text-center text-dis-light m-0">
                        Some quick example text to build on the component and make up the bulk of the component's content.
                    </p>
                </div>

                <!----------------->
                <!--   POPOVER   -->
                <!----------------->
                <h1 class="text-light mt-5 mb-3">popover</h1>

                <button class="btn light outline ripple" data-toggle="popover" data-placement="top"
                        title="Popover title" data-content="Popover content here">
                    Top popover
                </button>
                <button class="btn light outline ripple" data-toggle="popover" data-placement="bottom"
                        title="Popover title" data-content="Popover content here">
                    Bottom popover
                </button>
                <button class="btn light outline ripple" data-toggle="popover" data-placement="left"
                        title="Popover title" data-content="Popover content here">
                    Left popover
                </button>
                <button class="btn light outline ripple" data-toggle="popover" data-placement="right"
                        title="Popover title" data-content="Popover content here">
                    Right popover
                </button>

                <!----------------->
                <!--   TOOLTIP   -->
                <!----------------->
                <h1 class="text-light mt-5 mb-3">tooltip</h1>

                <button class="btn light outline ripple" data-toggle="tooltip" data-placement="top"
                        title="Tooltip">
                    Top tooltip
                </button>
                <button class="btn light outline ripple" data-toggle="tooltip" data-placement="bottom"
                        title="Tooltip">
                    Bottom tooltip
                </button>
                <button class="btn light outline ripple" data-toggle="tooltip" data-placement="left"
                        title="Tooltip">
                    Left tooltip
                </button>
                <button class="btn light outline ripple" data-toggle="tooltip" data-placement="right"
                        title="Tooltip">
                    Right tooltip
                </button>

                <!-------------->
                <!--   CHIP   -->
                <!-------------->
                <h1 class="text-light mt-5 mb-3">chip</h1>

                <div class="chip-container d-flex flex-wrap">
                    <div class="chip light">
                        <span>Chip text</span>
                    </div>
                    <div class="chip light">
                        <span>Chip text</span>
                        <button class="btn icon light ripple"><i class="mdi light mdi-close"></i></button>
                    </div>
                    <div class="chip light selected">
                        <i class="mdi light mdi-check"></i>
                        <span>Chip text</span>
                    </div>
                    <button class="chip light">
                        <img src="images/chip.jpg"/>
                        <span>Chip text</span>
                    </button>
                    <div class="chip light">
                        <i class="mdi light mdi-account-circle"></i>
                        <span>Chip text</span>
                        <button class="btn icon light ripple"><i class="mdi light mdi-close"></i></button>
                    </div>
                    <a href="#" class="chip light">
                        <img src="images/chip.jpg"/>
                        <span>Chip text</span>
                        <button class="btn icon light ripple"><i class="mdi light mdi-close"></i></button>
                    </a>
                </div>

                <!------------------>
                <!--   PROGRESS   -->
                <!------------------>
                <h1 class="text-light mt-5 mb-3">progress</h1>
                <div class="progress dark mb-3">
                    <div class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <div class="progress dark mb-3">
                    <div class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <div class="progress dark mb-3">
                    <div class="progress-bar" role="progressbar" style="width: 50%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <div class="progress dark mb-3">
                    <div class="progress-bar" role="progressbar" style="width: 75%" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <div class="progress dark">
                    <div class="progress-bar" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                </div>

                <!---------------->
                <!--   SLIDER   -->
                <!---------------->
                <h1 class="text-light mt-5 mb-3">slider</h1>

                <div class="slider-container">
                    <input id="slider-example" class="slider dark" type="range" min="1" max="100" value="50"/>
                    <span class="slider-progress"></span>
                    <span class="slider-tooltip">50</span>
                </div>
                <div class="slider-container">
                    <input id="slider-example-dis" class="slider dark" type="range" min="1" max="100" value="50" disabled/>
                    <span class="slider-progress"></span>
                    <span class="slider-tooltip">50</span>
                </div>

            </div>
        </div>
    </div>

    <?php include("footer.php"); ?>

    <?php include("scripts.php"); ?>

</body>
</html>