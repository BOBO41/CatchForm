
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// ProdAnswer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProdAnswer
	{
		public ProdAnswer()
		{}
		#region Model
		private int _id;
		private string _comid;
		private int? _uid;
		private string _question_answer_48;
		private string _question_answer_49;
		private string _question_answer_50;
		private string _question_answer_51;
		private string _question_answer_52;
		private string _question_answer_53;
		private string _question_answer_54;
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
		public string Question_answer_48
		{
			set{ _question_answer_48=value;}
			get{return _question_answer_48;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_49
		{
			set{ _question_answer_49=value;}
			get{return _question_answer_49;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_50
		{
			set{ _question_answer_50=value;}
			get{return _question_answer_50;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_51
		{
			set{ _question_answer_51=value;}
			get{return _question_answer_51;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_52
		{
			set{ _question_answer_52=value;}
			get{return _question_answer_52;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_53
		{
			set{ _question_answer_53=value;}
			get{return _question_answer_53;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_54
		{
			set{ _question_answer_54=value;}
			get{return _question_answer_54;}
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

