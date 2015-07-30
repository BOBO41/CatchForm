
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// ProcessManu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProcessManu
	{
		public ProcessManu()
		{}
		#region Model
		private int _id;
		private string _comid;
		private int? _uid;
		private string _ict1;
		private string _pc2;
		private string _sup3;
		private string _sup2;
		private string _ps4;
		private string _energy_cost;
		private string _water_cost;
		private string _waste_cost;
		private string _tqus;
		private string _qdu;
		private string _cs7;
		private string _man6;
		private string _man5;
		private string _man2;
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
		public string ICT1
		{
			set{ _ict1=value;}
			get{return _ict1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PC2
		{
			set{ _pc2=value;}
			get{return _pc2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SUP3
		{
			set{ _sup3=value;}
			get{return _sup3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SUP2
		{
			set{ _sup2=value;}
			get{return _sup2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PS4
		{
			set{ _ps4=value;}
			get{return _ps4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ENERGY_COST
		{
			set{ _energy_cost=value;}
			get{return _energy_cost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WATER_COST
		{
			set{ _water_cost=value;}
			get{return _water_cost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WASTE_COST
		{
			set{ _waste_cost=value;}
			get{return _waste_cost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TQUS
		{
			set{ _tqus=value;}
			get{return _tqus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QDU
		{
			set{ _qdu=value;}
			get{return _qdu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CS7
		{
			set{ _cs7=value;}
			get{return _cs7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MAN6
		{
			set{ _man6=value;}
			get{return _man6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MAN5
		{
			set{ _man5=value;}
			get{return _man5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MAN2
		{
			set{ _man2=value;}
			get{return _man2;}
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

