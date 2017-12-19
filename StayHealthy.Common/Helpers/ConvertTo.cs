namespace StayHealthy.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Manage to Convert the Data Type to other Data Type
    /// </summary>
    /// <CreatedBy>Sanjay Suthar</CreatedBy>
    /// <CreatedDate>22-Feb-2015</CreatedDate>
    public class ConvertTo
    {
        #region Constructor

        /// <summary>
        /// Prevents a default instance of the ConvertTo class from being created.
        /// </summary>
        private ConvertTo()
        {
        }

        #endregion

        #region Variable/Property Declaration
        #endregion

        #region Methods/Functions

        /// <summary> 
        /// check for given value is null string 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>if value=string return string else ""</returns> 
        public static string String(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    return Convert.ToString(readField, CultureInfo.InvariantCulture);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary> 
        /// check for given value is not double 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>if value=double return double else 0.0</returns> 
        public static double Double(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0.0;
                    }
                    else
                    {
                        return Convert.ToDouble(readField, CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    return 0.0;
                }
            }
            else
            {
                return 0.0;
            }
        }

        /// <summary> 
        /// check for given value is not decimal 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>if value=double return double else 0.0</returns> 
        public static decimal Decimal(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        decimal x;
                        if (decimal.TryParse(readField.ToString(), out x))
                        {
                            //x = decimal.Round(x, ProjectConfiguration.DecimalPlace);
                            return x;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary> 
        /// check for given value is not decimal 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <param name="numberOfDecimalPlace">number Of Decimal Place</param> 
        /// <returns>if value=double return double else 0.0</returns> 
        public static decimal Decimal(object readField, int numberOfDecimalPlace)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        decimal x;
                        if (decimal.TryParse(readField.ToString(), out x))
                        {
                            x = decimal.Round(x, numberOfDecimalPlace);
                            return x;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary> 
        /// check given value is boolean or null 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>return true else false</returns> 
        public static bool Boolean(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    bool x;
                    if (bool.TryParse(Convert.ToString(readField, CultureInfo.InvariantCulture), out x))
                    {
                        return x;
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
            else
            {
                return false;
            }
        }

        /// <summary> 
        /// check given value is boolean or null 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>return true else false</returns> 
        public static bool? BoolNull(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    bool x;
                    if (bool.TryParse(Convert.ToString(readField, CultureInfo.InvariantCulture), out x))
                    {
                        return x;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary> 
        /// check given value is integer or null 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>return integer else 0</returns> 
        public static int Integer(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        int toReturn;
                        if (int.TryParse(Convert.ToString(readField, CultureInfo.InvariantCulture), out toReturn))
                        {
                            return toReturn;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary> 
        /// check given value is long or null 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>return long else 0</returns> 
        public static long Long(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        long toReturn;
                        if (long.TryParse(Convert.ToString(readField, CultureInfo.InvariantCulture), out toReturn))
                        {
                            return toReturn;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary> 
        /// check given value is short or null 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>return short else 0</returns> 
        public static short Short(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        short toReturn = 0;
                        if (short.TryParse(Convert.ToString(readField, CultureInfo.InvariantCulture), out toReturn))
                        {
                            return toReturn;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary> 
        /// check given value of date is date or null 
        /// </summary> 
        /// <param name="readField">date value to check</param> 
        /// <returns>return date if valid format else return nothing</returns> 
        public static DateTime? Date(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    DateTime dateReturn;
                    if (DateTime.TryParse(Convert.ToString(readField, CultureInfo.CurrentCulture), out dateReturn))
                    {
                        return Convert.ToDateTime(readField, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }

        /// <summary> 
        /// check given value of date is date or null 
        /// </summary> 
        /// <param name="readField">date value to check</param> 
        /// <returns>return date if valid format else return nothing</returns> 
        public static string DateFormat(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    DateTime dateReturn;
                    if (DateTime.TryParse(Convert.ToString(readField, CultureInfo.CurrentCulture), out dateReturn))
                    {
                        return Convert.ToDateTime(readField, CultureInfo.InvariantCulture).GetDateTimeFormats('d', CultureInfo.InvariantCulture)[5];
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary> 
        /// check given value of date is date or null 
        /// </summary> 
        /// <param name="readField">date value to check</param> 
        /// <param name="dateFormat">Date format</param> 
        /// <returns>return date if valid format else return nothing</returns> 
        public static string Date(object readField, string dateFormat)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (!string.IsNullOrEmpty(dateFormat))
                    {
                        return Convert.ToDateTime(readField, CultureInfo.CurrentCulture).ToString(dateFormat, CultureInfo.InvariantCulture);
                    }

                    return Convert.ToDateTime(readField, CultureInfo.CurrentCulture).ToString(CultureInfo.CurrentCulture);
                }
            }

            return DateTime.MinValue.ToString(CultureInfo.CurrentCulture);
        }

        /// <summary> 
        /// for save null value in database 
        /// </summary> 
        /// <param name="value">object to convert</param> 
        /// <returns>return DBNull value</returns> 
        public static object DBNullValue(string value)
        {
            if (value == null | string.IsNullOrEmpty(value))
            {
                return System.DBNull.Value;
            }

            return value;
        }

        /// <summary>
        /// Set Default Value to Data row
        /// </summary>
        /// <param name="dr">Set DBNull value for Row</param>
        public static void DefaultValuesForDBNull(System.Data.DataRow dr)
        {
            TypeCode typeCode = default(TypeCode);

            foreach (System.Data.DataColumn col in dr.Table.Columns)
            {
                typeCode = Type.GetTypeCode(col.DataType);
                if (Convert.IsDBNull(dr[col]))
                {
                    switch (typeCode)
                    {
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.Decimal:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.UInt16:
                        case TypeCode.UInt32:
                        case TypeCode.UInt64:
                        case TypeCode.Byte:
                            dr[col] = 0;
                            break;
                        case TypeCode.Char:
                        case TypeCode.String:
                            dr[col] = string.Empty;
                            break;
                        case TypeCode.Boolean:
                            dr[col] = false;
                            break;
                        case TypeCode.DateTime:
                            dr[col] = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Set Default Value for Data Table
        /// </summary>
        /// <param name="table">Set DBNull value</param>
        public static void DefaultValuesForDBNull(System.Data.DataTable table)
        {
            foreach (System.Data.DataRow dr in table.Rows)
            {
                DefaultValuesForDBNull(dr);
            }
        }

        #endregion
    }
}
