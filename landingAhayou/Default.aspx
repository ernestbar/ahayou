<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAhayouAdmin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- begin #home -->
<%--<div id="home" class="content home" style="background-image:url('Imagenes/landingpage-AHAYOU_01.png'); background-repeat: no-repeat; background-position:center center;background-size:cover;background-attachment:fixed;">--%>
	<div id="home1" class="content" data-scrollview="true"  style="background-image:url('Imagenes/landingpage-AHAYOU_01.png'); background-repeat: no-repeat; background-size:100% 100%;">
	<%--<div class="container">--%>
		<div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel">
			  <div class="carousel-indicators">
				<button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
				<button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
				<button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
			  </div>
			  <div class="carousel-inner">
				<div class="carousel-item active">
				  <img src="img/header-img.jpg" class="d-block w-100" alt="..." >
				  <div class="carousel-caption d-none d-md-block">
					<h5>First slide label</h5>
					<p>Some representative placeholder content for the first slide.</p>
				  </div>
				</div>
				<div class="carousel-item">
				  <img src="img/header-img.jpg" class="d-block w-100" alt="...">
				  <div class="carousel-caption d-none d-md-block">
					<h5>Second slide label</h5>
					<p>Some representative placeholder content for the second slide.</p>
				  </div>
				</div>
				<div class="carousel-item">
				  <img src="img/header-img.jpg" class="d-block w-100" alt="...">
				  <div class="carousel-caption d-none d-md-block">
					<h5>Third slide label</h5>
					<p>Some representative placeholder content for the third slide.</p>
				  </div>
				</div>
			  </div>
			  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
				<span class="carousel-control-prev-icon" aria-hidden="true"></span>
				<span class="visually-hidden">Previous</span>
			  </button>
			  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
				<span class="carousel-control-next-icon" aria-hidden="true"></span>
				<span class="visually-hidden">Next</span>
			  </button>
			</div>
			
		<%--<section class="home">
  <div id="carousel" class="carousel slide" data-ride="carousel">

    <div class="carousel-controls">
      <ol class="carousel-indicators">
        <li data-target="#carousel" data-slide-to="1" style="background-image: url(img/header-img.jpg);"></li>
        <li data-target="#carousel" data-slide-to="2" style="background-image: url(img/slide-2.jpg);"></li>
        <li data-target="#carousel" data-slide-to="3" style="background-image: url(img/slide-3.jpg);"></li>
      </ol>

      <a class="carousel-control-prev" role="button" data-slide="prev" href="#carousel">
        <img src="img/left-arrow.svg" alt="Previous">
      </a>
      <a class="carousel-control-next" role="button" data-slide="next" href="#carousel">
        <img src="img/right-arrow.svg" alt="Next">
      </a>

    </div>
	  
    
    <div class="carousel-inner">
      <div class="carousel-item active" style="background-image: url(img/header-img.jpg);filter:brightness(1);width:100%">
        <div class="container">
         <h1>Streaming con Alma Boliviana</h1>
		<p>Una experiencia mejorada, no te pierdas los estrenos mas anticipados y tus clásicos favoritos.</p>
        </div>
      </div>

      <div class="carousel-item" style="background-image: url(img/slide-2.jpg);">
        <div class="container">
          <h2>I'm Ronda</h2>
          <p>App Developer</p>
        </div>
      </div>

      <div class="carousel-item" style="background-image: url(img/slide-3.jpg);">
        <div class="container">
          <h2>I'm Linda</h2>
          <p>Web Developer</p>
        </div>
      </div>
    </div>
    
  </div>
</section>--%>
				<%--<div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
					<ol class="carousel-indicators">
						<li data-bs-target="#carousel-example-generic" data-bs-slide-to="0" class="active"></li>
						<li data-bs-target="#carousel-example-generic" data-bs-slide-to="1"></li>
						<li data-bs-target="#carousel-example-generic" data-bs-slide-to="2"></li>
					</ol>
					<div class="carousel-inner align-items-lg-center">
						<div class="carousel-item active">
							<img src="img/header-img.jpg" class="w-100 h-100" alt="Carousel 1" />
							<div class="carousel-caption align">
								<h1>Streaming con Alma Boliviana</h1>
								<p>Una experiencia mejorada, no te pierdas los estrenos mas anticipados y tus clásicos favoritos.</p>
							</div>
							
						</div>
						<div class="carousel-item">
							<img src="assets/img/carousel/carousel-2.jpg" class="w-100" alt="Carousel 2" />
							<div class="carousel-caption">
								<h4 class="m-b-5">Caption Title 2</h4>
								<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
							</div>
						</div>
						<div class="carousel-item">
							<img src="assets/img/carousel/carousel-3.jpg" class="w-100" alt="Carousel 3" />
							<div class="carousel-caption">
								<h4 class="m-b-5">Caption Title 3</h4>
								<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
							</div>
						</div>
					</div>
					<a class="carousel-control-prev" href="#carousel-example-generic" role="button" data-bs-slide="prev">
					<i class="fa fa-chevron-left"></i>
					</a>
					<a class="carousel-control-next" href="#carousel-example-generic" role="button" data-bs-slide="next">
					<i class="fa fa-chevron-right"></i>
					</a>
				
				</div>--%>
	<%--</div>--%>
	
</div>
<!-- end #home -->
	
<!-- begin #about -->
<div id="nuevos" class="content" data-scrollview="true"  style="background-image:url('Imagenes/landingpage-AHAYOU_02.png'); background-repeat: no-repeat; background-size: 100% 100%;">
	<!-- begin container -->
	<div class="container">
		<h1 class="content-title text-white">Nuevos agregados</h1>
		
		<div>
			
			<div id="carousel-example-generic1" class="carousel slide" data-ride="carousel">
				<!-- Indicators -->
				<ol class="carousel-indicators">
					<li data-bs-target="#carousel-example-generic" data-bs-slide-to="0" class="active"></li>
					<li data-bs-target="#carousel-example-generic" data-bs-slide-to="1"></li>
					<li data-bs-target="#carousel-example-generic" data-bs-slide-to="2"></li>
				</ol>
				<!-- Wrapper for slides -->
				
				<div class="carousel-inner col-3">
					<div class="carousel-item active">
						<img src="img/header-img.jpg" class="w-100" alt="Carousel 1" />
						<div class="carousel-caption align-top">
							<h1>Streaming con Alma Boliviana</h1>
							<p>Una experiencia mejorada, no te pierdas los estrenos mas anticipados y tus clásicos favoritos.</p>
						</div>
						
					</div>
					<div class="carousel-item">
						<img src="assets/img/carousel/carousel-2.jpg" class="w-100" alt="Carousel 2" />
						<div class="carousel-caption">
							<h4 class="m-b-5">Caption Title 2</h4>
							<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
						</div>
					</div>
					<div class="carousel-item">
						<img src="assets/img/carousel/carousel-3.jpg" class="w-100" alt="Carousel 3" />
						<div class="carousel-caption">
							<h4 class="m-b-5">Caption Title 3</h4>
							<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
						</div>
					</div>
				</div>
				<a class="carousel-control-prev" href="#carousel-example-generic1" role="button" data-bs-slide="prev">
				<i class="fa fa-chevron-left"></i>
				</a>
				<a class="carousel-control-next" href="#carousel-example-generic1" role="button" data-bs-slide="next">
				<i class="fa fa-chevron-right"></i>
				</a>
			</div>
</div>
	</div>
	<!-- end container -->
</div>
<!-- end #about -->



<!-- begin #team -->
<div id="planes" class="content" data-scrollview="true"  style="background-image:url('Imagenes/landingpage-AHAYOU_03.png'); background-repeat: no-repeat; background-size: 100% 100%;">
	<!-- begin container -->
<div class="container">
	<h1 class="content-title text-white">Elije tu Plan</h1>
	
	<!-- begin pricing-table -->
	<ul class="pricing-table pricing-col-4">
		<li class="highlight" data-animation="true" data-animation-type="animate__fadeInUp">
			<div class="pricing-container">
				<h3>Premium</h3>
				<div class="price">
					<div class="price-figure">
						<span class="price-number">$19.99</span>
						<span class="price-tenure">per month</span>
						<span class="price-tenure">per month</span>
						<span class="price-tenure">per month</span>
					</div>
				</div>
				<ul class="features">
					<li>5GB Storage</li>
				</ul>
				<div class="footer">
					<a href="#" class="btn btn-primary btn-theme btn-block">Buy Now</a>
				</div>
			</div>
		</li>
		
	</ul>
</div>
<!-- end container -->
</div>
<!-- end #team -->

<!-- begin #quote -->
<div id="faqs" class="content" data-scrollview="true"  style="background-image:url('Imagenes/landingpage-AHAYOU_04.png'); background-repeat: no-repeat; background-size: 100% 100%;">
	<!-- begin container -->
			<div class="container" data-animation="true" data-animation-type="animate__fadeInDown">
				<h2 class="content-title  text-white">Preguntas Frecuentes</h2>
				<!-- begin accordion -->
				<div class="accordion overflow-hidden rounded" id="faq">
					<!-- begin panel -->
					<div class="accordion-item border-0">
						<div class="accordion-header">
							<button class="accordion-button bg-gray-800 text-white px-3 py-10px fw-bold shadow-none" type="button" data-bs-toggle="collapse" data-bs-target="#faq-1">
								<i class="fa fa-question-circle fa-fw text-theme me-5px"></i> 
								Question 1
							</button>
						</div>
						<div id="faq-1" class="collapse show" data-bs-parent="#faq">
							<div class="accordion-body bg-component">
								<p class="mb-0">
									Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 
									3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod.
									Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et.
									Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. 
									Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic 
									synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
								</p>
							</div>
						</div>
					</div>
					<!-- end card -->
					<!-- begin card -->
					<div class="accordion-item border-0">
						<div class="accordion-header">
							<button class="accordion-button bg-gray-800 text-white px-3 py-10px fw-bold shadow-none" type="button" data-bs-toggle="collapse" data-bs-target="#faq-2">
								<i class="fa fa-question-circle fa-fw text-theme me-5px"></i> 
								Question 2
							</button>
						</div>
						<div id="faq-2" class="collapse" data-bs-parent="#faq">
							<div class="accordion-body bg-component">
								<p class="mb-0">
									Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 
									3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod.
									Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et.
									Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. 
									Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic 
									synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
								</p>
							</div>
						</div>
					</div>
					<!-- end card -->
					<!-- begin card -->
					<div class="accordion-item border-0">
						<div class="accordion-header">
							<button class="accordion-button bg-gray-800 text-white px-3 py-10px fw-bold shadow-none" type="button" data-bs-toggle="collapse" data-bs-target="#faq-3">
								<i class="fa fa-question-circle fa-fw text-theme me-5px"></i> 
								Question 3
							</button>
						</div>
						<div id="faq-3" class="collapse" data-bs-parent="#faq">
							<div class="accordion-body bg-component rounded-bottom">
								<p class="mb-0">
									Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 
									3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod.
									Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et.
									Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. 
									Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic 
									synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
								</p>
							</div>
						</div>
					</div>
					<!-- end card -->
				</div>
				<!-- end accordion -->
			</div>
			<!-- end container -->
</div>
<!-- end #quote -->

<!-- beign #service -->
<div id="service" class="content" data-scrollview="true"  style="background-image:url('Imagenes/landingpage-AHAYOU_05.png'); background-repeat: no-repeat; background-size: 100% 100%;">
	<!-- begin container -->
	<div class="container">
		<h1 class="content-title text-white">Descarga la Web App</h1>
		<p class="content-desc">
			Con esta PWA, tendrá un sitio web que se comporta como si fuera<br />
			una aplicacion movil ahorrando espacio en tu dispositivo.
		</p>
		<!-- begin row -->
		<div class="row col-12" style="align-content:center">
				<div class="form-floating col-6">
					<input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">
					<label for="floatingInput">Correo Electronico</label>
				</div>
				<div class="col-auto">
					<button type="submit" class="btn btn-orange fw-bold">Suscribete</button>
				</div>
		</div>
		<!-- end row -->
	</div>
	<!-- end container -->
</div>
<!-- end #service -->

</asp:Content>
