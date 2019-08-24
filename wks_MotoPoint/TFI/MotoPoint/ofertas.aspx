<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.Master" AutoEventWireup="true" CodeBehind="ofertas.aspx.cs"
    Inherits="MotoPoint.ofertas" %>

<asp:Content ID="MasterNavBar" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MasterContenidoOfertas" ContentPlaceHolderID="body" runat="server">
    <div id="contenedorOfertas">
        <div class="CardOfertas">
            <!-- LINEA 1-->
            <div class="card-deck">
                <div class="card">
                    <img class="card-img-top" src="Content/ofertas/AUTOMOTORESDELSUR.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTituloOferta1" runat="server"></asp:Label></h5>
                        <p class="card-text"><asp:Label ID="lblDescOferta1" runat="server"></asp:Label></p>
                    </div>
                    <div class="card-footer">
                        <small class="text-muted"><asp:Label ID="lblFechaOferta1" class="fechaOferta" runat="server"></asp:Label></small>
                    </div>
                </div>
                <div class="card">
                    <img class="card-img-top" src="Content/ofertas/YAMAHA.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTituloOferta2" runat="server"></asp:Label></h5>
                        <p class="card-text"><asp:Label ID="lblDescOferta2" runat="server"></asp:Label></p>
                    </div>
                    <div class="card-footer">
                        <small class="text-muted"><asp:Label ID="lblFechaOferta2" class="fechaOferta" runat="server"></asp:Label></small>
                    </div>
                </div>
                <div class="card">
                    <img class="card-img-top" src="Content/ofertas/ZANELLA.jpg" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTituloOferta3" runat="server"></asp:Label></h5>
                        <p class="card-text"><asp:Label ID="lblDescOferta3" runat="server"></asp:Label></p>
                    </div>
                    <div class="card-footer">
                        <small class="text-muted"><asp:Label ID="lblFechaOferta3" class="fechaOferta" runat="server"></asp:Label></small>
                    </div>
                </div>
                <div class="card">
                    <img class="card-img-top" src="Content/ofertas/PIRELLI.jpg" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTituloOferta4" runat="server"></asp:Label></h5>
                        <p class="card-text"><asp:Label ID="lblDescOferta4" runat="server"></asp:Label></p>
                    </div>
                    <div class="card-footer">
                        <small class="text-muted"><asp:Label ID="lblFechaOferta4" class="fechaOferta" runat="server"></asp:Label></small>
                    </div>
                </div>
            </div>
        </div>
        <!-- LINEA 2-->
        <div class="CardOfertas">
            <div class="card-deck">
                <div class="card">
                    <img class="card-img-top" src="Content/ofertas/ATALAYA.png" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTituloOferta5" runat="server"></asp:Label></h5>
                        <p class="card-text"><asp:Label ID="lblDescOferta5" runat="server"></asp:Label></p>
                    </div>
                    <div class="card-footer">
                        <small class="text-muted"><asp:Label ID="lblFechaOferta5" class="fechaOferta" runat="server"></asp:Label></small>
                    </div>
                </div>
                <div class="card">
                    <img class="card-img-top" src="Content/ofertas/HONDA.jpg" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTituloOferta6" runat="server"></asp:Label></h5>
                        <p class="card-text"><asp:Label ID="lblDescOferta6" runat="server"></asp:Label></p>
                    </div>
                    <div class="card-footer">
                        <small class="text-muted"><asp:Label ID="lblFechaOferta6" class="fechaOferta" runat="server"></asp:Label></small>
                    </div>
                </div>
                <div class="card">
                    <img class="card-img-top" src="Content/ofertas/ACA.jpg" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTituloOferta7" runat="server"></asp:Label></h5>
                        <p class="card-text"><asp:Label ID="lblDescOferta7" runat="server"></asp:Label></p>
                    </div>
                    <div class="card-footer">
                        <small class="text-muted"><asp:Label ID="lblFechaOferta7" class="fechaOferta" runat="server"></asp:Label></small>
                    </div>
                </div>
                <div class="card">
                    <img class="card-img-top" src="Content/ofertas/YPF.jpeg" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTituloOferta8" runat="server"></asp:Label></h5>
                        <p class="card-text"><asp:Label ID="lblDescOferta8" runat="server"></asp:Label></p>
                    </div>
                    <div class="card-footer">
                        <small class="text-muted"><asp:Label ID="lblFechaOferta8" class="fechaOferta" runat ="server"></asp:Label></small>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
