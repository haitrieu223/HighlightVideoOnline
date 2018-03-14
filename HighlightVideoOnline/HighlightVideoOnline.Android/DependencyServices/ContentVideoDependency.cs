using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HighlightVideoOnline.DependencyServices;
using HighlightVideoOnline.Droid.DependencyServices;
using Java.IO;
using Java.Net;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ContentVideoDependency))]
namespace HighlightVideoOnline.Droid.DependencyServices
{
    public class ContentVideoDependency : IContentVideoDependency
    {
        public string DownloadUrl(string urlIput)
        {
            Stream inputStream = null;
            String contentAsString = "";
            try
            {
                URL url = new URL(urlIput);
                HttpURLConnection conn = (HttpURLConnection)url.OpenConnection();
                conn.ReadTimeout = 10000;
                conn.ConnectTimeout = 15000;
                conn.RequestMethod = "GET";
                conn.DoInput = true;
                conn.Connect();
                inputStream = conn.InputStream;
                contentAsString = readIt(inputStream);
                return contentAsString;
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (inputStream != null)
                {
                    inputStream.Close();
                }
            }

        }

        public string readIt(Stream stream)
        {
            BufferedReader reader = new BufferedReader(new InputStreamReader(stream, "UTF-8"));
            StringBuilder sb = new StringBuilder();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("fmt_stream_map"))
                {
                    sb.Append(line + "\n");
                    break;
                }
            }
            reader.Close();
            string result = decode(sb.ToString());
            string[] stringSeparators = new string[] { "\\|" };
            string[] url = result.Split(stringSeparators, StringSplitOptions.None);
            return url[1];
        }

        public String decode(String inDe)
        {
            String working = inDe;
            int index;
            index = working.IndexOf("\\u");
            while (index > -1)
            {
                int length = working.Length;
                if (index > (length - 6)) break;
                int numStart = index + 2;
                int numFinish = numStart + 4;
                String substring = working.Substring(numStart, numFinish);
                int number = int.Parse(substring);
                String stringStart = working.Substring(0, index);
                String stringEnd = working.Substring(numFinish);
                working = stringStart + ((char)number) + stringEnd;
                index = working.IndexOf("\\u");
            }
            return working;
        }
    }
}