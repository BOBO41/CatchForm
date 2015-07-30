
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// BenchmarkCriteria:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BenchmarkCriteria
	{
		public BenchmarkCriteria()
		{}
		#region Model
		private int _id;
		private string _comid;
		private int? _uid;
		private string _country_regions;
		private string _emp1;
		private string _emp2;
		private string _turn1;
		private string _turn2;
		private string _industry;
		private string _list1;
		private string _list2;
		private string _siccode;
		private string _selectedsiccodes;
		private string _probe_sic;
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
		public string Country_Regions
		{
			set{ _country_regions=value;}
			get{return _country_regions;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EMP1
		{
			set{ _emp1=value;}
			get{return _emp1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EMP2
		{
			set{ _emp2=value;}
			get{return _emp2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TURN1
		{
			set{ _turn1=value;}
			get{return _turn1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TURN2
		{
			set{ _turn2=value;}
			get{return _turn2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string INDUSTRY
		{
			set{ _industry=value;}
			get{return _industry;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string List1
		{
			set{ _list1=value;}
			get{return _list1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string List2
		{
			set{ _list2=value;}
			get{return _list2;}
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
		public string SelectedSicCodes
		{
			set{ _selectedsiccodes=value;}
			get{return _selectedsiccodes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PROBE_SIC
		{
			set{ _probe_sic=value;}
			get{return _probe_sic;}
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

