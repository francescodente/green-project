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
                <input id="c1" type="checkbox" class="checkbox" name="checkbox-example" value="1" checked/>
                <label for="c1">First option</label><br>
                <input id="c2" type="checkbox" class="checkbox" name="checkbox-example" value="2"/>
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
                    <label for="password">Password</label>
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
                    <li><a href="#" class="btn icon ripple disabled"><i class="mdi dark mdi-chevron-left"></i></a></li>
                    <li><a href="#" class="selected">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#" class="btn icon ripple"><i class="mdi dark mdi-chevron-right"></i></a></li>
                </ul>

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
                <input id="cd1" type="checkbox" class="checkbox light" name="checkbox-example2" value="1" checked/>
                <label for="cd1">First option</label><br>
                <input id="cd2" type="checkbox" class="checkbox light" name="checkbox-example2" value="2"/>
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
                    <input id="email" type="email" class="dark" value="prova"/>
                    <label for="email">Email</label>
                </div>

                <div class="text-input">
                    <input id="password" type="password" class="dark"/>
                    <label for="password">Password</label>
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
                    <li><a href="#" class="btn icon light ripple disabled"><i class="mdi light mdi-chevron-left"></i></a></li>
                    <li><a href="#" class="selected">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#" class="btn icon light ripple"><i class="mdi light mdi-chevron-right"></i></a></li>
                </ul>

            </div>
        </div>
    </div>

    <?php include("scripts.php"); ?>

</body>
</html>