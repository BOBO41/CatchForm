using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using ECommerce.Admin.DAL;
using HtmlAgilityPack;

namespace ECommerce.Web {
    public class HtmlHelper {
        private readonly ComInfo _comInfoDal = new ComInfo();
        private readonly Financel _financelDal = new Financel();
        private readonly CustomerService _customerServiceDal = new CustomerService();
        public void DataProcess(string or_path, string urlResponse, string query, NameValueCollection form) {
            //var user = HttpContext.Current.Session["CurrentUser"] as OrgUsers;
            if ("/benchmark/createbenchmarkcompany.php" == or_path.ToLower() && "" == urlResponse.ToLower()) {

            }

            #region 编辑公司信息

            else if ("/benchmark/getbmcompanydetails.php" == or_path.ToLower() &&
                     "/benchmark/benchmarkcompanycomplete.php" == urlResponse.ToLower()) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = form["comp_id"] };
                parameters.Add(comId);
                Admin.Model.ComInfo exists = _comInfoDal.GetModel(" ComID=@ComID ", parameters);
                var model = new Admin.Model.ComInfo();
                //model.UId = user.UId;
                model.ComID = form["comp_id"];
                model.Add1 = form["add1"];
                model.Add2 = form["add2"];
                model.Add3 = form["add3"];
                model.Area = form["t_region"];
                model.City = form["city"];
                model.ComDesc = form["businessDescription"];
                model.ComName = form["companyName"];
                model.ContactFirstName = form["contactFirstName"];
                model.contactSurname = form["contactSurname"];
                model.Country = form["country_name"];
                model.Employees = form["employees"];
                model.Fax = form["fax"];
                model.Phone = form["telephone"];
                model.PostCode = form["postcode"];
                model.Industry = form["t_industry"];
                model.SubIndustry = form["t_subIndustry"];
                model.SicCode = form["t_sicCode"];
                model.Industry2 = form["t_industry_2"];
                model.SubIndustry2 = form["t_subIndustry_2"];
                model.SicCode2 = form["t_sicCode_2"];
                model.Probe_sic = form["t_probe_sic_select_1"];
                model.Probe_sic2 = form["t_probe_sic_select_2"];
                model.Probe_sic3 = form["t_probe_sic_select_3"];
                model.Domestic_company = "0" == form["domestic_company"] ? "别国" : "是的";
                model.Title = form["title"];
                model.JobTitle = form["jobTitle"];
                if (null != exists) {
                    model.ID = exists.ID;
                    model.UpdateDate = DateTime.Now;
                    _comInfoDal.Update(model);
                }
                else {
                    model.CreateDate = DateTime.Now;
                    _comInfoDal.Add(model);
                }
            }

            #endregion

            #region 编辑企业财务

            else if ("/benchmark/financemini.php" == or_path.ToLower() &&
                     "/benchmark/customerservicemini.php" == urlResponse.ToLower()) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = form["comp_id"] };
                parameters.Add(comId);
                var exists = _financelDal.GetModel(" ComID=@ComID ", parameters);
                var model = new Admin.Model.Financel();
                //model.UId = user.UId;
                model.ComID = form["comp_id"];
                model.Fyear = form["fyear"];
                model.HF1 = form["HF1"];
                model.HF2 = form["HF2"];
                model.HF28 = form["HF28"];
                model.GHF1 = form["GHF1"];
                model.GHF2 = form["GHF2"];
                model.GHF28 = form["GHF28"];
                model.HF43 = form["HF43"];
                model.HF44 = form["HF44"];
                model.HF3 = form["HF3"];
                model.GHF3 = form["GHF3"];
                model.HF40 = form["HF40"];
                model.GHF40 = form["GHF40"];
                model.HF6 = form["HF6"];
                model.HF8 = form["HF8"];
                model.HF20 = form["HF20"];
                model.HF45 = form["HF45"];
                model.HF7 = form["HF7"];
                model.HF13 = form["HF13"];
                model.HF12 = form["HF12"];
                model.HF10 = form["HF10"];
                model.HF11 = form["HF11"];
                model.HF9 = form["HF9"];
                model.HF14 = form["HF14"];
                model.HF21 = form["HF21"];
                if (null != exists) {
                    model.ID = exists.ID;
                    model.UpdateDate = DateTime.Now;
                    _financelDal.Update(model);
                }
                else {
                    model.CreateDate = DateTime.Now;
                    _financelDal.Add(model);
                }
            }

            #endregion

            #region 编辑企业客户

            else if ("/benchmark/customerservicemini.php" == or_path.ToLower() &&
                     "/benchmark/processmanumini.php" == urlResponse.ToLower()) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = form["comp_id"] };
                parameters.Add(comId);
                var exists = _customerServiceDal.GetModel(" ComID=@ComID ", parameters);
                var model = new Admin.Model.CustomerService();
                //model.UId = user.UId;
                model.ComID = form["comp_id"];
                model.CS1 = form["CS1"];
                model.INN4 = form["INN4"];
                model.HF22 = form["HF22"];
                model.CS2 = form["CS2"];
                model.CS4 = form["CS4"];
                model.NLD = form["NLD"];
                if (null != exists) {
                    model.ID = exists.ID;
                    model.UpdateDate = DateTime.Now;
                    _customerServiceDal.Update(model);
                }
                else {
                    model.CreateDate = DateTime.Now;
                    _customerServiceDal.Add(model);
                }
            }

            #endregion


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