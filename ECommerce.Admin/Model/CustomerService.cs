
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// CustomerService:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CustomerService
	{
		public CustomerService()
		{}
		#region Model
		private int _id;
		private string _comid;
		private int? _uid;
		private string _cs1;
		private string _inn4;
		private string _hf22;
		private string _cs2;
		private string _cs4;
		private string _nld;
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
		public string CS1
		{
			set{ _cs1=value;}
			get{return _cs1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string INN4
		{
			set{ _inn4=value;}
			get{return _inn4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HF22
		{
			set{ _hf22=value;}
			get{return _hf22;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CS2
		{
			set{ _cs2=value;}
			get{return _cs2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CS4
		{
			set{ _cs4=value;}
			get{return _cs4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NLD
		{
			set{ _nld=value;}
			get{return _nld;}
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

