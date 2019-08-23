<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.Master" AutoEventWireup="true" CodeBehind="actividades.aspx.cs"
    Inherits="MotoPoint.actividades" %>

<asp:Content ID="MasterNavBar" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MasterContenidoActividades" ContentPlaceHolderID="body" runat="server">
    <div id="contenedorActividades">
        <div class="card-deck">
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/actividades/CHASCO.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title" style="text-align: center">
                        <asp:Label ID="lblTituloCHS" Text="QUE HACER EN CHASCOMÚS" runat="server"></asp:Label></h5>
                    <p class="card-text" style="text-align: center">
                        <asp:Label ID="lblDescChs" text="Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica." runat="server"></asp:Label>
                    </p>
                </div>
                <asp:Button ID="btnDetalleActCHS01" class="btnVer" runat="server" Text="VER" OnClick="btnActivCHS01_Click" />
            </div>
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/actividades/MDQ.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title" style="text-align: center">
                        <asp:Label ID="lblTituloMDQ" Text="QUE HACER EN MAR DEL PLATA" runat="server"></asp:Label></h5>
                    <p class="card-text" style="text-align: center">
                        <asp:Label ID="lblDescMdq" text="Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica." runat="server"></asp:Label>
                    </p>
                </div>
                <asp:Button ID="btnDetalleActMDQ01" class="btnVer" runat="server" Text="VER" OnClick="btnActivMDQ01_Click" />
            </div>
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/actividades/COR.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title" style="text-align: center">
                        <asp:Label ID="lblTituloCOR" Text="QUE HACER EN CORDOBA" runat="server"></asp:Label></h5>
                    <p class="card-text" style="text-align: center">
                        <asp:Label ID="lblDescCor" text="Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica." runat="server"></asp:Label>
                    </p>
                </div>
                <asp:Button ID="btnDetalleActCOR01" class="btnVer" runat="server" Text="VER" OnClick="btnActivCOR01_Click" />
            </div>
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/actividades/ROS.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title" style="text-align: center">
                        <asp:Label ID="lblTituloROS" Text="QUE HACER EN ROSARIO" runat="server"></asp:Label></h5>
                    <p class="card-text" style="text-align: center">
                        <asp:Label ID="lblDescRos" Text="Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica." runat="server"></asp:Label>
                    </p>
                </div>
                <asp:Button ID="btnDetalleActROS01" class="btnVer" runat="server" Text="VER" OnClick="btnActivROS01_Click" />
            </div>
        </div>
    </div>
    <!-- Modal03:DETALLE DE ACTIVIDADES -->
    <div class="modal fade" id="AvisoModal03" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="AvisoModalDetalleTitulo">Detalle Actividades</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="tituloDetalle">
                        <asp:Label ID="lblDetalleActividades" Text="Detalle del evento:" runat="server"></asp:Label>
                    </div>
                    <br />
                    <div>
                        <asp:Label ID="lblLugarSalida" Text="Lugar de Salida: " runat="server"></asp:Label><span><asp:Label ID="lblDetaDesde" class="lblDetalle" runat="server" Text=""></asp:Label></span>
                    </div>
                    <div>
                        <asp:Label ID="lblLugarLlegada" Text="Lugar de Llegada: " runat="server"></asp:Label><span><asp:Label ID="lblDetaHasta" class="lblDetalle" runat="server" Text=""></asp:Label></span>
                    </div>
                    <div>
                        <asp:Label ID="lblCantMinMont" Text="Cantidad Minima de motoqueros: " runat="server"></asp:Label><span><asp:Label ID="lblDetaCantMin" class="lblDetalle" runat="server" Text=""></asp:Label></span>
                    </div>
                    <div>
                        <asp:Label ID="lblCantMaxMont" Text="Cantidad Maxima de motoqueros: " runat="server"></asp:Label><span><asp:Label ID="lblDetaCantMax" class="lblDetalle" runat="server" Text=""></asp:Label></span>
                    </div>
                    <br />
                    <p>
                        <asp:Label ID="lblNotificacionEvento" Text="Como siempre cuando se llegue al cupo minimo de la ruta se lanzara el evento, lugar de salida y horario seran enviados via Email!" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openModalActividad() {
            $('#AvisoModal03').modal('show');
        }
    </script>
</asp:Content>
