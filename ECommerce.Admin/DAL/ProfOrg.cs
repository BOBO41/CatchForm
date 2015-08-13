
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
	/// 数据访问类:ProfOrg
	/// </summary>
	public partial class ProfOrg
	{
		public ProfOrg()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(OID)+1 from ProfOrg";
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
		public bool Exists(int OID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from ProfOrg where OID=@OID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "OID", DbType.Int32,OID);
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
		public int Add(ECommerce.Admin.Model.ProfOrg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProfOrg(");
			strSql.Append("Name,OrgAptitude,YYZZ,Addr,FR,Tel,Contact,Email,Descr,MajorSell,UId,Status,CreateDate,UpdateDate)");

			strSql.Append(" values (");
			strSql.Append("@Name,@OrgAptitude,@YYZZ,@Addr,@FR,@Tel,@Contact,@Email,@Descr,@MajorSell,@UId,@Status,@CreateDate,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "Name", DbType.String, model.Name);
			db.AddInParameter(dbCommand, "OrgAptitude", DbType.String, model.OrgAptitude);
			db.AddInParameter(dbCommand, "YYZZ", DbType.String, model.YYZZ);
			db.AddInParameter(dbCommand, "Addr", DbType.String, model.Addr);
			db.AddInParameter(dbCommand, "FR", DbType.String, model.FR);
			db.AddInParameter(dbCommand, "Tel", DbType.String, model.Tel);
			db.AddInParameter(dbCommand, "Contact", DbType.String, model.Contact);
			db.AddInParameter(dbCommand, "Email", DbType.String, model.Email);
			db.AddInParameter(dbCommand, "Descr", DbType.String, model.Descr);
			db.AddInParameter(dbCommand, "MajorSell", DbType.String, model.MajorSell);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
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
		public bool Update(ECommerce.Admin.Model.ProfOrg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProfOrg set ");
			strSql.Append("Name=@Name,");
			strSql.Append("OrgAptitude=@OrgAptitude,");
			strSql.Append("YYZZ=@YYZZ,");
			strSql.Append("Addr=@Addr,");
			strSql.Append("FR=@FR,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("Email=@Email,");
			strSql.Append("Descr=@Descr,");
			strSql.Append("MajorSell=@MajorSell,");
			strSql.Append("UId=@UId,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where OID=@OID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "OID", DbType.Int32, model.OID);
			db.AddInParameter(dbCommand, "Name", DbType.String, model.Name);
			db.AddInParameter(dbCommand, "OrgAptitude", DbType.String, model.OrgAptitude);
			db.AddInParameter(dbCommand, "YYZZ", DbType.String, model.YYZZ);
			db.AddInParameter(dbCommand, "Addr", DbType.String, model.Addr);
			db.AddInParameter(dbCommand, "FR", DbType.String, model.FR);
			db.AddInParameter(dbCommand, "Tel", DbType.String, model.Tel);
			db.AddInParameter(dbCommand, "Contact", DbType.String, model.Contact);
			db.AddInParameter(dbCommand, "Email", DbType.String, model.Email);
			db.AddInParameter(dbCommand, "Descr", DbType.String, model.Descr);
			db.AddInParameter(dbCommand, "MajorSell", DbType.String, model.MajorSell);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
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
		public bool Delete(int OID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProfOrg ");
			strSql.Append(" where OID=@OID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "OID", DbType.Int32,OID);
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
		public bool DeleteList(string OIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProfOrg ");
			strSql.Append(" where OID in ("+OIDlist + ")  ");
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
		public ECommerce.Admin.Model.ProfOrg GetModel(int OID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OID,Name,OrgAptitude,YYZZ,Addr,FR,Tel,Contact,Email,Descr,MajorSell,UId,Status,CreateDate,UpdateDate from ProfOrg ");
			strSql.Append(" where OID=@OID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "OID", DbType.Int32,OID);
			ECommerce.Admin.Model.ProfOrg model=null;
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
		public ECommerce.Admin.Model.ProfOrg DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.ProfOrg model=new ECommerce.Admin.Model.ProfOrg();
			if (row != null)
			{
				if(row["OID"]!=null && row["OID"].ToString()!="")
				{
					model.OID=Convert.ToInt32(row["OID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["OrgAptitude"]!=null)
				{
					model.OrgAptitude=row["OrgAptitude"].ToString();
				}
				if(row["YYZZ"]!=null)
				{
					model.YYZZ=row["YYZZ"].ToString();
				}
				if(row["Addr"]!=null)
				{
					model.Addr=row["Addr"].ToString();
				}
				if(row["FR"]!=null)
				{
					model.FR=row["FR"].ToString();
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
				if(row["MajorSell"]!=null)
				{
					model.MajorSell=row["MajorSell"].ToString();
				}
				if(row["UId"]!=null && row["UId"].ToString()!="")
				{
					model.UId=Convert.ToInt32(row["UId"].ToString());
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
			strSql.Append("select OID,Name,OrgAptitude,YYZZ,Addr,FR,Tel,Contact,Email,Descr,MajorSell,UId,Status,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProfOrg ");
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
			strSql.Append(" OID,Name,OrgAptitude,YYZZ,Addr,FR,Tel,Contact,Email,Descr,MajorSell,UId,Status,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProfOrg ");
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
			strSql.Append("select count(1) FROM ProfOrg ");
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
				strSql.Append("order by T.OID desc");
			}
			strSql.Append(")AS Row, T.*  from ProfOrg T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "ProfOrg");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "OID");
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
		public List<ECommerce.Admin.Model.ProfOrg> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OID,Name,OrgAptitude,YYZZ,Addr,FR,Tel,Contact,Email,Descr,MajorSell,UId,Status,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProfOrg ");
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
			List<ECommerce.Admin.Model.ProfOrg> list = new List<ECommerce.Admin.Model.ProfOrg>();
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
		public ECommerce.Admin.Model.ProfOrg ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.ProfOrg model=new ECommerce.Admin.Model.ProfOrg();
			object ojb; 
			ojb = dataReader["OID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OID=Convert.ToInt32(ojb);
			}
			model.Name=dataReader["Name"].ToString();
			model.OrgAptitude=dataReader["OrgAptitude"].ToString();
			model.YYZZ=dataReader["YYZZ"].ToString();
			model.Addr=dataReader["Addr"].ToString();
			model.FR=dataReader["FR"].ToString();
			model.Tel=dataReader["Tel"].ToString();
			model.Contact=dataReader["Contact"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.Descr=dataReader["Descr"].ToString();
			model.MajorSell=dataReader["MajorSell"].ToString();
			ojb = dataReader["UId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UId=Convert.ToInt32(ojb);
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

        #region

        public Model.ProfOrg GetModel(string strWhere, List<SqlParameter> parameters) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ProfOrg ");
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
            Model.ProfOrg model = null;
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

