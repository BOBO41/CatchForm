
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace ECommerce.Admin.DAL
{
	/// <summary>
	/// 数据访问类:ProdAnswer
	/// </summary>
	public partial class ProdAnswer
	{
		public ProdAnswer()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ID)+1 from ProdAnswer";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from ProdAnswer where ID=@ID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32,ID);
			int cmdresult;
			object obj = db.ExecuteScalar(dbCommand);
			if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
			{
				cmdresult = 0;
			}
			else
			{
				cmdresult = int.Parse(obj.ToString());
			}
			if (cmdresult == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECommerce.Admin.Model.ProdAnswer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProdAnswer(");
			strSql.Append("ComID,UId,Question_answer_48,Question_answer_49,Question_answer_50,Question_answer_51,Question_answer_52,Question_answer_53,Question_answer_54,CreateDate,UpdateDate)");

			strSql.Append(" values (");
			strSql.Append("@ComID,@UId,@Question_answer_48,@Question_answer_49,@Question_answer_50,@Question_answer_51,@Question_answer_52,@Question_answer_53,@Question_answer_54,@CreateDate,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Question_answer_48", DbType.String, model.Question_answer_48);
			db.AddInParameter(dbCommand, "Question_answer_49", DbType.String, model.Question_answer_49);
			db.AddInParameter(dbCommand, "Question_answer_50", DbType.String, model.Question_answer_50);
			db.AddInParameter(dbCommand, "Question_answer_51", DbType.String, model.Question_answer_51);
			db.AddInParameter(dbCommand, "Question_answer_52", DbType.String, model.Question_answer_52);
			db.AddInParameter(dbCommand, "Question_answer_53", DbType.String, model.Question_answer_53);
			db.AddInParameter(dbCommand, "Question_answer_54", DbType.String, model.Question_answer_54);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			db.AddInParameter(dbCommand, "UpdateDate", DbType.DateTime, model.UpdateDate);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ECommerce.Admin.Model.ProdAnswer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProdAnswer set ");
			strSql.Append("ComID=@ComID,");
			strSql.Append("UId=@UId,");
			strSql.Append("Question_answer_48=@Question_answer_48,");
			strSql.Append("Question_answer_49=@Question_answer_49,");
			strSql.Append("Question_answer_50=@Question_answer_50,");
			strSql.Append("Question_answer_51=@Question_answer_51,");
			strSql.Append("Question_answer_52=@Question_answer_52,");
			strSql.Append("Question_answer_53=@Question_answer_53,");
			strSql.Append("Question_answer_54=@Question_answer_54,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32, model.ID);
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Question_answer_48", DbType.String, model.Question_answer_48);
			db.AddInParameter(dbCommand, "Question_answer_49", DbType.String, model.Question_answer_49);
			db.AddInParameter(dbCommand, "Question_answer_50", DbType.String, model.Question_answer_50);
			db.AddInParameter(dbCommand, "Question_answer_51", DbType.String, model.Question_answer_51);
			db.AddInParameter(dbCommand, "Question_answer_52", DbType.String, model.Question_answer_52);
			db.AddInParameter(dbCommand, "Question_answer_53", DbType.String, model.Question_answer_53);
			db.AddInParameter(dbCommand, "Question_answer_54", DbType.String, model.Question_answer_54);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			db.AddInParameter(dbCommand, "UpdateDate", DbType.DateTime, model.UpdateDate);
			int rows=db.ExecuteNonQuery(dbCommand);

			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProdAnswer ");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32,ID);
			int rows=db.ExecuteNonQuery(dbCommand);

			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProdAnswer ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			int rows=db.ExecuteNonQuery(dbCommand);

			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ECommerce.Admin.Model.ProdAnswer GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Question_answer_48,Question_answer_49,Question_answer_50,Question_answer_51,Question_answer_52,Question_answer_53,Question_answer_54,CreateDate,UpdateDate from ProdAnswer ");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32,ID);
			ECommerce.Admin.Model.ProdAnswer model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ECommerce.Admin.Model.ProdAnswer DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.ProdAnswer model=new ECommerce.Admin.Model.ProdAnswer();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=Convert.ToInt32(row["ID"].ToString());
				}
				if(row["ComID"]!=null)
				{
					model.ComID=row["ComID"].ToString();
				}
				if(row["UId"]!=null && row["UId"].ToString()!="")
				{
					model.UId=Convert.ToInt32(row["UId"].ToString());
				}
				if(row["Question_answer_48"]!=null)
				{
					model.Question_answer_48=row["Question_answer_48"].ToString();
				}
				if(row["Question_answer_49"]!=null)
				{
					model.Question_answer_49=row["Question_answer_49"].ToString();
				}
				if(row["Question_answer_50"]!=null)
				{
					model.Question_answer_50=row["Question_answer_50"].ToString();
				}
				if(row["Question_answer_51"]!=null)
				{
					model.Question_answer_51=row["Question_answer_51"].ToString();
				}
				if(row["Question_answer_52"]!=null)
				{
					model.Question_answer_52=row["Question_answer_52"].ToString();
				}
				if(row["Question_answer_53"]!=null)
				{
					model.Question_answer_53=row["Question_answer_53"].ToString();
				}
				if(row["Question_answer_54"]!=null)
				{
					model.Question_answer_54=row["Question_answer_54"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=Convert.ToDateTime(row["CreateDate"].ToString());
				}
				if(row["UpdateDate"]!=null && row["UpdateDate"].ToString()!="")
				{
					model.UpdateDate=Convert.ToDateTime(row["UpdateDate"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
		/// <param name="parameters">List<SqlParameter> parameters</param>
		/// </summary>
		public DataSet GetList(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Question_answer_48,Question_answer_49,Question_answer_50,Question_answer_51,Question_answer_52,Question_answer_53,Question_answer_54,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProdAnswer ");
			Database db = DatabaseFactory.CreateDatabase();
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
			{
				foreach (SqlParameter sqlParameter in parameters)
				{
					dbCommand.Parameters.Add(sqlParameter);
				}
			}
			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// 获得前几行数据
		/// <param name="Top">int Top</param>
		/// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
		/// <param name="parameters">List<SqlParameter> parameters</param>
		/// </summary>
		public DataSet GetList(int Top,string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,ComID,UId,Question_answer_48,Question_answer_49,Question_answer_50,Question_answer_51,Question_answer_52,Question_answer_53,Question_answer_54,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProdAnswer ");
			Database db = DatabaseFactory.CreateDatabase();
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
			{
				foreach (SqlParameter sqlParameter in parameters)
				{
					dbCommand.Parameters.Add(sqlParameter);
				}
			}
			return db.ExecuteDataSet(dbCommand);
		}

		/*
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ProdAnswer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}*/
		/// <summary>
		/// 分页获取数据列表
		/// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell  like写法:'%'+@Cell+'%' </param>
		/// <param name="orderby">string orderby</param>
		/// <param name="startIndex">开始页码</param>
		/// <param name="endIndex">结束页码</param>
		/// <param name="parameters">List<SqlParameter> parameters</param>
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, List<SqlParameter> parameters)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProdAnswer T ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
			{
				foreach (SqlParameter sqlParameter in parameters)
				{
					dbCommand.Parameters.Add(sqlParameter);
				}
			}
			return db.ExecuteDataSet(dbCommand);
		}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "ProdAnswer");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
		/// <param name="parameters">List<SqlParameter> parameters</param>
		/// </summary>
		public List<ECommerce.Admin.Model.ProdAnswer> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Question_answer_48,Question_answer_49,Question_answer_50,Question_answer_51,Question_answer_52,Question_answer_53,Question_answer_54,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProdAnswer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
			{
				foreach (SqlParameter sqlParameter in parameters)
				{
					dbCommand.Parameters.Add(sqlParameter);
				}
			}
			List<ECommerce.Admin.Model.ProdAnswer> list = new List<ECommerce.Admin.Model.ProdAnswer>();
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public ECommerce.Admin.Model.ProdAnswer ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.ProdAnswer model=new ECommerce.Admin.Model.ProdAnswer();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ID=Convert.ToInt32(ojb);
			}
			model.ComID=dataReader["ComID"].ToString();
			ojb = dataReader["UId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UId=Convert.ToInt32(ojb);
			}
			model.Question_answer_48=dataReader["Question_answer_48"].ToString();
			model.Question_answer_49=dataReader["Question_answer_49"].ToString();
			model.Question_answer_50=dataReader["Question_answer_50"].ToString();
			model.Question_answer_51=dataReader["Question_answer_51"].ToString();
			model.Question_answer_52=dataReader["Question_answer_52"].ToString();
			model.Question_answer_53=dataReader["Question_answer_53"].ToString();
			model.Question_answer_54=dataReader["Question_answer_54"].ToString();
			ojb = dataReader["CreateDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreateDate=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["UpdateDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UpdateDate=Convert.ToDateTime(ojb);
			}
			return model;
		}

		#endregion  Method
	}
}

