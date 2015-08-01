using System;
using ECommerce.Admin.DAL;
using ECommerce.Web.UI;

namespace ECommerce.Web.Manage.Companies {
    public partial class Detail : WebPage {
        private readonly ComInfo _comInfoDal = new ComInfo();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["id"])) {
                    Admin.Model.ComInfo model = _comInfoDal.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                    if (null != model) {
                        Literal1.Text = model.ComName;
                        Literal2.Text = model.Add1;
                        Literal3.Text = model.Add2;
                        Literal4.Text = model.Add3;
                        Literal5.Text = model.City;
                        Literal6.Text = model.Area;
                        Literal7.Text = model.PostCode;
                        Literal8.Text = model.Country;
                        Literal9.Text = model.Phone;
                        Literal10.Text = model.Fax;
                        Literal11.Text = model.ComDesc;
                        Literal12.Text = model.Industry;
                        Literal13.Text = model.SubIndustry;
                        Literal14.Text = model.SicCode;

                        Literal24.Text = model.Industry2;
                        Literal25.Text = model.SubIndustry2;
                        Literal26.Text = model.SicCode2;

                        Literal15.Text = model.Probe_sic;
                        Literal16.Text = model.Probe_sic2;
                        Literal17.Text = model.Probe_sic3;
                        Literal18.Text = model.Employees;
                        Literal19.Text = model.Domestic_company;
                        Literal20.Text = model.Title;
                        Literal21.Text = model.ContactFirstName;
                        Literal22.Text = model.contactSurname;
                        Literal23.Text = model.JobTitle;
                        Literal27.Text = model.ComID;
                    }
                }
            }
            catch {
            }
        }
    }
}