<!doctype html>
<html lang="it">
<head>
    <?php include("head.php"); ?>
    <title>Fruitracers - Componenti</title>
</head>
<body style="background-color: #FAFAFA">

    <div class="container-fluid">
        <div class="row">
            <div class="col-12 col-md-6" style="background-color: #FAFAFA">

                <h1>Heading 1</h1>
                <h2>Heading 2</h2>
                <h3>Heading 3</h3>
                <h4>Heading 4</h4>
                <h5>Heading 5</h5>
                <h6>Heading 6</h6>
                <p>Paragraph</p>
                <a href="#">Link</a><br>
                <i class="mdi dark mdi-content-save"></i>

                <!--  -->
                <h4><br>btn transparent</h4>
                <!--  -->

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

                <!--  -->
                <h4><br>btn accent</h4>
                <!--  -->

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

                <!--  -->
                <h4><br>btn icon</h4>
                <!--  -->

                <a href="#" class="btn icon ripple"><i class="mdi dark mdi-content-save"></i></a>
                <button class="btn icon ripple"><i class="mdi dark mdi-content-save"></i></button>
                <button class="btn icon ripple" disabled><i class="mdi dark mdi-content-save"></i></button>

                <!--  -->
                <h4><br>btn round</h4>
                <!--  -->

                <!-- Text only -->
                <a href="#" class="btn round ripple">Button</a>
                <button class="btn round ripple">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round ripple">
                    <i class="mdi dark mdi-chevron-down"></i>
                    <p>Button</p>
                </a>
                <button class="btn round ripple">
                    <i class="mdi dark mdi-chevron-down"></i>
                    <p>Button</p>
                </button>
                <button class="btn round ripple" disabled>
                    <i class="mdi dark mdi-chevron-down"></i>
                    <p>Disabled</p>
                </button>

                <!--  -->
                <h4><br>btn fab</h4>
                <!--  -->

                <a href="#" class="btn fab ripple"><i class="mdi light mdi-content-save"></i></a>
                <button class="btn fab ripple"><i class="mdi light mdi-content-save"></i></button>

                <!--  -->
                <h4><br>radio</h4>
                <!--  -->

                <h6>Title</h6>
                <input id="r1" type="radio" class="radio" name="radio-example" value="1" checked/>
                <label for="r1">First option</label><br>
                <input id="r2" type="radio" class="radio" name="radio-example" value="2"/>
                <label for="r2">Second option</label><br>
                <input id="r3" type="radio" class="radio" name="radio-example" value="3" disabled/>
                <label for="r3">Third option (disabled)</label>

                <!--  -->
                <h4><br>check</h4>
                <!--  -->

                <h6>Title</h6>
                <input id="c-toggle" type="checkbox" class="checkbox toggle-all" data-toggle="ce"/>
                <label for="c-toggle">All</label><br>
                <input id="c1" type="checkbox" class="checkbox" name="checkbox-example" value="1" data-toggled-by="ce" checked/>
                <label for="c1">First option</label><br>
                <input id="c2" type="checkbox" class="checkbox" name="checkbox-example" value="2" data-toggled-by="ce"/>
                <label for="c2">Second option</label><br>
                <input id="c3" type="checkbox" class="checkbox" name="checkbox-example" value="3" disabled/>
                <label for="c3">Third option (disabled)</label>

                <!--  -->
                <h4><br>switch</h4>
                <!--  -->

                <input id="s1" type="checkbox" class="switch" name="switch-example" checked>
                <label for="s1">Switch <span class="on">On</span><span class="off">Off</span></label><br>
                <input id="s2" type="checkbox" class="switch" name="switch-example" disabled>
                <label for="s2">Switch <span class="on">On</span><span class="off">Off</span> (disabled)</label>

                <!--  -->
                <h4><br>divider</h4>
                <!--  -->

                <div class="divider dark"></div>

                <!--  -->
                <h4><br>text field</h4>
                <!--  -->

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

                <!--  -->
                <h4><br>text area</h4>
                <!--  -->

                <div class="text-area">
                    <textarea id="textarea"></textarea>
                    <label for="textarea">Text area</label>
                </div>

                <div class="text-area">
                    <textarea id="textarea" disabled></textarea>
                    <label for="textarea">Disabled Text area</label>
                </div>

                <!--  -->
                <h4><br>rich radio</h4>
                <!--  -->

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

                <!--  -->
                <h4><br>pagination</h4>
                <!--  -->

                <ul class="pagination">
                    <li><a href="#" class="btn icon ripple disabled" title="Pagina precedente"><i class="mdi dark mdi-chevron-left"></i></a></li>
                    <li><a href="#" class="selected">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#" class="btn icon ripple" title="Pagina successiva"><i class="mdi dark mdi-chevron-right"></i></a></li>
                </ul>

                <!--  -->
                <h4><br>breadcrumb</h4>
                <!--  -->

                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Library</li>
                </ol>

                <!--  -->
                <h4><br>file input</h4>
                <!--  -->

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

                <!--  -->
                <h4><br>search bar</h4>
                <!--  -->

                <div class="search-bar">
                    <button class="search btn icon ripple" title="Cerca"><i class="mdi dark mdi-magnify"></i></button>
                    <input type="text" placeholder="Cerca..."/>
                    <button class="clear btn icon ripple" title="Cancella" disabled><i class="mdi dark mdi-close"></i></button>
                </div>

                <!--  -->
                <h4><br>collapse</h4>
                <!--  -->

                <button class="btn icon ripple" data-toggle="collapse" data-target="#collapse-example" aria-expanded="false" title="Mostra">
                    <i class="mdi dark mdi-chevron-down"></i>
                </button>
                <div id="collapse-example" class="collapse">
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </p>
                </div>

                <!--  -->
                <h4><br>loading</h4>
                <!--  -->

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

                <br><br><br>

            </div>
            <div class="col-12 col-md-6" style="background-color: #303030">

                <h1 class="text-light">Heading 1</h1>
                <h2 class="text-light">Heading 2</h2>
                <h3 class="text-light">Heading 3</h3>
                <h4 class="text-light">Heading 4</h4>
                <h5 class="text-light">Heading 5</h5>
                <h6 class="text-light">Heading 6</h6>
                <p class="text-light">Paragraph</p>
                <a href="#" class="light">Link</a><br>
                <i class="mdi light mdi-content-save"></i>

                <!--  -->
                <h4 class="text-light"><br>btn transparent</h4>
                <!--  -->

                <!-- Text only -->
                <a href="#" class="btn transparent ripple light">Button</a>
                <button class="btn transparent ripple light">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn transparent ripple light">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </a>
                <button class="btn transparent ripple light">
                    <i class="mdi light mdi-content-save"></i>
                    <p>Button</p>
                </button>
                <button class="btn transparent ripple light" disabled>
                    <i class="mdi light mdi-content-save"></i>
                    <p>Disabled</p>
                </button>

                <!--  -->
                <h4 class="text-light"><br>btn accent</h4>
                <!--  -->

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

                <!--  -->
                <h4 class="text-light"><br>btn icon</h4>
                <!--  -->

                <a href="#" class="btn icon ripple light"><i class="mdi light mdi-content-save"></i></a>
                <button class="btn icon ripple light"><i class="mdi light mdi-content-save"></i></button>
                <button class="btn icon ripple light" disabled><i class="mdi light mdi-content-save"></i></button>

                <!--  -->
                <h4 class="text-light"><br>btn round</h4>
                <!--  -->

                <!-- Text only -->
                <a href="#" class="btn round ripple light">Button</a>
                <button class="btn round ripple light">Button</button>

                <!-- Text + icon -->
                <a href="#" class="btn round ripple light">
                    <i class="mdi light mdi-chevron-down"></i>
                    <p>Button</p>
                </a>
                <button class="btn round ripple light">
                    <i class="mdi light mdi-chevron-down"></i>
                    <p>Button</p>
                </button>
                <button class="btn round ripple light" disabled>
                    <i class="mdi light mdi-chevron-down"></i>
                    <p>Disabled</p>
                </button>

                <!--  -->
                <h4 class="text-light"><br>btn fab</h4>
                <!--  -->

                <a href="#" class="btn fab ripple"><i class="mdi light mdi-content-save"></i></a>
                <button class="btn fab ripple"><i class="mdi light mdi-content-save"></i></button>

                <!--  -->
                <h4 class="text-light"><br>radio</h4>
                <!--  -->

                <h6 class="text-light">Title</h6>
                <input id="rd1" type="radio" class="radio light" name="radio-example2" value="1" checked/>
                <label for="rd1">First option</label><br>
                <input id="rd2" type="radio" class="radio light" name="radio-example2" value="2"/>
                <label for="rd2">Second option</label><br>
                <input id="rd3" type="radio" class="radio light" name="radio-example2" value="3" disabled/>
                <label for="rd3">Third option (disabled)</label>

                <!--  -->
                <h4 class="text-light"><br>check</h4>
                <!--  -->

                <h6 class="text-light">Title</h6>
                <input id="cd-toggle" type="checkbox" class="checkbox light toggle-all" data-toggle="ce2"/>
                <label for="cd-toggle">All</label><br>
                <input id="cd1" type="checkbox" class="checkbox light" name="checkbox-example2" value="1" data-toggled-by="ce2" checked/>
                <label for="cd1">First option</label><br>
                <input id="cd2" type="checkbox" class="checkbox light" name="checkbox-example2" value="2"data-toggled-by="ce2"/>
                <label for="cd2">Second option</label><br>
                <input id="cd3" type="checkbox" class="checkbox light" name="checkbox-example2" value="3" disabled/>
                <label for="cd3">Third option (disabled)</label>

                <!--  -->
                <h4 class="text-light"><br>switch</h4>
                <!--  -->

                <input id="sd1" type="checkbox" class="switch light" name="switch-example2" checked>
                <label for="sd1">Switch <span class="on">On</span><span class="off">Off</span></label><br>
                <input id="sd2" type="checkbox" class="switch light" name="switch-example2" disabled>
                <label for="sd2">Switch <span class="on">On</span><span class="off">Off</span> (disabled)</label>

                <!--  -->
                <h4 class="text-light"><br>divider</h4>
                <!--  -->

                <div class="divider light"></div>

                <!--  -->
                <h4 class="text-light"><br>text field</h4>
                <!--  -->

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

                <!--  -->
                <h4 class="text-light"><br>text area</h4>
                <!--  -->

                <div class="text-area">
                    <textarea id="textarea" class="dark"></textarea>
                    <label for="textarea">Text area</label>
                </div>

                <div class="text-area">
                    <textarea id="textarea" class="dark" disabled></textarea>
                    <label for="textarea">Disabled Text area</label>
                </div>

                <!--  -->
                <h4 class="text-light"><br>rich radio</h4>
                <!--  -->

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

                <!--  -->
                <h4 class="text-light"><br>pagination</h4>
                <!--  -->

                <ul class="pagination light">
                    <li><a href="#" class="btn icon light ripple disabled" title="Pagina precedente"><i class="mdi light mdi-chevron-left"></i></a></li>
                    <li><a href="#" class="selected">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#" class="btn icon light ripple" title="Pagina successiva"><i class="mdi light mdi-chevron-right"></i></a></li>
                </ul>

                <!--  -->
                <h4 class="text-light"><br>breadcrumb</h4>
                <!--  -->

                <ol class="breadcrumb light">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Library</li>
                </ol>

                <!--  -->
                <h4 class="text-light"><br>file input</h4>
                <!--  -->

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

                <!--  -->
                <h4 class="text-light"><br>search bar</h4>
                <!--  -->

                <div class="search-bar dark">
                    <button class="search btn icon ripple" title="Cerca"><i class="mdi dark mdi-magnify"></i></button>
                    <input type="text" placeholder="Cerca..."/>
                    <button class="clear btn icon ripple" title="Cancella" disabled><i class="mdi dark mdi-close"></i></button>
                </div>

                <!--  -->
                <h4 class="text-light"><br>collapse</h4>
                <!--  -->

                <button class="btn icon light ripple" data-toggle="collapse" data-target="#collapse-example2" aria-expanded="false" title="Mostra">
                    <i class="mdi light mdi-chevron-down"></i>
                </button>
                <div id="collapse-example2" class="collapse">
                    <p class="text-light">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </p>
                </div>

                <!--  -->
                <h4 class="text-light"><br>loading</h4>
                <!--  -->

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

            </div>
        </div>
    </div>

    <?php include("scripts.php"); ?>

</body>
</html>