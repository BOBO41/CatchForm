using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using ECommerce.Admin.DAL;
using HtmlAgilityPack;

namespace ECommerce.Web {
    public class HtmlHelper {
        private readonly ComInfo _comInfoDal = new ComInfo();
        private readonly Financel _financelDal = new Financel();
        private readonly CustomerService _customerServiceDal = new CustomerService();
        private readonly ProcessManu _processManuDal = new ProcessManu();
        private readonly DevelopmentService _developmentServiceDal = new DevelopmentService();
        private readonly AnswerWrapper _answerWrapperDal = new AnswerWrapper();
        private readonly DevelopAnswer _developAnswerDal = new DevelopAnswer();
        private readonly WorkAnswer _workAnswerDal = new WorkAnswer();
        private readonly ProdAnswer _prodAnswerDal = new ProdAnswer();
        private readonly BenchmarkCriteria _benchmarkDal = new BenchmarkCriteria();
        public void DataProcess(string or_path, HttpWebResponse wr, string query, NameValueCollection form) {
            string urlResponse = wr.ResponseUri.AbsolutePath;
            //var user = HttpContext.Current.Session["CurrentUser"] as OrgUsers;

            #region

            if ("/benchmark/createbenchmarkcompany.php" == or_path.ToLower() &&
                "/benchmark/benchmarkcompanycomplete.php" == urlResponse.ToLower()) {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                var rQuery = wr.ResponseUri.Query;
                if (!string.IsNullOrEmpty(rQuery)) {
                    var paras = rQuery.Substring(1).Split('&');
                    foreach (string para in paras) {
                        try {
                            var kv = para.Split('=');
                            dic.Add(kv[0], kv[1]);
                        }
                        catch (Exception) {
                        }
                    }
                }
                if (dic.ContainsKey("compId") && !string.IsNullOrEmpty(dic["compId"])) {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = dic["compId"] };
                    parameters.Add(comId);
                    Admin.Model.ComInfo exists = _comInfoDal.GetModel(" ComID=@ComID ", parameters);
                    var model = new Admin.Model.ComInfo();
                    //model.UId = user.UId;
                    model.ComID = dic["compId"];
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
            }
            #endregion

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

            #region 企业流程

            else if ("/benchmark/processmanumini.php" == or_path.ToLower() &&
                     "/benchmark/developmentmanumini.php" == urlResponse.ToLower()) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = form["comp_id"] };
                parameters.Add(comId);
                var exists = _processManuDal.GetModel(" ComID=@ComID ", parameters);
                var model = new Admin.Model.ProcessManu();
                //model.UId = user.UId;
                model.ComID = form["comp_id"];
                model.ICT1 = form["ICT1"];
                model.PC2 = form["PC2"];
                model.SUP3 = form["SUP3"];
                model.SUP2 = form["SUP2"];
                model.PS4 = form["PS4"];
                model.ENERGY_COST = form["ENERGY_COST"];
                model.WATER_COST = form["WATER_COST"];
                model.WASTE_COST = form["WASTE_COST"];
                model.TQUS = form["TQUS"];
                model.QDU = form["QDU"];
                model.CS7 = form["CS7"];
                model.MAN6 = form["MAN6"];
                model.MAN5 = form["MAN5"];
                model.MAN2 = form["MAN2"];
                if (null != exists) {
                    model.ID = exists.ID;
                    model.UpdateDate = DateTime.Now;
                    _processManuDal.Update(model);
                }
                else {
                    model.CreateDate = DateTime.Now;
                    _processManuDal.Add(model);
                }
            }

            #endregion

            #region 企业成长

            else if ("/benchmark/developmentmanumini.php" == or_path.ToLower() &&
                     "/benchmark/unido_inputpartb.php" == urlResponse.ToLower()) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = form["comp_id"] };
                parameters.Add(comId);
                var exists = _developmentServiceDal.GetModel(" ComID=@ComID ", parameters);
                var model = new Admin.Model.DevelopmentService();
                //model.UId = user.UId;
                model.ComID = form["comp_id"];
                model.HF15 = form["HF15"];
                model.PS3 = form["PS3"];
                model.PS1 = form["PS1"];
                model.HF24 = form["HF24"];
                model.HF23 = form["HF23"];
                model.PC4 = form["PC4"];
                model.PC3 = form["PC3"];
                model.INN1 = form["INN1"];
                if (null != exists) {
                    model.ID = exists.ID;
                    model.UpdateDate = DateTime.Now;
                    _developmentServiceDal.Update(model);
                }
                else {
                    model.CreateDate = DateTime.Now;
                    _developmentServiceDal.Add(model);
                }
            }

            #endregion

            #region 企业计划

            else if ("/benchmark/unido_inputpartb.php" == or_path.ToLower() &&
                     "/benchmark/unido_inputpartb.php" == urlResponse.ToLower() && "2" == form["section"]) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = form["comp_id"] };
                parameters.Add(comId);
                var exists = _answerWrapperDal.GetModel(" ComID=@ComID ", parameters);
                var model = new Admin.Model.AnswerWrapper();
                //model.UId = user.UId;
                model.ComID = form["comp_id"];
                model.Question_answer_1 = FormatAnswer(form["question_answer[1]"]);
                model.Question_answer_2 = FormatAnswer(form["question_answer[2]"]);
                model.Question_answer_3 = FormatAnswer(form["question_answer[3]"]);
                model.Question_answer_4 = FormatAnswer(form["question_answer[4]"]);
                model.Question_answer_5 = FormatAnswer(form["question_answer[5]"]);
                model.Question_answer_6 = FormatAnswer(form["question_answer[6]"]);
                if (null != exists) {
                    model.ID = exists.ID;
                    model.UpdateDate = DateTime.Now;
                    _answerWrapperDal.Update(model);
                }
                else {
                    model.CreateDate = DateTime.Now;
                    _answerWrapperDal.Add(model);
                }
            }

            #endregion

            #region 业务发展

            else if ("/benchmark/unido_inputpartb.php" == or_path.ToLower() &&
                     "/benchmark/unido_inputpartb.php" == urlResponse.ToLower() && "3" == form["section"]) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = form["comp_id"] };
                parameters.Add(comId);
                var exists = _developAnswerDal.GetModel(" ComID=@ComID ", parameters);
                var model = new Admin.Model.DevelopAnswer();
                //model.UId = user.UId;
                model.ComID = form["comp_id"];
                model.Question_answer_7 = NAString(form["question_answer[7]"]);
                model.Question_answer_8 = NAString(form["question_answer[8]"]);
                model.Question_answer_9 = NAString(form["question_answer[9]"]);
                model.Question_answer_10 = NAString(form["question_answer[10]"]);
                model.Question_answer_11 = NAString(form["question_answer[11]"]);
                model.Question_answer_12 = NAString(form["question_answer[12]"]);
                model.Question_answer_13 = NAString(form["question_answer[13]"]);
                model.Question_answer_14 = NAString(form["question_answer[14]"]);
                model.Question_answer_15 = NAString(form["question_answer[15]"]);
                model.Question_answer_16 = NAString(form["question_answer[16]"]);
                model.Question_answer_17 = NAString(form["question_answer[17]"]);
                model.Question_answer_18 = NAString(form["question_answer[18]"]);
                model.Question_answer_19 = NAString(form["question_answer[19]"]);
                model.Question_answer_20 = NAString(form["question_answer[20]"]);
                model.Question_answer_21 = NAString(form["question_answer[21]"]);
                model.Question_answer_22 = NAString(form["question_answer[22]"]);
                model.Question_answer_23 = NAString(form["question_answer[23]"]);
                model.Question_answer_24 = NAString(form["question_answer[24]"]);
                if (null != exists) {
                    model.ID = exists.ID;
                    model.UpdateDate = DateTime.Now;
                    _developAnswerDal.Update(model);
                }
                else {
                    model.CreateDate = DateTime.Now;
                    _developAnswerDal.Add(model);
                }
            }

            #endregion

            #region 工作市场

            else if ("/benchmark/unido_inputpartb.php" == or_path.ToLower() &&
                     "/benchmark/unido_inputpartb.php" == urlResponse.ToLower() && "4" == form["section"]) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = form["comp_id"] };
                parameters.Add(comId);
                var exists = _workAnswerDal.GetModel(" ComID=@ComID ", parameters);
                var model = new Admin.Model.WorkAnswer();
                //model.UId = user.UId;
                model.ComID = form["comp_id"];
                model.Question_answer_25 = NAString(form["question_answer[25]"]);
                model.Question_answer_26 = NAString(form["question_answer[26]"]);
                model.Question_answer_27 = NAString(form["question_answer[27]"]);
                model.Question_answer_28 = NAString(form["question_answer[28]"]);
                model.Question_answer_29 = NAString(form["question_answer[29]"]);
                model.Question_answer_30 = NAString(form["question_answer[30]"]);
                model.Question_answer_31 = NAString(form["question_answer[31]"]);
                model.Question_answer_32 = NAString(form["question_answer[32]"]);
                model.Question_answer_33 = NAString(form["question_answer[33]"]);
                model.Question_answer_34 = NAString(form["question_answer[34]"]);
                model.Question_answer_35 = NAString(form["question_answer[35]"]);
                model.Question_answer_36 = NAString(form["question_answer[36]"]);
                model.Question_answer_37 = NAString(form["question_answer[37]"]);
                model.Question_answer_38 = NAString(form["question_answer[38]"]);
                model.Question_answer_39 = NAString(form["question_answer[39]"]);
                model.Question_answer_40 = NAString(form["question_answer[40]"]);
                model.Question_answer_41 = NAString(form["question_answer[41]"]);
                model.Question_answer_42 = NAString(form["question_answer[42]"]);
                model.Question_answer_43 = NAString(form["question_answer[43]"]);
                model.Question_answer_44 = NAString(form["question_answer[44]"]);
                model.Question_answer_45 = NAString(form["question_answer[45]"]);
                model.Question_answer_46 = NAString(form["question_answer[46]"]);
                model.Question_answer_47 = NAString(form["question_answer[47]"]);
                if (null != exists) {
                    model.ID = exists.ID;
                    model.UpdateDate = DateTime.Now;
                    _workAnswerDal.Update(model);
                }
                else {
                    model.CreateDate = DateTime.Now;
                    _workAnswerDal.Add(model);
                }
            }

            #endregion

            #region 开发产品与服务

            else if ("/benchmark/unido_inputpartb.php" == or_path.ToLower() &&
                     "/benchmark/confbenchmark.php" == urlResponse.ToLower() && "last" == form["section"]) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = form["comp_id"] };
                parameters.Add(comId);
                var exists = _prodAnswerDal.GetModel(" ComID=@ComID ", parameters);
                var model = new Admin.Model.ProdAnswer();
                //model.UId = user.UId;
                model.ComID = form["comp_id"];
                model.Question_answer_48 = NAString(form["question_answer[48]"]);
                model.Question_answer_49 = NAString(form["question_answer[49]"]);
                model.Question_answer_50 = NAString(form["question_answer[50]"]);
                model.Question_answer_51 = NAString(form["question_answer[51]"]);
                model.Question_answer_52 = NAString(form["question_answer[52]"]);
                model.Question_answer_53 = NAString(form["question_answer[53]"]);
                model.Question_answer_54 = NAString(form["question_answer[54]"]);
                if (null != exists) {
                    model.ID = exists.ID;
                    model.UpdateDate = DateTime.Now;
                    _prodAnswerDal.Update(model);
                }
                else {
                    model.CreateDate = DateTime.Now;
                    _prodAnswerDal.Add(model);
                }
            }

            #endregion

            #region 基准测评

            else if ("/benchmark/acceptterms.php" == or_path.ToLower() &&
                     "/benchmark/acceptterms.php" == urlResponse.ToLower()) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = form["comp_id"] };
                parameters.Add(comId);
                var exists = _benchmarkDal.GetModel(" ComID=@ComID ", parameters);
                var model = new Admin.Model.BenchmarkCriteria();
                //model.UId = user.UId;
                model.ComID = form["comp_id"];
                model.Country_Regions = form["t_Country_Regions"];
                model.EMP1 = form["EMP1"];
                model.EMP2 = form["EMP2"];
                model.TURN1 = form["t_TURN1"];
                model.TURN2 = form["t_TURN2"];
                model.INDUSTRY = form["business-areas"].Replace("\n", "").Replace("\t", "").Replace("\r", "").Trim();
                model.List1 = form["t_list1"];
                model.List2 = form["t_list2"];
                model.SicCode = form["t_sicCode"];
                model.SelectedSicCodes = form["t_SelectedSicCodes"];
                model.PROBE_SIC = form["t_PROBE_SIC"];
                if (null != exists) {
                    model.ID = exists.ID;
                    model.UpdateDate = DateTime.Now;
                    _benchmarkDal.Update(model);
                }
                else {
                    model.CreateDate = DateTime.Now;
                    _benchmarkDal.Add(model);
                }
            }

            #endregion
        }

        private string FormatAnswer(string form) {
            switch (form) {
                case "0":
                    return "N/A";
                case "1":
                    return "A";
                case "2":
                    return "B";
                case "3":
                    return "C";
                case "4":
                    return "D";
                case "5":
                    return "E";
                default:
                    return "";
            }
        }

        private string NAString(string form) {
            if ("0" == form) {
                return "N/A";
            }
            else {
                return form;
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