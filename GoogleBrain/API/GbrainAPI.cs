using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace GoogleBrain
{
    public class GbrainAPI : IGbrainAPI
    {
        private const string GoogleBaseQueryString = "https://www.google.com/search?q=";
        private const string ResultDiv = "resultStats";

        public long GetNumerOfResults(params string[] keywords)
        {
            string URL = GenerateSearchURL(keywords);
            string page = GetPlainPage(URL);

            string divHTML = GetGoogleResultsDiv(page);
            long numResult = GetNumberOfResultsFromDiv(divHTML);
        
            return numResult;
        }

        private string GetPlainPage(string URL)
        {
            WebClient client = new WebClient();
            //client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            string downloadString = client.DownloadString(URL);
            return downloadString;
        }

        private string GenerateSearchURL(params string[] keywords)
        {
            string queryStr = GoogleBaseQueryString;
            for (int i = 0; i < keywords.Length-1; i++)
            {
                queryStr += keywords[i] + "+";
            }
            queryStr += keywords[keywords.Length - 1];
            return queryStr;
        }

        private string GetGoogleResultsDiv(string page)
        {
            string divname = "id=\"resultStats\">";
            int StartDivIndex = page.IndexOf(divname);
            int EndDivIndex = page.IndexOf("</div>", StartDivIndex);

            string divInnerHtml = page.Substring(StartDivIndex + divname.Length, EndDivIndex - StartDivIndex - divname.Length);
            return divInnerHtml;
        }

        private long GetNumberOfResultsFromDiv(string div)
        {
            Regex regex = new Regex(@"(?<=\s)([0-9\.\,]+)(?=\s)");
            Match match = regex.Match(div);
            if (match.Success)
            {
                char[] strNum = match.Value.Where(c => ((int)c < 58 && (int)c > 47)).ToArray();
                if (long.TryParse(strNum, out long res))
                {
                    return res;
                }
                return -2;
            }
            return -1;
        }

        //just here to remember me to make an async version :D
        private async void GetPlainHTML()
        {
            // ... Target page.
            string page = "http://en.wikipedia.org/";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null &&
                    result.Length >= 50)
                {
                    Console.WriteLine(result.Substring(0, 50) + "...");
                }
            }
        }
    }
}
