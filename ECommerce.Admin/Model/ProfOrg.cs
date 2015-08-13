
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// ProfOrg:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProfOrg
	{
		public ProfOrg()
		{}
		#region Model
		private int _oid;
		private string _name;
		private string _orgaptitude;
		private string _yyzz;
		private string _addr;
		private string _fr;
		private string _tel;
		private string _contact;
		private string _email;
		private string _descr;
		private string _majorsell;
		private int? _uid;
		private int? _status;
		private DateTime? _createdate= DateTime.Now;
		private DateTime? _updatedate;
		/// <summary>
		/// 
		/// </summary>
		public int OID
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrgAptitude
		{
			set{ _orgaptitude=value;}
			get{return _orgaptitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YYZZ
		{
			set{ _yyzz=value;}
			get{return _yyzz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FR
		{
			set{ _fr=value;}
			get{return _fr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Descr
		{
			set{ _descr=value;}
			get{return _descr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MajorSell
		{
			set{ _majorsell=value;}
			get{return _majorsell;}
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
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
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

