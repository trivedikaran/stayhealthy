namespace StayHealthy.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Manage the sorting and paging Properties
    /// </summary>
    /// <CreatedBy>Sanjay Suthar</CreatedBy>
    /// <CreatedDate>19-Nov-2015</CreatedDate>
    public class SortingPagingInfo
    {
        /// <summary>
        /// Gets or sets the value for SortField
        /// </summary>
        public string SortField
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value for SortDirection
        /// </summary>
        public string SortDirection
        {
            get;
            set;
        }
    }
}
