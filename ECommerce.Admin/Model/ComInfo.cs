
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// ComInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ComInfo
	{
		public ComInfo()
		{}
		#region Model
		private int _id;
		private string _comid;
		private int? _uid;
		private string _comname;
		private string _add1;
		private string _add2;
		private string _add3;
		private string _city;
		private string _area;
		private string _postcode;
		private string _country;
		private string _phone;
		private string _fax;
		private string _comdesc;
		private string _industry;
		private string _subindustry;
		private string _siccode;
		private string _industry2;
		private string _subindustry2;
		private string _siccode2;
		private string _probe_sic;
		private string _probe_sic2;
		private string _probe_sic3;
		private string _employees;
		private string _domestic_company;
		private string _title;
		private string _contactfirstname;
		private string _contactsurname;
		private string _jobtitle;
		private DateTime? _createdate= DateTime.Now;
		private DateTime? _updatedate;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComID
		{
			set{ _comid=value;}
			get{return _comid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComName
		{
			set{ _comname=value;}
			get{return _comname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Add1
		{
			set{ _add1=value;}
			get{return _add1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Add2
		{
			set{ _add2=value;}
			get{return _add2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Add3
		{
			set{ _add3=value;}
			get{return _add3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostCode
		{
			set{ _postcode=value;}
			get{return _postcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComDesc
		{
			set{ _comdesc=value;}
			get{return _comdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Industry
		{
			set{ _industry=value;}
			get{return _industry;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SubIndustry
		{
			set{ _subindustry=value;}
			get{return _subindustry;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SicCode
		{
			set{ _siccode=value;}
			get{return _siccode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Industry2
		{
			set{ _industry2=value;}
			get{return _industry2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SubIndustry2
		{
			set{ _subindustry2=value;}
			get{return _subindustry2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SicCode2
		{
			set{ _siccode2=value;}
			get{return _siccode2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Probe_sic
		{
			set{ _probe_sic=value;}
			get{return _probe_sic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Probe_sic2
		{
			set{ _probe_sic2=value;}
			get{return _probe_sic2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Probe_sic3
		{
			set{ _probe_sic3=value;}
			get{return _probe_sic3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Employees
		{
			set{ _employees=value;}
			get{return _employees;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Domestic_company
		{
			set{ _domestic_company=value;}
			get{return _domestic_company;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContactFirstName
		{
			set{ _contactfirstname=value;}
			get{return _contactfirstname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contactSurname
		{
			set{ _contactsurname=value;}
			get{return _contactsurname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JobTitle
		{
			set{ _jobtitle=value;}
			get{return _jobtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model

	}
}

