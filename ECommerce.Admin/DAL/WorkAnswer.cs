
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
	/// 数据访问类:WorkAnswer
	/// </summary>
	public partial class WorkAnswer
	{
		public WorkAnswer()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ID)+1 from WorkAnswer";
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
			strSql.Append("select count(1) from WorkAnswer where ID=@ID ");
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
		public int Add(ECommerce.Admin.Model.WorkAnswer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WorkAnswer(");
			strSql.Append("ComID,UId,Question_answer_25,Question_answer_26,Question_answer_27,Question_answer_28,Question_answer_29,Question_answer_30,Question_answer_31,Question_answer_32,Question_answer_33,Question_answer_34,Question_answer_35,Question_answer_36,Question_answer_37,Question_answer_38,Question_answer_39,Question_answer_40,Question_answer_41,Question_answer_42,Question_answer_43,Question_answer_44,Question_answer_45,Question_answer_46,Question_answer_47,CreateDate,UpdateDate)");

			strSql.Append(" values (");
			strSql.Append("@ComID,@UId,@Question_answer_25,@Question_answer_26,@Question_answer_27,@Question_answer_28,@Question_answer_29,@Question_answer_30,@Question_answer_31,@Question_answer_32,@Question_answer_33,@Question_answer_34,@Question_answer_35,@Question_answer_36,@Question_answer_37,@Question_answer_38,@Question_answer_39,@Question_answer_40,@Question_answer_41,@Question_answer_42,@Question_answer_43,@Question_answer_44,@Question_answer_45,@Question_answer_46,@Question_answer_47,@CreateDate,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Question_answer_25", DbType.String, model.Question_answer_25);
			db.AddInParameter(dbCommand, "Question_answer_26", DbType.String, model.Question_answer_26);
			db.AddInParameter(dbCommand, "Question_answer_27", DbType.String, model.Question_answer_27);
			db.AddInParameter(dbCommand, "Question_answer_28", DbType.String, model.Question_answer_28);
			db.AddInParameter(dbCommand, "Question_answer_29", DbType.String, model.Question_answer_29);
			db.AddInParameter(dbCommand, "Question_answer_30", DbType.String, model.Question_answer_30);
			db.AddInParameter(dbCommand, "Question_answer_31", DbType.String, model.Question_answer_31);
			db.AddInParameter(dbCommand, "Question_answer_32", DbType.String, model.Question_answer_32);
			db.AddInParameter(dbCommand, "Question_answer_33", DbType.String, model.Question_answer_33);
			db.AddInParameter(dbCommand, "Question_answer_34", DbType.String, model.Question_answer_34);
			db.AddInParameter(dbCommand, "Question_answer_35", DbType.String, model.Question_answer_35);
			db.AddInParameter(dbCommand, "Question_answer_36", DbType.String, model.Question_answer_36);
			db.AddInParameter(dbCommand, "Question_answer_37", DbType.String, model.Question_answer_37);
			db.AddInParameter(dbCommand, "Question_answer_38", DbType.String, model.Question_answer_38);
			db.AddInParameter(dbCommand, "Question_answer_39", DbType.String, model.Question_answer_39);
			db.AddInParameter(dbCommand, "Question_answer_40", DbType.String, model.Question_answer_40);
			db.AddInParameter(dbCommand, "Question_answer_41", DbType.String, model.Question_answer_41);
			db.AddInParameter(dbCommand, "Question_answer_42", DbType.String, model.Question_answer_42);
			db.AddInParameter(dbCommand, "Question_answer_43", DbType.String, model.Question_answer_43);
			db.AddInParameter(dbCommand, "Question_answer_44", DbType.String, model.Question_answer_44);
			db.AddInParameter(dbCommand, "Question_answer_45", DbType.String, model.Question_answer_45);
			db.AddInParameter(dbCommand, "Question_answer_46", DbType.String, model.Question_answer_46);
			db.AddInParameter(dbCommand, "Question_answer_47", DbType.String, model.Question_answer_47);
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
		public bool Update(ECommerce.Admin.Model.WorkAnswer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WorkAnswer set ");
			strSql.Append("ComID=@ComID,");
			strSql.Append("UId=@UId,");
			strSql.Append("Question_answer_25=@Question_answer_25,");
			strSql.Append("Question_answer_26=@Question_answer_26,");
			strSql.Append("Question_answer_27=@Question_answer_27,");
			strSql.Append("Question_answer_28=@Question_answer_28,");
			strSql.Append("Question_answer_29=@Question_answer_29,");
			strSql.Append("Question_answer_30=@Question_answer_30,");
			strSql.Append("Question_answer_31=@Question_answer_31,");
			strSql.Append("Question_answer_32=@Question_answer_32,");
			strSql.Append("Question_answer_33=@Question_answer_33,");
			strSql.Append("Question_answer_34=@Question_answer_34,");
			strSql.Append("Question_answer_35=@Question_answer_35,");
			strSql.Append("Question_answer_36=@Question_answer_36,");
			strSql.Append("Question_answer_37=@Question_answer_37,");
			strSql.Append("Question_answer_38=@Question_answer_38,");
			strSql.Append("Question_answer_39=@Question_answer_39,");
			strSql.Append("Question_answer_40=@Question_answer_40,");
			strSql.Append("Question_answer_41=@Question_answer_41,");
			strSql.Append("Question_answer_42=@Question_answer_42,");
			strSql.Append("Question_answer_43=@Question_answer_43,");
			strSql.Append("Question_answer_44=@Question_answer_44,");
			strSql.Append("Question_answer_45=@Question_answer_45,");
			strSql.Append("Question_answer_46=@Question_answer_46,");
			strSql.Append("Question_answer_47=@Question_answer_47,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32, model.ID);
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Question_answer_25", DbType.String, model.Question_answer_25);
			db.AddInParameter(dbCommand, "Question_answer_26", DbType.String, model.Question_answer_26);
			db.AddInParameter(dbCommand, "Question_answer_27", DbType.String, model.Question_answer_27);
			db.AddInParameter(dbCommand, "Question_answer_28", DbType.String, model.Question_answer_28);
			db.AddInParameter(dbCommand, "Question_answer_29", DbType.String, model.Question_answer_29);
			db.AddInParameter(dbCommand, "Question_answer_30", DbType.String, model.Question_answer_30);
			db.AddInParameter(dbCommand, "Question_answer_31", DbType.String, model.Question_answer_31);
			db.AddInParameter(dbCommand, "Question_answer_32", DbType.String, model.Question_answer_32);
			db.AddInParameter(dbCommand, "Question_answer_33", DbType.String, model.Question_answer_33);
			db.AddInParameter(dbCommand, "Question_answer_34", DbType.String, model.Question_answer_34);
			db.AddInParameter(dbCommand, "Question_answer_35", DbType.String, model.Question_answer_35);
			db.AddInParameter(dbCommand, "Question_answer_36", DbType.String, model.Question_answer_36);
			db.AddInParameter(dbCommand, "Question_answer_37", DbType.String, model.Question_answer_37);
			db.AddInParameter(dbCommand, "Question_answer_38", DbType.String, model.Question_answer_38);
			db.AddInParameter(dbCommand, "Question_answer_39", DbType.String, model.Question_answer_39);
			db.AddInParameter(dbCommand, "Question_answer_40", DbType.String, model.Question_answer_40);
			db.AddInParameter(dbCommand, "Question_answer_41", DbType.String, model.Question_answer_41);
			db.AddInParameter(dbCommand, "Question_answer_42", DbType.String, model.Question_answer_42);
			db.AddInParameter(dbCommand, "Question_answer_43", DbType.String, model.Question_answer_43);
			db.AddInParameter(dbCommand, "Question_answer_44", DbType.String, model.Question_answer_44);
			db.AddInParameter(dbCommand, "Question_answer_45", DbType.String, model.Question_answer_45);
			db.AddInParameter(dbCommand, "Question_answer_46", DbType.String, model.Question_answer_46);
			db.AddInParameter(dbCommand, "Question_answer_47", DbType.String, model.Question_answer_47);
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
			strSql.Append("delete from WorkAnswer ");
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
			strSql.Append("delete from WorkAnswer ");
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
		public ECommerce.Admin.Model.WorkAnswer GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Question_answer_25,Question_answer_26,Question_answer_27,Question_answer_28,Question_answer_29,Question_answer_30,Question_answer_31,Question_answer_32,Question_answer_33,Question_answer_34,Question_answer_35,Question_answer_36,Question_answer_37,Question_answer_38,Question_answer_39,Question_answer_40,Question_answer_41,Question_answer_42,Question_answer_43,Question_answer_44,Question_answer_45,Question_answer_46,Question_answer_47,CreateDate,UpdateDate from WorkAnswer ");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32,ID);
			ECommerce.Admin.Model.WorkAnswer model=null;
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
		public ECommerce.Admin.Model.WorkAnswer DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.WorkAnswer model=new ECommerce.Admin.Model.WorkAnswer();
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
				if(row["Question_answer_25"]!=null)
				{
					model.Question_answer_25=row["Question_answer_25"].ToString();
				}
				if(row["Question_answer_26"]!=null)
				{
					model.Question_answer_26=row["Question_answer_26"].ToString();
				}
				if(row["Question_answer_27"]!=null)
				{
					model.Question_answer_27=row["Question_answer_27"].ToString();
				}
				if(row["Question_answer_28"]!=null)
				{
					model.Question_answer_28=row["Question_answer_28"].ToString();
				}
				if(row["Question_answer_29"]!=null)
				{
					model.Question_answer_29=row["Question_answer_29"].ToString();
				}
				if(row["Question_answer_30"]!=null)
				{
					model.Question_answer_30=row["Question_answer_30"].ToString();
				}
				if(row["Question_answer_31"]!=null)
				{
					model.Question_answer_31=row["Question_answer_31"].ToString();
				}
				if(row["Question_answer_32"]!=null)
				{
					model.Question_answer_32=row["Question_answer_32"].ToString();
				}
				if(row["Question_answer_33"]!=null)
				{
					model.Question_answer_33=row["Question_answer_33"].ToString();
				}
				if(row["Question_answer_34"]!=null)
				{
					model.Question_answer_34=row["Question_answer_34"].ToString();
				}
				if(row["Question_answer_35"]!=null)
				{
					model.Question_answer_35=row["Question_answer_35"].ToString();
				}
				if(row["Question_answer_36"]!=null)
				{
					model.Question_answer_36=row["Question_answer_36"].ToString();
				}
				if(row["Question_answer_37"]!=null)
				{
					model.Question_answer_37=row["Question_answer_37"].ToString();
				}
				if(row["Question_answer_38"]!=null)
				{
					model.Question_answer_38=row["Question_answer_38"].ToString();
				}
				if(row["Question_answer_39"]!=null)
				{
					model.Question_answer_39=row["Question_answer_39"].ToString();
				}
				if(row["Question_answer_40"]!=null)
				{
					model.Question_answer_40=row["Question_answer_40"].ToString();
				}
				if(row["Question_answer_41"]!=null)
				{
					model.Question_answer_41=row["Question_answer_41"].ToString();
				}
				if(row["Question_answer_42"]!=null)
				{
					model.Question_answer_42=row["Question_answer_42"].ToString();
				}
				if(row["Question_answer_43"]!=null)
				{
					model.Question_answer_43=row["Question_answer_43"].ToString();
				}
				if(row["Question_answer_44"]!=null)
				{
					model.Question_answer_44=row["Question_answer_44"].ToString();
				}
				if(row["Question_answer_45"]!=null)
				{
					model.Question_answer_45=row["Question_answer_45"].ToString();
				}
				if(row["Question_answer_46"]!=null)
				{
					model.Question_answer_46=row["Question_answer_46"].ToString();
				}
				if(row["Question_answer_47"]!=null)
				{
					model.Question_answer_47=row["Question_answer_47"].ToString();
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
			strSql.Append("select ID,ComID,UId,Question_answer_25,Question_answer_26,Question_answer_27,Question_answer_28,Question_answer_29,Question_answer_30,Question_answer_31,Question_answer_32,Question_answer_33,Question_answer_34,Question_answer_35,Question_answer_36,Question_answer_37,Question_answer_38,Question_answer_39,Question_answer_40,Question_answer_41,Question_answer_42,Question_answer_43,Question_answer_44,Question_answer_45,Question_answer_46,Question_answer_47,CreateDate,UpdateDate ");
			strSql.Append(" FROM WorkAnswer ");
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
			strSql.Append(" ID,ComID,UId,Question_answer_25,Question_answer_26,Question_answer_27,Question_answer_28,Question_answer_29,Question_answer_30,Question_answer_31,Question_answer_32,Question_answer_33,Question_answer_34,Question_answer_35,Question_answer_36,Question_answer_37,Question_answer_38,Question_answer_39,Question_answer_40,Question_answer_41,Question_answer_42,Question_answer_43,Question_answer_44,Question_answer_45,Question_answer_46,Question_answer_47,CreateDate,UpdateDate ");
			strSql.Append(" FROM WorkAnswer ");
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
			strSql.Append("select count(1) FROM WorkAnswer ");
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
			strSql.Append(")AS Row, T.*  from WorkAnswer T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "WorkAnswer");
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
		public List<ECommerce.Admin.Model.WorkAnswer> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Question_answer_25,Question_answer_26,Question_answer_27,Question_answer_28,Question_answer_29,Question_answer_30,Question_answer_31,Question_answer_32,Question_answer_33,Question_answer_34,Question_answer_35,Question_answer_36,Question_answer_37,Question_answer_38,Question_answer_39,Question_answer_40,Question_answer_41,Question_answer_42,Question_answer_43,Question_answer_44,Question_answer_45,Question_answer_46,Question_answer_47,CreateDate,UpdateDate ");
			strSql.Append(" FROM WorkAnswer ");
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
			List<ECommerce.Admin.Model.WorkAnswer> list = new List<ECommerce.Admin.Model.WorkAnswer>();
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
		public ECommerce.Admin.Model.WorkAnswer ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.WorkAnswer model=new ECommerce.Admin.Model.WorkAnswer();
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
			model.Question_answer_25=dataReader["Question_answer_25"].ToString();
			model.Question_answer_26=dataReader["Question_answer_26"].ToString();
			model.Question_answer_27=dataReader["Question_answer_27"].ToString();
			model.Question_answer_28=dataReader["Question_answer_28"].ToString();
			model.Question_answer_29=dataReader["Question_answer_29"].ToString();
			model.Question_answer_30=dataReader["Question_answer_30"].ToString();
			model.Question_answer_31=dataReader["Question_answer_31"].ToString();
			model.Question_answer_32=dataReader["Question_answer_32"].ToString();
			model.Question_answer_33=dataReader["Question_answer_33"].ToString();
			model.Question_answer_34=dataReader["Question_answer_34"].ToString();
			model.Question_answer_35=dataReader["Question_answer_35"].ToString();
			model.Question_answer_36=dataReader["Question_answer_36"].ToString();
			model.Question_answer_37=dataReader["Question_answer_37"].ToString();
			model.Question_answer_38=dataReader["Question_answer_38"].ToString();
			model.Question_answer_39=dataReader["Question_answer_39"].ToString();
			model.Question_answer_40=dataReader["Question_answer_40"].ToString();
			model.Question_answer_41=dataReader["Question_answer_41"].ToString();
			model.Question_answer_42=dataReader["Question_answer_42"].ToString();
			model.Question_answer_43=dataReader["Question_answer_43"].ToString();
			model.Question_answer_44=dataReader["Question_answer_44"].ToString();
			model.Question_answer_45=dataReader["Question_answer_45"].ToString();
			model.Question_answer_46=dataReader["Question_answer_46"].ToString();
			model.Question_answer_47=dataReader["Question_answer_47"].ToString();
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

