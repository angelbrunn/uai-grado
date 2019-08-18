<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.Master" AutoEventWireup="true" CodeBehind="eventos.aspx.cs"
    Inherits="MotoPoint.Eventos" %>

<asp:Content ID="MasterNavBar" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="MasterContenidoEventos" ContentPlaceHolderID="body" runat="server">

    <div id="contenedorEventos">
        <div class="card-deck">

            <div id="Mapa1" class="card" style="box-shadow: 10px 10px 5px grey;">
                <div id="map1" style="width: 100%; height: 207px;"></div>
                <div class="card-body">

                    <h5 class="card-title">
                        <asp:Label ID="lblCodigoEvento1" runat="server" /></h5>
                    <p class="card-text">
                        <asp:Label ID="lblDetalleEvento1" runat="server" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblFechaEvento1" class="lblFechaEvento" runat="server"></asp:Label>
                    </small>
                </div>
            </div>

            <div id="Mapa2" class="card" style="box-shadow: 10px 10px 5px grey;">
                <div id="map2" style="width: 100%; height: 207px;"></div>
                <div class="card-body">

                    <h5 class="card-title">
                        <asp:Label ID="lblCodigoEvento2" runat="server" />
                    </h5>
                    <p class="card-text">
                        <asp:Label ID="lblDetalleEvento2" runat="server" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblFechaEvento2" class="lblFechaEvento" runat="server"></asp:Label>
                    </small>
                </div>
            </div>

            <div id="weather" class="card" style="box-shadow: 10px 10px 5px grey;">
                <div class="card-body">
                    <div id="weatherTitle">
                        <asp:Label ID="lblWeatherTitle" Text="Informacion del Clima" runat="server" />
                    </div>
                    <div class="card-text">
                        <div id="dataWeatherHeader">
                            [
                            <asp:Label ID="lblWeatherHeaderCity" Text="Min" runat="server" />
                            <asp:Label ID="lblWeatherHeaderTempMin" Text="Min" runat="server" />
                            <asp:Label ID="lblWeatherHeaderTempMax" Text="Max" runat="server" />
                            <asp:Label ID="lblWeatherHeaderTmp" Text="Tmp" runat="server" />
                            <asp:Label ID="lblWeatherHeaderHum" Text="Hum (%)" runat="server" />
                            ]
                        </div>
                        <div id="dataWeatherBue">
                            <asp:Image ID="imgCountryFlagBue" runat="server" />
                            <asp:Label ID="lblCityBue" runat="server" />
                            <asp:Label ID="lblBueTempMin" runat="server" />
                            <asp:Label ID="lblBueTempMax" runat="server" />
                            <asp:Label ID="lblBueTempDay" runat="server" />
                            <asp:Label ID="lblBueHumidity" runat="server" />
                            <asp:Image ID="imgWeatherIconBue" runat="server" />
                        </div>

                        <div id="dataWeatherCor">
                            <asp:Image ID="imgCountryFlagMen" runat="server" />
                            <asp:Label ID="lblCityCMen" runat="server" />
                            <asp:Label ID="lblMenTempMin" runat="server" />
                            <asp:Label ID="lblMenTempMax" runat="server" />
                            <asp:Label ID="lblMenTempDay" runat="server" />
                            <asp:Label ID="lblMenHumidity" runat="server" />
                            <asp:Image ID="imgWeatherIconMen" runat="server" />
                        </div>

                        <div id="dataWeatherRos">
                            <asp:Image ID="imgCountryFlagRos" runat="server" />
                            <asp:Label ID="lblCityRos" runat="server" />
                            <asp:Label ID="lblRosTempMin" runat="server" />
                            <asp:Label ID="lblRosTempMax" runat="server" />
                            <asp:Label ID="lblRosTempDay" runat="server" />
                            <asp:Label ID="lblRosHumidity" runat="server" />
                            <asp:Image ID="imgWeatherIconRos" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </br>
        <div class="card-deck">
            <div id="Mapa3" class="card" style="box-shadow: 10px 10px 5px grey;">
                <div id="map3" style="width: 100%; height: 207px;"></div>
                <div class="card-body">

                    <h5 class="card-title">
                        <asp:Label ID="lblCodigoEvento3" runat="server" />
                    </h5>
                    <p class="card-text">
                        <asp:Label ID="lblDetalleEvento3" runat="server" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblFechaEvento3" class="lblFechaEvento" runat="server"></asp:Label>
                    </small>
                </div>
            </div>

            <div id="Mapa4" class="card" style="box-shadow: 10px 10px 5px grey;">
                <div id="map4" style="width: 100%; height: 207px;"></div>
                <div class="card-body">

                    <h5 class="card-title">
                        <asp:Label ID="lblCodigoEvento4" runat="server" />
                    </h5>
                    <p class="card-text">
                        <asp:Label ID="lblDetalleEvento4" runat="server" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblFechaEvento4" class="lblFechaEvento" runat="server"></asp:Label>
                    </small>
                </div>
            </div>

            <div id="Mapa5" class="card" style="box-shadow: 10px 10px 5px grey;">
                <div id="map5" style="width: 345px; height: 207px;"></div>
                <div class="card-body">

                    <h5 class="card-title">
                        <asp:Label ID="lblCodigoEvento5" runat="server" />
                    </h5>
                    <p class="card-text">
                        <asp:Label ID="lblDetalleEvento5" runat="server" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblFechaEvento5" class="lblFechaEvento" runat="server"></asp:Label>
                    </small>
                </div>
            </div>
        </div>
        </br>
        <div class="card-deck">
            <div id="Mapa6" class="card" style="box-shadow: 10px 10px 5px grey;">
                <div id="map6" style="width: 100%; height: 207px;"></div>
                <div class="card-body">

                    <h5 class="card-title">
                        <asp:Label ID="lblCodigoEvento6" runat="server" />
                    </h5>
                    <p class="card-text">
                        <asp:Label ID="lblDetalleEvento6" runat="server" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblFechaEvento6" class="lblFechaEvento" runat="server"></asp:Label>
                    </small>
                </div>
            </div>
        </div>
    </div>
    <script>
        function initMap() {
            var directionsService1 = new google.maps.DirectionsService;
            var directionsDisplay1 = new google.maps.DirectionsRenderer;
            map1 = new google.maps.Map(document.getElementById('map1'), {
                center: { lat: -34.603035, lng: -58.399807 },
                zoom: 8
            });
            directionsDisplay1.setMap(map1);
            calculateAndDisplayRouteMap1(directionsService1, directionsDisplay1);

            var directionsService2 = new google.maps.DirectionsService;
            var directionsDisplay2 = new google.maps.DirectionsRenderer;
            map2 = new google.maps.Map(document.getElementById('map2'), {
                center: { lat: -34.603035, lng: -58.399807 },
                zoom: 8
            });
            directionsDisplay2.setMap(map2);
            calculateAndDisplayRouteMap2(directionsService2, directionsDisplay2);

            var directionsService3 = new google.maps.DirectionsService;
            var directionsDisplay3 = new google.maps.DirectionsRenderer;
            map3 = new google.maps.Map(document.getElementById('map3'), {
                center: { lat: -34.603035, lng: -58.399807 },
                zoom: 8
            });
            directionsDisplay3.setMap(map3);
            calculateAndDisplayRouteMap3(directionsService3, directionsDisplay3);

            var directionsService4 = new google.maps.DirectionsService;
            var directionsDisplay4 = new google.maps.DirectionsRenderer;
            map4 = new google.maps.Map(document.getElementById('map4'), {
                center: { lat: -34.603035, lng: -58.399807 },
                zoom: 8
            });
            directionsDisplay4.setMap(map4);
            calculateAndDisplayRouteMap4(directionsService4, directionsDisplay4);

            var directionsService5 = new google.maps.DirectionsService;
            var directionsDisplay5 = new google.maps.DirectionsRenderer;
            map5 = new google.maps.Map(document.getElementById('map5'), {
                center: { lat: -34.603035, lng: -58.399807 },
                zoom: 8
            });
            directionsDisplay5.setMap(map5);
            calculateAndDisplayRouteMap5(directionsService5, directionsDisplay5);

            var directionsService6 = new google.maps.DirectionsService;
            var directionsDisplay6 = new google.maps.DirectionsRenderer;
            map6 = new google.maps.Map(document.getElementById('map6'), {
                center: { lat: -34.603035, lng: -58.399807 },
                zoom: 8
            });
            directionsDisplay6.setMap(map6);
            calculateAndDisplayRouteMap6(directionsService6, directionsDisplay6);
        }

        function calculateAndDisplayRouteMap1(directionsService, directionsDisplay) {
            var dbMap1Origen = '<%= Session["map1Origen"].ToString() %>';
            var dbMap1Destino = '<%= Session["map1Destino"].ToString() %>';
            directionsService.route({
                origin: dbMap1Origen,
                destination: dbMap1Destino,
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    directionsDisplay.setDirections(response);
                } else {
                    window.alert('Directions request failed due to ' + status);
                }
            });
        }
        function calculateAndDisplayRouteMap2(directionsService, directionsDisplay) {
            var dbMap2Origen = '<%= Session["map2Origen"].ToString() %>';
            var dbMap2Destino = '<%= Session["map2Destino"].ToString() %>';
            directionsService.route({
                origin: dbMap2Origen,
                destination: dbMap2Destino,
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    directionsDisplay.setDirections(response);
                } else {
                    window.alert('Directions request failed due to ' + status);
                }
            });
        }
        function calculateAndDisplayRouteMap3(directionsService, directionsDisplay) {
            var dbMap3Origen = '<%= Session["map3Origen"].ToString() %>';
            var dbMap3Destino = '<%= Session["map3Destino"].ToString() %>';
            directionsService.route({
                origin: dbMap3Origen,
                destination: dbMap3Destino,
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    directionsDisplay.setDirections(response);
                } else {
                    window.alert('Directions request failed due to ' + status);
                }
            });
        }
        function calculateAndDisplayRouteMap4(directionsService, directionsDisplay) {
            var dbMap4Origen = '<%= Session["map4Origen"].ToString() %>';
            var dbMap4Destino = '<%= Session["map4Destino"].ToString() %>';
            directionsService.route({
                origin: dbMap4Origen,
                destination: dbMap4Destino,
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    directionsDisplay.setDirections(response);
                } else {
                    window.alert('Directions request failed due to ' + status);
                }
            });
        }
        function calculateAndDisplayRouteMap5(directionsService, directionsDisplay) {
            var dbMap5Origen = '<%= Session["map5Origen"].ToString() %>';
            var dbMap5Destino = '<%= Session["map5Destino"].ToString() %>';
            directionsService.route({
                origin: dbMap5Origen,
                destination: dbMap5Destino,
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    directionsDisplay.setDirections(response);
                } else {
                    window.alert('Directions request failed due to ' + status);
                }
            });
        }
        function calculateAndDisplayRouteMap6(directionsService, directionsDisplay) {
            var dbMap6Origen = '<%= Session["map6Origen"].ToString() %>';
            var dbMap6Destino = '<%= Session["map6Destino"].ToString() %>';
            directionsService.route({
                origin: dbMap6Origen,
                destination: dbMap6Destino,
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    directionsDisplay.setDirections(response);
                } else {
                    window.alert('Directions request failed due to ' + status);
                }
            });
        }

        var dbMap1Show = '<%= Session["map1Show"].ToString() %>';
        var dbMap2Show = '<%= Session["map2Show"].ToString() %>';
        var dbMap3Show = '<%= Session["map3Show"].ToString() %>';
        var dbMap4Show = '<%= Session["map4Show"].ToString() %>';
        var dbMap5Show = '<%= Session["map5Show"].ToString() %>';
        var dbMap6Show = '<%= Session["map6Show"].ToString() %>';
        if (dbMap1Show == 1) {
            document.getElementById("Mapa1").style.display = 'inline';
        } else {
            document.getElementById("Mapa1").style.display = 'none';
        }
        if (dbMap2Show == 1) {
            document.getElementById("Mapa2").style.display = 'inline';
        } else {
            document.getElementById("Mapa2").style.display = 'none';
        }
        if (dbMap3Show == 1) {
            document.getElementById("Mapa3").style.display = 'inline';
        } else {
            document.getElementById("Mapa3").style.display = 'none';
        }
        if (dbMap4Show == 1) {
            document.getElementById("Mapa4").style.display = 'inline';
        } else {
            document.getElementById("Mapa4").style.display = 'none';
        }
        if (dbMap5Show == 1) {
            document.getElementById("Mapa5").style.display = 'inline';
        } else {
            document.getElementById("Mapa5").style.display = 'none';
        }
        if (dbMap6Show == 1) {
            document.getElementById("Mapa6").style.display = 'inline';
        } else {
            document.getElementById("Mapa6").style.display = 'none';
        }
    </script>
</asp:Content>
