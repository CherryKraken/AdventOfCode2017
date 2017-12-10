using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class FileLoader
    {
        public static string FromUri(string uriString)
        {
            //WebClient client = new WebClient();
            //client.Proxy = null;
            //client.Headers.Add("Content-Type", "text/plain;charset=UTF-8");
            //client.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10 ( .NET CLR 3.5.30729; .NET4.0C)");
            //return client.DownloadString(uriString);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriString);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                string data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();

                return data;
            }
            else
            {
                throw new Exception("string download failed");
            }
        }

        public static string FromFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
