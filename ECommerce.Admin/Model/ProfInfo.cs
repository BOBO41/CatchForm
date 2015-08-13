
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// ProfInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProfInfo
	{
		public ProfInfo()
		{}
		#region Model
		private int _piid;
		private int? _ptid;
		private string _name;
		private int? _uid;
		private string _age;
		private string _comaddr;
		private string _job;
		private string _majorsearch;
		private string _descri;
		private string _education;
		private string _photo;
		private int? _status;
		private DateTime? _createdate= DateTime.Now;
		private DateTime? _updatedate;
		/// <summary>
		/// 
		/// </summary>
		public int PIID
		{
			set{ _piid=value;}
			get{return _piid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PTID
		{
			set{ _ptid=value;}
			get{return _ptid;}
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
		public int? UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComAddr
		{
			set{ _comaddr=value;}
			get{return _comaddr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Job
		{
			set{ _job=value;}
			get{return _job;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MajorSearch
		{
			set{ _majorsearch=value;}
			get{return _majorsearch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Descri
		{
			set{ _descri=value;}
			get{return _descri;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Education
		{
			set{ _education=value;}
			get{return _education;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Photo
		{
			set{ _photo=value;}
			get{return _photo;}
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

