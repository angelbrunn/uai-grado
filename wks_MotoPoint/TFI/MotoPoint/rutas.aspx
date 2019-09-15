<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.Master" AutoEventWireup="true" CodeBehind="rutas.aspx.cs"
    Inherits="MotoPoint.rutas" meta:resourcekey="PageResource1" %>

<asp:Content ID="MasterNavBar" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MasterContenidoRutas" ContentPlaceHolderID="body" runat="server">
    <div id="contenedorRutas">
        <div class="card-deck">
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/rutas/MDQ.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">BS AS - MDQ </h5>
                    <p class="card-text"><asp:Label ID="lblDetalleRutaVotacionMDQ" runat="server" meta:resourcekey="lblDetalleRutaVotacionMDQResource1"></asp:Label></p><span><asp:ImageButton id="btnDetaMDQ01" class="detalleIcon" runat="server" imageUrl="~/Content/image/rutaDetalle.svg" onClick ="btnDetaMDQ_Click" meta:resourcekey="btnDetaMDQ01Resource1" /></span>
                    <p>
                        <asp:Button ID="btnLikeMDQ01" class="btnLike" runat="server" Text="Like" OnClick="btnLikeMDQ_Click" meta:resourcekey="btnLikeMDQ01Resource1" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblMDQ01CantMotos" class="lblCantMotos" runat="server" Text="Motoqueros:" meta:resourcekey="lblMDQ01CantMotosResource1"></asp:Label>
                        <asp:Label ID="lblMDQ01FechaLimite" class="lblFechaCierre" runat="server" Text="Cierre:" meta:resourcekey="lblMDQ01FechaLimiteResource1"></asp:Label>
                        <asp:Label ID="lblMDQ01Estado" class="" runat="server" meta:resourcekey="lblMDQ01EstadoResource1"></asp:Label>
                    </small>
                </div>
            </div>
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/rutas/ATALAYA.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">BS AS - ATALAYA</h5>
                    <p class="card-text"><asp:Label ID="lblDetalleRutaVotacionATA" runat="server" meta:resourcekey="lblDetalleRutaVotacionATAResource1"></asp:Label></p><span><asp:ImageButton id="btnDetaATA01" class="detalleIcon" runat="server" imageUrl="~/Content/image/rutaDetalle.svg" onClick ="btnDetaATA_Click" meta:resourcekey="btnDetaATA01Resource1" /></span>
                    <p>
                        <asp:Button ID="btnLikeATA01" class="btnLike" runat="server" Text="Like" OnClick="btnLikeATA01_Click" meta:resourcekey="btnLikeATA01Resource1" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblATA01CantMotos" class="lblCantMotos" runat="server" Text="Motoqueros:" meta:resourcekey="lblATA01CantMotosResource1"></asp:Label>
                        <asp:Label ID="lblATA01FechaLimite" class="lblFechaCierre" runat="server" Text="Cierre:" meta:resourcekey="lblATA01FechaLimiteResource1"></asp:Label>
                        <asp:Label ID="lblATA01Estado" class="" runat="server" meta:resourcekey="lblATA01EstadoResource1"></asp:Label>
                    </small>
                </div>
            </div>
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/rutas/CORDOBA.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">BS AS - CORDOBA</h5>
                    <p class="card-text"><asp:Label ID="lblDetalleRutaVotacionCOR" runat="server" meta:resourcekey="lblDetalleRutaVotacionCORResource1"></asp:Label></p><span><asp:ImageButton id="btnDetaCOD01" class="detalleIcon" runat="server" imageUrl="~/Content/image/rutaDetalle.svg" onClick ="btnDetaCOD_Click" meta:resourcekey="btnDetaCOD01Resource1" /></span>
                    <p>
                        <asp:Button ID="btnLikeCOD01" class="btnLike" runat="server" Text="Like" OnClick="btnLikeCOD01_Click" meta:resourcekey="btnLikeCOD01Resource1" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblCOD01CantMotos" class="lblCantMotos" runat="server" Text="Motoqueros:" meta:resourcekey="lblCOD01CantMotosResource1"></asp:Label>
                        <asp:Label ID="lblCOD01FechaLimite" class="lblFechaCierre" runat="server" Text="Cierre:" meta:resourcekey="lblCOD01FechaLimiteResource1"></asp:Label>
                        <asp:Label ID="lblCOD01Estado" class="" runat="server" meta:resourcekey="lblCOD01EstadoResource1"></asp:Label>
                    </small>
                </div>
            </div>
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/rutas/ROS.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">BS AS - ROSARIO</h5>
                    <p class="card-text"><asp:Label ID="lblDetalleRutaVotacionROS" runat="server" meta:resourcekey="lblDetalleRutaVotacionROSResource1"></asp:Label></p><span><asp:ImageButton id="btnDetaROS01" class="detalleIcon" runat="server" imageUrl="~/Content/image/rutaDetalle.svg" onClick ="btnDetaROS_Click" meta:resourcekey="btnDetaROS01Resource1" /></span>
                    <p>
                        <asp:Button ID="btnLikeROS01" class="btnLike" runat="server" Text="Like" OnClick="btnLikeROS01_Click" meta:resourcekey="btnLikeROS01Resource1" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblROS01CantMotos" class="lblCantMotos" runat="server" Text="Motoqueros:" meta:resourcekey="lblROS01CantMotosResource1"></asp:Label>
                        <asp:Label ID="lblROS01FechaLimite" class="lblFechaCierre" runat="server" Text="Cierre:" meta:resourcekey="lblROS01FechaLimiteResource1"></asp:Label>
                        <asp:Label ID="lblROS01Estado" class="" runat="server" meta:resourcekey="lblROS01EstadoResource1"></asp:Label>
                    </small>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal01:AVISO DE LIKE -->
    <div class="modal fade" id="AvisoModal01" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="AvisoModalLikeTitulo">Aviso Votación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Usted ya ha dado like a esta Ruta!
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal02:DETALLE DE LA RUTA -->
    <div class="modal fade" id="AvisoModal02" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="AvisoModalDetalleTitulo">Detalle Ruta</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="tituloDetalle"><asp:Label ID="lblDetalleEvento"  Text="Detalle del evento:" runat="server" meta:resourcekey="lblDetalleEventoResource1"></asp:Label></div>
                    <br />
                    <div><asp:Label ID="lblLugarSalida"  Text="Lugar de Salida: " runat="server" meta:resourcekey="lblLugarSalidaResource1"></asp:Label><span><asp:Label ID="lblDetaDesde" class="lblDetalle" runat="server" meta:resourcekey="lblDetaDesdeResource1"></asp:Label></span></div>
                    <div><asp:Label ID="lblLugarLlegada"  Text="Lugar de Llegada: " runat="server" meta:resourcekey="lblLugarLlegadaResource1"></asp:Label><span><asp:Label ID="lblDetaHasta" class="lblDetalle" runat="server" meta:resourcekey="lblDetaHastaResource1"></asp:Label></span></div>
                    <div><asp:Label ID="lblCantMinMont"  Text="Cantidad Minima de motoqueros: " runat="server" meta:resourcekey="lblCantMinMontResource1"></asp:Label><span><asp:Label ID="lblDetaCantMin" class="lblDetalle" runat="server" meta:resourcekey="lblDetaCantMinResource1"></asp:Label></span></div>
                    <div><asp:Label ID="lblCantMaxMont"  Text="Cantidad Maxima de motoqueros: " runat="server" meta:resourcekey="lblCantMaxMontResource1"></asp:Label><span><asp:Label ID="lblDetaCantMax" class="lblDetalle" runat="server" meta:resourcekey="lblDetaCantMaxResource1"></asp:Label></span></div>
                    <br />
                    <p><asp:Label ID="lblNotificacionEvento"  Text="Como siempre cuando se llegue al cupo minimo de la ruta se lanzara el evento, lugar de salida y horario seran enviados via Email!" runat="server" meta:resourcekey="lblNotificacionEventoResource1"></asp:Label></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openModal() {
            $('#AvisoModal01').modal('show');
        }
        function openModalDetalle() {
            $('#AvisoModal02').modal('show');
        }
    </script>
</asp:Content>
