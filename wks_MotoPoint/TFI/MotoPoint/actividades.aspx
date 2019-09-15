<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.Master" AutoEventWireup="true" CodeBehind="actividades.aspx.cs"
    Inherits="MotoPoint.actividades" meta:resourcekey="PageResource1" %>

<asp:Content ID="MasterNavBar" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MasterContenidoActividades" ContentPlaceHolderID="body" runat="server">
    <div id="contenedorActividades">
        <div class="card-deck">
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/actividades/CHASCO.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title" style="text-align: center">
                        <asp:Label ID="lblTituloCHS" Text="QUE HACER EN CHASCOMÚS" meta:resourceKey="lblTituloCHS" runat="server"></asp:Label></h5>
                    <p class="card-text" style="text-align: center">
                        <asp:Label ID="lblDescChs" Text="Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica." runat="server" meta:resourcekey="lblDescChsResource1"></asp:Label>
                    </p>
                </div>
                <asp:Button ID="btnDetalleActCHS01" class="btnVer" runat="server" Text="VER" OnClick="btnActivCHS01_Click" meta:resourcekey="btnDetalleActCHS01Resource1" />
            </div>
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/actividades/MDQ.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title" style="text-align: center">
                        <asp:Label ID="lblTituloMDQ" Text="QUE HACER EN MAR DEL PLATA" runat="server" meta:resourcekey="lblTituloMDQResource1"></asp:Label></h5>
                    <p class="card-text" style="text-align: center">
                        <asp:Label ID="lblDescMdq" Text="Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica." runat="server" meta:resourcekey="lblDescMdqResource1"></asp:Label>
                    </p>
                </div>
                <asp:Button ID="btnDetalleActMDQ01" class="btnVer" runat="server" Text="VER" OnClick="btnActivMDQ01_Click" meta:resourcekey="btnDetalleActMDQ01Resource1" />
            </div>
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/actividades/COR.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title" style="text-align: center">
                        <asp:Label ID="lblTituloCOR" Text="QUE HACER EN CORDOBA" runat="server" meta:resourcekey="lblTituloCORResource1"></asp:Label></h5>
                    <p class="card-text" style="text-align: center">
                        <asp:Label ID="lblDescCor" Text="Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica." runat="server" meta:resourcekey="lblDescCorResource1"></asp:Label>
                    </p>
                </div>
                <asp:Button ID="btnDetalleActCOR01" class="btnVer" runat="server" Text="VER" OnClick="btnActivCOR01_Click" meta:resourcekey="btnDetalleActCOR01Resource1" />
            </div>
            <div class="card" style="box-shadow: 10px 10px 5px grey;">
                <img class="card-img-top" src="Content/actividades/ROS.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title" style="text-align: center">
                        <asp:Label ID="lblTituloROS" Text="QUE HACER EN ROSARIO" runat="server" meta:resourcekey="lblTituloROSResource1"></asp:Label></h5>
                    <p class="card-text" style="text-align: center">
                        <asp:Label ID="lblDescRos" Text="Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica." runat="server" meta:resourcekey="lblDescRosResource1"></asp:Label>
                    </p>
                </div>
                <asp:Button ID="btnDetalleActROS01" class="btnVer" runat="server" Text="VER" OnClick="btnActivROS01_Click" meta:resourcekey="btnDetalleActROS01Resource1" />
            </div>
        </div>
    </div>
    <!-- Modal03:DETALLE DE ACTIVIDADES -->
    <div class="modal fade" id="AvisoModal03" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label class="modal-title" ID="AvisoModalDetalleTitulo" Text="Detalle Actividades" runat="server" meta:resourcekey="lblAvisoModalDetalleTituloResource1"></asp:Label>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="tituloDetalle">
                        <div class="Act">
                            <div id="ActCheck0" class="left">
                                <asp:Label ID="lblListActiv" Text="(Lista de Actividades)" runat="server" meta:resourcekey="lblListActivResource1"></asp:Label>
                            </div>
                            <div class="fill-remaining-space"></div>
                            <div id="ActCheck0Desc" class="right">
                                <asp:Label ID="lblListDeta" Text="(Ver Datalle)" runat="server" meta:resourcekey="lblListDetaResource1"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <!-- LISTA DE ACTIVIDADES-->
                    <div id="ConteinerActividad">
                        <div class="Act">
                            <div id="ActCheck1" class="left">
                                <label class="customcheck">
                                    <asp:CheckBox ID="chkAct1" runat="server" OnCheckedChanged="AddSumaTotalAct1" AutoPostBack="True" meta:resourcekey="chkAct1Resource1" />
                                    <span class="checkmark"></span>
                                    <span>
                                        <asp:Label class="lblPrecio" ID="lblAct1Precio" runat="server" meta:resourcekey="lblAct1PrecioResource1"></asp:Label></span>
                                </label>
                            </div>
                            <div class="fill-remaining-space"></div>
                            <div id="ActCheck1Desc" class="right">
                                <span>
                                    <asp:ImageButton ID="imgAct1" class="detalleIcon" runat="server" ImageUrl="~/Content/image/bill.svg" ToolTip="detalle1" Style="margin: 0 0 12px 0;" meta:resourcekey="imgAct1Resource1" /></span>
                            </div>
                        </div>
                        <div class="Act">
                            <div id="ActCheck2" class="left">
                                <label class="customcheck">
                                    <asp:CheckBox ID="chkAct2" runat="server" OnCheckedChanged="AddSumaTotalAct2" AutoPostBack="True" meta:resourcekey="chkAct2Resource1" />
                                    <span class="checkmark"></span>
                                    <span>
                                        <asp:Label class="lblPrecio" ID="lblAct2Precio" runat="server" meta:resourcekey="lblAct2PrecioResource1"></asp:Label></span>
                                </label>
                            </div>
                            <div class="fill-remaining-space"></div>
                            <div id="ActCheck2Desc" class="right">
                                <span>
                                    <asp:ImageButton ID="imgAct2" class="detalleIcon" runat="server" ImageUrl="~/Content/image/bill.svg" ToolTip="detalle1" Style="margin: 0 0 12px 0;" meta:resourcekey="imgAct2Resource1" /></span>
                            </div>
                        </div>
                        <div class="Act">
                            <div id="ActCheck3" class="left">
                                <label class="customcheck">
                                    <asp:CheckBox ID="chkAct3" runat="server" OnCheckedChanged="AddSumaTotalAct3" AutoPostBack="True" meta:resourcekey="chkAct3Resource1" />
                                    <span class="checkmark"></span>
                                    <span>
                                        <asp:Label class="lblPrecio" ID="lblAct3Precio" runat="server" meta:resourcekey="lblAct3PrecioResource1"></asp:Label></span>
                                </label>
                            </div>
                            <div class="fill-remaining-space"></div>
                            <div id="ActCheck3Desc" class="right">
                                <span>
                                    <asp:ImageButton ID="imgAct3" class="detalleIcon" runat="server" ImageUrl="~/Content/image/bill.svg" ToolTip="detalle1" Style="margin: 0 0 12px 0;" meta:resourcekey="imgAct3Resource1" /></span>
                            </div>
                        </div>
                        <div class="Act">
                            <div id="ActCheck4" class="left">
                                <label class="customcheck">
                                    <asp:CheckBox ID="chkAct4" runat="server" OnCheckedChanged="AddSumaTotalAct4" AutoPostBack="True" meta:resourcekey="chkAct4Resource1" />
                                    <span class="checkmark"></span>
                                    <span>
                                        <asp:Label class="lblPrecio" ID="lblAct4Precio" runat="server" meta:resourcekey="lblAct4PrecioResource1"></asp:Label></span>
                                </label>
                            </div>
                            <div class="fill-remaining-space"></div>
                            <div id="ActCheck4Desc" class="right">
                                <span>
                                    <asp:ImageButton ID="imgAct4" class="detalleIcon" runat="server" ImageUrl="~/Content/image/bill.svg" ToolTip="detalle1" Style="margin: 0 0 12px 0;" meta:resourcekey="imgAct4Resource1" /></span>
                            </div>
                        </div>
                        <div class="Act">
                            <div id="ActResult" class="left">
                                <asp:Label ID="lblActResult" runat="server" Text="Total" meta:resourcekey="lblActResultResource1"></asp:Label>
                            </div>
                            <div class="fill-remaining-space-no-dotter"></div>
                            <div id="ActResultSuma" class="right">
                                $
                                <asp:Label ID="lblResultSumatoria" Text="0" runat="server" meta:resourcekey="lblResultSumatoriaResource1"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="left">
                        <asp:Button ID="btnCerrar" class="btn btn-secondary" Text="Cerrar" OnClick="CleanModal" runat="server" meta:resourcekey="btnCerrarResource1" />
                    </div>
                    <div class="fill-remaining-space-no-dotter"></div>
                    <div class="right">
                        <asp:ImageButton ID="imgComprar" class="detalleIcon" runat="server" ImageUrl="~/Content/image/shopping-bag.svg" ToolTip="Comprar" OnClick="btnComprarActividad" meta:resourcekey="imgComprarResource1"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openModalActividad() {
            $('#AvisoModal03').modal('show');
        }
        function closeModalActividad() {
            $('#AvisoModal03').modal('close');
        }
    </script>
</asp:Content>
