<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs"
    Inherits="MotoPoint.home" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>MotoPoint!</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="Content/css/home.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <!-- FIXME:DESCOMENTAR UNA VEZ ARREGLADO -->
    <!--
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-3.3.1.slim.min.js" type="text/javascript"></script>
    <script src="Scripts/popper.min.js" type="text/javascript"></script>
    -->

    <!-- FIXME: BORRAR PARA DEJAR LOCAL -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

</head>
<body>
    <form id="frmHome" runat="server">
        <!-- INI - NAVEGADOR01 WEBAPP -->
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="#">LOGO</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavDropdown">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="#">Expertos</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Ofertas</a>
                    </li>
                </ul>
                <div id="actPerfil">
                    <ul class="navbar-nav">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Motoquero
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item" href="#">Mi Perfil</a>
                                <a class="dropdown-item" href="#">Salir!</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <!-- INI - NAVEGADOR02 WEBAPP -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <a class="navbar-brand" href="#"></a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="eventos.aspx">Eventos <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Rutas</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Actividades</a>
                    </li>
                </ul>
            </div>
        </nav>

        <br />
        <br />
        <!-- INI - BODY DE LA WEBAPP -->
        <div class="container">
            <h3>Aca desarrollar el home de eventos</h3>
            <p>Basicamente aqui estaran los eventos en curso que ya estan proximos a realizarse o que se estan realizando.</p>
        </div>
        <!-- INI - BODY DE LA WEBAPP -->
        <br />
        <br />
    </form>
</body>
</html>
<!-- INI - FOOTER DE LA WEBAPP 6351ce-->
<footer class="page-footer font-small unique-color-dark">

    <div id="footerHeader">
        <div class="container">

            <!-- Grid row-->
            <div class="row py-4 d-flex align-items-center">

                <!-- Grid column -->
                <div class="col-md-6 col-lg-5 text-center text-md-left mb-4 mb-md-0">
                    <h6 id="footerMsg" class="mb-0">¡Conéctese con nosotros en las redes sociales!</h6>
                </div>
                <!-- Grid column -->

                <!-- Grid column -->
                <div class="col-md-6 col-lg-7 text-center text-md-right">

                    <!-- Facebook -->
                    <a class="fb-ic">
                        <i class="fa fa-facebook white-text mr-4"></i>
                    </a>
                    <!-- Twitter -->
                    <a class="tw-ic">
                        <i class="fa fa-twitter white-text mr-4"></i>
                    </a>
                    <!-- Google +-->
                    <a class="gplus-ic">
                        <i class="fa fa-google-plus white-text mr-4"></i>
                    </a>
                    <!--Linkedin -->
                    <a class="li-ic">
                        <i class="fa fa-linkedin white-text mr-4"></i>
                    </a>
                    <!--Instagram-->
                    <a class="ins-ic">
                        <i class="fa fa-instagram white-text"></i>
                    </a>
                </div>
                <!-- Grid column -->
            </div>
            <!-- Grid row-->
        </div>
    </div>

    <!-- Footer Links -->
    <div class="container text-center text-md-left mt-5">

        <!-- Grid row -->
        <div class="row mt-3">

            <!-- Grid column -->
            <div class="col-md-3 col-lg-4 col-xl-3 mx-auto mb-4">

                <!-- Content -->
                <h6 class="text-uppercase font-weight-bold">Compañia</h6>
                <hr class="deep-purple accent-2 mb-4 mt-0 d-inline-block mx-auto" style="width: 60px;">
                <p>
                    2017-2019. MotoPoint.com.ar S.R.L. Todos los derechos reservados. - Evt: MotoPoint.com.ar - Legajo: 8362 - Disp: 1350/93 - Cuit Nº 30-65951462-8.El titular de los datos personales tiene la facultad de ejercer el derecho de acceso a los mismos en forma gratuita a intervalos no inferiores a seis meses, salvo que se acredite un interés legítimo al efecto conforme lo establecido en el artículo 14, inciso 3 de la Ley Nº 25.326. 
                    La Dirección Nacional de Protección de Datos de Personas, Órgano de Control de la Ley Nº 25.326, tiene la atribución de atender las denuncias y reclamos que se interpongan con relación al incumplimiento de las normas sobre protección de datos personales.
                </p>

            </div>
            <!-- Grid column -->

            <!-- Grid column -->
            <div class="col-md-2 col-lg-2 col-xl-2 mx-auto mb-4">

                <!-- Links -->
                <h6 class="text-uppercase font-weight-bold">Productos</h6>
                <hr class="deep-purple accent-2 mb-4 mt-0 d-inline-block mx-auto" style="width: 60px;">
                <p>
                    <a href="#!">Ofertas</a>
                </p>
                <p>
                    <a href="#!">Expertos</a>
                </p>
                <p>
                    <a href="#!">Membresias</a>
                </p>
            </div>
            <!-- Grid column -->

            <!-- Grid column -->
            <div class="col-md-3 col-lg-2 col-xl-2 mx-auto mb-4">

                <!-- Links -->
                <h6 class="text-uppercase font-weight-bold">Links Utiles</h6>
                <hr class="deep-purple accent-2 mb-4 mt-0 d-inline-block mx-auto" style="width: 60px;">
                <p>
                    <a href="#!">Su cuenta</a>
                </p>
                <p>
                    <a href="#!">Cambie plan</a>
                </p>
                <p>
                    <a href="#!">Ayuda</a>
                </p>

            </div>
            <!-- Grid column -->

            <!-- Grid column -->
            <div class="col-md-4 col-lg-3 col-xl-3 mx-auto mb-md-0 mb-4">

                <!-- Links -->
                <h6 class="text-uppercase font-weight-bold">Contacto</h6>
                <hr class="deep-purple accent-2 mb-4 mt-0 d-inline-block mx-auto" style="width: 60px;">
                <p>
                    <i class="fa fa-home mr-3"></i>New York, NY 10012, US
                </p>
                <p>
                    <i class="fa fa-envelope mr-3"></i>motopoint@gmail.com
                </p>
                <p>
                    <i class="fa fa-phone mr-3"></i>+ 0800 100 28745
                </p>
            </div>
            <!-- Grid column -->
        </div>
        <!-- Grid row -->
    </div>
    <!-- Footer Links -->

    <!-- Copyright -->
    <div class="footer-copyright text-center py-3">
        © 2018 Copyright:
      <a href="https://motopoint.com.ar/">MotoPoint.com</a>
    </div>
    <!-- FIN - FOOTER DE LA WEBAPP -->
    <!-- FIN - FOOTER DE LA WEBAPP -->
</footer>
<script>
    function ExCodeBehindLogOffEvent() {
        document.getElementById("btnLogOff").click();
    }
</script>
