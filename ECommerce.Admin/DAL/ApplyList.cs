
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
	/// 数据访问类:ApplyList
	/// </summary>
	public partial class ApplyList
	{
		public ApplyList()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ALID)+1 from ApplyList";
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
		public bool Exists(int ALID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from ApplyList where ALID=@ALID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ALID", DbType.Int32,ALID);
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
		public int Add(ECommerce.Admin.Model.ApplyList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ApplyList(");
			strSql.Append("Name,Addr,Tel,Contact,Email,Descr,UId,AType,Status,CreateDate,UpdateDate)");

			strSql.Append(" values (");
			strSql.Append("@Name,@Addr,@Tel,@Contact,@Email,@Descr,@UId,@AType,@Status,@CreateDate,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "Name", DbType.String, model.Name);
			db.AddInParameter(dbCommand, "Addr", DbType.String, model.Addr);
			db.AddInParameter(dbCommand, "Tel", DbType.String, model.Tel);
			db.AddInParameter(dbCommand, "Contact", DbType.String, model.Contact);
			db.AddInParameter(dbCommand, "Email", DbType.String, model.Email);
			db.AddInParameter(dbCommand, "Descr", DbType.String, model.Descr);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "AType", DbType.Byte, model.AType);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
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
		public bool Update(ECommerce.Admin.Model.ApplyList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ApplyList set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Addr=@Addr,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("Email=@Email,");
			strSql.Append("Descr=@Descr,");
			strSql.Append("UId=@UId,");
			strSql.Append("AType=@AType,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ALID=@ALID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ALID", DbType.Int32, model.ALID);
			db.AddInParameter(dbCommand, "Name", DbType.String, model.Name);
			db.AddInParameter(dbCommand, "Addr", DbType.String, model.Addr);
			db.AddInParameter(dbCommand, "Tel", DbType.String, model.Tel);
			db.AddInParameter(dbCommand, "Contact", DbType.String, model.Contact);
			db.AddInParameter(dbCommand, "Email", DbType.String, model.Email);
			db.AddInParameter(dbCommand, "Descr", DbType.String, model.Descr);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "AType", DbType.Byte, model.AType);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
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
		public bool Delete(int ALID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ApplyList ");
			strSql.Append(" where ALID=@ALID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ALID", DbType.Int32,ALID);
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
		public bool DeleteList(string ALIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ApplyList ");
			strSql.Append(" where ALID in ("+ALIDlist + ")  ");
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
		public ECommerce.Admin.Model.ApplyList GetModel(int ALID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ALID,Name,Addr,Tel,Contact,Email,Descr,UId,AType,Status,CreateDate,UpdateDate from ApplyList ");
			strSql.Append(" where ALID=@ALID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ALID", DbType.Int32,ALID);
			ECommerce.Admin.Model.ApplyList model=null;
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
		public ECommerce.Admin.Model.ApplyList DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.ApplyList model=new ECommerce.Admin.Model.ApplyList();
			if (row != null)
			{
				if(row["ALID"]!=null && row["ALID"].ToString()!="")
				{
					model.ALID=Convert.ToInt32(row["ALID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Addr"]!=null)
				{
					model.Addr=row["Addr"].ToString();
				}
				if(row["Tel"]!=null)
				{
					model.Tel=row["Tel"].ToString();
				}
				if(row["Contact"]!=null)
				{
					model.Contact=row["Contact"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Descr"]!=null)
				{
					model.Descr=row["Descr"].ToString();
				}
				if(row["UId"]!=null && row["UId"].ToString()!="")
				{
					model.UId=Convert.ToInt32(row["UId"].ToString());
				}
				if(row["AType"]!=null && row["AType"].ToString()!="")
				{
					model.AType=Convert.ToInt32(row["AType"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
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
			strSql.Append("select ALID,Name,Addr,Tel,Contact,Email,Descr,UId,AType,Status,CreateDate,UpdateDate ");
			strSql.Append(" FROM ApplyList ");
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
			strSql.Append(" ALID,Name,Addr,Tel,Contact,Email,Descr,UId,AType,Status,CreateDate,UpdateDate ");
			strSql.Append(" FROM ApplyList ");
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
			strSql.Append("select count(1) FROM ApplyList ");
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
				strSql.Append("order by T.ALID desc");
			}
			strSql.Append(")AS Row, T.*  from ApplyList T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "ApplyList");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ALID");
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
		public List<ECommerce.Admin.Model.ApplyList> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ALID,Name,Addr,Tel,Contact,Email,Descr,UId,AType,Status,CreateDate,UpdateDate ");
			strSql.Append(" FROM ApplyList ");
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
			List<ECommerce.Admin.Model.ApplyList> list = new List<ECommerce.Admin.Model.ApplyList>();
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
		public ECommerce.Admin.Model.ApplyList ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.ApplyList model=new ECommerce.Admin.Model.ApplyList();
			object ojb; 
			ojb = dataReader["ALID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ALID=Convert.ToInt32(ojb);
			}
			model.Name=dataReader["Name"].ToString();
			model.Addr=dataReader["Addr"].ToString();
			model.Tel=dataReader["Tel"].ToString();
			model.Contact=dataReader["Contact"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.Descr=dataReader["Descr"].ToString();
			ojb = dataReader["UId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["AType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AType=Convert.ToInt32(ojb);
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
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

        public bool CheckList(string aid, int status, int cemplId) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ApplyList set Status=@Status,UpdateDate=@CheckTime");
            strSql.Append(" ,UId=@CEmplId");
            strSql.Append(" where ALID in (select * from SplitToTable(@AId,','))");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            var parameter1 = new SqlParameter("@Status", DbType.Int32);
            parameter1.Value = status;
            dbCommand.Parameters.Add(parameter1);
            var parameter2 = new SqlParameter("@CEmplId", DbType.Int32);
            parameter2.Value = cemplId;
            dbCommand.Parameters.Add(parameter2);
            var parameter = new SqlParameter("@AId", DbType.AnsiString);
            parameter.Value = aid;
            dbCommand.Parameters.Add(parameter);
            var parameter3 = new SqlParameter("@CheckTime", DbType.DateTime);
            parameter3.Value = DateTime.Now;
            dbCommand.Parameters.Add(parameter3);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        public Model.ApplyList GetModel(string strWhere, List<SqlParameter> parameters) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ApplyList ");
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
            Model.ApplyList model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand)) {
                if (dataReader.Read()) {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

	}
}

