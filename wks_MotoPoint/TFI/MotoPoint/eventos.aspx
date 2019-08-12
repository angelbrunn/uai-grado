<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.Master" AutoEventWireup="true" CodeBehind="eventos.aspx.cs"
    Inherits="MotoPoint.Eventos" %>

<asp:Content ID="MasterNavBar" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="MasterContenidoEventos" ContentPlaceHolderID="body" runat="server">

    <div id="contenedorEventos">
        <div class="card-deck">

            <div class="card">
                <div id="map" style="flex: 1 1 100%;"></div>
                <div class="card-body">

                    <h5 class="card-title">Evento 1 </h5>
                    <p class="card-text">This card has supporting text below as a natural lead-in to additional content.</p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">footer</small>
                </div>
            </div>

            <div class="card">
                <div id="map1" style="flex: 1 1 100%;"></div>
                <div class="card-body">

                    <h5 class="card-title">Evento 2 </h5>
                    <p class="card-text">This card has supporting text below as a natural lead-in to additional content.</p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">footer</small>
                </div>
            </div>

            <div class="card">
                <div id="map2" style="width: 345px; height: 207px;"></div>
                <div class="card-body">

                    <h5 class="card-title">Evento 3 </h5>
                    <p class="card-text">This card has supporting text below as a natural lead-in to additional content.</p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">footer</small>
                </div>
            </div>
        </div>

    </div>

    <script>
        function initMap() {
            var map;
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -34.397, lng: 150.644 },
                zoom: 8
            });

        }
    </script>



</asp:Content>
