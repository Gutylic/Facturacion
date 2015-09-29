using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Facturacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
            PuntoVenta.SelectedIndex = 0;
        }

        int TipoDocumento;
        string Documento;
        
        public string CUIT_Correcto(string valor1, string valor2, string valor3)
        {            

            if (valor1 == string.Empty && valor2 == string.Empty && valor3 == string.Empty)
            {                
                return "0";
            }

            try
            {
                int Analizar1 = int.Parse(valor1);
                int Analizar2 = int.Parse(valor2);
                int Analizar3 = int.Parse(valor3);
            }
            catch
            {
                return "-1";
            }


            if (valor1.Length != 2 || valor3.Length != 1)
            {
                return "-1";
            }
            
            return valor1 + valor2 + valor3;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (TipoFactura.SelectedItem == null)
            {
                MessageBox.Show("Es obligatorio un tipo de factura");
                return;
            }
            
            if (Correo.Text == string.Empty)
            {
                MessageBox.Show("Es obligatorio el correo electrónico en una factura digital");
                return;
            }
            
            try
            {
                var addr = new System.Net.Mail.MailAddress(Correo.Text);
            }
            catch
            {
                MessageBox.Show("No tiene forma de correo electrónico");
                return;
            }

            int Lote;

            if (C1.Text == string.Empty)
            {
                Lote = 0;
            }
            else
            {
                if (C2.Text == string.Empty)
                {
                    Lote = 1;
                }
                else
                {
                    if (C3.Text == string.Empty)
                    {
                        Lote = 2;
                    }
                    else
                    {
                        if (C4.Text == string.Empty)
                        {
                            Lote = 3;
                        }
                        else
                        {
                            if (C5.Text == string.Empty)
                            {
                                Lote = 4;
                            }
                            else
                            {
                                if (C6.Text == string.Empty)
                                {
                                    Lote = 5;
                                }
                                else
                                {
                                    if (C7.Text == string.Empty)
                                    {
                                        Lote = 6;
                                    }
                                    else
                                    {
                                        if (C8.Text == string.Empty)
                                        {
                                            Lote = 7;
                                        }
                                        else
                                        {
                                            if (C9.Text == string.Empty)
                                            {
                                                Lote = 8;
                                            }
                                            else
                                            {
                                                if (C10.Text == string.Empty)
                                                {
                                                    Lote = 9;
                                                }
                                                else
                                                {
                                                    Lote = 10;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (Lote == 0)
            {
                return;
            }

            if (Lote == 1)
            {
                try
                {
                    I1.Text = (Convert.ToDecimal(C1.Text) * Convert.ToDecimal(PU1.Text)).ToString();
                    I11.Text = I1.Text;
                }
                catch
                {
                    MessageBox.Show("Debe escribir números en la factura");
                    return;
                }

            }

            if (Lote == 2)
            {
                try
                {
                    I1.Text = (Convert.ToDecimal(C1.Text) * Convert.ToDecimal(PU1.Text)).ToString();
                    I2.Text = (Convert.ToDecimal(C2.Text) * Convert.ToDecimal(PU2.Text)).ToString();
                    I11.Text = (Convert.ToDecimal(I1.Text) + Convert.ToDecimal(I2.Text)).ToString();
                }
                catch
                {
                    MessageBox.Show("Debe escribir números en la factura");
                    return;
                }

            }

            if (Lote == 3)
            {
                try
                {
                    I1.Text = (Convert.ToDecimal(C1.Text) * Convert.ToDecimal(PU1.Text)).ToString();
                    I2.Text = (Convert.ToDecimal(C2.Text) * Convert.ToDecimal(PU2.Text)).ToString();
                    I3.Text = (Convert.ToDecimal(C3.Text) * Convert.ToDecimal(PU3.Text)).ToString();
                    I11.Text = (Convert.ToDecimal(I1.Text) + Convert.ToDecimal(I2.Text) + Convert.ToDecimal(I3.Text)).ToString();
                }
                catch
                {
                    MessageBox.Show("Debe escribir números en la factura");
                    return;
                }

            }

            if (Lote == 4)
            {
                try
                {
                    I1.Text = (Convert.ToDecimal(C1.Text) * Convert.ToDecimal(PU1.Text)).ToString();
                    I2.Text = (Convert.ToDecimal(C2.Text) * Convert.ToDecimal(PU2.Text)).ToString();
                    I3.Text = (Convert.ToDecimal(C3.Text) * Convert.ToDecimal(PU3.Text)).ToString();
                    I4.Text = (Convert.ToDecimal(C4.Text) * Convert.ToDecimal(PU4.Text)).ToString();
                    I11.Text = (Convert.ToDecimal(I1.Text) + Convert.ToDecimal(I2.Text) + Convert.ToDecimal(I3.Text)
                        + Convert.ToDecimal(I4.Text)).ToString();
                }
                catch
                {
                    MessageBox.Show("Debe escribir números en la factura");
                    return;
                }

            }

            if (Lote == 5)
            {
                try
                {
                    I1.Text = (Convert.ToDecimal(C1.Text) * Convert.ToDecimal(PU1.Text)).ToString();
                    I2.Text = (Convert.ToDecimal(C2.Text) * Convert.ToDecimal(PU2.Text)).ToString();
                    I3.Text = (Convert.ToDecimal(C3.Text) * Convert.ToDecimal(PU3.Text)).ToString();
                    I4.Text = (Convert.ToDecimal(C4.Text) * Convert.ToDecimal(PU4.Text)).ToString();
                    I5.Text = (Convert.ToDecimal(C5.Text) * Convert.ToDecimal(PU5.Text)).ToString();
                    I11.Text = (Convert.ToDecimal(I1.Text) + Convert.ToDecimal(I2.Text) + Convert.ToDecimal(I3.Text)
                        + Convert.ToDecimal(I4.Text) + Convert.ToDecimal(I5.Text)).ToString();
                }
                catch
                {
                    MessageBox.Show("Debe escribir números en la factura");
                    return;
                }

            }

            if (Lote == 6)
            {
                try
                {
                    I1.Text = (Convert.ToDecimal(C1.Text) * Convert.ToDecimal(PU1.Text)).ToString();
                    I2.Text = (Convert.ToDecimal(C2.Text) * Convert.ToDecimal(PU2.Text)).ToString();
                    I3.Text = (Convert.ToDecimal(C3.Text) * Convert.ToDecimal(PU3.Text)).ToString();
                    I4.Text = (Convert.ToDecimal(C4.Text) * Convert.ToDecimal(PU4.Text)).ToString();
                    I5.Text = (Convert.ToDecimal(C5.Text) * Convert.ToDecimal(PU5.Text)).ToString();
                    I6.Text = (Convert.ToDecimal(C6.Text) * Convert.ToDecimal(PU6.Text)).ToString();
                    I11.Text = (Convert.ToDecimal(I1.Text) + Convert.ToDecimal(I2.Text) + Convert.ToDecimal(I3.Text)
                        + Convert.ToDecimal(I4.Text) + Convert.ToDecimal(I5.Text) + Convert.ToDecimal(I6.Text)).ToString();
                }
                catch
                {
                    MessageBox.Show("Debe escribir números en la factura");
                    return;
                }

            }

            if (Lote == 7)
            {
                try
                {
                    I1.Text = (Convert.ToDecimal(C1.Text) * Convert.ToDecimal(PU1.Text)).ToString();
                    I2.Text = (Convert.ToDecimal(C2.Text) * Convert.ToDecimal(PU2.Text)).ToString();
                    I3.Text = (Convert.ToDecimal(C3.Text) * Convert.ToDecimal(PU3.Text)).ToString();
                    I4.Text = (Convert.ToDecimal(C4.Text) * Convert.ToDecimal(PU4.Text)).ToString();
                    I5.Text = (Convert.ToDecimal(C5.Text) * Convert.ToDecimal(PU5.Text)).ToString();
                    I6.Text = (Convert.ToDecimal(C6.Text) * Convert.ToDecimal(PU6.Text)).ToString();
                    I7.Text = (Convert.ToDecimal(C7.Text) * Convert.ToDecimal(PU7.Text)).ToString();
                    I11.Text = (Convert.ToDecimal(I1.Text) + Convert.ToDecimal(I2.Text) + Convert.ToDecimal(I3.Text)
                        + Convert.ToDecimal(I4.Text) + Convert.ToDecimal(I5.Text) + Convert.ToDecimal(I6.Text)
                        + Convert.ToDecimal(I7.Text)).ToString();
                }
                catch
                {
                    MessageBox.Show("Debe escribir números en la factura");
                    return;
                }

            }

            if (Lote == 8)
            {
                try
                {
                    I1.Text = (Convert.ToDecimal(C1.Text) * Convert.ToDecimal(PU1.Text)).ToString();
                    I2.Text = (Convert.ToDecimal(C2.Text) * Convert.ToDecimal(PU2.Text)).ToString();
                    I3.Text = (Convert.ToDecimal(C3.Text) * Convert.ToDecimal(PU3.Text)).ToString();
                    I4.Text = (Convert.ToDecimal(C4.Text) * Convert.ToDecimal(PU4.Text)).ToString();
                    I5.Text = (Convert.ToDecimal(C5.Text) * Convert.ToDecimal(PU5.Text)).ToString();
                    I6.Text = (Convert.ToDecimal(C6.Text) * Convert.ToDecimal(PU6.Text)).ToString();
                    I7.Text = (Convert.ToDecimal(C7.Text) * Convert.ToDecimal(PU7.Text)).ToString();
                    I8.Text = (Convert.ToDecimal(C8.Text) * Convert.ToDecimal(PU8.Text)).ToString();
                    I11.Text = (Convert.ToDecimal(I1.Text) + Convert.ToDecimal(I2.Text) + Convert.ToDecimal(I3.Text)
                        + Convert.ToDecimal(I4.Text) + Convert.ToDecimal(I5.Text) + Convert.ToDecimal(I6.Text)
                        + Convert.ToDecimal(I7.Text) + Convert.ToDecimal(I8.Text)).ToString();
                }
                catch
                {
                    MessageBox.Show("Debe escribir números en la factura");
                    return;
                }

            }

            if (Lote == 9)
            {
                try
                {
                    I1.Text = (Convert.ToDecimal(C1.Text) * Convert.ToDecimal(PU1.Text)).ToString();
                    I2.Text = (Convert.ToDecimal(C2.Text) * Convert.ToDecimal(PU2.Text)).ToString();
                    I3.Text = (Convert.ToDecimal(C3.Text) * Convert.ToDecimal(PU3.Text)).ToString();
                    I4.Text = (Convert.ToDecimal(C4.Text) * Convert.ToDecimal(PU4.Text)).ToString();
                    I5.Text = (Convert.ToDecimal(C5.Text) * Convert.ToDecimal(PU5.Text)).ToString();
                    I6.Text = (Convert.ToDecimal(C6.Text) * Convert.ToDecimal(PU6.Text)).ToString();
                    I7.Text = (Convert.ToDecimal(C7.Text) * Convert.ToDecimal(PU7.Text)).ToString();
                    I8.Text = (Convert.ToDecimal(C8.Text) * Convert.ToDecimal(PU8.Text)).ToString();
                    I9.Text = (Convert.ToDecimal(C9.Text) * Convert.ToDecimal(PU9.Text)).ToString();
                    I11.Text = (Convert.ToDecimal(I1.Text) + Convert.ToDecimal(I2.Text) + Convert.ToDecimal(I3.Text)
                        + Convert.ToDecimal(I4.Text) + Convert.ToDecimal(I5.Text) + Convert.ToDecimal(I6.Text)
                        + Convert.ToDecimal(I7.Text) + Convert.ToDecimal(I8.Text) + Convert.ToDecimal(I9.Text)).ToString();
                }
                catch
                {
                    MessageBox.Show("Debe escribir números en la factura");
                    return;
                }

            }

            if (Lote == 10)
            {
                try
                {
                    I1.Text = (Convert.ToDecimal(C1.Text) * Convert.ToDecimal(PU1.Text)).ToString();
                    I2.Text = (Convert.ToDecimal(C2.Text) * Convert.ToDecimal(PU2.Text)).ToString();
                    I3.Text = (Convert.ToDecimal(C3.Text) * Convert.ToDecimal(PU3.Text)).ToString();
                    I4.Text = (Convert.ToDecimal(C4.Text) * Convert.ToDecimal(PU4.Text)).ToString();
                    I5.Text = (Convert.ToDecimal(C5.Text) * Convert.ToDecimal(PU5.Text)).ToString();
                    I6.Text = (Convert.ToDecimal(C6.Text) * Convert.ToDecimal(PU6.Text)).ToString();
                    I7.Text = (Convert.ToDecimal(C7.Text) * Convert.ToDecimal(PU7.Text)).ToString();
                    I8.Text = (Convert.ToDecimal(C8.Text) * Convert.ToDecimal(PU8.Text)).ToString();
                    I9.Text = (Convert.ToDecimal(C9.Text) * Convert.ToDecimal(PU9.Text)).ToString();
                    I10.Text = (Convert.ToDecimal(C10.Text) * Convert.ToDecimal(PU10.Text)).ToString();
                    I11.Text = (Convert.ToDecimal(I1.Text) + Convert.ToDecimal(I2.Text) + Convert.ToDecimal(I3.Text)
                        + Convert.ToDecimal(I4.Text) + Convert.ToDecimal(I5.Text) + Convert.ToDecimal(I6.Text)
                        + Convert.ToDecimal(I7.Text) + Convert.ToDecimal(I8.Text) + Convert.ToDecimal(I9.Text) + Convert.ToDecimal(I10.Text)).ToString();
                }
                catch
                {
                    MessageBox.Show("Debe escribir números en la factura");
                    return;
                }

            }


            try
            {

                if ((Convert.ToDecimal(I11.Text) - Convert.ToDecimal(I12.Text)) > Convert.ToDecimal(I12.Text))
                {
                    I13.Text = (Convert.ToDecimal(I11.Text) - Convert.ToDecimal(I12.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("El descuento es mayor que la compra");
                    return;
                }
            }

            catch
            {
                MessageBox.Show("Debe escribir números en la factura");
                return;
            }


            int Valor = TipoFactura.SelectedIndex;
           
            switch (Valor)
            {
                case 0:
                    Documento = CUIT_Correcto(PrimeroCUIT.Text, DocumentoCUIT.Text, SegundoCUIT.Text);
                    if (Documento == "-1")
                    {
                        MessageBox.Show("No tiene forma de CUIT");
                        return;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) < 1000)
                    {
                        TipoDocumento = 99;                       
                        break;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) > 1000)
                    {
                        MessageBox.Show("Las facturas C de más de $ 1.000 necesitan CUIT");
                        return;
                    }

                    TipoDocumento = 80;                    
                    break;
                case 1:
                    Documento = CUIT_Correcto(PrimeroCUIT.Text, DocumentoCUIT.Text, SegundoCUIT.Text);
                    if (Documento == "-1")
                    {
                        MessageBox.Show("No tiene forma de CUIT");
                        return;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) < 1000)
                    {
                        TipoDocumento = 99;                        
                        break;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) > 1000)
                    {
                        MessageBox.Show("Las facturas C de más de $ 1.000 necesitan CUIT");
                        return;
                    }

                    TipoDocumento = 80;  
                    break;
                case 2:
                    Documento = CUIT_Correcto(PrimeroCUIT.Text, DocumentoCUIT.Text, SegundoCUIT.Text);
                    if (Documento == "-1")
                    {
                        MessageBox.Show("No tiene forma de CUIT");
                        return;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) < 1000)
                    {
                        TipoDocumento = 99;                    
                        break;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) > 1000)
                    {
                        MessageBox.Show("Las facturas B de más de $ 1.000 necesitan CUIT");
                        return;
                    }

                    TipoDocumento = 80;                    
                    break;
                   
                case 3:
                    Documento = CUIT_Correcto(PrimeroCUIT.Text, DocumentoCUIT.Text, SegundoCUIT.Text);
                    if (Documento == "-1")
                    {
                        MessageBox.Show("No tiene forma de CUIT");
                        return;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) < 1000)
                    {
                        TipoDocumento = 99;                        
                        break;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) > 1000)
                    {
                        MessageBox.Show("Las facturas B de más de $ 1.000 necesitan CUIT");
                        return;
                    }

                    TipoDocumento = 80;                    
                    break;
                case 4:
                    Documento = CUIT_Correcto(PrimeroCUIT.Text, DocumentoCUIT.Text, SegundoCUIT.Text);
                    if (Documento == "-1")
                    {
                        MessageBox.Show("No tiene forma de CUIT");
                        return;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) < 1000)
                    {
                        TipoDocumento = 99;                        
                        break;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) > 1000)
                    {
                        MessageBox.Show("Las facturas B de más de $ 1.000 necesitan CUIT");
                        return;
                    }

                    TipoDocumento = 80;                       
                    break;
                case 5:
                    Documento = CUIT_Correcto(PrimeroCUIT.Text, DocumentoCUIT.Text, SegundoCUIT.Text);
                    if (Documento == "-1")
                    {
                        MessageBox.Show("No tiene forma de CUIT");
                        return;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) < 1000)
                    {
                        TipoDocumento = 99;                        
                        break;
                    }
                    if (Documento == "0" && decimal.Parse(I13.Text) > 1000)
                    {
                        MessageBox.Show("Las facturas B de más de $ 1.000 necesitan CUIT");
                        return;
                    }

                    TipoDocumento = 80;
                    break;
                case 6:
                    Documento = CUIT_Correcto(PrimeroCUIT.Text, DocumentoCUIT.Text, SegundoCUIT.Text);
                    if (Documento == "-1" || Documento == "0")
                    {
                        MessageBox.Show("Las facturas A necesitan CUIT y ser correcto");
                        return;
                    }
                    TipoDocumento = 80;
                    break;
                case 7:
                    Documento = CUIT_Correcto(PrimeroCUIT.Text, DocumentoCUIT.Text, SegundoCUIT.Text);
                    if (Documento == "-1" || Documento == "0")
                    {
                        MessageBox.Show("Las facturas A necesitan CUIT y ser correcto");
                        return;
                    }
                    TipoDocumento = 80;
                    break;

                case 8:
                    Documento = CUIT_Correcto(PrimeroCUIT.Text, DocumentoCUIT.Text, SegundoCUIT.Text);
                    if (Documento == "-1" || Documento == "0")
                    {
                        MessageBox.Show("Las facturas A necesitan CUIT y ser correcto");
                        return;
                    }
                    TipoDocumento = 80;
                    break;
            }
            

            button1.Visible = false;
            button3.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button3.Visible = false;
            I1.Text = string.Empty;
            I2.Text = string.Empty;
            I3.Text = string.Empty;
            I4.Text = string.Empty;
            I5.Text = string.Empty;
            I6.Text = string.Empty;
            I7.Text = string.Empty;
            I8.Text = string.Empty;
            I9.Text = string.Empty;
            I10.Text = string.Empty;
            I11.Text = string.Empty;
            I12.Text = string.Empty;
            I13.Text = string.Empty;
            PU1.Text = string.Empty;
            PU2.Text = string.Empty;
            PU3.Text = string.Empty;
            PU4.Text = string.Empty;
            PU5.Text = string.Empty;
            PU6.Text = string.Empty;
            PU7.Text = string.Empty;
            PU8.Text = string.Empty;
            PU9.Text = string.Empty;
            PU10.Text = string.Empty;
            C1.Text = string.Empty;
            C2.Text = string.Empty;
            C3.Text = string.Empty;
            C4.Text = string.Empty;
            C5.Text = string.Empty;
            C6.Text = string.Empty;
            C7.Text = string.Empty;
            C8.Text = string.Empty;
            C9.Text = string.Empty;
            C10.Text = string.Empty;
            this.TipoFactura.SelectedItem = null;
            this.ProvinciaComprador.SelectedItem = null;
            RazonSocial.Text = string.Empty;
            PrimeroCUIT.Text = string.Empty;
            SegundoCUIT.Text = string.Empty;
            DocumentoCUIT.Text = string.Empty;
            Correo.Text = string.Empty;
            DomicilioComprador.Text = string.Empty;
            LocalidadComprador.Text = string.Empty;

        }

        public int TipoDeFactura(int Valor)
        {
            switch (Valor)
            { 
                case 0:
                    return 11;
                case 1:
                    return 12;
                case 2:
                    return 13;
                case 3:
                    return 6;
                case 4:
                    return 7;
                case 5:
                    return 8;
                case 6:
                    return 1;
                case 7:
                    return 2;
                case 8:
                    return 3;

            }
            return 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Factura = TipoDeFactura(TipoFactura.SelectedIndex);
            
            WSAFIPFE.Factura fe = new WSAFIPFE.Factura();
            Boolean bResultado = false;
            bResultado = fe.iniciar(0, "20217264732", @"c:\Xela1970.pfx", @" ");
            // la ubicacion del certificado digital Xela1970.pfx lo tengo guardado en AFIP
            // 0 es en modo testeo u homologacion, tendria que reemplazarlo por 1 en modo real
            // la ultima comilla es la que contiene la licencia del wasfipfe3100
            if (bResultado)
            {
                fe.ArchivoCertificadoPassword = "Xela1970";
                // password del certificado electronico de la pagina
                bResultado = fe.f1ObtenerTicketAcceso();
                if (bResultado)
                {

                    fe.F1CabeceraCantReg = 1;
                    // esta linea es para que yo pida a la AFIP un CAE por factura (se pueden pedir por cantidad pero se recomienda por facilidad pedir de a una no es mejor ni peor solo mas facil
                    fe.F1CabeceraPtoVta = PuntoVenta.SelectedIndex + 1;
                    // Punto de venta de los comprobantes eso se ve en las facturas en la cabecera como 000X-092394389 numero de factura. Lo de adelante es el punto de venta                    
                    fe.F1CabeceraCbteTipo = Factura;
                    // tipo de comprobante 1-factura A 2- Nota de Debito A 3- Nota de Credito A (6-7-8 con B) y (11, 12,13 con C)


                    //fe.f1Indice = fe.F1CompUltimoAutorizado(fe.F1CabeceraPtoVta, fe.F1CabeceraCbteTipo);
                    fe.f1Indice = 0;
                    // hace que comienze de la factura numero 1 (asi que este valor debe ser variable segun el ultimo valor tomado menos uno)
                    fe.F1DetalleConcepto = 3;
                    // 1- productos <> 2-servicio <> 3-producto y servicio
                    fe.F1DetalleDocTipo = TipoDocumento;
                    // facturacion A = 80 ingresar abajo el CUIT en fe.F1DetalleDocNro
                    // Facturacion B = 80 ingresar abajo el cuit en fe.F1DetalleDocNro 
                    // Facturacion B = 80 ingresar abajo el cuit 23000000000 (que es no categorizado)
                    // Facturacion B = 99 ingresar 0 en el cuit
                    // Facturacion B = 80 si es mayor la compra que de 1000 pesos
                    // Facturacion C = 99 ingresar 0 en el cuit
                    fe.F1DetalleDocNro = Documento;
                    // se inserta el cuit segun se requiera arriba
                    fe.F1DetalleCbteDesde = fe.F1CompUltimoAutorizado(PuntoVenta.SelectedIndex + 1, Factura) + 1;
                    fe.F1DetalleCbteHasta = fe.F1CompUltimoAutorizado(PuntoVenta.SelectedIndex + 1, Factura) + 1;
                    // pues quiero un solo comprobante
                    DateTime dt = DateTime.Now;
                    string hoy = dt.ToString("yyyyMMdd");                    
                    fe.F1DetalleCbteFch = hoy;
                    // fecha de emision del comprobante aaaammdd
                    fe.F1DetalleImpTotal = Convert.ToDouble(I13.Text);
                    fe.F1DetalleImpTotalConc = 0;
                    fe.F1DetalleImpNeto = Convert.ToDouble(I13.Text);
                    fe.F1DetalleImpOpEx = 0;
                    fe.F1DetalleImpTrib = 0;
                    fe.F1DetalleImpIva = 0;
                    // aca van todos los valores de la factura general
                    fe.F1DetalleFchServDesde = hoy;
                    fe.F1DetalleFchServHasta = hoy;
                    fe.F1DetalleFchVtoPago = hoy;
                    fe.F1DetalleMonId = "PES";
                    fe.F1DetalleMonCotiz = 1;

                    //fe.F1DetalleTributoItemCantidad = 1;
                    //fe.f1IndiceItem = 0;
                    //fe.F1DetalleTributoId = 3;
                    //fe.F1DetalleTributoDesc = "Impuesto Municipal Matanza";
                    //fe.F1DetalleTributoBaseImp = 150;
                    //fe.F1DetalleTributoAlic = 5.2;
                    //fe.F1DetalleTributoImporte = 7.8;

                    //fe.F1DetalleIvaItemCantidad = 2;
                    //fe.f1IndiceItem = 0;
                    //fe.F1DetalleIvaId = 5;
                    //fe.F1DetalleIvaBaseImp = 100;
                    //fe.F1DetalleIvaImporte = 21;

                    //fe.f1IndiceItem = 1;
                    //fe.F1DetalleIvaId = 4;
                    //fe.F1DetalleIvaBaseImp = 50;
                    //fe.F1DetalleIvaImporte = 5.25;


                    fe.F1DetalleCbtesAsocItemCantidad = 0;
                    fe.F1DetalleOpcionalItemCantidad = 0;

                    
                    bResultado = fe.F1CAESolicitar();
                    //if (bResultado)
                    //{
                    //    MessageBox.Show("resultado verdadero ");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("resultado falso ");
                    //}
                    //MessageBox.Show("resultado global AFIP: " + fe.F1RespuestaResultado);
                    //MessageBox.Show("es reproceso? " + fe.F1RespuestaReProceso);
                    //MessageBox.Show("registros procesados por AFIP: " + fe.F1RespuestaCantidadReg.ToString());
                    //MessageBox.Show("error genérico global:" + fe.f1ErrorMsg1);
                    if (fe.F1RespuestaCantidadReg > 0)
                    {
                        fe.f1Indice = 0;
                        //MessageBox.Show("resultado detallado comprobante: " + fe.F1RespuestaDetalleResultado);
                        string CAE = fe.F1RespuestaDetalleCae;
                        string Vencimiento_CAE = fe.F1RespuestaDetalleCAEFchVto;
                        string Delantera = "20217264739" + Factura.ToString() + "000" + fe.F1CabeceraPtoVta.ToString() + fe.F1RespuestaDetalleCae.ToString() + fe.F1RespuestaDetalleCAEFchVto.ToString(); 
                        string Codigo_De_Barras = Delantera + DigitoVerificador(Delantera);
                        //MessageBox.Show("número comprobante:" + fe.F1RespuestaDetalleCbteDesdeS);
                        //MessageBox.Show("error detallado comprobante: " + fe.F1RespuestaDetalleObservacionMsg1);
                    }
                }
                else
                {
                    MessageBox.Show("fallo acceso " + fe.UltimoMensajeError);
                }
            }
            else
            {
                MessageBox.Show("error inicio " + fe.UltimoMensajeError);
            }

            Form2 Form = new Form2();

            switch(TipoFactura.SelectedIndex)
            {
                case 0:
                    Form.Letra.Text = "C";
                    Form.Tipo_de_Factura.Text = "";
                    break;
                case 1:
                    Form.Letra.Text = "C";
                    Form.Tipo_de_Factura.Text = "Nota de Débito";
                    break;
                case 2:
                    Form.Letra.Text = "C";
                    Form.Tipo_de_Factura.Text = "Nota de Crédito";
                    break;
                case 3:
                    Form.Letra.Text = "B";
                    Form.Tipo_de_Factura.Text = "";
                    break;
                case 4:
                    Form.Letra.Text = "B";
                    Form.Tipo_de_Factura.Text = "Nota de Débito";
                    break;
                case 5:
                    Form.Letra.Text = "B";
                    Form.Tipo_de_Factura.Text = "Nota de Crédito";
                    break;
                case 6:
                    Form.Letra.Text = "A";
                    Form.Tipo_de_Factura.Text = "";
                    break;
                case 7:
                    Form.Letra.Text = "A";
                    Form.Tipo_de_Factura.Text = "Nota de Débito";
                    break;
                case 8:
                    Form.Letra.Text = "A";
                    Form.Tipo_de_Factura.Text = "Nota de Crédito";
                    break;
            }

            Form.textBox5.Text = C1.Text;
            Form.textBox12.Text = C2.Text;
            Form.textBox16.Text = C3.Text;
            Form.textBox20.Text = C4.Text;
            Form.textBox24.Text = C5.Text;
            Form.textBox44.Text = C6.Text;
            Form.textBox40.Text = C7.Text;
            Form.textBox36.Text = C8.Text;
            Form.textBox32.Text = C9.Text;
            Form.textBox28.Text = C10.Text;

            Form.textBox6.Text = textBox12.Text;
            Form.textBox11.Text = textBox13.Text;
            Form.textBox15.Text = textBox14.Text;
            Form.textBox19.Text = textBox15.Text;
            Form.textBox23.Text = textBox16.Text;
            Form.textBox43.Text = textBox17.Text;
            Form.textBox39.Text = textBox18.Text;
            Form.textBox35.Text = textBox19.Text;
            Form.textBox31.Text = textBox20.Text;
            Form.textBox27.Text = textBox21.Text;

            Form.textBox7.Text = PU1.Text;
            Form.textBox10.Text = PU2.Text;
            Form.textBox14.Text = PU3.Text;
            Form.textBox18.Text = PU4.Text;
            Form.textBox22.Text = PU5.Text;
            Form.textBox42.Text = PU6.Text;
            Form.textBox38.Text = PU7.Text;
            Form.textBox34.Text = PU8.Text;
            Form.textBox30.Text = PU9.Text;
            Form.textBox26.Text = PU10.Text;

            Form.textBox8.Text = I1.Text;
            Form.textBox9.Text = I2.Text;
            Form.textBox13.Text = I3.Text;
            Form.textBox17.Text = I4.Text;
            Form.textBox21.Text = I5.Text;
            Form.textBox41.Text = I6.Text;
            Form.textBox37.Text = I7.Text;
            Form.textBox33.Text = I8.Text;
            Form.textBox29.Text = I9.Text;
            Form.textBox25.Text = I10.Text;

            Form.textBox45.Text = I11.Text;
            Form.textBox49.Text = I12.Text;
            Form.textBox47.Text = I13.Text;

            Form.Factura.Text = "Nº: " + fe.F1CabeceraPtoVta.ToString("D4") + "-" + fe.F1CompUltimoAutorizado(PuntoVenta.SelectedIndex + 1, Factura).ToString("D8");

            Form.Envio = Correo.Text;

            DateTime ahora = DateTime.Now;            
            Form.Fecha.Text = ahora.ToString("dd/MM/yyyy");
            Form.Nombre.Text = RazonSocial.Text;
            Form.Domicilio.Text = DomicilioComprador.Text;
            Form.Loclidad.Text = LocalidadComprador.Text;
            Form.Provincia.Text = ProvinciaComprador.Text;
            Form.CAE.Text = fe.F1RespuestaDetalleCae;
            string FechaCAE = fe.F1RespuestaDetalleCAEFchVto;
            string Año = FechaCAE.Substring(0, 4);
            string Mes = FechaCAE.Substring(4, 2);
            string Dia = FechaCAE.Substring(6, 2);
            Form.VtoCAE.Text = Dia + "/" + Mes + "/" + Año;
            string Delante = "20217264739" + Factura.ToString() + fe.F1CabeceraPtoVta.ToString("D4") + fe.F1RespuestaDetalleCae.ToString() + fe.F1RespuestaDetalleCAEFchVto.ToString();
            string Codigo_Barras = Delante + DigitoVerificador(Delante);
            Form.Codigo.Text = Codigo_Barras;
            Form.Show();
            
        }

        public string DigitoVerificador(string Delantera)
        {
            int sum_par = 0;
            int sum_impar = 0;
            int posicion = 0;
            
            foreach (char item in Delantera)
            {
                posicion = posicion + 1;
                int nro = (int)Char.GetNumericValue(item);
                if (posicion % 2 == 0)
                    sum_par += nro;
                else
                    sum_impar += nro;
            }

            sum_impar = sum_impar * 3;
            int sum_impar_par = sum_impar + sum_par;
            sum_impar_par = sum_impar_par % 10;

            return (10 - sum_impar_par).ToString();

        }

        private void TipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }












    }

}