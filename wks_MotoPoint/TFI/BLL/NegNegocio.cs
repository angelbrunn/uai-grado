using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.IO;
using System.Web;
using System.Net.Mime;

namespace SIS.BUSINESS
{
    /// <summary>
    ///  FacadeNegocio | https://www.dofactory.com/net/facade-design-pattern
    /// </summary>
    public class NegNegocio : INegNegocio
    {
        /// <summary>
        /// 
        /// </summary>
        string rutaPDF = System.Web.HttpContext.Current.Server.MapPath("~/Content/FilesMotoPoint/Contingencia/FACTURA/");
        //ESTE SERVICIO WEB DA SERVICIO DE COBRO
        BLL.localhost.Service ws_001 = new BLL.localhost.Service();
        /// <summary>
        /// 
        /// </summary>
        private INegBitacora interfazNegocioBitacora = new NegBitacora();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="numeroSeguridad"></param>
        /// <param name="fechaValidez"></param>
        /// <param name="nombreTitular"></param>
        public void RealizarCobroMembresia(string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular)
        {
            Boolean realizarPagoResultado;
            realizarPagoResultado = ws_001.PagoMembresia(numeroTarjeta, numeroSeguridad, fechaValidez, nombreTitular);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CategoriaMoto> ObtenerCategoriaMoto()
        {
            List<CategoriaMoto> listadoCategoriaMoto = new List<CategoriaMoto>();
            DATOS.DALCategoriaMoto oDalCategoriaMoto = new DATOS.DALCategoriaMoto();
            listadoCategoriaMoto = oDalCategoriaMoto.ObtenerTablaCategoriaMoto();
            return listadoCategoriaMoto;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public int RegistrarMembresiaParaUsuario(string idMembresia, string idUsuario)
        {
            int resultadoValidacion = 1;
            MembresiaUsuario oMembresiaUsuario = new MembresiaUsuario();
            oMembresiaUsuario.IdMembresia = idMembresia;
            oMembresiaUsuario.IdUsuario = idUsuario;

            try
            {
                resultadoValidacion = 0;
                DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
                oDalMembresia.InsertarMembresiaParaUsuario(oMembresiaUsuario);
            }
            catch (Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(idUsuario, oExBLL);
            }
            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoMembresia"></param>
        /// <returns></returns>
        public int ObtenerMembresiaSegunTipo(string tipoMembresia)
        {
            int idMembresia = 0; ;
            string user = "UI";
            DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
            try
            {
                idMembresia = oDalMembresia.ObtenerMembresiaSegunTipo(tipoMembresia);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(user, oExBLL);
            }
            return idMembresia;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoMembresia"></param>
        /// <returns></returns>
        public int ObtenerMembresiaPrecio(string idMembresia)
        {
            int idMembresiaPrecio = 0; ;
            string user = "UI";
            DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
            try
            {
                idMembresiaPrecio = oDalMembresia.ObtenerMembresiaPrecio(idMembresia);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(user, oExBLL);
            }
            return idMembresiaPrecio;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nombreApellido"></param>
        /// <param name="descipcion"></param>
        /// <param name="monto"></param>
        /// <returns></returns>
        public int RegistrarPagoUsuario(string idUsuario, string nombreApellido, string descipcion, string monto)
        {
            int resultadoValidacion = 1;

            PagoUsuario oPagoUsuario = new PagoUsuario();
            oPagoUsuario.IdUsuario = idUsuario;
            oPagoUsuario.NombreApellido = nombreApellido;
            oPagoUsuario.Descripcion = descipcion;
            oPagoUsuario.Monto = monto;
            string fechaPago = DateTime.Now.ToString();
            oPagoUsuario.FechaPago = fechaPago;

            try
            {
                DATOS.DALPago oDalPago = new DATOS.DALPago();
                //NEGOCIO - OBTENER ULTIMO NUMERO DE ORDER 
                int numOrden = oDalPago.ObtenerUltimoNumeroOrden();
                int NumeroOrden = numOrden + 1;
                oPagoUsuario.IdNumeroOrden = NumeroOrden;
                //NEGOCIO - GRABAR PAGO DEL CLIENTE
                List<PagoUsuario> listaPagoUsuario = new List<PagoUsuario>();
                listaPagoUsuario.Add(oPagoUsuario);
                resultadoValidacion = System.Convert.ToInt16(NumeroOrden);
                oDalPago.InsertarPago(listaPagoUsuario);
            }
            catch (Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(idUsuario, oExBLL);
            }
            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="numeroOrden"></param>
        /// <param name="destinatarioEmail"></param>
        /// <param name="estadoPago"></param>
        /// <returns></returns>
        public bool EnviarTicketConfirmacionPago(string idUsuario, int numeroOrden, string destinatarioEmail, string estadoPago)
        {
            bool estado = false;
            string IdSys = "SYS";

            string filename = rutaPDF + "FACTURA" + "-" + numeroOrden + ".pdf";
            Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);

            //NEGOCIO - OBTENER PAGO REALIZADO POR EL CLIENTE
            PagoUsuario oPagoUsuario = new PagoUsuario();
            DATOS.DALPago oDalPago = new DATOS.DALPago();
            oPagoUsuario = oDalPago.ObtenerPagoUsuarioPorNumeroOrden(numeroOrden.ToString());


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("motopointserviciocontacto@gmail.com");
            mail.To.Add(destinatarioEmail);

            mail.Subject = "Sistema de cobro - MOTOPOINT";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("                       MOTOPOINT                                         ");
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("DIRECCION: Buenos Aires, 10012, ARG");
            sb.AppendLine("TELEFONO: + 0800 100 28745");
            sb.AppendLine("EMAIL: motopointserviciocontacto@gmail.com");
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("MONTO: " + oPagoUsuario.Monto.ToString());
            sb.AppendLine("FECHA: " + oPagoUsuario.FechaPago.ToString());
            sb.AppendLine("NUMERO ORDE: " + oPagoUsuario.IdNumeroOrden.ToString());
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("ESTADO: " + estadoPago);
            sb.AppendLine("-------------------------------------------------------------------------");

            mail.Body = sb.ToString(); ;

            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("motopointserviciocontacto@gmail.com", "Motopoint1#_");
            SmtpServer.EnableSsl = true;

            try
            {
                estado = true;
                mail.Attachments.Add(data);
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                estado = false;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }

            return estado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroOrden"></param>
        /// <param name="nombre"></param>
        /// <param name="desc"></param>
        /// <param name="monto"></param>
        public void CrearPDFVoucher(string numeroOrden, string nombre, string desc, string monto)
        {
            string orderNo = "0000" + numeroOrden;
            string orderDate = DateTime.Now.ToString("dd MMM yyyy");

            /*
            string accountNo = "0123456789012";
            string accountName = "John Willion";
            string branch = "Phahon Yothin Branch";
            string bank = "Kasikorn Bank";
            */

            string CustomerName = nombre;
            string Address = "Buenos Aires,AR";

            // Create a Document object
            Document document = new Document(PageSize.A4, 70, 70, 70, 70);

            PdfWriter writer = PdfWriter.GetInstance(document,
                            new FileStream(rutaPDF + "FACTURA" + "-" + numeroOrden + ".pdf", FileMode.Create));

            document.AddTitle("FACTURA -" + numeroOrden);
            document.AddCreator("MOTOPOINT S.A");

            // Abrimos el archivo
            document.Open();

            // First, create our fonts
            var titleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 10, Font.BOLD);
            var bodyFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);
            Rectangle pageSize = writer.PageSize;

            #region Top table
            // Create the header table 
            PdfPTable headertable = new PdfPTable(3);
            headertable.HorizontalAlignment = 0;
            headertable.WidthPercentage = 100;
            headertable.SetWidths(new float[] { 4, 2, 4 });  // then set the column's __relative__ widths
            headertable.DefaultCell.Border = Rectangle.NO_BORDER;

            // DATOS DE MI COMPANIA
            headertable.SpacingAfter = 30;
            PdfPTable nested = new PdfPTable(1);
            nested.DefaultCell.Border = Rectangle.BOX;
            PdfPCell nextPostCell1 = new PdfPCell(new Phrase("MotoPoint .SRL", bodyFont));
            nextPostCell1.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            nested.AddCell(nextPostCell1);
            PdfPCell nextPostCell2 = new PdfPCell(new Phrase("Disp: 1350/93 , Cuit Nº 30-65951462-8", bodyFont));
            nextPostCell2.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            nested.AddCell(nextPostCell2);
            PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Buenos Aires, 10012, ARG", bodyFont));
            nextPostCell3.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            nested.AddCell(nextPostCell3);
            PdfPCell nesthousing = new PdfPCell(nested);
            nesthousing.Rowspan = 4;
            nesthousing.Padding = 0f;
            headertable.AddCell(nesthousing);

            // DATOS DE NRO DE OPERACION, FECHA Y DESTINATARIO
            headertable.AddCell("");
            PdfPCell invoiceCell = new PdfPCell(new Phrase("FACTURA - A", titleFont));
            invoiceCell.HorizontalAlignment = 2;
            invoiceCell.Border = Rectangle.NO_BORDER;
            headertable.AddCell(invoiceCell);
            PdfPCell noCell = new PdfPCell(new Phrase("Num :", bodyFont));
            noCell.HorizontalAlignment = 2;
            noCell.Border = Rectangle.NO_BORDER;
            headertable.AddCell(noCell);
            headertable.AddCell(new Phrase(orderNo, bodyFont));
            PdfPCell dateCell = new PdfPCell(new Phrase("Fecha :", bodyFont));
            dateCell.HorizontalAlignment = 2;
            dateCell.Border = Rectangle.NO_BORDER;
            headertable.AddCell(dateCell);
            headertable.AddCell(new Phrase(orderDate, bodyFont));
            PdfPCell billCell = new PdfPCell(new Phrase("Para :", bodyFont));
            billCell.HorizontalAlignment = 2;
            billCell.Border = Rectangle.NO_BORDER;
            headertable.AddCell(billCell);
            headertable.AddCell(new Phrase(CustomerName + "\n" + Address, bodyFont));
            document.Add(headertable);
            #endregion

            #region Items Table
            //Create body table
            PdfPTable itemTable = new PdfPTable(3);
            itemTable.HorizontalAlignment = 0;
            itemTable.WidthPercentage = 100;
            itemTable.SetWidths(new float[] { 30, 50, 20 });  // then set the column's __relative__ widths
            itemTable.SpacingAfter = 40;
            itemTable.DefaultCell.Border = Rectangle.BOX;


            PdfPCell cell1 = new PdfPCell(new Phrase("NOMBRE Y APELLIDO", boldTableFont));
            cell1.HorizontalAlignment = 1;
            itemTable.AddCell(cell1);
            PdfPCell cell2 = new PdfPCell(new Phrase("DESCRIPCION", boldTableFont));
            cell2.HorizontalAlignment = 1;
            itemTable.AddCell(cell2);
            PdfPCell cell3 = new PdfPCell(new Phrase("MONTO ($ARS)", boldTableFont));
            cell3.HorizontalAlignment = 1;
            itemTable.AddCell(cell3);


            PdfPCell numberCell = new PdfPCell(new Phrase(nombre, bodyFont));
            numberCell.HorizontalAlignment = 1;
            numberCell.PaddingLeft = 10f;
            numberCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            itemTable.AddCell(numberCell);

            PdfPCell descCell = new PdfPCell(new Phrase(desc, bodyFont));
            descCell.HorizontalAlignment = 1;
            descCell.PaddingLeft = 10f;
            descCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            itemTable.AddCell(descCell);

            PdfPCell montoCell = new PdfPCell(new Phrase(monto, bodyFont));
            montoCell.HorizontalAlignment = 1;
            montoCell.PaddingLeft = 10f;
            montoCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            itemTable.AddCell(montoCell);


            // Table footer
            PdfPCell totalAmtCell1 = new PdfPCell(new Phrase(""));
            totalAmtCell1.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
            itemTable.AddCell(totalAmtCell1);
            PdfPCell totalAmtStrCell = new PdfPCell(new Phrase("TOTAL ($ARS)", boldTableFont));
            totalAmtStrCell.Border = Rectangle.TOP_BORDER;   //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
            totalAmtStrCell.HorizontalAlignment = 1;
            itemTable.AddCell(totalAmtStrCell);
            PdfPCell totalAmtCell = new PdfPCell(new Phrase(monto, boldTableFont));
            totalAmtCell.HorizontalAlignment = 1;
            itemTable.AddCell(totalAmtCell);

            PdfPCell cell = new PdfPCell(new Phrase("*** Por favor, tener en cuenta que los montos de esta factura son en Pesos $ Argentinos ARS ***", bodyFont));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1;
            itemTable.AddCell(cell);
            document.Add(itemTable);
            #endregion

            /*
            Chunk transferBank = new Chunk("Your Bank Account:", boldTableFont);
            transferBank.SetUnderline(0.1f, -2f); //0.1 thick, -2 y-location
            document.Add(transferBank);
            document.Add(Chunk.NEWLINE);

            // Bank Account Info
            PdfPTable bottomTable = new PdfPTable(3);
            bottomTable.HorizontalAlignment = 0;
            bottomTable.TotalWidth = 300f;
            bottomTable.SetWidths(new int[] { 90, 10, 200 });
            bottomTable.LockedWidth = true;
            bottomTable.SpacingBefore = 20;
            bottomTable.DefaultCell.Border = Rectangle.NO_BORDER;
            bottomTable.AddCell(new Phrase("Account No", bodyFont));
            bottomTable.AddCell(":");
            bottomTable.AddCell(new Phrase(accountNo, bodyFont));
            bottomTable.AddCell(new Phrase("Account Name", bodyFont));
            bottomTable.AddCell(":");
            bottomTable.AddCell(new Phrase(accountName, bodyFont));
            bottomTable.AddCell(new Phrase("Branch", bodyFont));
            bottomTable.AddCell(":");
            bottomTable.AddCell(new Phrase(branch, bodyFont));
            bottomTable.AddCell(new Phrase("Bank", bodyFont));
            bottomTable.AddCell(":");
            bottomTable.AddCell(new Phrase(bank, bodyFont));
            document.Add(bottomTable);
            */

            //Approved by
            PdfContentByte cb = new PdfContentByte(writer);
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
            cb = writer.DirectContent;
            cb.BeginText();
            cb.SetFontAndSize(bf, 10);
            cb.SetTextMatrix(pageSize.GetLeft(280), 200);
            cb.ShowText("Aprobado!");
            cb.EndText();

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Content/image/logoPdf.svg"));
            logo.SetAbsolutePosition((PageSize.A4.Width - logo.ScaledWidth) / 2, (PageSize.A4.Height - logo.ScaledHeight) / 2);
            document.Add(logo);

            cb = new PdfContentByte(writer);
            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
            cb = writer.DirectContent;
            cb.BeginText();
            cb.SetFontAndSize(bf, 10);
            cb.SetTextMatrix(pageSize.GetLeft(70), 100);
            cb.ShowText("Gracias por la compra! Si tiene alguna pregunta sobre su pedido, contáctenos al 800-333-MOTOPOINT.");
            cb.EndText();

            document.Close();
            writer.Close();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public int ObtenerCodigoMembresiaUsuario(string idUsuario)
        {
            int idMembresia = 0; ;
            string user = "UI";
            DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
            try
            {
                idMembresia = oDalMembresia.ObtenerMembresiaUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(user, oExBLL);
            }
            return idMembresia;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        public int RegistrarMembresiaUsuario(string idUsuario, string idMembresia)
        {
            int resultadoValidacion = 1;
            try
            {
                DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
                oDalMembresia.InsertarMembresiaUsuario(idUsuario, idMembresia);
            }
            catch (Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(idUsuario, oExBLL);
            }
            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        public int ActualizarMembresiaUsuario(string idUsuario, string idMembresia)
        {
            int resultadoValidacion = 1;
            try
            {
                DATOS.DALMembresia oDalMembresia = new DATOS.DALMembresia();
                oDalMembresia.ActualizarMembresiaUsuario(idUsuario, idMembresia);
            }
            catch (Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(idUsuario, oExBLL);
            }
            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreApellido"></param>
        /// <param name="email"></param>
        /// <param name="tipo"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public bool EnviarConsulta(string nombreApellido, string email, string tipo, string descripcion)
        {
            bool estado = false;
            string IdSys = "SYS";
            string contacService = "motopointserviciocontacto@gmail.com";

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("motopointserviciocontacto@gmail.com");
            mail.To.Add(contacService);

            mail.Subject = "Sistema de ayuda - MOTOPOINT";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("                           MOTOPOINT                                     ");
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("CONSULTA TIPO: " + tipo);
            sb.AppendLine("USUARIO NOMBRE Y APELLIDO: " + nombreApellido);
            sb.AppendLine("USUARIO EMAIL: " + email);
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("DESCRIPCION: " + descripcion);
            sb.AppendLine("-------------------------------------------------------------------------");
            mail.Body = sb.ToString(); ;

            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("motopointserviciocontacto@gmail.com", "Motopoint1#_");
            SmtpServer.EnableSsl = true;

            try
            {
                estado = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                estado = false;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }

            return estado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ConsultarLikeUsuario(string codRuta, string usuario)
        {
            bool resultado = true;
            string IdSys = "BLL";
            try
            {
                DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();
                resultado = oDalNegocio.ValidarLikeUsuario(codRuta, usuario);
            }
            catch (Exception ex)
            {
                resultado = false;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }

            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <param name="usuario"></param>
        /// <param name="fechaRuta"></param>
        /// <returns></returns>
        public int RegistrarLikeUsuario(int idRutaLikeUsuario, string codRuta, string usuario, string fechaRuta)
        {
            int resultadoValidacion = 0;
            string IdSys = "BLL";
            try
            {
                DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();
                oDalNegocio.RegistrarLike(idRutaLikeUsuario, codRuta, usuario, fechaRuta);
            }
            catch (Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }
            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <returns></returns>
        public string ObtenerFechaRuta(string codRuta)
        {
            string fecha = "";
            string user = "UI";
            try
            {
                DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();
                fecha = oDalNegocio.ObtenerFecha(codRuta);
            }
            catch (Exception ex)
            {
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(user, oExBLL);
            }
            return fecha;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ObtenerIdLikeUsuario()
        {
            int ultimoIdUsuario = 1;

            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();
            ultimoIdUsuario = oDalNegocio.ObtenerUltimoIdLikeUsuario();

            if (ultimoIdUsuario == 0)
                ultimoIdUsuario = 1;

            ultimoIdUsuario = ultimoIdUsuario + 1;

            return ultimoIdUsuario;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        public void RegistrarVotacionRuta(string codRuta)
        {
            string IdSys = "BLL";
            try
            {
                DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();
                oDalNegocio.RegistrarVotacion(codRuta);
            }
            catch (Exception ex)
            {

                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Ruta> VotacionesUsuario(string usuario)
        {
            List<Ruta> listadoVotacionesUsuario = new List<Ruta>();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();

            listadoVotacionesUsuario = oDalNegocio.ObtenerVotacionesUsuario(usuario);
            return listadoVotacionesUsuario;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        public void BorrarVotacionRutaUsuario(string usuario, string codRuta)
        {
            string IdSys = "BLL";
            try
            {
                DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();
                oDalNegocio.BorrarVotacion(usuario, codRuta);
            }
            catch (Exception ex)
            {

                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        public void DecrementarVotacionRuta(string codRuta)
        {
            string IdSys = "BLL";
            try
            {
                DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();
                oDalNegocio.DecrementarVotacion(codRuta);
            }
            catch (Exception ex)
            {

                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RutaVotacion> DatosRutas()
        {
            List<RutaVotacion> listadoDatosRuta = new List<RutaVotacion>();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();

            listadoDatosRuta = oDalNegocio.ObtenerDatosRutas();
            return listadoDatosRuta;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Evento> DatosEventos()
        {
            List<Evento> listadoDatosEventos = new List<Evento>();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();

            listadoDatosEventos = oDalNegocio.ObtenerDatosEventos();
            return listadoDatosEventos;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RutaVotacion> EstadoVotacion()
        {
            List<RutaVotacion> listadoEstadoVotacion = new List<RutaVotacion>();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();

            listadoEstadoVotacion = oDalNegocio.ObtenerEstadoVotaciones();
            return listadoEstadoVotacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <returns></returns>
        public Ruta ObtenerDetalleRuta(string codRuta)
        {
            Ruta detalleRuta = new Ruta();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();

            detalleRuta = oDalNegocio.ObtenerDetalleRuta(codRuta);
            return detalleRuta;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ActividadPrecio> ObtenerPrecioActividades(string CodAct)
        {
            List<ActividadPrecio> listadoActividadPrecio = new List<ActividadPrecio>();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();

            listadoActividadPrecio = oDalNegocio.ObtenerPrecioActividades(CodAct);
            return listadoActividadPrecio;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <returns></returns>
        public Actividad ObtenerActividad(string codRuta)
        {
            Actividad detalleActividad = new Actividad();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();

            detalleActividad = oDalNegocio.ObtenerActividad(codRuta);
            return detalleActividad;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Ofertas> ObtenerOfertas()
        {
            List<Ofertas> listadoOfertas = new List<Ofertas>();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();

            listadoOfertas = oDalNegocio.ObteneOfetasDisponibles();
            return listadoOfertas;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreApellido"></param>
        /// <param name="emailExperto"></param>
        /// <param name="email"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public bool EnviarConsultaExperto(string nombreApellido, string emailExperto, string email, string descripcion)
        {
            bool estado = false;
            string IdSys = "SYS";
            string contacService = emailExperto;

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("motopointserviciocontacto@gmail.com");
            mail.To.Add(contacService);

            mail.Subject = "Sistema de Experto - MOTOPOINT";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("                           MOTOPOINT                                     ");
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("USUARIO NOMBRE Y APELLIDO: " + nombreApellido);
            sb.AppendLine("USUARIO EMAIL: " + email);
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine("MENSAJE DE LA CONSULTA: " + descripcion);
            sb.AppendLine("-------------------------------------------------------------------------");
            mail.Body = sb.ToString(); ;

            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("motopointserviciocontacto@gmail.com", "Motopoint1#_");
            SmtpServer.EnableSsl = true;

            try
            {
                estado = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                estado = false;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }

            return estado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codExp"></param>
        /// <returns></returns>
        public Experto ObtenerExperto(string codExp)
        {
            Experto detalleExperto = new Experto();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();

            detalleExperto = oDalNegocio.ObteneExperto(codExp);
            return detalleExperto;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Experto> ObtenerExpertoDisponibles()
        {
            List<Experto> listadoExpertos = new List<Experto>();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();

            listadoExpertos = oDalNegocio.ObteneExpertoDisponibles();
            return listadoExpertos;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TarjetaCredito> ObtenerTarjetaCredito()
        {
            List<TarjetaCredito> listadoTarjetaCredito = new List<TarjetaCredito>();
            DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();
            listadoTarjetaCredito = oDalNegocio.ObtenerTarjetasCredito();
            return listadoTarjetaCredito;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="numeroSeguridad"></param>
        /// <param name="fechaValidez"></param>
        /// <param name="nombreTitular"></param>
        /// <param name="saldo"></param>
        /// <returns></returns>
        public int RegistrarTarjetaCredito(TarjetaCredito oTarjetaCredito)
        {
            int resultadoValidacion = 1;
            string idUsuario = "Sys";
            try
            {
                resultadoValidacion = 0;
                DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();
                oDalNegocio.RegistrarTarjetaCredito(oTarjetaCredito.NumeroTarjeta, oTarjetaCredito.NumeroSeguridad, oTarjetaCredito.FechaValidez, oTarjetaCredito.NombreTitular, oTarjetaCredito.Saldo);
            }
            catch (Exception ex)
            {
                resultadoValidacion = 1;
                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(idUsuario, oExBLL);
            }
            return resultadoValidacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saldo"></param>
        public void DecrementarTarjetaCreditoSaldo(string numeroTarjeta, string saldo)
        {
            string IdSys = "BLL";
            try
            {
                DATOS.DALNegocio oDalNegocio = new DATOS.DALNegocio();
                oDalNegocio.DecrementarTarjetaCreditoSaldo(numeroTarjeta, saldo);
            }
            catch (Exception ex)
            {

                EXCEPCIONES.BLLExcepcion oExBLL = new EXCEPCIONES.BLLExcepcion(ex.Message);
                interfazNegocioBitacora.RegistrarEnBitacora_BLL(IdSys, oExBLL);
            }
        }
    }
}
