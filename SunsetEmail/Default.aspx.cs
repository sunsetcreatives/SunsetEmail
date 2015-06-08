using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;

namespace SunsetEmail
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() != string.Empty && txtPassword.Text.Trim() != string.Empty)
            {
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;

                // setup Smtp authentication
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("sunsetcreatives@gmail.com", txtPassword.Text.Trim());
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("sunsetcreatives@gmail.com");
                msg.To.Add(new MailAddress(txtEmail.Text.Trim()));

                msg.Subject = "Web Designing";
                msg.IsBodyHtml = true;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate.htm")))
                {
                    msg.Body = reader.ReadToEnd();
                }

                try
                {
                    client.Send(msg);
                    EmailDal.Save(txtEmail.Text.Trim());
                    lblMessage.Text = "Success...";
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error occured..." + ex.Message;
                }
            }
        }
    }
}