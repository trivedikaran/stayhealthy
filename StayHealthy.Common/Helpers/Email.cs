namespace StayHealthy.Helpers
{
    using StayHealthy.Common.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Web;

    /// <summary>
    ///  Implemented common mail functionality.
    /// </summary>
    public class Email
    {
        public enum EmailType
        {
            Default,
            NoMaster
        }

        public static bool Send(string mailFrom, string mailTo, string mailCC, string mailBCC, string subject, string body, string attachment, bool isBodyHtml, EmailType emailType = EmailType.NoMaster, Stream attachmentstream = null, string fileExtension = null, string filename = null,bool istest = false, string testemail = "")
        {
            if (istest == true)
            {
                mailTo = testemail;
            }
            
            string str = string.Empty;
            System.Net.Mail.MailMessage mailMesg = new System.Net.Mail.MailMessage(mailFrom, mailTo);
            ////System.Net.Mail.MailMessage MailMesg = new System.Net.Mail.MailMessage(mailFrom, " twinkle.patel@server1.com");

            if (mailCC != string.Empty)
            {
                string[] arrayMailCC = mailCC.Split(';');
                foreach (string email in arrayMailCC)
                {
                    if (email != string.Empty)
                    {
                        mailMesg.CC.Add(email);
                    }
                }
            }

            if (mailBCC != string.Empty)
            {
                mailBCC = mailBCC.Replace(";", ",");
                mailMesg.Bcc.Add(mailBCC);
            }

            if (attachmentstream != null)
            {
                if (fileExtension == SystemEnum.GetEnumDescription(typeof(SystemEnum.FileExtensionTypes), (int)SystemEnum.FileExtensionTypes.jpg))
                {
                    System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Image.Jpeg);
                    Attachment attach = new System.Net.Mail.Attachment(attachmentstream, ct);
                    attach.ContentDisposition.FileName = filename;
                    mailMesg.Attachments.Add(attach);
                }

                if (fileExtension == SystemEnum.GetEnumDescription(typeof(SystemEnum.FileExtensionTypes), (int)SystemEnum.FileExtensionTypes.pdf))
                {
                    System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                    Attachment attach = new System.Net.Mail.Attachment(attachmentstream, ct);
                    attach.ContentDisposition.FileName = filename;
                    mailMesg.Attachments.Add(attach);
                }
            }

            ////if (!string.IsNullOrEmpty(attachment))
            ////{
            ////    string[] arrayAttachment = attachment.Split(';');
            ////    foreach (string attachFile in arrayAttachment)
            ////    {
            ////        try
            ////        {
            ////            System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(attachFile);
            ////            MailMesg.Attachments.Add(attach);
            ////        }
            ////        catch
            ////        { }
            ////    }
            ////}

            mailMesg.Subject = subject;
            mailMesg.Body = body;
            mailMesg.IsBodyHtml = isBodyHtml;

            var objSMTP = new SmtpClient
            {
                Host = System.Configuration.ConfigurationManager.AppSettings["Host"],
                Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Port"]),
                EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableSsl"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["FromMail"], System.Configuration.ConfigurationManager.AppSettings["Password"])
            };

            try
            {
                ////var objSMTP1 = new SmtpClient
                ////{
                ////    Host = "smtp.gmail.com",
                ////    Port = 587,
                ////    EnableSsl =true,
                ////    DeliveryMethod = SmtpDeliveryMethod.Network,
                ////    UseDefaultCredentials = false,
                ////    Credentials = new NetworkCredential("shaligramdev1@gmail.com","sit@1234")
                ////};
                
                objSMTP.Send(mailMesg);
                return true;
            }
            catch (Exception ex)
            {
                str = ex.Message;
                mailMesg.Dispose();
                mailMesg = null;
            }

            return false;
        }

        /// <summary>
        /// Read the Tempate from Formate and return
        /// </summary>
        /// <param name="emailTemplate"></param>
        /// <returns></returns>
        public static string GetEmailTemplate(SystemEnum.EmailTemplate emailTemplate)
        {
            string bodyTemplate = string.Empty;
            string filePath = @"D:\Projects\AKSteel\SourceCode\AKSteel.Common\MailTemplate\" + emailTemplate.ToString() + ".html";
            if (File.Exists(filePath))
            {
                try
                {
                    StreamReader reader = new StreamReader(filePath);
                    bodyTemplate = reader.ReadToEnd();
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                catch (Exception ex)
                {
                }
            }

            return bodyTemplate;
        }

        public static void SendErrorEmail(Exception ex)
        {
            StringBuilder error = new StringBuilder();
            string strTmp = null;

            ////----- Generate the Html Structure for the Sending Email 

            error.Append("<b>Error in :</b> " + HttpContext.Current.Request.Path + "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Url :</b> " + HttpContext.Current.Request.RawUrl + "<br><br>");

            error.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Request from IpAddress :</b> " + HttpContext.Current.Request.UserHostAddress + "<br>");

            //// Get the exception object for the last error message that occured. 

            error.Append("<b>Error Message : &nbsp;</b>" + ex.Message.ToString());

            error.Append("<br><b>Error StackTrace : &nbsp;</b>" + ex.StackTrace.ToString());
            ////'k 

            strTmp = ex.Source;
            error.Append("<br><br><b>Error Source &nbsp;&nbsp;: &nbsp;&nbsp;</b>" + strTmp);

            if ((!object.ReferenceEquals(ex.TargetSite.Name, DBNull.Value)))
            {
                error.Append("<br><br><b>Error Target Site :&nbsp; </b>" + ex.TargetSite.Name);
            }

            error.Append("<br><br><b>QueryString Data</b><br>------------------------<br>");
            //// Gathering QueryString information 
            error.Append(HttpContext.Current.Request.QueryString.ToString() + "<br>");

            error.Append("<br>");

            error.Append("<br><b>Post Data</b><br>--------------<br>");
            //// Gathering Post Data information 
            error.Append(HttpContext.Current.Request.Form.ToString() + "<br>");
            error.Append("<br>");
            error.Append("<br>");

            error.Append("<b>Session Info</b><br>--------------<br>");

            if (HttpContext.Current.Session != null)
            {
                System.Collections.Specialized.NameObjectCollectionBase.KeysCollection SessionKeys = HttpContext.Current.Session.Keys;

                for (int i = 0; i <= SessionKeys.Count - 1; i++)
                {
                    error.Append("<br>" + (i + 1).ToString() + ":-><b>Name: </b>" + SessionKeys[i].ToString());

                    //if (HttpContext.Current.Session[i].GetType == "String")
                    //{
                    error.Append(" <--> <b>Value:</b>" + HttpContext.Current.Session[SessionKeys[i].ToString()]);
                    //}

                    //if (HttpContext.Current.Session[i].GetType.Name == "DataTable")
                    //{
                    //    Error.Append(" <--> <b>Value:</b> Number of rows:" + (DataTable)HttpContext.Current.Session[SessionKeys[i].ToString()].Rows.Count.ToString());
                    //}
                }

                error.Append("<br>Total Session Count:- " + HttpContext.Current.Session.Count);
            }

            string MailFrom = null;
            string MailTo = null;
            string Subject = null;

            MailFrom = ProjectConfiguration.ErrorLogFromEmail;//ProjectConfiguration.AdminEmailID ;
            MailTo = ProjectConfiguration.ErrorEmail;

            Subject = "Error: " + HttpContext.Current.Request.RawUrl + " - " + DateTime.Now.ToString("dd/MM/yyy HH:mm:ss");

            //--sending error mail 
            Email.Send(MailFrom, MailTo, "", "", Subject, error.ToString(), "", true, Email.EmailType.Default);
        }
    }

    public class EmailSubject
    {
        
    }

}

