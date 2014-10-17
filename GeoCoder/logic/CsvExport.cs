using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;
using System.IO;
using System.Reflection;

namespace GeoCoder.logic
{
    /// <summary>
    /// the generic CsvExport class.
    /// This class handles the ability of the caller to export any list of objects 
    /// to call this method (for example):
    ///     var export = new CsvExport<AddressExport>(exportList);
    /// Here the user can call the CsvExport class and pass in their own custom object type and list of these object types. 
    /// </summary>
    /// <typeparam name="T">the class of objects being exported to csv</typeparam>
    public class CsvExport<T> where T : class
    {
        /// <summary>
        /// generic list of objects which are to be exported
        /// </summary>
        public List<T> Objects;

        /// <summary>
        /// the generic constructor
        /// </summary>
        /// <param name="objects">list of generic objects</param>
        public CsvExport(List<T> objects)
        {
            Objects = objects;
        }

        /// <summary>
        /// the default constructor
        /// </summary>
        /// <returns>returns the export method with headers</returns>
        public string Export()
        {
            return Export(true);
        }

        /// <summary>
        /// The export method of the csv class.
        /// This method:
        ///     -   creates the headers for the csv file
        ///     -   creates the value for each file from the list of generic objects
        /// </summary>
        /// <param name="includeHeaderLine">bool value to determine if a header line should be used or not</param>
        /// <returns>a string of exported data</returns>
        public string Export(bool includeHeaderLine)
        {
            var sb = new StringBuilder();

            //Get properties using reflection.
            IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();

            if (includeHeaderLine)
            {
                //add header line.
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    sb.Append(propertyInfo.Name).Append(",");
                }

                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            //add value for each property.
            foreach (T obj in Objects)
            {
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(",");
                }

                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// export to a file.
        /// </summary>
        /// <param name="path">path to export the file to</param>
        public void ExportToFile(string path)
        {
            File.WriteAllText(path, Export());
        }


        /// <summary>
        /// export as binary data.
        /// </summary>
        /// <returns>the bytes that have been exported</returns>
        public byte[] ExportToBytes()
        {
            return Encoding.UTF8.GetBytes(Export());
        }

        /// <summary>
        /// This method makes the value valid to be output in csv format.
        /// 
        /// Specific use cases include:
        ///     -   null values
        ///     -   DateTime values
        ///     -   string values with commas
        ///     -   string values with \'s
        /// </summary>
        /// <param name="value">the object that is being converted to it's csv value</param>
        /// <returns>the csv friendly string</returns>
        private string MakeValueCsvFriendly(object value)
        {
            if (value == null)
            {
                return "";
            }

            if (value is Nullable && ((INullable)value).IsNull)
            {
                return "";
            }

            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                {
                    return ((DateTime)value).ToString("yyyy-MM-dd");
                }   
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }

            string output = value.ToString();

            if (output.Contains(",") || output.Contains("\""))
            {
                output = '"' + output.Replace("\"", "\"\"") + '"';
            }
                
            return output;
        }
    }
}
