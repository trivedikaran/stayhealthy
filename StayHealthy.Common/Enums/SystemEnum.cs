namespace StayHealthy.Common.Enums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Enum Related Data 
    /// <CreatedBy> Sanjay Suthar </CreatedBy>
    /// <CreatedDate> 17 Nov 2015 </CreatedDate>
    /// </summary>
    public class SystemEnum
    {
        public enum EmailTemplate
        {
            Customer_ForgotPassword,
            ////ForgotPasswordMail,
            ////CreateUserMail,
            ////ContactusFormMail,
            ////ForgotPasswordCustomerMail
            Customer_SignupForm_AsInActive,
            ProductAnnouncement_Email
        }

        public enum MonthOfYear
        {
            [Display(Name = "January")]
            January = 1,
            [Display(Name = "February")]
            February = 2,
            [Display(Name = "March")]
            March = 3,
            [Display(Name = "April")]
            April = 4,
            [Display(Name = "May")]
            May = 5,
            [Display(Name = "June")]
            June = 6,
            [Display(Name = "July")]
            July = 7,
            [Display(Name = "August")]
            August = 8,
            [Display(Name = "September")]
            September = 9,
            [Display(Name = "October")]
            October = 10,
            [Display(Name = "November")]
            November = 11,
            [Display(Name = "December")]
            December = 12,
        }

        public enum WeekOfDay
        {
            [Display(Name = "Monday")]
            Monday = 0,
            [Display(Name = "Tuesday")]
            Tuesday = 1,
            [Display(Name = "Wednesday")]
            Wednesday = 2,
            [Display(Name = "Thursday")]
            Thursday = 3,
            [Display(Name = "Friday")]
            Friday = 4,
            [Display(Name = "Saturday")]
            Saturday = 5,
            [Display(Name = "Sunday")]
            Sunday = 6,
        }

        public enum UserTitle
        {
            [Display(Name = "Mr.")]
            Mr = 1,
            [Display(Name = "Mrs.")]
            Mrs = 2,
            [Display(Name = "Ms.")]
            Ms = 3,
            [Display(Name = "Miss")]
            Miss = 4
        }

        public enum EmailScedultType
        {
            [Display(Name = "Daily")]
            Daily = 1,
            [Display(Name = "Weekly")]
            Weekly = 2,
            [Display(Name = "Monthly")]
            Monthly = 3,
            [Display(Name = "Yearly")]
            Yearly = 4
        }
        public enum SSRSReports
        {
            [Display(Name = "rptHQOrderStatus")]
            rptHQOrderStatus = 1,
            [Display(Name = "rptBilOfLanding")]
            rptBilOfLanding = 2,
            [Display(Name = "Shipper")]
            Shipper = 3,
            [Display(Name = "rptActiveReadyMaterial")]
            rptActiveReadyMaterial = 4
        }

        public enum AdminCMSPages
        {
            Aboutus = 1,
            PrivacyPolicy = 2,
            ContactUs = 3,
            PriceBook = 4,
            Currentleadtime = 5,
            Freightrates = 6,
            InternalProfiles = 7,
            UploadYoutubeVideo = 8,
            UploadSymposiumVideo = 9
        }

        public enum UserStatus
        {
            [Display(Name = "Pending")]
            Pending = 1,
            [Display(Name = "Active")]
            Active = 2,
            [Display(Name = "Inactive")]
            Inactive = 3,
            [Display(Name = "Rejected")]
            Rejected = 4
        }

        public enum InputType
        {
            [Display(Name = "Prioritize Hot Orders")]
            PrioritizeHotOrders = 1,
            [Display(Name = "Request Remakes")]
            RequestRemakes = 2,
            [Display(Name = "Request Quotes")]
            RequestQuotes = 3,
            [Display(Name = "Repeat Order Item")]
            RepeatOrderItem = 4,
            [Display(Name = "Release Order")]
            ReleaseOrder = 5
        }

        public enum DocumentType
        {
            [Display(Name = "PO")]
            PO = 1,
            [Display(Name = "Shipment No ")]
            ShipmentNo = 2
        }

        public enum CustomerInputStatus
        {
            [Display(Name = "Pending")]
            Pending = 1,
            [Display(Name = "Acknowledge")]
            Acknowledge = 2,
            [Display(Name = "On Hold")]
            OnHold = 3,
            [Display(Name = "Close")]
            Close = 4
        }

        public enum NotifyType
        {
            [Description("Error")]
            Error = 0,
            [Description("Success")]
            Success = 1,
        }

        public enum AnnouncementDestinationType
        {
            [Display(Name = "Message Box")]
            MessageBox = 1,
            [Display(Name = "Email")]
            Email = 2,
            [Display(Name = "Inbox")]
            Inbox = 3
        }

        public enum AnnouncementSelectionType
        {
            [Display(Name = "Send to All Group")]
            SelectAll = 1,
            [Display(Name = "Send to Selected Group")]
            SelectCustom = 2,
        }

        public enum FileExtensionTypes
        {
            [Description(".jpg")]
            jpg = 1,
            [Description(".docx")]
            docx = 2,
            [Description(".jpeg")]
            jpeg = 3,
            [Description(".pdf")]
            pdf = 4,
            [Description(".doc")]
            doc = 5,
            [Description(".csv")]
            csv = 5
        }

        public enum UserType
        {
            [Display(Name = "Admin")]
            Admin = 1,
            [Display(Name = "Internal User")]
            InternalUser = 2,
            [Display(Name = "Customer")]
            Customer = 3
        }

        public enum NAFTACertificateStatus
        {
            [Display(Name = "Pending")]
            Pending = 1,
            [Display(Name = "Processed")]
            Processed = 2,
            [Display(Name = "Cancel")]
            Cancel = 3
        }

        #region Order Status Enums

        public enum OrderStatus
        {
            [Display(Name = "Select All")]
            SelectAll = 1,
            [Display(Name = "Open")]
            Open = 2,
            [Display(Name = "Pending")]
            Pending = 3,
            [Display(Name = "Complete")]
            Complete = 4,
            [Display(Name = "Closed")]
            Closed = 5,
            [Display(Name = "Cancelled")]
            Cancelled = 6
        }

        public enum SearchTextOption
        {
            [Display(Name = "Part Number")]
            PartNumber = 1,
            [Display(Name = "Stock Card")]
            StockCard = 2,
            [Display(Name = "PO Number")]
            PONumber = 3,
            [Display(Name = "Item Number")]
            ItemNumber = 4,
            [Display(Name = "DUNS/DASH")]
            DUNSDASH = 5,
            [Display(Name = "Program")]
            Program = 6
        }

        public enum SearchDateOption
        {
            [Display(Name = "Search Promise Date")]
            PromoiseDate = 1,
            [Display(Name = "Search Wanted Date")]
            WantedDate = 2
        }

        public enum HFROption
        {
            [Display(Name = "Select All")]
            SelectAll = 1,
            [Display(Name = "HFR")]
            HFR = 2,
            [Display(Name = "Non-HFR")]
            NonHFR = 3
        }

        public enum DefaultDetailLevel
        {
            [Display(Name = "By Customer")]
            ByCustomer = 1,
            [Display(Name = "By Customer/Ship-To")]
            ByCustomerShipTo = 2,
            [Display(Name = "By Customer/Ship-To/Item")]
            ByCustomerShipToItem = 3,
            [Display(Name = "By Customer/Ship-To/Item/Dash")]
            ByCustomerShipToItemDash = 4,
            [Display(Name = "By Customer/Ship-To/Item/Dash/Stockcard")]
            ByCustomerShipToItemDashStockcard = 5
        }

        public enum UnitOfMeasure
        {
            [Display(Name = "Tons")]
            Tons = 1,
            [Display(Name = "Lbs")]
            Lbs = 2,
            [Display(Name = "KGs")]
            KGs = 3
        }

        #endregion

        public enum ModuleType
        {
            Admin = 1,
            InternalUser = 2,
            Customer = 3
        }

        #region Property

        /// <summary>
        /// Gets or sets the ID value.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Name value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string DisplayName { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Get the Enum Name from Enum Value
        /// </summary>
        /// <param name="objEnumType">Enum Type like typeof(EnumType)</param>
        /// <param name="value">enum value</param>
        /// <returns>string - Name of Enum</returns>
        public static string GetEnumName(Type objEnumType, int value)
        {
            SystemEnumList lstEnum = GetEnumList(objEnumType);
            SystemEnum objSystemEnum;
            objSystemEnum = lstEnum.Find(delegate(SystemEnum systemEnum)
            {
                return systemEnum.ID == value;
            });

            if (objSystemEnum != null)
            {
                return objSystemEnum.Name;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get the Enum Name from Enum Value
        /// </summary>
        /// <param name="objEnumType">Enum Type like typeof(EnumType)</param>
        /// <param name="value">enum value</param>
        /// <returns>string - Name of Enum</returns>
        public static string GetEnumDescription(Type objEnumType, int value)
        {
            SystemEnumList lstEnum = GetEnumList(objEnumType);
            SystemEnum objSystemEnum;
            objSystemEnum = lstEnum.Find(delegate(SystemEnum systemEnum)
            {
                return systemEnum.ID == value;
            });

            if (objSystemEnum != null)
            {
                return objSystemEnum.Description;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get the Enum Name from Enum Value
        /// </summary>
        /// <param name="objEnumType">Enum Type like typeof(EnumType)</param>
        /// <param name="value">enum value</param>
        /// <returns>string - Name of Enum</returns>
        public static string GetEnumDisplayName(Type objEnumType, int value)
        {
            SystemEnumList lstEnum = GetEnumList(objEnumType);
            SystemEnum objSystemEnum;
            objSystemEnum = lstEnum.Find(delegate(SystemEnum systemEnum)
            {
                return systemEnum.ID == value;
            });

            if (objSystemEnum != null)
            {
                return objSystemEnum.DisplayName;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get the SystemEnumList from given Enum type
        /// </summary>
        /// <param name="objEnumType">Enum Type like typeof(EnumType)</param>
        /// <returns>List of Enum with Name Value pair</returns>
        public static SystemEnumList GetEnumList(Type objEnumType)
        {
            Array values = Enum.GetValues(objEnumType);
            SystemEnumList lstEnum = new SystemEnumList();
            SystemEnum objEnum;
            for (int i = 0; i < values.Length; i++)
            {
                objEnum = new SystemEnum();
                objEnum.ID = values.GetValue(i).GetHashCode();
                objEnum.Name = Convert.ToString(values.GetValue(i), CultureInfo.CurrentCulture).Replace("_", " ");
                objEnum.Description = string.Empty;
                objEnum.DisplayName = string.Empty;

                var memInfo = objEnumType.GetMember(Convert.ToString(values.GetValue(i), CultureInfo.CurrentCulture));
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Count() > 0)
                {
                    objEnum.Description = ((DescriptionAttribute)attributes[0]).Description;
                }

                var memInfoDisplayName = objEnumType.GetMember(Convert.ToString(values.GetValue(i), CultureInfo.CurrentCulture));
                var attributesDisplayName = memInfoDisplayName[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                if (attributesDisplayName.Count() > 0)
                {
                    objEnum.DisplayName = ((DisplayAttribute)attributesDisplayName[0]).Name;
                }

                lstEnum.Add(objEnum);
            }

            return lstEnum;
        }

        #endregion
        public enum NotiifcationEmailType
        {
            ProductAnnouncement = 1
        }
        public enum PublishStatus
        {
            [Display(Name = "Pending")]
            Pending = 0,
            [Display(Name = "Done")]
            Processed = 1
        }
        public enum UserDashboardWidget
        {
            [Display(Name = "Customer Signup Request")]
            CustomerSignupRequest = 1,
            [Display(Name = "Message Box")]
            NotificationMessages = 2,
            [Display(Name = "Pending Customer Request")]
            PendingCustomerInputRequest = 3,
            [Display(Name = "Upload Pending Request")]
            UploadPendingRequest = 4,
        }
        public enum CustomerDashboarWidget
        {
            ///Customer Dashboar Widget
            [Display(Name = "Customer Input Request")]
            CustomerInputRequest = 6,
            [Display(Name = "Message Box")]
            CustomerMessageBox = 7,
            [Display(Name = "Customer Order Document")]
            CustomerOrderDocument = 8,
        }
        #region OrderStatus Report Columns
        public enum OSReportColumns
        {
            [Display(Name = "DASH")]
            DASH = 1,
            [Display(Name = "HFR")]
            HFR = 2,
            [Display(Name = "PO #")]
            PO = 3,
            [Display(Name = "Part #")]
            PART = 4,
            [Display(Name = "Mode")]
            MODE = 5,
            [Display(Name = "Mat Type")]
            MATTYPE = 6,
            [Display(Name = "Order Type")]
            ORDERTYPE = 7,
            [Display(Name = "Product Class")]
            PRODUCTCLASS = 8,
            [Display(Name = "Guage")]
            GUAGE = 9,
            [Display(Name = "Width")]
            WIDTH = 10,
            [Display(Name = "Stock Card")]
            STOCKCARD = 11,
            [Display(Name = "Wanted Date")]
            WANTEDDATE = 12,
            [Display(Name = "Promise Date")]
            PROMISEDATE = 13,
            [Display(Name = "Melt Grd")]
            MELGRD = 14,
            [Display(Name = "Order To")]
            ORDERTO = 15,
            [Display(Name = "Booked")]
            BOOKED = 16,
            [Display(Name = "To Ship")]
            TOSHIP = 17,
            [Display(Name = "Bal")]
            BAL = 18,
            [Display(Name = "Over/Under")]
            OVERUNDER = 19,
            [Display(Name = "Shipped")]
            SHIPPED = 20,
            [Display(Name = "OSP Fin")]
            OSPFIN = 21,
            [Display(Name = "OSP WIP")]
            OSPWIP = 22,
            [Display(Name = "OSP To OSP")]
            OSPTOOSP = 23,
            [Display(Name = "In Transit")]
            INTRANSIT = 24,
            [Display(Name = "To OSP")]
            TOOSP = 25,
            [Display(Name = "Mill Fnshd")]
            MILLFNSHD = 26,
            [Display(Name = "Needs Pkgd")]
            NEEDSPKGD = 27,
            [Display(Name = "On Hold")]
            ONHOLD = 28,
            [Display(Name = "WIP MILL")]
            WIPMILL = 29,
            [Display(Name = "AL")]
            AL = 30,
            [Display(Name = "EG")]
            EG = 31,
            [Display(Name = "Galv")]
            GALV = 32,
            [Display(Name = "Tempr Mill")]
            TEMPRMILL = 33,
            [Display(Name = "Anneal")]
            ANNEAL = 34,
            [Display(Name = "Tand Mill")]
            TANDMILL = 35,
            [Display(Name = "PKL")]
            PKL = 36,
            [Display(Name = "HSM")]
            HSM = 37,
            [Display(Name = "Cast")]
            CAST = 38,
        }
        #endregion

        public enum AccountBalanceStatus
        {
            [Display(Name = "Open")]
            Open = 1,
            [Display(Name = "Closed")]
            Closed = 2,
            [Display(Name = "Both")]
            Both = 3
        }
        public enum Locked
        {
            [Display(Name = "Lock")]
            locked = 1,
            [Display(Name = "Unlock")]
            Unlocked = 0
        }

        public enum RightsType
        {
            [Display(Name = "Edit")]
            Edit = 1,
            [Display(Name = "View")]
            View = 2,
            [Display(Name = "Download")]
            Download = 3
        }

        public enum ToastType
        {
            Error,
            Info,
            Success,
            Warning
        }
    }


    /// <summary>
    /// Used to get System EnumList
    /// <CreatedBy>Sanjay Suthar</CreatedBy>
    /// <CreatedDate> 17 Nov 2015 </CreatedDate>
    /// </summary>
    public class SystemEnumList : List<SystemEnum>
    {
    }
}
