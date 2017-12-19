namespace StayHealthy.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    public class ProjectConfiguration
    {
        #region Variable

        /// <summary>
        /// root path variable
        /// </summary>
        private static string rootPath;

        #endregion

        #region Format

        /// <summary>
        /// Gets the Date Format
        /// </summary>
        public static string DateFormat
        {
            get
            {
                //return "yyyy-MM-dd";
                //return "dd MMM yy";
                return "MM/dd/yyyy";
            }
        }

        /// <summary>
        /// Gets the Date Time Format
        /// </summary>
        public static string DateTimeFormat
        {
            get
            {
                //return "yyyy-MM-dd hh:mm tt";
                return "dd MMM yy hh:mm tt";
            }
        }
        /// <summary>
        /// Gets the date time formats.
        /// </summary>
        /// <value>The date time formats.</value>
        public static string DateTimeFormats
        {
            get
            {
                //return "yyyy-MM-dd hh:mm";
                return "MM/dd/yyyy HH:mm";
            }
        }

        /// <summary>
        /// Gets the Time Format
        /// </summary>
        public static string TimeFormat
        {
            get
            {
                return "hh:mm tt";
            }
        }

        public static string FormatDateTime
        {
            get
            {
                //return "{0:yyyy-MM-dd hh:mm tt}";
                return "{0:dd MMM yy hh:mm tt}";
            }
        }

        public static string FormatDate
        {
            get
            {
                //return "{0:yyyy-MM-dd}";
                return "{0:dd MMM yy}";
            }
        }

        public static string FormatTime
        {
            get
            {
                return "{0:hh:mm tt}";
            }
        }

        /// <summary>
        /// Gets the Decimal Place
        /// </summary>
        public static int DecimalPlace
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the Minimum Date
        /// </summary>
        public static string MinDate
        {
            get
            {
                return "01/01/1753 12:00:00 AM";
            }
        }

        #endregion

        #region System Path

        /// <summary>
        /// Gets the Root Path of the Project
        /// </summary>
        public static string ApplicationRootPath
        {
            get
            {
                if (rootPath.EndsWith("\\", StringComparison.CurrentCulture))
                {
                    return rootPath;
                }
                else
                {
                    return rootPath + "\\";
                }
            }
        }

        /// <summary>
        /// Gets HostName
        /// </summary>
        public static string HostName
        {
            get { return HttpContext.Current.Request.Url.Host; }
        }

        /// <summary>
        /// Gets Secure User Base
        /// </summary>
        public static string SecureUrlBase
        {
            get
            {
                return "https://" + UrlSuffix;
            }
        }

        /// <summary>
        /// Gets Url Base
        /// </summary>
        public static string UrlBase
        {
            get
            {
                return "http://" + UrlSuffix;
            }
        }

        /// <summary>
        /// Gets Site Url Base
        /// </summary>
        public static string SiteUrlBase
        {
            get
            {
                if (HttpContext.Current.Request.IsSecureConnection)
                {
                    return SecureUrlBase;
                }
                else
                {
                    return UrlBase;
                }
            }
        }

        /// <summary>
        /// Gets Url Suffix
        /// </summary>
        private static string UrlSuffix
        {
            get
            {
                if (HttpContext.Current.Request.ApplicationPath == "/")
                {
                    return HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath;
                }
                else
                {
                    return HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath + "/";
                }
            }
        }

        public static int RememberMeTimeout
        {
            get
            {
                if (ConfigurationManager.AppSettings["RememberMeTimeout"] == null)
                    return 0;

                else
                    return Convert.ToInt32(ConfigurationManager.AppSettings["RememberMeTimeout"]);
            }

        }

        public static string ErrorEmail
        {
            get
            {
                if (ConfigurationManager.AppSettings["ErrorEmail"] == null)
                {
                    return string.Empty;
                }

                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["ErrorEmail"]);
                }
            }

        }

        public static string ErrorLogFromEmail
        {
            get
            {
                if (ConfigurationManager.AppSettings["ErrorLogFromEmail"] == null)
                {
                    return string.Empty;
                }

                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["ErrorLogFromEmail"]);
                }
            }
        }

        /// <summary>
        /// Gets the MailTamplate.
        /// </summary>
        public static string AKSteelEmailTemplatePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("../MailTemplate/");
            }
        }

        public static string ReportGenerationPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/ReportExportedData/");
            }
        }

        public static string ReportDisplayPath
        {
            get
            {
                return SiteUrlBase + "/ReportExportedData/";
            }
        }

        public static string FromMail
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["FromMail"]))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["FromMail"]);
                }
            }

        }

        public static string ContactUsFromMail
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["ContactUsFromMail"]))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["ContactUsFromMail"]);
                }
            }

        }

        public static string ContactUsToMail
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["ContactUsToMail"]))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["ContactUsToMail"]);
                }
            }

        }

        public static string ContactUsSubject
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["ContactUsSubject"]))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["ContactUsSubject"]);
                }
            }

        }

        public static string Subject
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["Subject"]))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["Subject"]);
                }
            }

        }

        public static string SuperAdminMail
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["SuperAdminMail"]))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["SuperAdminMail"]);
                }
            }
        }

        public static string WebApiUrl
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["WebApiUrl"]))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["WebApiUrl"]);
                }
            }
        }

        public static string BuyNowUrl
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["BuyNowUrl"]))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["BuyNowUrl"]);
                }
            }
        }

        public static string AuctionSiteUrl
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["AuctionSiteUrl"]))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["AuctionSiteUrl"]);
                }
            }
        }
        public static string ColorCode
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["ColorCode"]))
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(ConfigurationManager.AppSettings["ColorCode"]);
                }
            }
        }
        #endregion
    }
}
