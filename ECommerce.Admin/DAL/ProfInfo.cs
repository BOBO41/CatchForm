
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
	/// 数据访问类:ProfInfo
	/// </summary>
	public partial class ProfInfo
	{
		public ProfInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(PIID)+1 from ProfInfo";
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
		public bool Exists(int PIID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from ProfInfo where PIID=@PIID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PIID", DbType.Int32,PIID);
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
		public int Add(ECommerce.Admin.Model.ProfInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProfInfo(");
			strSql.Append("PTID,Name,UId,Age,ComAddr,Job,MajorSearch,Descri,Education,Photo,Status,CreateDate,UpdateDate)");

			strSql.Append(" values (");
			strSql.Append("@PTID,@Name,@UId,@Age,@ComAddr,@Job,@MajorSearch,@Descri,@Education,@Photo,@Status,@CreateDate,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PTID", DbType.Int32, model.PTID);
			db.AddInParameter(dbCommand, "Name", DbType.String, model.Name);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Age", DbType.String, model.Age);
			db.AddInParameter(dbCommand, "ComAddr", DbType.String, model.ComAddr);
			db.AddInParameter(dbCommand, "Job", DbType.String, model.Job);
			db.AddInParameter(dbCommand, "MajorSearch", DbType.String, model.MajorSearch);
			db.AddInParameter(dbCommand, "Descri", DbType.String, model.Descri);
			db.AddInParameter(dbCommand, "Education", DbType.String, model.Education);
			db.AddInParameter(dbCommand, "Photo", DbType.String, model.Photo);
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
		public bool Update(ECommerce.Admin.Model.ProfInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProfInfo set ");
			strSql.Append("PTID=@PTID,");
			strSql.Append("Name=@Name,");
			strSql.Append("UId=@UId,");
			strSql.Append("Age=@Age,");
			strSql.Append("ComAddr=@ComAddr,");
			strSql.Append("Job=@Job,");
			strSql.Append("MajorSearch=@MajorSearch,");
			strSql.Append("Descri=@Descri,");
			strSql.Append("Education=@Education,");
			strSql.Append("Photo=@Photo,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where PIID=@PIID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PIID", DbType.Int32, model.PIID);
			db.AddInParameter(dbCommand, "PTID", DbType.Int32, model.PTID);
			db.AddInParameter(dbCommand, "Name", DbType.String, model.Name);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Age", DbType.String, model.Age);
			db.AddInParameter(dbCommand, "ComAddr", DbType.String, model.ComAddr);
			db.AddInParameter(dbCommand, "Job", DbType.String, model.Job);
			db.AddInParameter(dbCommand, "MajorSearch", DbType.String, model.MajorSearch);
			db.AddInParameter(dbCommand, "Descri", DbType.String, model.Descri);
			db.AddInParameter(dbCommand, "Education", DbType.String, model.Education);
			db.AddInParameter(dbCommand, "Photo", DbType.String, model.Photo);
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
		public bool Delete(int PIID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProfInfo ");
			strSql.Append(" where PIID=@PIID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PIID", DbType.Int32,PIID);
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
		public bool DeleteList(string PIIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProfInfo ");
			strSql.Append(" where PIID in ("+PIIDlist + ")  ");
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
		public ECommerce.Admin.Model.ProfInfo GetModel(int PIID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PIID,PTID,Name,UId,Age,ComAddr,Job,MajorSearch,Descri,Education,Photo,Status,CreateDate,UpdateDate from ProfInfo ");
			strSql.Append(" where PIID=@PIID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PIID", DbType.Int32,PIID);
			ECommerce.Admin.Model.ProfInfo model=null;
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
		public ECommerce.Admin.Model.ProfInfo DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.ProfInfo model=new ECommerce.Admin.Model.ProfInfo();
			if (row != null)
			{
				if(row["PIID"]!=null && row["PIID"].ToString()!="")
				{
					model.PIID=Convert.ToInt32(row["PIID"].ToString());
				}
				if(row["PTID"]!=null && row["PTID"].ToString()!="")
				{
					model.PTID=Convert.ToInt32(row["PTID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["UId"]!=null && row["UId"].ToString()!="")
				{
					model.UId=Convert.ToInt32(row["UId"].ToString());
				}
				if(row["Age"]!=null)
				{
					model.Age=row["Age"].ToString();
				}
				if(row["ComAddr"]!=null)
				{
					model.ComAddr=row["ComAddr"].ToString();
				}
				if(row["Job"]!=null)
				{
					model.Job=row["Job"].ToString();
				}
				if(row["MajorSearch"]!=null)
				{
					model.MajorSearch=row["MajorSearch"].ToString();
				}
				if(row["Descri"]!=null)
				{
					model.Descri=row["Descri"].ToString();
				}
				if(row["Education"]!=null)
				{
					model.Education=row["Education"].ToString();
				}
				if(row["Photo"]!=null)
				{
					model.Photo=row["Photo"].ToString();
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
			strSql.Append("select PIID,PTID,Name,UId,Age,ComAddr,Job,MajorSearch,Descri,Education,Photo,Status,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProfInfo ");
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
			strSql.Append(" PIID,PTID,Name,UId,Age,ComAddr,Job,MajorSearch,Descri,Education,Photo,Status,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProfInfo ");
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
			strSql.Append("select count(1) FROM ProfInfo ");
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
				strSql.Append("order by T.PIID desc");
			}
			strSql.Append(")AS Row, T.*  from ProfInfo T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "ProfInfo");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "PIID");
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
		public List<ECommerce.Admin.Model.ProfInfo> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PIID,PTID,Name,UId,Age,ComAddr,Job,MajorSearch,Descri,Education,Photo,Status,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProfInfo ");
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
			List<ECommerce.Admin.Model.ProfInfo> list = new List<ECommerce.Admin.Model.ProfInfo>();
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
		public ECommerce.Admin.Model.ProfInfo ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.ProfInfo model=new ECommerce.Admin.Model.ProfInfo();
			object ojb; 
			ojb = dataReader["PIID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PIID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["PTID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PTID=Convert.ToInt32(ojb);
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["UId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UId=Convert.ToInt32(ojb);
			}
			model.Age=dataReader["Age"].ToString();
			model.ComAddr=dataReader["ComAddr"].ToString();
			model.Job=dataReader["Job"].ToString();
			model.MajorSearch=dataReader["MajorSearch"].ToString();
			model.Descri=dataReader["Descri"].ToString();
			model.Education=dataReader["Education"].ToString();
			model.Photo=dataReader["Photo"].ToString();
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

        #region

        public Model.ProfInfo GetModel(string strWhere, List<SqlParameter> parameters) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ProfInfo ");
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
            Model.ProfInfo model = null;
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

