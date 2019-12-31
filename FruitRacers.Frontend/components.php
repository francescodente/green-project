<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Componenti</title>
</head>
<body>

    <div class="container-fluid">
        <div class="row">
            <div class="col-12 col-md-6 bg-primary">

                <h1>Heading 1</h1>
                <h2>Heading 2</h2>
                <h3>Heading 3</h3>
                <h4>Heading 4</h4>
                <h5>Heading 5</h5>
                <h6>Heading 6</h6>
                <h4 class="h-variant">Heading variant</h4>
                <p>Paragraph</p>
                <a href="#">Link</a><br>
                <i class="mdi dark mdi-content-save"></i>

                <!------------------------->
                <!--   BTN TRANSPARENT   -->
                <!------------------------->
                <h1 class="mt-5 mb-3">btn transparent</h1>

                <!-- Text only -->
                <a href="#" class="btn transparent ripple">Button</a>
                <button class="btn transparent ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn transparent ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn transparent ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn transparent ripple" disabled>
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Disabled</p>
                </button>

                <!--------------------->
                <!--   BTN OUTLINE   -->
                <!--------------------->
                <h1 class="mt-5 mb-3">btn outline</h1>

                <!-- Text only -->
                <a href="#" class="btn outline ripple">Button</a>
                <button class="btn outline ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn outline ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn outline ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn outline ripple" disabled>
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Disabled</p>
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
                    <p>Button</p>
                </a>
                <button class="btn accent ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn accent ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <p>Disabled</p>
                </button>

                <!------------------------------->
                <!--   BTN ROUND TRANSPARENT   -->
                <!------------------------------->
                <h1 class="mt-5 mb-3">btn round transparent</h1>

                <!-- Text only -->
                <a href="#" class="btn round transparent ripple">Button</a>
                <button class="btn round transparent ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round transparent ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn round transparent ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn round transparent ripple" disabled>
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Disabled</p>
                </button>

                <!--------------------------->
                <!--   BTN ROUND OUTLINE   -->
                <!--------------------------->
                <h1 class="mt-5 mb-3">btn round outline</h1>

                <!-- Text only -->
                <a href="#" class="btn round outline ripple">Button</a>
                <button class="btn round outline ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round outline ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn round outline ripple">
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn round outline ripple" disabled>
                    <i class="mdi dark mdi-content-save"></i>
                    <p>Disabled</p>
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
                    <p>Button</p>
                </a>
                <button class="btn round accent ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn round accent ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <p>Disabled</p>
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
                    <p>File input</p>
                    <span class="count d-none"><i class="mdi mdi-check"></i></span>
                </label>

                <label class="file-input ripple">
                    <input type="file" multiple/>
                    <i class="mdi dark mdi-upload"></i>
                    <p>Multiple file input</p>
                    <span class="count d-none">1</span>
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
                <input id="c-toggle" type="checkbox" class="checkbox toggle-all" data-toggle="ce"/>
                <label for="c-toggle">All</label><br>
                <input id="c1" type="checkbox" class="checkbox" name="checkbox-example" value="1" data-toggled-by="ce" checked/>
                <label for="c1">First option</label><br>
                <input id="c2" type="checkbox" class="checkbox" name="checkbox-example" value="2" data-toggled-by="ce"/>
                <label for="c2">Second option</label><br>
                <input id="c3" type="checkbox" class="checkbox" name="checkbox-example" value="3" disabled/>
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

                <div class="select-input">
                    <label for="select-example">
                        <button type="button"><p>Seleziona</p><i class="mdi dark mdi-menu-swap"></i></button>
                    </label>
                    <ul id="select-example" role="listbox" name="select-example">
                        <li id="s1" value="s1" role="option" tabindex="-1" aria-selected="true" class="selected">Option 1</li>
                        <li id="s2" value="s2" role="option" tabindex="-1" aria-selected="false">Option 2</li>
                        <li id="s3" value="s3" role="option" tabindex="-1" aria-selected="false">Option 3</li>
                        <li id="s4" value="s4" role="option" tabindex="-1" aria-selected="false">Option 4</li>
                        <li id="s5" value="s5" role="option" tabindex="-1" aria-selected="false">Option 5</li>
                        <li id="s6" value="s6" role="option" tabindex="-1" aria-selected="false">Option 6</li>
                        <li id="s7" value="s7" role="option" tabindex="-1" aria-selected="false">Option 7</li>
                        <li id="s8" value="s8" role="option" tabindex="-1" aria-selected="false">Option 8</li>
                        <li id="s9" value="s9" role="option" tabindex="-1" aria-selected="false">Option 9</li>
                    </ul>
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

                <!---------------------->
                <!--   REVIEW STARS   -->
                <!---------------------->
                <h1 class="mt-5 mb-3">review stars</h1>

                <div class="review-stars">
                    <input type ="radio" id="star5" name="rating" value="5"/>
                    <label for="star5" title="5 stelle">
                        <i class="unchecked mdi dark mdi-star-outline"></i>
                        <i class="checked mdi dark mdi-star"></i>
                    </label>
                    <input type ="radio" id="star4" name="rating" value="4"/>
                    <label for="star4" title="4 stelle">
                        <i class="unchecked mdi dark mdi-star-outline"></i>
                        <i class="checked mdi dark mdi-star"></i>
                    </label>
                    <input type ="radio" id="star3" name="rating" value="3"/>
                    <label for="star3" title="3 stelle">
                        <i class="unchecked mdi dark mdi-star-outline"></i>
                        <i class="checked mdi dark mdi-star"></i>
                    </label>
                    <input type ="radio" id="star2" name="rating" value="2"/>
                    <label for="star2" title="2 stelle">
                        <i class="unchecked mdi dark mdi-star-outline"></i>
                        <i class="checked mdi dark mdi-star"></i>
                    </label>
                    <input type ="radio" id="star1" name="rating" value="1" checked/>
                    <label for="star1" title="1 stella">
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

                <div class="text-input">
                    <input id="email" type="email" value="prova"/>
                    <label for="email">Email</label>
                </div>

                <div class="text-input">
                    <input id="password" type="password"/>
                    <label for="password">
                        <i class="mdi dark mdi-key"></i>
                        <span>Password</span>
                    </label>
                </div>

                <div class="text-input">
                    <input id="text1" type="text"/>
                    <label for="text1">Text</label>
                    <span>Hint message</span>
                </div>

                <div class="text-input">
                    <input id="text2" type="text" class="valid" value="value"/>
                    <label for="text2">Valid</label>
                </div>

                <div class="text-input">
                    <input id="text3" type="text" class="error" value="value"/>
                    <label for="text3">Error</label>
                    <span>Error message</span>
                </div>

                <div class="text-input">
                    <input id="text4" type="text" disabled/>
                    <label for="text4">Disabled</label>
                </div>

                <!------------------->
                <!--   TEXT AREA   -->
                <!------------------->
                <h1 class="mt-5 mb-3">text area</h1>

                <div class="text-area">
                    <textarea id="textarea"></textarea>
                    <label for="textarea">Text area</label>
                </div>

                <div class="text-area">
                    <textarea id="textarea" disabled></textarea>
                    <label for="textarea">Disabled Text area</label>
                </div>

                <!-------------------->
                <!--   PAGINATION   -->
                <!-------------------->
                <h1 class="mt-5 mb-3">pagination</h1>

                <ul class="pagination">
                    <li><a href="#" class="btn icon ripple disabled" title="Pagina precedente"><i class="mdi dark mdi-chevron-left"></i></a></li>
                    <li><a href="#" class="selected">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#" class="btn icon ripple" title="Pagina successiva"><i class="mdi dark mdi-chevron-right"></i></a></li>
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

                <div class="search-bar">
                    <button class="search btn icon ripple" title="Cerca"><i class="mdi dark mdi-magnify"></i></button>
                    <input type="text" placeholder="Cerca..."/>
                    <button class="clear btn icon ripple" title="Cancella" disabled><i class="mdi dark mdi-close"></i></button>
                </div>

                <!------------------>
                <!--   COLLAPSE   -->
                <!------------------>
                <h1 class="mt-5 mb-3">collapse</h1>

                <button class="btn icon ripple" data-toggle="collapse" data-target="#collapse-example" aria-expanded="false" title="Mostra">
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

                <button class="btn icon ripple" data-toggle="dropdown" data-target="#dropdown-example" style="float: right">
                    <i class="mdi dark mdi-dots-vertical"></i>
                </button>
                <div id="dropdown-example" class="dropdown">
                    <ul>
                        <li>
                            <a href="#"><i class="mdi dark mdi-account-box"></i><span>Dropdown item 1</span></a>
                        </li>
                        <li>
                            <a href="#"><i class="mdi dark mdi-bell-outline"></i><span>Dropdown item 2</span></a>
                        </li>
                        <li>
                            <a href="#"><i class="mdi dark mdi-headphones"></i><span>Dropdown item 3</span></a>
                        </li>
                        <li>
                            <a href="#"><i class="mdi dark mdi-settings"></i><span>Dropdown item 4</span></a>
                        </li>
                    </ul>
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

                <!------------------>
                <!--   CAROUSEL   -->
                <!------------------>
                <h1 class="mt-5 mb-3">carousel</h1>

                <div id="carousel-example" class="carousel slide" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#carousel-example" data-slide-to="0" class="active"></li>
                        <li data-target="#carousel-example" data-slide-to="1"></li>
                        <li data-target="#carousel-example" data-slide-to="2"></li>
                    </ol>
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img class="d-block w-100" src="images/example1.jpg" alt="First">
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="images/example2.jpg" alt="Second">
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="images/example3.jpg" alt="Third">
                        </div>
                        <div class="image-shade"></div>
                    </div>
                    <a class="carousel-control-prev" href="#carousel-example" role="button" data-slide="prev" title="Indietro">
                        <i class="mdi light mdi-chevron-left"></i>
                    </a>
                    <a class="carousel-control-next" href="#carousel-example" role="button" data-slide="next" title="Avanti">
                        <i class="mdi mdi-chevron-right"></i>
                    </a>
                    <a class="carousel-full-screen-toggle btn icon light ripple" href="#carousel-example" title="Visualizza a schermo intero">
                        <i class="mdi light mdi-fullscreen"></i>
                    </a>
                </div>

                <!------------------------>
                <!--   IMG-CLICK-ZOOM   -->
                <!------------------------>
                <h1 class="mt-5 mb-3">img-click-zoom</h1>
                <div class="card image fixed-ratio fr-16-9">
                    <img class="card-bg img-click-zoom" src="images/example2.jpg"/>
                </div>

                <!----------------->
                <!--   POPOVER   -->
                <!----------------->
                <h1 class="mt-5 mb-3">popover</h1>

                <button class="btn transparent ripple" data-toggle="popover" data-theme="dark" data-placement="top"
                        title="Popover title" data-content="Popover content here">
                    Top popover
                </button>
                <button class="btn transparent ripple" data-toggle="popover" data-theme="dark" data-placement="bottom"
                        title="Popover title" data-content="Popover content here">
                    Bottom popover
                </button>
                <button class="btn transparent ripple" data-toggle="popover" data-theme="dark" data-placement="left"
                        title="Popover title" data-content="Popover content here">
                    Left popover
                </button>
                <button class="btn transparent ripple" data-toggle="popover" data-theme="dark" data-placement="right"
                        title="Popover title" data-content="Popover content here">
                    Right popover
                </button>

                <!----------------->
                <!--   TOOLTIP   -->
                <!----------------->
                <h1 class="mt-5 mb-3">tooltip</h1>

                <button class="btn transparent ripple" data-toggle="tooltip" data-theme="dark" data-placement="top"
                        title="Tooltip">
                    Top tooltip
                </button>
                <button class="btn transparent ripple" data-toggle="tooltip" data-theme="dark" data-placement="bottom"
                        title="Tooltip">
                    Bottom tooltip
                </button>
                <button class="btn transparent ripple" data-toggle="tooltip" data-theme="dark" data-placement="left"
                        title="Tooltip">
                    Left tooltip
                </button>
                <button class="btn transparent ripple" data-toggle="tooltip" data-theme="dark" data-placement="right"
                        title="Tooltip">
                    Right tooltip
                </button>

                <!-------------->
                <!--   CHIP   -->
                <!-------------->
                <h1 class="mt-5 mb-3">chip</h1>

                <div class="d-flex">
                    <div class="chip">
                        <p>Chip text</p>
                    </div>
                    <div class="chip">
                        <p>Chip text</p>
                        <i class="chip-dismiss mdi mdi-close-circle"></i>
                    </div>
                    <div class="chip">
                        <i class="mdi dark mdi-account-circle"></i>
                        <p>Chip text</p>
                        <i class="chip-dismiss mdi mdi-close-circle"></i>
                    </div>
                    <div class="chip">
                        <img src="images/chip.jpg"/>
                        <p>Chip text</p>
                        <i class="chip-dismiss mdi mdi-close-circle"></i>
                    </div>
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

                <br><br><br><br><br><br>

            </div>
            <div class="col-12 col-md-6 bg-dark-primary">

                <h1 class="text-light">Heading 1</h1>
                <h2 class="text-light">Heading 2</h2>
                <h3 class="text-light">Heading 3</h3>
                <h4 class="text-light">Heading 4</h4>
                <h5 class="text-light">Heading 5</h5>
                <h6 class="text-light">Heading 6</h6>
                <h4 class="text-light h-variant">Heading variant</h4>
                <p class="text-light">Paragraph</p>
                <a href="#" class="light">Link</a><br>
                <i class="mdi light mdi-content-save"></i>

                <!------------------------->
                <!--   BTN TRANSPARENT   -->
                <!------------------------->
                <h1 class="text-light mt-5 mb-3">btn transparent</h1>

                <!-- Text only -->
                <a href="#" class="btn transparent light ripple">Button</a>
                <button class="btn transparent light ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn transparent light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn transparent light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn transparent light ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <p>Disabled</p>
                </button>

                <!--------------------->
                <!--   BTN OUTLINE   -->
                <!--------------------->
                <h1 class="text-light mt-5 mb-3">btn outline</h1>

                <!-- Text only -->
                <a href="#" class="btn outline light ripple">Button</a>
                <button class="btn outline light ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn outline light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn outline light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn outline light ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <p>Disabled</p>
                </button>

                <!-------------------->
                <!--   BTN ACCENT   -->
                <!-------------------->
                <h1 class="text-light mt-5 mb-3">btn accent</h1>

                <!-- Text only -->
                <a href="#" class="btn accent light ripple">Button</a>
                <button class="btn accent light ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn accent light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn accent light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn accent light ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <p>Disabled</p>
                </button>

                <!------------------------------->
                <!--   BTN ROUND TRANSPARENT   -->
                <!------------------------------->
                <h1 class="text-light mt-5 mb-3">btn round transparent</h1>

                <!-- Text only -->
                <a href="#" class="btn round transparent light ripple">Button</a>
                <button class="btn round transparent light ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round transparent light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn round transparent light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn round transparent light ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <p>Disabled</p>
                </button>

                <!--------------------------->
                <!--   BTN ROUND OUTLINE   -->
                <!--------------------------->
                <h1 class="text-light mt-5 mb-3">btn round outline</h1>

                <!-- Text only -->
                <a href="#" class="btn round outline light ripple">Button</a>
                <button class="btn round outline light ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round outline light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn round outline light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn round outline light ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <p>Disabled</p>
                </button>

                <!-------------------------->
                <!--   BTN ROUND ACCENT   -->
                <!-------------------------->
                <h1 class="text-light mt-5 mb-3">btn round accent</h1>

                <!-- Text only -->
                <a href="#" class="btn round accent light ripple">Button</a>
                <button class="btn round accent light ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round accent light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn round accent light ripple">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn round accent light ripple" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <p>Disabled</p>
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

                <a href="#" class="btn fab ripple"><i class="mdi light mdi-content-save"></i></a>
                <button class="btn fab ripple"><i class="mdi light mdi-content-save"></i></button>
                <button class="btn fab ripple" disabled><i class="mdi light mdi-content-save"></i></button>

                <!-------------------->
                <!--   FILE INPUT   -->
                <!-------------------->
                <h1 class="text-light mt-5 mb-3">file input</h1>

                <label class="file-input ripple">
                    <input type="file"/>
                    <i class="mdi mdi-upload"></i>
                    <p>File input</p>
                    <span class="count d-none"><i class="mdi mdi-check"></i></span>
                </label>

                <label class="file-input ripple">
                    <input type="file" multiple/>
                    <i class="mdi dark mdi-upload"></i>
                    <p>Multiple file input</p>
                    <span class="count d-none">1</span>
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
                <input id="cd-toggle" type="checkbox" class="checkbox light toggle-all" data-toggle="ce2"/>
                <label for="cd-toggle">All</label><br>
                <input id="cd1" type="checkbox" class="checkbox light" name="checkbox-example2" value="1" data-toggled-by="ce2" checked/>
                <label for="cd1">First option</label><br>
                <input id="cd2" type="checkbox" class="checkbox light" name="checkbox-example2" value="2"data-toggled-by="ce2"/>
                <label for="cd2">Second option</label><br>
                <input id="cd3" type="checkbox" class="checkbox light" name="checkbox-example2" value="3" disabled/>
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

                <div class="select-input dark">
                    <label for="select-example2">
                        <button type="button"><p>Seleziona</p><i class="mdi light mdi-menu-swap"></i></button>
                    </label>
                    <ul id="select-example2" role="listbox" name="select-example">
                        <li id="s1" value="s1" role="option" tabindex="-1" aria-selected="true" class="selected">Option 1</li>
                        <li id="s2" value="s2" role="option" tabindex="-1" aria-selected="false">Option 2</li>
                        <li id="s3" value="s3" role="option" tabindex="-1" aria-selected="false">Option 3</li>
                        <li id="s4" value="s4" role="option" tabindex="-1" aria-selected="false">Option 4</li>
                        <li id="s5" value="s5" role="option" tabindex="-1" aria-selected="false">Option 5</li>
                        <li id="s6" value="s6" role="option" tabindex="-1" aria-selected="false">Option 6</li>
                        <li id="s7" value="s7" role="option" tabindex="-1" aria-selected="false">Option 7</li>
                        <li id="s8" value="s8" role="option" tabindex="-1" aria-selected="false">Option 8</li>
                        <li id="s9" value="s9" role="option" tabindex="-1" aria-selected="false">Option 9</li>
                    </ul>
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

                <!---------------------->
                <!--   REVIEW STARS   -->
                <!---------------------->
                <h1 class="text-light mt-5 mb-3">review stars</h1>

                <div class="review-stars">
                    <input type ="radio" id="stard5" name="rating" value="5"/>
                    <label for="stard5" title="5 stelle">
                        <i class="unchecked mdi light mdi-star-outline"></i>
                        <i class="checked mdi light mdi-star"></i>
                    </label>
                    <input type ="radio" id="stard4" name="rating" value="4"/>
                    <label for="stard4" title="4 stelle">
                        <i class="unchecked mdi light mdi-star-outline"></i>
                        <i class="checked mdi light mdi-star"></i>
                    </label>
                    <input type ="radio" id="stard3" name="rating" value="3"/>
                    <label for="stard3" title="3 stelle">
                        <i class="unchecked mdi light mdi-star-outline"></i>
                        <i class="checked mdi light mdi-star"></i>
                    </label>
                    <input type ="radio" id="stard2" name="rating" value="2"/>
                    <label for="stard2" title="2 stelle">
                        <i class="unchecked mdi light mdi-star-outline"></i>
                        <i class="checked mdi light mdi-star"></i>
                    </label>
                    <input type ="radio" id="stard1" name="rating" value="1" checked/>
                    <label for="stard1" title="1 stella">
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

                <div class="text-input">
                    <input id="emaild" type="email" class="dark" value="prova"/>
                    <label for="emaild">Email</label>
                </div>

                <div class="text-input">
                    <input id="passwordd" type="password" class="dark"/>
                    <label for="password">
                        <i class="mdi light mdi-key"></i>
                        <span>Password</span>
                    </label>
                </div>

                <div class="text-input">
                    <input id="textd1" type="text" class="dark"/>
                    <label for="textd1">Text</label>
                    <span>Hint message</span>
                </div>

                <div class="text-input">
                    <input id="textd2" type="text" class="input dark valid" value="value"/>
                    <label for="textd2">Valid</label>
                </div>

                <div class="text-input">
                    <input id="textd3" type="text" class="input dark error" value="value"/>
                    <label for="textd3">Error</label>
                    <span>Error message</span>
                </div>

                <div class="text-input">
                    <input id="textd4" type="text" class="dark" disabled/>
                    <label for="textd4">Disabled</label>
                </div>

                <!------------------->
                <!--   TEXT AREA   -->
                <!------------------->
                <h1 class="text-light mt-5 mb-3">text area</h1>

                <div class="text-area">
                    <textarea id="textarea" class="dark"></textarea>
                    <label for="textarea">Text area</label>
                </div>

                <div class="text-area">
                    <textarea id="textarea" class="dark" disabled></textarea>
                    <label for="textarea">Disabled Text area</label>
                </div>

                <!-------------------->
                <!--   PAGINATION   -->
                <!-------------------->
                <h1 class="text-light mt-5 mb-3">pagination</h1>

                <ul class="pagination light">
                    <li><a href="#" class="btn icon light ripple disabled" title="Pagina precedente"><i class="mdi light mdi-chevron-left"></i></a></li>
                    <li><a href="#" class="selected">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#" class="btn icon light ripple" title="Pagina successiva"><i class="mdi light mdi-chevron-right"></i></a></li>
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

                <div class="search-bar dark">
                    <button class="search btn icon ripple" title="Cerca"><i class="mdi dark mdi-magnify"></i></button>
                    <input type="text" placeholder="Cerca..."/>
                    <button class="clear btn icon ripple" title="Cancella" disabled><i class="mdi dark mdi-close"></i></button>
                </div>

                <!------------------>
                <!--   COLLAPSE   -->
                <!------------------>
                <h1 class="text-light mt-5 mb-3">collapse</h1>

                <button class="btn icon light ripple" data-toggle="collapse" data-target="#collapse-example2" aria-expanded="false" title="Mostra">
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

                <button class="btn icon light dar ripple" data-toggle="dropdown" data-target="#dropdown-example2" style="float: right">
                    <i class="mdi light mdi-dots-vertical"></i>
                </button>
                <div id="dropdown-example2" class="dropdown dark text-light">
                    <ul>
                        <li>
                            <a href="#"><i class="mdi dark mdi-account-box"></i><span>Dropdown item 1</span></a>
                        </li>
                        <li>
                            <a href="#"><i class="mdi dark mdi-bell-outline"></i><span>Dropdown item 2</span></a>
                        </li>
                        <li>
                            <a href="#"><i class="mdi dark mdi-headphones"></i><span>Dropdown item 3</span></a>
                        </li>
                        <li>
                            <a href="#"><i class="mdi dark mdi-settings"></i><span>Dropdown item 4</span></a>
                        </li>
                    </ul>
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

                <!------------------>
                <!--   CAROUSEL   -->
                <!------------------>
                <h1 class="text-light mt-5 mb-3">carousel</h1>

                <div id="carousel-example2" class="carousel slide" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#carousel-example2" data-slide-to="0" class="active"></li>
                        <li data-target="#carousel-example2" data-slide-to="1"></li>
                        <li data-target="#carousel-example2" data-slide-to="2"></li>
                    </ol>
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img class="d-block w-100" src="images/example1.jpg" alt="First">
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="images/example2.jpg" alt="Second">
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="images/example3.jpg" alt="Third">
                        </div>
                        <div class="image-shade"></div>
                    </div>
                    <a class="carousel-control-prev" href="#carousel-example2" role="button" data-slide="prev" title="Indietro">
                        <i class="mdi light mdi-chevron-left"></i>
                    </a>
                    <a class="carousel-control-next" href="#carousel-example2" role="button" data-slide="next" title="Avanti">
                        <i class="mdi light mdi-chevron-right"></i>
                    </a>
                </div>

                <!------------------------>
                <!--   IMG-CLICK-ZOOM   -->
                <!------------------------>
                <h1 class="text-light mt-5 mb-3">img-click-zoom</h1>
                <div class="card image fixed-ratio fr-16-9">
                    <img class="card-bg img-click-zoom" src="images/example2.jpg"/>
                </div>

                <!----------------->
                <!--   POPOVER   -->
                <!----------------->
                <h1 class="text-light mt-5 mb-3">popover</h1>

                <button class="btn light transparent ripple" data-toggle="popover" data-theme="light" data-placement="top"
                        title="Popover title" data-content="Popover content here">
                    Top popover
                </button>
                <button class="btn light transparent ripple" data-toggle="popover" data-theme="light" data-placement="bottom"
                        title="Popover title" data-content="Popover content here">
                    Bottom popover
                </button>
                <button class="btn light transparent ripple" data-toggle="popover" data-theme="light" data-placement="left"
                        title="Popover title" data-content="Popover content here">
                    Left popover
                </button>
                <button class="btn light transparent ripple" data-toggle="popover" data-theme="light" data-placement="right"
                        title="Popover title" data-content="Popover content here">
                    Right popover
                </button>

                <!----------------->
                <!--   TOOLTIP   -->
                <!----------------->
                <h1 class="text-light mt-5 mb-3">tooltip</h1>

                <button class="btn light transparent ripple" data-toggle="tooltip" data-theme="light" data-placement="top"
                        title="Tooltip">
                    Top tooltip
                </button>
                <button class="btn light transparent ripple" data-toggle="tooltip" data-theme="light" data-placement="bottom"
                        title="Tooltip">
                    Bottom tooltip
                </button>
                <button class="btn light transparent ripple" data-toggle="tooltip" data-theme="light" data-placement="left"
                        title="Tooltip">
                    Left tooltip
                </button>
                <button class="btn light transparent ripple" data-toggle="tooltip" data-theme="light" data-placement="right"
                        title="Tooltip">
                    Right tooltip
                </button>

                <!-------------->
                <!--   CHIP   -->
                <!-------------->
                <h1 class="text-light mt-5 mb-3">chip</h1>

                <div class="d-flex">
                    <div class="chip light">
                        <p>Chip text</p>
                    </div>
                    <div class="chip light">
                        <p>Chip text</p>
                        <i class="chip-dismiss mdi mdi-close-circle"></i>
                    </div>
                    <div class="chip light">
                        <i class="mdi light mdi-account-circle"></i>
                        <p>Chip text</p>
                        <i class="chip-dismiss mdi mdi-close-circle"></i>
                    </div>
                    <div class="chip light">
                        <img src="images/chip.jpg"/>
                        <p>Chip text</p>
                        <i class="chip-dismiss mdi mdi-close-circle"></i>
                    </div>
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

            </div>
        </div>
    </div>

    <?php include("scripts.php"); ?>

</body>
</html>