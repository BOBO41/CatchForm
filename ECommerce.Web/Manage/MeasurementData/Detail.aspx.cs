using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ECommerce.Admin.DAL;
using ECommerce.Web.UI;

namespace ECommerce.Web.Manage.MeasurementData {
    public partial class Detail : WebPage {
        private readonly ComInfo _comInfoDal = new ComInfo();
        private readonly BenchmarkCriteria _benchmarkDal = new BenchmarkCriteria();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["id"])) {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
                    parameters.Add(comId);
                    Admin.Model.BenchmarkCriteria model = _benchmarkDal.GetModel(" ComID=@ComID ", parameters);
                    if (null != model) {
                        Literal1.Text = model.Country_Regions;
                        Literal2.Text = model.EMP1;
                        Literal3.Text = model.EMP2;
                        Literal4.Text = model.TURN1;
                        Literal5.Text = model.TURN2;
                        Literal6.Text = model.INDUSTRY;
                        Literal7.Text = model.List1;
                        Literal8.Text = model.List2;
                        Literal9.Text = model.SicCode.Replace("全部选中<br/>", "");
                        Literal10.Text = model.SelectedSicCodes;
                        Literal11.Text = model.PROBE_SIC;
                    }
                }
            }
            catch {
            }
        }
    }
}