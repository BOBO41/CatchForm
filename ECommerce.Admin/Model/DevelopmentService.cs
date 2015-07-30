
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// DevelopmentService:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DevelopmentService
	{
		public DevelopmentService()
		{}
		#region Model
		private int _id;
		private string _comid;
		private int? _uid;
		private string _hf15;
		private string _ps3;
		private string _ps1;
		private string _hf24;
		private string _hf23;
		private string _pc4;
		private string _pc3;
		private string _inn1;
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
		public string HF15
		{
			set{ _hf15=value;}
			get{return _hf15;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PS3
		{
			set{ _ps3=value;}
			get{return _ps3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PS1
		{
			set{ _ps1=value;}
			get{return _ps1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HF24
		{
			set{ _hf24=value;}
			get{return _hf24;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HF23
		{
			set{ _hf23=value;}
			get{return _hf23;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PC4
		{
			set{ _pc4=value;}
			get{return _pc4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PC3
		{
			set{ _pc3=value;}
			get{return _pc3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string INN1
		{
			set{ _inn1=value;}
			get{return _inn1;}
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

