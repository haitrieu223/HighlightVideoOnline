using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;

namespace HighlightVideoOnline.Commons
{
    internal sealed class HttpUtility
    {
        internal sealed class HttpQSCollection : Dictionary<string, string>
        {
            public override string ToString()
            {
                int count = Count;
                if (count == 0)
                    return "";
                StringBuilder sb = new StringBuilder();
                var keys = this.Keys;
                foreach (var key in this.Keys)
                {
                    sb.AppendFormat("{0}={1}&", key, this[key]);
                }
                if (sb.Length > 0)
                    sb.Length--;
                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets the file contents.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The contents of the file.</returns>
        public static string GetFileContents(string filePath)
        {
            var contents = string.Empty;
            var path = filePath.ToLower();

            try
            {
                if (path.StartsWith("http:") || path.StartsWith("https:"))
                    return contents;

                var httpClient = new HttpClient();

                using (var stream = httpClient.GetStreamAsync(filePath).Result)
                using (var reader = new StreamReader(stream))
                {
                    contents = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return contents;
        }

        #region Constructors

        public HttpUtility()
        {
        }

        #endregion // Constructors

        #region Methods

        public static Dictionary<string, string> ParseQueryString(string query)
        {
            return ParseQueryString(query, Encoding.UTF8);
        }

        public static Dictionary<string, string> ParseQueryString(string query, Encoding encoding)
        {
            if (query == null)
                throw new ArgumentNullException("query");
            if (encoding == null)
                throw new ArgumentNullException("encoding");
            if (query.Length == 0 || (query.Length == 1 && query[0] == '?'))
                return new HttpQSCollection();
            if (query[0] == '?')
                query = query.Substring(1);

            var result = new HttpQSCollection();
            ParseQueryString(query, encoding, result);
            return result;
        }

        internal static void ParseQueryString(string query, Encoding encoding, Dictionary<string, string> result)
        {
            if (query.Length == 0)
                return;

            string decoded = System.Net.WebUtility.HtmlDecode(query);
            int decodedLength = decoded.Length;
            int namePos = 0;
            bool first = true;
            while (namePos <= decodedLength)
            {
                int valuePos = -1, valueEnd = -1;
                for (int q = namePos; q < decodedLength; q++)
                {
                    if (valuePos == -1 && decoded[q] == '=')
                    {
                        valuePos = q + 1;
                    }
                    else if (decoded[q] == '&')
                    {
                        valueEnd = q;
                        break;
                    }
                }

                if (first)
                {
                    first = false;
                    if (decoded[namePos] == '?')
                        namePos++;
                }

                string name, value;
                if (valuePos == -1)
                {
                    name = null;
                    valuePos = namePos;
                }
                else
                {
                    name = System.Net.WebUtility.UrlDecode(decoded.Substring(namePos, valuePos - namePos - 1));
                }
                if (valueEnd < 0)
                {
                    namePos = -1;
                    valueEnd = decoded.Length;
                }
                else
                {
                    namePos = valueEnd + 1;
                }
                value = System.Net.WebUtility.UrlDecode(decoded.Substring(valuePos, valueEnd - valuePos));

                result.Add(name, value);
                if (namePos == -1)
                    break;
            }
        }

        #endregion // Methods
    }
}
