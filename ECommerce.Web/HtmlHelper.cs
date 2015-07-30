using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace ECommerce.Web {
    public class HtmlHelper {
        public static void DataProcess(string or_path, string urlResponse, string query, string form) {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(form)) {
                var paras = form.Split('&');
                foreach (var data in paras.Select(para => para.Split('='))) {
                    dictionary.Add(data[0], data[1]);
                }
            }

            if ("/benchmark/createbenchmarkcompany.php" == or_path.ToLower() && "" == urlResponse.ToLower()) {

            }
            else if ("/benchmark/createbenchmarkcompany.php" == or_path.ToLower() && "" == urlResponse.ToLower()) {

            }

        }

        public static HtmlDocument AppendScript(string orPath, HtmlDocument doc) {
            string fun = string.Empty;
            switch (orPath.ToLower()) {
                case "/benchmark/createbenchmarkcompany.php":
                    fun = "createcompany();";
                    break;
                case "": fun = "";
                    break;
                default:
                    break;
            }
            HtmlNode head = doc.DocumentNode.SelectSingleNode("//head");
            if (!string.IsNullOrEmpty(fun)) {
                HtmlNode btn = doc.GetElementbyId("next");
                btn.SetAttributeValue("onclick", fun);
                HtmlNode jquery = HtmlNode.CreateNode("<script src=\"/Scripts/jquery-1.7.1.min.js\"></script>");
                head.AppendChild(jquery);
            }
            return doc;
        }
    }
}