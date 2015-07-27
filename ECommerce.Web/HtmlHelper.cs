using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace ECommerce.Web {
    public class HtmlHelper {
        public static void DataProcess(string method, string orPath, HtmlDocument doc) {

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