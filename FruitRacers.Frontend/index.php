<!doctype html>
<html lang="it">
<head>
	<?php include("head.php"); ?>
	<title>Fruitracers - Home</title>
</head>
<body>
	<div>

		<?php include("menu.php"); ?>

		<!-- HOME -->
		<section id="home" class="parallax-container d-flex justify-content-center align-items-center" data-section="home">
			<div class="container">
				<div class="row">
					<div class="col-0 col-lg-3"></div>
					<div class="col-12 col-lg-6">
						<a href="index.php"><img class="img-fluid" src="images/logo/fruitracers_logo_muted_shadow.png"></a>
					</div>
					<div class="col-0 col-lg-3"></div>
				</div>
			</div>
			<div class="bottom-links mb-4">
				<button class="btn round light ripple">Accedi o registrati</button>
			</div>
			<div class="parallax shade" data-parallax-image="images/home.jpg"></div>
		</section>
		<section id="highlights" class="container py-4" data-section="home">
			<h2 class="text-center m-0 mb-4">PRODOTTI IN EVIDENZA</h2>
			<div class="row">
				<?php
				for ($i = 0; $i < 8; $i++) {
					?>
					<div class="col-6 col-md-4 col-lg-3">
						<div class="product-card mb-4">
							<div class="product-image">
								<a href="#">
									<div class="fixed-ratio fr-1-1" style="background-image: url('images/example_product.jpg');"></div>
								</a>
							</div>
							<div class="product-content p-3">
								<div class="product-info">
									<h6 class="product-name font-weight-bold mb-1">Product name</h6>
									<a href="#" class="company-name">Company name</a>
								</div>
								<div class="product-price d-flex justify-content-between align-items-center mt-2">
									<span class="text-sec-dark">€00,00 / kg</span>
									<button class="add-to-cart btn icon ripple"><i class="mdi dark mdi-cart"></i></button>
								</div>
							</div>
						</div>
					</div>
					<?php
				}
				?>
			</div>
		</section>

		<!-- Chi siamo -->
		<section id="who" class="parallax-container header d-flex justify-content-center align-items-center" data-section="who">
			<div class="text-center">
				<h1 class="text-light">CHI SIAMO</h1>
			</div>
			<div class="parallax shade" data-parallax-image="images/who.jpg"></div>
		</section>
		<section id="who-content" class="container py-4" data-section="who">
			<div class="row">
				<div class="col">
					<p>
						Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
					</p>
					<p>
						Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
					</p>
					<p>
						Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
					</p>
					<p>
						Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
					</p>
				</div>
			</div>
		</section>

		<!-- Contatti -->
		<section id="contacts" class="parallax-container header d-flex justify-content-center align-items-center" data-section="contacts">
			<div class="text-center">
				<h1 class="text-light">CONTATTI</h1>
			</div>
			<div class="parallax shade" data-parallax-image="images/contacts.jpg"></div>
		</section>
		<section id="contacts-content" class="container py-4" data-section="contacts">
			<div class="row">
				<div class="col">
					<p>
						Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
					</p>
					<p>
						Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
					</p>
					<p>
						Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
					</p>
					<p>
						Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
					</p>
				</div>
			</div>
		</section>

		<!-- Dove trovarci -->
		<section id="companies" class="parallax-container header d-flex justify-content-center align-items-center" data-section="companies">
			<div class="text-center">
				<h1 class="text-light">AZIENDE</h1>
			</div>
			<div class="parallax shade" data-parallax-image="images/where.jpg"></div>
		</section>
		<section id="companies-content" class="container py-4" data-section="companies">
			<div class="container">
				<div class="row">
					<div class="col-12 col-md-8">
						<div class="fixed-ratio fr-4-3">
							<!-- <div id="map">
								<script>
									var map;
									function initMap() {
										map = new google.maps.Map(document.getElementById('map'), {
											center: {lat: -34.397, lng: 150.644},
											zoom: 8
										});
									}
							    </script>
							</div> -->
							<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d91609.89225232352!2d12.192423981391768!3d44.14917995506394!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x132ca4d41ed493c1%3A0xbee0ab1075577a47!2sCesena%20FC!5e0!3m2!1sit!2sit!4v1571049543493!5m2!1sit!2sit" id="map" frameborder="0" allowfullscreen=""></iframe>
						</div>
					</div>
					<div class="col-12 col-md-4">
						<br>
						<h5>Cesena</h5>
						<p>Viale della Via 123</p>
					</div>
				</div>
			</div>
		</section>
	</div>

	<?php include("footer.php"); ?>

	<?php include("scripts.php"); ?>
	<!-- <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap" async defer></script> -->

</body>
</html>