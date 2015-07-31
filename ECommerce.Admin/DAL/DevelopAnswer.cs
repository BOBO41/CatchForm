
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
	/// 数据访问类:DevelopAnswer
	/// </summary>
	public partial class DevelopAnswer
	{
		public DevelopAnswer()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ID)+1 from DevelopAnswer";
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
			strSql.Append("select count(1) from DevelopAnswer where ID=@ID ");
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
		public int Add(ECommerce.Admin.Model.DevelopAnswer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DevelopAnswer(");
			strSql.Append("ComID,UId,Question_answer_7,Question_answer_8,Question_answer_9,Question_answer_10,Question_answer_11,Question_answer_12,Question_answer_13,Question_answer_14,Question_answer_15,Question_answer_16,Question_answer_17,Question_answer_18,Question_answer_19,Question_answer_20,Question_answer_21,Question_answer_22,Question_answer_23,Question_answer_24,CreateDate,UpdateDate)");

			strSql.Append(" values (");
			strSql.Append("@ComID,@UId,@Question_answer_7,@Question_answer_8,@Question_answer_9,@Question_answer_10,@Question_answer_11,@Question_answer_12,@Question_answer_13,@Question_answer_14,@Question_answer_15,@Question_answer_16,@Question_answer_17,@Question_answer_18,@Question_answer_19,@Question_answer_20,@Question_answer_21,@Question_answer_22,@Question_answer_23,@Question_answer_24,@CreateDate,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Question_answer_7", DbType.String, model.Question_answer_7);
			db.AddInParameter(dbCommand, "Question_answer_8", DbType.String, model.Question_answer_8);
			db.AddInParameter(dbCommand, "Question_answer_9", DbType.String, model.Question_answer_9);
			db.AddInParameter(dbCommand, "Question_answer_10", DbType.String, model.Question_answer_10);
			db.AddInParameter(dbCommand, "Question_answer_11", DbType.String, model.Question_answer_11);
			db.AddInParameter(dbCommand, "Question_answer_12", DbType.String, model.Question_answer_12);
			db.AddInParameter(dbCommand, "Question_answer_13", DbType.String, model.Question_answer_13);
			db.AddInParameter(dbCommand, "Question_answer_14", DbType.String, model.Question_answer_14);
			db.AddInParameter(dbCommand, "Question_answer_15", DbType.String, model.Question_answer_15);
			db.AddInParameter(dbCommand, "Question_answer_16", DbType.String, model.Question_answer_16);
			db.AddInParameter(dbCommand, "Question_answer_17", DbType.String, model.Question_answer_17);
			db.AddInParameter(dbCommand, "Question_answer_18", DbType.String, model.Question_answer_18);
			db.AddInParameter(dbCommand, "Question_answer_19", DbType.String, model.Question_answer_19);
			db.AddInParameter(dbCommand, "Question_answer_20", DbType.String, model.Question_answer_20);
			db.AddInParameter(dbCommand, "Question_answer_21", DbType.String, model.Question_answer_21);
			db.AddInParameter(dbCommand, "Question_answer_22", DbType.String, model.Question_answer_22);
			db.AddInParameter(dbCommand, "Question_answer_23", DbType.String, model.Question_answer_23);
			db.AddInParameter(dbCommand, "Question_answer_24", DbType.String, model.Question_answer_24);
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
		public bool Update(ECommerce.Admin.Model.DevelopAnswer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DevelopAnswer set ");
			strSql.Append("ComID=@ComID,");
			strSql.Append("UId=@UId,");
			strSql.Append("Question_answer_7=@Question_answer_7,");
			strSql.Append("Question_answer_8=@Question_answer_8,");
			strSql.Append("Question_answer_9=@Question_answer_9,");
			strSql.Append("Question_answer_10=@Question_answer_10,");
			strSql.Append("Question_answer_11=@Question_answer_11,");
			strSql.Append("Question_answer_12=@Question_answer_12,");
			strSql.Append("Question_answer_13=@Question_answer_13,");
			strSql.Append("Question_answer_14=@Question_answer_14,");
			strSql.Append("Question_answer_15=@Question_answer_15,");
			strSql.Append("Question_answer_16=@Question_answer_16,");
			strSql.Append("Question_answer_17=@Question_answer_17,");
			strSql.Append("Question_answer_18=@Question_answer_18,");
			strSql.Append("Question_answer_19=@Question_answer_19,");
			strSql.Append("Question_answer_20=@Question_answer_20,");
			strSql.Append("Question_answer_21=@Question_answer_21,");
			strSql.Append("Question_answer_22=@Question_answer_22,");
			strSql.Append("Question_answer_23=@Question_answer_23,");
			strSql.Append("Question_answer_24=@Question_answer_24,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32, model.ID);
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Question_answer_7", DbType.String, model.Question_answer_7);
			db.AddInParameter(dbCommand, "Question_answer_8", DbType.String, model.Question_answer_8);
			db.AddInParameter(dbCommand, "Question_answer_9", DbType.String, model.Question_answer_9);
			db.AddInParameter(dbCommand, "Question_answer_10", DbType.String, model.Question_answer_10);
			db.AddInParameter(dbCommand, "Question_answer_11", DbType.String, model.Question_answer_11);
			db.AddInParameter(dbCommand, "Question_answer_12", DbType.String, model.Question_answer_12);
			db.AddInParameter(dbCommand, "Question_answer_13", DbType.String, model.Question_answer_13);
			db.AddInParameter(dbCommand, "Question_answer_14", DbType.String, model.Question_answer_14);
			db.AddInParameter(dbCommand, "Question_answer_15", DbType.String, model.Question_answer_15);
			db.AddInParameter(dbCommand, "Question_answer_16", DbType.String, model.Question_answer_16);
			db.AddInParameter(dbCommand, "Question_answer_17", DbType.String, model.Question_answer_17);
			db.AddInParameter(dbCommand, "Question_answer_18", DbType.String, model.Question_answer_18);
			db.AddInParameter(dbCommand, "Question_answer_19", DbType.String, model.Question_answer_19);
			db.AddInParameter(dbCommand, "Question_answer_20", DbType.String, model.Question_answer_20);
			db.AddInParameter(dbCommand, "Question_answer_21", DbType.String, model.Question_answer_21);
			db.AddInParameter(dbCommand, "Question_answer_22", DbType.String, model.Question_answer_22);
			db.AddInParameter(dbCommand, "Question_answer_23", DbType.String, model.Question_answer_23);
			db.AddInParameter(dbCommand, "Question_answer_24", DbType.String, model.Question_answer_24);
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
			strSql.Append("delete from DevelopAnswer ");
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
			strSql.Append("delete from DevelopAnswer ");
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
		public ECommerce.Admin.Model.DevelopAnswer GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Question_answer_7,Question_answer_8,Question_answer_9,Question_answer_10,Question_answer_11,Question_answer_12,Question_answer_13,Question_answer_14,Question_answer_15,Question_answer_16,Question_answer_17,Question_answer_18,Question_answer_19,Question_answer_20,Question_answer_21,Question_answer_22,Question_answer_23,Question_answer_24,CreateDate,UpdateDate from DevelopAnswer ");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32,ID);
			ECommerce.Admin.Model.DevelopAnswer model=null;
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
		public ECommerce.Admin.Model.DevelopAnswer DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.DevelopAnswer model=new ECommerce.Admin.Model.DevelopAnswer();
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
				if(row["Question_answer_7"]!=null)
				{
					model.Question_answer_7=row["Question_answer_7"].ToString();
				}
				if(row["Question_answer_8"]!=null)
				{
					model.Question_answer_8=row["Question_answer_8"].ToString();
				}
				if(row["Question_answer_9"]!=null)
				{
					model.Question_answer_9=row["Question_answer_9"].ToString();
				}
				if(row["Question_answer_10"]!=null)
				{
					model.Question_answer_10=row["Question_answer_10"].ToString();
				}
				if(row["Question_answer_11"]!=null)
				{
					model.Question_answer_11=row["Question_answer_11"].ToString();
				}
				if(row["Question_answer_12"]!=null)
				{
					model.Question_answer_12=row["Question_answer_12"].ToString();
				}
				if(row["Question_answer_13"]!=null)
				{
					model.Question_answer_13=row["Question_answer_13"].ToString();
				}
				if(row["Question_answer_14"]!=null)
				{
					model.Question_answer_14=row["Question_answer_14"].ToString();
				}
				if(row["Question_answer_15"]!=null)
				{
					model.Question_answer_15=row["Question_answer_15"].ToString();
				}
				if(row["Question_answer_16"]!=null)
				{
					model.Question_answer_16=row["Question_answer_16"].ToString();
				}
				if(row["Question_answer_17"]!=null)
				{
					model.Question_answer_17=row["Question_answer_17"].ToString();
				}
				if(row["Question_answer_18"]!=null)
				{
					model.Question_answer_18=row["Question_answer_18"].ToString();
				}
				if(row["Question_answer_19"]!=null)
				{
					model.Question_answer_19=row["Question_answer_19"].ToString();
				}
				if(row["Question_answer_20"]!=null)
				{
					model.Question_answer_20=row["Question_answer_20"].ToString();
				}
				if(row["Question_answer_21"]!=null)
				{
					model.Question_answer_21=row["Question_answer_21"].ToString();
				}
				if(row["Question_answer_22"]!=null)
				{
					model.Question_answer_22=row["Question_answer_22"].ToString();
				}
				if(row["Question_answer_23"]!=null)
				{
					model.Question_answer_23=row["Question_answer_23"].ToString();
				}
				if(row["Question_answer_24"]!=null)
				{
					model.Question_answer_24=row["Question_answer_24"].ToString();
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
			strSql.Append("select ID,ComID,UId,Question_answer_7,Question_answer_8,Question_answer_9,Question_answer_10,Question_answer_11,Question_answer_12,Question_answer_13,Question_answer_14,Question_answer_15,Question_answer_16,Question_answer_17,Question_answer_18,Question_answer_19,Question_answer_20,Question_answer_21,Question_answer_22,Question_answer_23,Question_answer_24,CreateDate,UpdateDate ");
			strSql.Append(" FROM DevelopAnswer ");
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
			strSql.Append(" ID,ComID,UId,Question_answer_7,Question_answer_8,Question_answer_9,Question_answer_10,Question_answer_11,Question_answer_12,Question_answer_13,Question_answer_14,Question_answer_15,Question_answer_16,Question_answer_17,Question_answer_18,Question_answer_19,Question_answer_20,Question_answer_21,Question_answer_22,Question_answer_23,Question_answer_24,CreateDate,UpdateDate ");
			strSql.Append(" FROM DevelopAnswer ");
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
			strSql.Append("select count(1) FROM DevelopAnswer ");
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
			strSql.Append(")AS Row, T.*  from DevelopAnswer T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "DevelopAnswer");
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
		public List<ECommerce.Admin.Model.DevelopAnswer> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Question_answer_7,Question_answer_8,Question_answer_9,Question_answer_10,Question_answer_11,Question_answer_12,Question_answer_13,Question_answer_14,Question_answer_15,Question_answer_16,Question_answer_17,Question_answer_18,Question_answer_19,Question_answer_20,Question_answer_21,Question_answer_22,Question_answer_23,Question_answer_24,CreateDate,UpdateDate ");
			strSql.Append(" FROM DevelopAnswer ");
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
			List<ECommerce.Admin.Model.DevelopAnswer> list = new List<ECommerce.Admin.Model.DevelopAnswer>();
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
		public ECommerce.Admin.Model.DevelopAnswer ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.DevelopAnswer model=new ECommerce.Admin.Model.DevelopAnswer();
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
			model.Question_answer_7=dataReader["Question_answer_7"].ToString();
			model.Question_answer_8=dataReader["Question_answer_8"].ToString();
			model.Question_answer_9=dataReader["Question_answer_9"].ToString();
			model.Question_answer_10=dataReader["Question_answer_10"].ToString();
			model.Question_answer_11=dataReader["Question_answer_11"].ToString();
			model.Question_answer_12=dataReader["Question_answer_12"].ToString();
			model.Question_answer_13=dataReader["Question_answer_13"].ToString();
			model.Question_answer_14=dataReader["Question_answer_14"].ToString();
			model.Question_answer_15=dataReader["Question_answer_15"].ToString();
			model.Question_answer_16=dataReader["Question_answer_16"].ToString();
			model.Question_answer_17=dataReader["Question_answer_17"].ToString();
			model.Question_answer_18=dataReader["Question_answer_18"].ToString();
			model.Question_answer_19=dataReader["Question_answer_19"].ToString();
			model.Question_answer_20=dataReader["Question_answer_20"].ToString();
			model.Question_answer_21=dataReader["Question_answer_21"].ToString();
			model.Question_answer_22=dataReader["Question_answer_22"].ToString();
			model.Question_answer_23=dataReader["Question_answer_23"].ToString();
			model.Question_answer_24=dataReader["Question_answer_24"].ToString();
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

        #region

        public Model.DevelopAnswer GetModel(string strWhere, List<SqlParameter> parameters) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DevelopAnswer ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0) {
                foreach (SqlParameter sqlParameter in parameters) {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            Model.DevelopAnswer model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand)) {
                if (dataReader.Read()) {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        #endregion
	}
}

