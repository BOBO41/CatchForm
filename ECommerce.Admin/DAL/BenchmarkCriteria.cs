
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
	/// 数据访问类:BenchmarkCriteria
	/// </summary>
	public partial class BenchmarkCriteria
	{
		public BenchmarkCriteria()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ID)+1 from BenchmarkCriteria";
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
			strSql.Append("select count(1) from BenchmarkCriteria where ID=@ID ");
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
		public int Add(ECommerce.Admin.Model.BenchmarkCriteria model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BenchmarkCriteria(");
			strSql.Append("ComID,UId,Country_Regions,EMP1,EMP2,TURN1,TURN2,INDUSTRY,List1,List2,SicCode,SelectedSicCodes,PROBE_SIC,CreateDate,UpdateDate)");

			strSql.Append(" values (");
			strSql.Append("@ComID,@UId,@Country_Regions,@EMP1,@EMP2,@TURN1,@TURN2,@INDUSTRY,@List1,@List2,@SicCode,@SelectedSicCodes,@PROBE_SIC,@CreateDate,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Country_Regions", DbType.String, model.Country_Regions);
			db.AddInParameter(dbCommand, "EMP1", DbType.String, model.EMP1);
			db.AddInParameter(dbCommand, "EMP2", DbType.String, model.EMP2);
			db.AddInParameter(dbCommand, "TURN1", DbType.String, model.TURN1);
			db.AddInParameter(dbCommand, "TURN2", DbType.String, model.TURN2);
			db.AddInParameter(dbCommand, "INDUSTRY", DbType.String, model.INDUSTRY);
			db.AddInParameter(dbCommand, "List1", DbType.String, model.List1);
			db.AddInParameter(dbCommand, "List2", DbType.String, model.List2);
			db.AddInParameter(dbCommand, "SicCode", DbType.String, model.SicCode);
			db.AddInParameter(dbCommand, "SelectedSicCodes", DbType.AnsiString, model.SelectedSicCodes);
			db.AddInParameter(dbCommand, "PROBE_SIC", DbType.String, model.PROBE_SIC);
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
		public bool Update(ECommerce.Admin.Model.BenchmarkCriteria model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BenchmarkCriteria set ");
			strSql.Append("ComID=@ComID,");
			strSql.Append("UId=@UId,");
			strSql.Append("Country_Regions=@Country_Regions,");
			strSql.Append("EMP1=@EMP1,");
			strSql.Append("EMP2=@EMP2,");
			strSql.Append("TURN1=@TURN1,");
			strSql.Append("TURN2=@TURN2,");
			strSql.Append("INDUSTRY=@INDUSTRY,");
			strSql.Append("List1=@List1,");
			strSql.Append("List2=@List2,");
			strSql.Append("SicCode=@SicCode,");
			strSql.Append("SelectedSicCodes=@SelectedSicCodes,");
			strSql.Append("PROBE_SIC=@PROBE_SIC,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32, model.ID);
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Country_Regions", DbType.String, model.Country_Regions);
			db.AddInParameter(dbCommand, "EMP1", DbType.String, model.EMP1);
			db.AddInParameter(dbCommand, "EMP2", DbType.String, model.EMP2);
			db.AddInParameter(dbCommand, "TURN1", DbType.String, model.TURN1);
			db.AddInParameter(dbCommand, "TURN2", DbType.String, model.TURN2);
			db.AddInParameter(dbCommand, "INDUSTRY", DbType.String, model.INDUSTRY);
			db.AddInParameter(dbCommand, "List1", DbType.String, model.List1);
			db.AddInParameter(dbCommand, "List2", DbType.String, model.List2);
			db.AddInParameter(dbCommand, "SicCode", DbType.String, model.SicCode);
			db.AddInParameter(dbCommand, "SelectedSicCodes", DbType.AnsiString, model.SelectedSicCodes);
			db.AddInParameter(dbCommand, "PROBE_SIC", DbType.String, model.PROBE_SIC);
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
			strSql.Append("delete from BenchmarkCriteria ");
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
			strSql.Append("delete from BenchmarkCriteria ");
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
		public ECommerce.Admin.Model.BenchmarkCriteria GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Country_Regions,EMP1,EMP2,TURN1,TURN2,INDUSTRY,List1,List2,SicCode,SelectedSicCodes,PROBE_SIC,CreateDate,UpdateDate from BenchmarkCriteria ");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32,ID);
			ECommerce.Admin.Model.BenchmarkCriteria model=null;
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
		public ECommerce.Admin.Model.BenchmarkCriteria DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.BenchmarkCriteria model=new ECommerce.Admin.Model.BenchmarkCriteria();
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
				if(row["Country_Regions"]!=null)
				{
					model.Country_Regions=row["Country_Regions"].ToString();
				}
				if(row["EMP1"]!=null)
				{
					model.EMP1=row["EMP1"].ToString();
				}
				if(row["EMP2"]!=null)
				{
					model.EMP2=row["EMP2"].ToString();
				}
				if(row["TURN1"]!=null)
				{
					model.TURN1=row["TURN1"].ToString();
				}
				if(row["TURN2"]!=null)
				{
					model.TURN2=row["TURN2"].ToString();
				}
				if(row["INDUSTRY"]!=null)
				{
					model.INDUSTRY=row["INDUSTRY"].ToString();
				}
				if(row["List1"]!=null)
				{
					model.List1=row["List1"].ToString();
				}
				if(row["List2"]!=null)
				{
					model.List2=row["List2"].ToString();
				}
				if(row["SicCode"]!=null)
				{
					model.SicCode=row["SicCode"].ToString();
				}
				if(row["SelectedSicCodes"]!=null)
				{
					model.SelectedSicCodes=row["SelectedSicCodes"].ToString();
				}
				if(row["PROBE_SIC"]!=null)
				{
					model.PROBE_SIC=row["PROBE_SIC"].ToString();
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
			strSql.Append("select ID,ComID,UId,Country_Regions,EMP1,EMP2,TURN1,TURN2,INDUSTRY,List1,List2,SicCode,SelectedSicCodes,PROBE_SIC,CreateDate,UpdateDate ");
			strSql.Append(" FROM BenchmarkCriteria ");
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
			strSql.Append(" ID,ComID,UId,Country_Regions,EMP1,EMP2,TURN1,TURN2,INDUSTRY,List1,List2,SicCode,SelectedSicCodes,PROBE_SIC,CreateDate,UpdateDate ");
			strSql.Append(" FROM BenchmarkCriteria ");
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
			strSql.Append("select count(1) FROM BenchmarkCriteria ");
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
			strSql.Append(")AS Row, T.*  from BenchmarkCriteria T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "BenchmarkCriteria");
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
		public List<ECommerce.Admin.Model.BenchmarkCriteria> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Country_Regions,EMP1,EMP2,TURN1,TURN2,INDUSTRY,List1,List2,SicCode,SelectedSicCodes,PROBE_SIC,CreateDate,UpdateDate ");
			strSql.Append(" FROM BenchmarkCriteria ");
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
			List<ECommerce.Admin.Model.BenchmarkCriteria> list = new List<ECommerce.Admin.Model.BenchmarkCriteria>();
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
		public ECommerce.Admin.Model.BenchmarkCriteria ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.BenchmarkCriteria model=new ECommerce.Admin.Model.BenchmarkCriteria();
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
			model.Country_Regions=dataReader["Country_Regions"].ToString();
			model.EMP1=dataReader["EMP1"].ToString();
			model.EMP2=dataReader["EMP2"].ToString();
			model.TURN1=dataReader["TURN1"].ToString();
			model.TURN2=dataReader["TURN2"].ToString();
			model.INDUSTRY=dataReader["INDUSTRY"].ToString();
			model.List1=dataReader["List1"].ToString();
			model.List2=dataReader["List2"].ToString();
			model.SicCode=dataReader["SicCode"].ToString();
			model.SelectedSicCodes=dataReader["SelectedSicCodes"].ToString();
			model.PROBE_SIC=dataReader["PROBE_SIC"].ToString();
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

