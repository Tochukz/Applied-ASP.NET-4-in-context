using System;
using System.Net.Mail;
using System.Configuration;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Globalization;

namespace EmailApp
{
    public partial class Mail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                Validate();
                if (IsValid)
                {
                    try
                    {
                        string host = ConfigurationManager.AppSettings["GMAIL_SMTP_SERVER"];
                        int port = int.Parse(ConfigurationManager.AppSettings["GMAIL_PORT"]);
                        SmtpClient smtpClient = new SmtpClient(host, port);
                        smtpClient.EnableSsl = true;

                        string systemEmail = ConfigurationManager.AppSettings["SYSTEM_EMAIL"];
                        string emailPassword = ConfigurationManager.AppSettings["EMAIL_PASSWORD"];

                        smtpClient.Credentials = new System.Net.NetworkCredential(systemEmail, emailPassword);
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                        MailMessage mailMessage = new MailMessage(systemEmail, RecipientEmail.Text);
                        mailMessage.Subject = EmailSubject.Text;
                        mailMessage.IsBodyHtml = true;
                        HtmlGenericControl messageBody = BuildMessageBody(SenderEmail.Text, RecipientEmail.Text, EmailBody.Text);
                        mailMessage.Body = ConvertControlToHtmlString(messageBody);

                        smtpClient.Send(mailMessage);
                        MessageLabel.ForeColor = Color.Green;
                        MessageLabel.Text = "Email Sent Successfully";

                        SenderEmail.Enabled = false;
                        RecipientEmail.Enabled = false;
                        EmailSubject.Enabled = false;
                        EmailBody.Enabled = false;

                        MessageSummary.Controls.Add(messageBody);
                    }
                    catch (SmtpFailedRecipientException ex)
                    {
                        MessageLabel.ForeColor = Color.Red;
                        MessageLabel.Text = "Failed Recepient " + ex.Message + ex.StackTrace;
                    }
                    catch (SmtpException ex)
                    {
                        MessageLabel.ForeColor = Color.Red;
                        MessageLabel.Text = "SMTP failure: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        MessageLabel.ForeColor = Color.Red;
                        MessageLabel.Text = "Generic Error " + ex.Message + ex.StackTrace;

                        // Log Exception to event viewer or databae table
                    }
                }

            }

        }

        private HtmlGenericControl BuildMessageBody(string senderEmail, string recipientEmail, string messageBody)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            HtmlGenericControl p1 = new HtmlGenericControl("p");
            HtmlGenericControl p2 = new HtmlGenericControl("p");
            HtmlGenericControl p3 = new HtmlGenericControl("p");
            HtmlGenericControl strong1 = new HtmlGenericControl("strong");
            HtmlGenericControl strong2 = new HtmlGenericControl("strong");
            HtmlGenericControl strong3 = new HtmlGenericControl("strong");
            HtmlGenericControl span1 = new HtmlGenericControl("span");
            HtmlGenericControl span2 = new HtmlGenericControl("span");
            HtmlGenericControl span3 = new HtmlGenericControl("span");

            strong1.InnerText = "Sender Email:";
            strong2.InnerText = "Recipient Email:";
            strong3.InnerText = "Message:";
            span1.InnerText = senderEmail;
            span2.InnerText = recipientEmail;
            span3.InnerText = messageBody;

            p1.Controls.Add(strong1);
            p1.Controls.Add(span1);
            p2.Controls.Add(strong2);
            p2.Controls.Add(span2);
            p3.Controls.Add(strong3);
            p3.Controls.Add(span3);

            div.Controls.Add(p1);
            div.Controls.Add(p2);
            div.Controls.Add(p3);

            return div;
        }

        private string ConvertControlToHtmlString(HtmlGenericControl htmlControl)
        {
            StringBuilder stringBuilder = new StringBuilder();
            HtmlTextWriter htmlTextWriter= new HtmlTextWriter(new StringWriter(stringBuilder, CultureInfo.InvariantCulture));
            htmlControl.RenderControl(htmlTextWriter);
            string html = stringBuilder.ToString();
            return html;
        }
    }
}