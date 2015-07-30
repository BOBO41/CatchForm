
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// AnswerWrapper:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AnswerWrapper
	{
		public AnswerWrapper()
		{}
		#region Model
		private int _id;
		private string _comid;
		private int? _uid;
		private string _question_answer_1;
		private string _question_answer_2;
		private string _question_answer_3;
		private string _question_answer_4;
		private string _question_answer_5;
		private string _question_answer_6;
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
		public string Question_answer_1
		{
			set{ _question_answer_1=value;}
			get{return _question_answer_1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_2
		{
			set{ _question_answer_2=value;}
			get{return _question_answer_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_3
		{
			set{ _question_answer_3=value;}
			get{return _question_answer_3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_4
		{
			set{ _question_answer_4=value;}
			get{return _question_answer_4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_5
		{
			set{ _question_answer_5=value;}
			get{return _question_answer_5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question_answer_6
		{
			set{ _question_answer_6=value;}
			get{return _question_answer_6;}
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

