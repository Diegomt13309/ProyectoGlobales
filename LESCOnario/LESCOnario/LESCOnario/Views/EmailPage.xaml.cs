using System;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LESCOnario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmailPage : ContentPage
    {
        public EmailPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (confirmar(email.Text))
                {
                    MailMessage correo = new MailMessage();
                    correo.From = new MailAddress("lesconario@gmail.com", "LESCOnario", System.Text.Encoding.UTF8);//Correo de salida
                    correo.To.Add("jfarrieta.s@gmail.com"); //Correo destino?
                    correo.Subject = asunto.Text; //Asunto
                    correo.Body = " De: " + email.Text + "<br/><br/>" +
                                    " " + mensaje.Text; //Mensaje del correo
                    correo.IsBodyHtml = true;
                    correo.Priority = MailPriority.Normal;
                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                    smtp.Port = 25; //Puerto de salida
                    smtp.Credentials = new System.Net.NetworkCredential("lesconario@gmail.com", "Lesco123");//Cuenta de correo
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                    smtp.Send(correo);
                    DisplayAlert("Correcto", "El mensaje ha sido enviado", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Correo no válido", "OK");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }

            asunto.Text = "";
            email.Text = "";
            mensaje.Text = "";
        }

        private Boolean confirmar(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}