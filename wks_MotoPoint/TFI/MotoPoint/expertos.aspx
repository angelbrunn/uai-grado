<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.Master" AutoEventWireup="true" CodeBehind="expertos.aspx.cs"
    Inherits="MotoPoint.expertos" meta:resourcekey="PageResource1" %>

<asp:Content ID="MasterNavBar" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MasterContenidoExpertos" ContentPlaceHolderID="body" runat="server">
    <div id="contenedorExpertos">
        <div class="card-deck">
            <div class="card">
                <img class="card-img-top" src="Content/expertos/EXP1.png" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title"><asp:label ID="lblExpertoName1" Text="Pablo Imhoff" runat="server" meta:resourcekey="lblExpertoName1Resource1"></asp:label></h5>
                    <p class="card-text"><asp:label ID="lblExpertoDesc1" runat="server" meta:resourcekey="lblExpertoDesc1Resource1"></asp:label></p>
                </div>
                <asp:Button ID="btnContactoExp1" class="btnVer" runat="server" Text="CONTACTAR" OnClick="btnExperto1_Click" meta:resourcekey="btnContactoExp1Resource1" />
            </div>
            <div class="card">
                <img class="card-img-top" src="Content/expertos/EXP2.jpeg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title"><asp:label ID="lblExpertoName2" Text="Fernando Picasso" runat="server" meta:resourcekey="lblExpertoName2Resource1"></asp:label></h5>
                    <p class="card-text"><asp:label ID="lblExpertoDesc2" runat="server" meta:resourcekey="lblExpertoDesc2Resource1"></asp:label></p>
                </div>
                <asp:Button ID="btnContactoExp2" class="btnVer" runat="server" Text="CONTACTAR" OnClick="btnExperto2_Click" meta:resourcekey="btnContactoExp2Resource1" />
            </div>
            <div class="card">
                <img class="card-img-top" src="Content/expertos/EXP3.jpeg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title"><asp:label ID="lblExpertoName3" Text="Javier Pérez" runat="server" meta:resourcekey="lblExpertoName3Resource1"></asp:label></h5>
                    <p class="card-text"><asp:label ID="lblExpertoDesc3" runat="server" meta:resourcekey="lblExpertoDesc3Resource1"></asp:label></p>
                </div>
                <asp:Button ID="btnContactoExp3" class="btnVer" runat="server" Text="CONTACTAR" OnClick="btnExperto3_Click" meta:resourcekey="btnContactoExp3Resource1" />
            </div>
            <div class="card">
                <img class="card-img-top" src="Content/expertos/EXP4.jpeg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title"><asp:label ID="lblExpertoName4" Text="Valeria Grinblat" runat="server" meta:resourcekey="lblExpertoName4Resource1"></asp:label></h5>
                    <p class="card-text"><asp:label ID="lblExpertoDesc4" runat="server" meta:resourcekey="lblExpertoDesc4Resource1"></asp:label></p>
                </div>
                <asp:Button ID="btnContactoExp4" class="btnVer" runat="server" Text="CONTACTAR" OnClick="btnExperto4_Click" meta:resourcekey="btnContactoExp4Resource1" />
            </div>
        </div>
    </div>
    <!-- Modal04:CONTACTO EXPERTO -->
    <div class="modal fade" id="AvisoModal04" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label class="modal-title" ID="AvisoModalLikeTitulo" Text="Contacte al Experto" runat="server" meta:resourcekey="lblAvisoModalLikeTituloResource1"></asp:Label>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div class="form-group">

                        <asp:Label ID="lblNombre" class="grey-text font-weight-light" Text="Nombre y Apellido" runat="server" meta:resourcekey="lblNombreResource1"></asp:Label>
                        <span>
                            <asp:TextBox ID="txtNombre" class="form-control" runat="server" meta:resourcekey="txtNombreResource1"></asp:TextBox></span>
                        <br />
                        <asp:Label ID="lblEmail" class="grey-text font-weight-light" Text="Email" runat="server" meta:resourcekey="lblEmailResource1"></asp:Label>
                        <span>
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server" meta:resourcekey="txtEmailResource1"></asp:TextBox></span>
                        <br />
                        <asp:Label ID="lblMensaje" class="grey-text font-weight-light" Text="Mensaje" runat="server" meta:resourcekey="lblMensajeResource1"></asp:Label>
                        <span>
                            <asp:TextBox ID="txtMensaje" class="form-control" TextMode="MultiLine" Rows="8" text=" " runat="server" meta:resourcekey="txtMensajeResource1"></asp:TextBox></span>
                    </div>

                </div>
                <div class="modal-footer">
                    <div class="left">
                        <asp:Button ID="btnExpertoCerrar" class="btn btn-secondary" Text="Cerrar" OnClick="Cerrar" runat="server" meta:resourcekey="btnExpertoCerrarResource1" />
                    </div>
                    <div class="fill-remaining-space-no-dotter"></div>
                    <div class="right">
                        <asp:Button ID="btnExpertoEnviar" class="btn btn-secondary" Text="Contactar" OnClick="Contactar" runat="server" meta:resourcekey="btnExpertoEnviarResource1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openModalExperto() {
            $('#AvisoModal04').modal('show');
        }
        function closeModalExperto() {
            $('#AvisoModal04').modal('close');
        }
    </script>
</asp:Content>
