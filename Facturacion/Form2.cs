using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

using System.Net.Mail;
using System.Net;

namespace Facturacion
{
    public partial class Form2 : Form
    {
        public string Envio;
        private Button btImprimir;
        private Button btVistaPrevia;
        private PrintDocument DocumentoParaImprimir = new PrintDocument();
        private PrintDialog Impresora = new PrintDialog();
        private PrintPreviewDialog VistaPrevia = new PrintPreviewDialog();
        private Bitmap bmp;

       // private bool Adj = false;
        // private string Archivo;
       
        public Form2()
        {
            this.btImprimir = new System.Windows.Forms.Button();
            this.btImprimir.Location = new System.Drawing.Point(20, 540);
            this.btImprimir.Size = new System.Drawing.Size(100, 30);
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.Click += new System.EventHandler(this.button1_Click);
            this.Controls.Add(this.btImprimir);

            this.btVistaPrevia = new System.Windows.Forms.Button();
            this.btVistaPrevia.Location = new System.Drawing.Point(20, 580);
            this.btVistaPrevia.Size = new System.Drawing.Size(100, 30);
            this.btVistaPrevia.Text = "Vista Previa";
            this.btVistaPrevia.Click += new System.EventHandler(this.btVistaPrevia_Click);
            this.Controls.Add(this.btVistaPrevia);

            InitializeComponent();  

            DocumentoParaImprimir.PrintPage +=
                new PrintPageEventHandler(DocumentoParaImprimir_PrintPage);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CapturaFormulario();

            Impresora.Document = DocumentoParaImprimir;
            DialogResult Result = Impresora.ShowDialog();

            if (Result == DialogResult.OK)
            {
                DocumentoParaImprimir.DefaultPageSettings.Landscape = false;
                DocumentoParaImprimir.Print();
            }
           
        }


        void DocumentoParaImprimir_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
        }


        private void btVistaPrevia_Click(object sender, EventArgs e)
        {
            CapturaFormulario();

            VistaPrevia.Document = DocumentoParaImprimir;
            VistaPrevia.ShowDialog();
        }

        private void CapturaFormulario()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size sz = this.ClientRectangle.Size;
            bmp = new Bitmap(sz.Width, sz.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width,
                   this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
            string name = Factura.Text.Substring(4,Factura.Text.Length - 4);

            

            //bmp.Save(@"c:\facturacion\" + name + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void CapturaFormulario_Envio()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size sz = this.ClientRectangle.Size;
            bmp = new Bitmap(sz.Width, sz.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width,
                   this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
            string name = Factura.Text.Substring(4, Factura.Text.Length - 4);



            bmp.Save(@"c:\facturacion\" + name + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest,
            int nXDest,
            int nYDest,
            int nWidth,
            int nHeight,
            IntPtr hdcSrc,
            int nXSrc,
            int nYSrc,
            int dwRop);

        private void Mail_Click(object sender, EventArgs e)
        {
            //SaveFileDialog guarda = new SaveFileDialog();

            //guarda.Filter = "imagen jpg|*.jpg";
            //guarda.ShowDialog();

            //if (guarda.FileName != "")
            //{
            //    Bitmap bm = new Bitmap(groupBox1.Width, groupBox1.Height);
            //    groupBox1.DrawToBitmap(bm, new Rectangle(0, 0, groupBox1.Width, groupBox1.Height));
            //    FileStream flujo = new FileStream(guarda.FileName, FileMode.Create, FileAccess.Write);
            //    bm.Save(flujo, System.Drawing.Imaging.ImageFormat.Bmp);
            //    flujo.Close();
            //    bm.Dispose();
            //}
            CapturaFormulario_Envio();

            MailMessage _Correo = new MailMessage();
            _Correo.From = new MailAddress("xeladostechnology@gmail.com");

            _Correo.To.Add(Envio);
            _Correo.Subject = "Factura digital de la empresa";
            _Correo.Body = "enviando la factura";
            _Correo.IsBodyHtml = false;
            _Correo.Priority = MailPriority.Normal;


            //Adj = true;
            //OpenFileDialog _file = new OpenFileDialog();
            //_file.Title = "seleccione archivo";
            //_file.InitialDirectory = @"c:";
            //_file.Filter = "All Files(*.*)|*.*";
            //_file.FilterIndex = 1;
            //_file.RestoreDirectory = true;
            //_file.ShowDialog();
            //Archivo = _file.FileName;
            string name = Factura.Text.Substring(4, Factura.Text.Length - 4);

            //if (Adj == true)
            //{
                Attachment _attachement = new Attachment(@"c:\facturacion\" + name + ".bmp");
                _Correo.Attachments.Add(_attachement);
               // Adj = false;

            //}

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("gutylic@gmail.com", "dxqfqsvxfhxmcsel");

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(_Correo);
                MessageBox.Show("Correo Enviado");

            }
            catch
            {
                MessageBox.Show("No se envio el correo");

            }

            _Correo.Dispose();


        }

       
    }
}

        
    
