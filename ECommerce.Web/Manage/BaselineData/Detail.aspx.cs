using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ECommerce.Admin.DAL;
using ECommerce.Web.UI;

namespace ECommerce.Web.Manage.BaselineData {
    public partial class Detail : WebPage {
        private readonly ComInfo _comInfoDal = new ComInfo();
        private readonly Financel _financelDal = new Financel();
        private readonly CustomerService _customerServiceDal = new CustomerService();
        private readonly ProcessManu _processManuDal = new ProcessManu();
        private readonly DevelopmentService _developmentServiceDal = new DevelopmentService();
        private readonly AnswerWrapper _answerWrapperDal = new AnswerWrapper();
        private readonly DevelopAnswer _developAnswerDal = new DevelopAnswer();
        private readonly WorkAnswer _workAnswerDal = new WorkAnswer();
        private readonly ProdAnswer _prodAnswerDal = new ProdAnswer();
        string where = " ComID=@ComID ";
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["id"])) {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
                    parameters.Add(comId);
                    //#region 

                    //Admin.Model.ComInfo model = _comInfoDal.GetModel(where,parameters);;
                    //if (null != model)
                    //{
                    //    Literal1.Text = model.ComName;
                    //    Literal2.Text = model.Add1;
                    //    Literal3.Text = model.Add2;
                    //    Literal4.Text = model.Add3;
                    //    Literal5.Text = model.City;
                    //    Literal6.Text = model.Area;
                    //    Literal7.Text = model.PostCode;
                    //    Literal8.Text = model.Country;
                    //    Literal9.Text = model.Phone;
                    //    Literal10.Text = model.Fax;
                    //    Literal11.Text = model.ComDesc;
                    //    Literal12.Text = model.Industry;
                    //    Literal13.Text = model.SubIndustry;
                    //    Literal14.Text = model.SicCode;

                    //    Literal24.Text = model.Industry2;
                    //    Literal25.Text = model.SubIndustry2;
                    //    Literal26.Text = model.SicCode2;

                    //    Literal15.Text = model.Probe_sic;
                    //    Literal16.Text = model.Probe_sic2;
                    //    Literal17.Text = model.Probe_sic3;
                    //    Literal18.Text = model.Employees;
                    //    Literal19.Text = model.Domestic_company;
                    //    Literal20.Text = model.Title;
                    //    Literal21.Text = model.ContactFirstName;
                    //    Literal22.Text = model.contactSurname;
                    //    Literal23.Text = model.JobTitle;
                    //    Literal27.Text = model.ComID;
                    //}

                    //#endregion

                    GetFinancel();
                    GetCustomerService();
                    GetProcessManu();
                    GetDevelopmentService();
                    GetAnswerWrapper();
                    GetDevelopAnswer();
                    GetWorkAnswer();
                    GetProdAnswer();
                }
            }
            catch {
            }
        }

        protected void GetFinancel() {
            #region
            List<SqlParameter> parameters = new List<SqlParameter>();
            var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
            parameters.Add(comId);
            Admin.Model.Financel model = _financelDal.GetModel(where, parameters);
            if (null != model) {
                Literal1.Text = model.ComID;
                Literal2.Text = model.Fyear;
                Literal3.Text = model.HF1;
                Literal4.Text = model.HF2;
                Literal5.Text = model.HF28;
                Literal6.Text = model.GHF1;
                Literal7.Text = model.GHF2;
                Literal8.Text = model.GHF28;
                Literal9.Text = model.HF43;
                Literal10.Text = model.HF44;
                Literal11.Text = model.HF3;
                Literal12.Text = model.GHF3;
                Literal13.Text = model.HF40;
                Literal14.Text = model.GHF40;
                Literal15.Text = model.HF6;
                Literal16.Text = model.HF8;
                Literal17.Text = model.HF20;
                Literal18.Text = model.HF45;
                Literal19.Text = model.HF7;
                Literal20.Text = model.HF13;
                Literal21.Text = model.HF12;
                Literal22.Text = model.HF10;
                Literal23.Text = model.HF11;
                Literal24.Text = model.HF9;
                Literal25.Text = model.HF14;
                Literal26.Text = model.HF21;
            }

            #endregion
        }

        protected void GetCustomerService() {
            #region
            List<SqlParameter> parameters = new List<SqlParameter>();
            var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
            parameters.Add(comId);
            Admin.Model.CustomerService model = _customerServiceDal.GetModel(where, parameters);
            if (null != model) {
                Literal27.Text = model.CS1;
                Literal28.Text = model.INN4;
                Literal29.Text = model.HF22;
                Literal30.Text = model.CS2;
                Literal31.Text = model.CS4;
                Literal32.Text = model.NLD;
            }

            #endregion
        }

        protected void GetProcessManu() {
            #region
            List<SqlParameter> parameters = new List<SqlParameter>();
            var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
            parameters.Add(comId);
            Admin.Model.ProcessManu model = _processManuDal.GetModel(where, parameters); ;
            if (null != model) {
                Literal33.Text = model.ICT1;
                Literal34.Text = model.PC2;
                Literal35.Text = model.SUP3;
                Literal36.Text = model.SUP2;
                Literal37.Text = model.PS4;
                Literal38.Text = model.ENERGY_COST;
                Literal39.Text = model.WATER_COST;
                Literal40.Text = model.WASTE_COST;
                Literal41.Text = model.TQUS;
                Literal42.Text = model.QDU;
                Literal43.Text = model.CS7;
                Literal44.Text = model.MAN6;
                Literal45.Text = model.MAN5;
                Literal46.Text = model.MAN2;
            }

            #endregion
        }

        protected void GetDevelopmentService() {
            #region
            List<SqlParameter> parameters = new List<SqlParameter>();
            var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
            parameters.Add(comId);
            Admin.Model.DevelopmentService model = _developmentServiceDal.GetModel(where, parameters); ;
            if (null != model) {
                Literal47.Text = model.HF15;
                Literal48.Text = model.PS3;
                Literal49.Text = model.PS1;
                Literal50.Text = model.HF24;
                Literal51.Text = model.HF23;
                Literal52.Text = model.PC4;
                Literal53.Text = model.PC3;
                Literal54.Text = model.INN1;
            }

            #endregion
        }

        protected void GetAnswerWrapper() {
            #region
            List<SqlParameter> parameters = new List<SqlParameter>();
            var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
            parameters.Add(comId);
            Admin.Model.AnswerWrapper model = _answerWrapperDal.GetModel(where, parameters); ;
            if (null != model) {
                Literal55.Text = model.Question_answer_1;
                Literal56.Text = model.Question_answer_2;
                Literal57.Text = model.Question_answer_3;
                Literal58.Text = model.Question_answer_4;
                Literal59.Text = model.Question_answer_5;
                Literal60.Text = model.Question_answer_6;
            }

            #endregion
        }

        protected void GetDevelopAnswer() {
            #region
            List<SqlParameter> parameters = new List<SqlParameter>();
            var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
            parameters.Add(comId);
            Admin.Model.DevelopAnswer model = _developAnswerDal.GetModel(where, parameters); ;
            if (null != model) {
                Literal61.Text = model.Question_answer_7;
                Literal62.Text = model.Question_answer_8;
                Literal63.Text = model.Question_answer_9;
                Literal64.Text = model.Question_answer_10;
                Literal65.Text = model.Question_answer_11;
                Literal66.Text = model.Question_answer_12;
                Literal67.Text = model.Question_answer_13;
                Literal68.Text = model.Question_answer_14;
                Literal69.Text = model.Question_answer_15;
                Literal70.Text = model.Question_answer_16;
                Literal71.Text = model.Question_answer_17;
                Literal72.Text = model.Question_answer_18;
                Literal73.Text = model.Question_answer_19;
                Literal74.Text = model.Question_answer_20;
                Literal75.Text = model.Question_answer_21;
                Literal76.Text = model.Question_answer_22;
                Literal77.Text = model.Question_answer_23;
                Literal78.Text = model.Question_answer_24;
            }

            #endregion
        }

        protected void GetWorkAnswer() {
            #region
            List<SqlParameter> parameters = new List<SqlParameter>();
            var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
            parameters.Add(comId);
            Admin.Model.WorkAnswer model = _workAnswerDal.GetModel(where, parameters); ;
            if (null != model) {
                Literal79.Text = model.Question_answer_25;
                Literal80.Text = model.Question_answer_26;
                Literal81.Text = model.Question_answer_27;
                Literal82.Text = model.Question_answer_28;
                Literal83.Text = model.Question_answer_29;
                Literal84.Text = model.Question_answer_30;
                Literal85.Text = model.Question_answer_31;
                Literal86.Text = model.Question_answer_32;
                Literal87.Text = model.Question_answer_33;
                Literal88.Text = model.Question_answer_34;
                Literal89.Text = model.Question_answer_35;
                Literal90.Text = model.Question_answer_36;
                Literal91.Text = model.Question_answer_37;
                Literal92.Text = model.Question_answer_38;
                Literal93.Text = model.Question_answer_39;
                Literal94.Text = model.Question_answer_40;
                Literal95.Text = model.Question_answer_41;
                Literal96.Text = model.Question_answer_42;
                Literal97.Text = model.Question_answer_43;
                Literal98.Text = model.Question_answer_44;
                Literal99.Text = model.Question_answer_45;
                Literal100.Text = model.Question_answer_46;
                Literal101.Text = model.Question_answer_47;
            }

            #endregion
        }

        protected void GetProdAnswer() {
            #region
            List<SqlParameter> parameters = new List<SqlParameter>();
            var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
            parameters.Add(comId);
            Admin.Model.ProdAnswer model = _prodAnswerDal.GetModel(where, parameters); ;
            if (null != model) {
                Literal102.Text = model.Question_answer_48;
                Literal103.Text = model.Question_answer_49;
                Literal104.Text = model.Question_answer_50;
                Literal105.Text = model.Question_answer_51;
                Literal106.Text = model.Question_answer_52;
                Literal107.Text = model.Question_answer_53;
                Literal108.Text = model.Question_answer_54;
            }

            #endregion
        }

    }
}