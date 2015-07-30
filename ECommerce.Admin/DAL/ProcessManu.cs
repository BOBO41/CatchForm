
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
	/// 数据访问类:ProcessManu
	/// </summary>
	public partial class ProcessManu
	{
		public ProcessManu()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ID)+1 from ProcessManu";
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
			strSql.Append("select count(1) from ProcessManu where ID=@ID ");
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
		public int Add(ECommerce.Admin.Model.ProcessManu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProcessManu(");
			strSql.Append("ComID,UId,ICT1,PC2,SUP3,SUP2,PS4,ENERGY_COST,WATER_COST,WASTE_COST,TQUS,QDU,CS7,MAN6,MAN5,MAN2,CreateDate,UpdateDate)");

			strSql.Append(" values (");
			strSql.Append("@ComID,@UId,@ICT1,@PC2,@SUP3,@SUP2,@PS4,@ENERGY_COST,@WATER_COST,@WASTE_COST,@TQUS,@QDU,@CS7,@MAN6,@MAN5,@MAN2,@CreateDate,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "ICT1", DbType.String, model.ICT1);
			db.AddInParameter(dbCommand, "PC2", DbType.String, model.PC2);
			db.AddInParameter(dbCommand, "SUP3", DbType.String, model.SUP3);
			db.AddInParameter(dbCommand, "SUP2", DbType.String, model.SUP2);
			db.AddInParameter(dbCommand, "PS4", DbType.String, model.PS4);
			db.AddInParameter(dbCommand, "ENERGY_COST", DbType.String, model.ENERGY_COST);
			db.AddInParameter(dbCommand, "WATER_COST", DbType.String, model.WATER_COST);
			db.AddInParameter(dbCommand, "WASTE_COST", DbType.String, model.WASTE_COST);
			db.AddInParameter(dbCommand, "TQUS", DbType.String, model.TQUS);
			db.AddInParameter(dbCommand, "QDU", DbType.String, model.QDU);
			db.AddInParameter(dbCommand, "CS7", DbType.String, model.CS7);
			db.AddInParameter(dbCommand, "MAN6", DbType.String, model.MAN6);
			db.AddInParameter(dbCommand, "MAN5", DbType.String, model.MAN5);
			db.AddInParameter(dbCommand, "MAN2", DbType.String, model.MAN2);
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
		public bool Update(ECommerce.Admin.Model.ProcessManu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProcessManu set ");
			strSql.Append("ComID=@ComID,");
			strSql.Append("UId=@UId,");
			strSql.Append("ICT1=@ICT1,");
			strSql.Append("PC2=@PC2,");
			strSql.Append("SUP3=@SUP3,");
			strSql.Append("SUP2=@SUP2,");
			strSql.Append("PS4=@PS4,");
			strSql.Append("ENERGY_COST=@ENERGY_COST,");
			strSql.Append("WATER_COST=@WATER_COST,");
			strSql.Append("WASTE_COST=@WASTE_COST,");
			strSql.Append("TQUS=@TQUS,");
			strSql.Append("QDU=@QDU,");
			strSql.Append("CS7=@CS7,");
			strSql.Append("MAN6=@MAN6,");
			strSql.Append("MAN5=@MAN5,");
			strSql.Append("MAN2=@MAN2,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32, model.ID);
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "ICT1", DbType.String, model.ICT1);
			db.AddInParameter(dbCommand, "PC2", DbType.String, model.PC2);
			db.AddInParameter(dbCommand, "SUP3", DbType.String, model.SUP3);
			db.AddInParameter(dbCommand, "SUP2", DbType.String, model.SUP2);
			db.AddInParameter(dbCommand, "PS4", DbType.String, model.PS4);
			db.AddInParameter(dbCommand, "ENERGY_COST", DbType.String, model.ENERGY_COST);
			db.AddInParameter(dbCommand, "WATER_COST", DbType.String, model.WATER_COST);
			db.AddInParameter(dbCommand, "WASTE_COST", DbType.String, model.WASTE_COST);
			db.AddInParameter(dbCommand, "TQUS", DbType.String, model.TQUS);
			db.AddInParameter(dbCommand, "QDU", DbType.String, model.QDU);
			db.AddInParameter(dbCommand, "CS7", DbType.String, model.CS7);
			db.AddInParameter(dbCommand, "MAN6", DbType.String, model.MAN6);
			db.AddInParameter(dbCommand, "MAN5", DbType.String, model.MAN5);
			db.AddInParameter(dbCommand, "MAN2", DbType.String, model.MAN2);
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
			strSql.Append("delete from ProcessManu ");
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
			strSql.Append("delete from ProcessManu ");
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
		public ECommerce.Admin.Model.ProcessManu GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,ICT1,PC2,SUP3,SUP2,PS4,ENERGY_COST,WATER_COST,WASTE_COST,TQUS,QDU,CS7,MAN6,MAN5,MAN2,CreateDate,UpdateDate from ProcessManu ");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32,ID);
			ECommerce.Admin.Model.ProcessManu model=null;
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
		public ECommerce.Admin.Model.ProcessManu DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.ProcessManu model=new ECommerce.Admin.Model.ProcessManu();
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
				if(row["ICT1"]!=null)
				{
					model.ICT1=row["ICT1"].ToString();
				}
				if(row["PC2"]!=null)
				{
					model.PC2=row["PC2"].ToString();
				}
				if(row["SUP3"]!=null)
				{
					model.SUP3=row["SUP3"].ToString();
				}
				if(row["SUP2"]!=null)
				{
					model.SUP2=row["SUP2"].ToString();
				}
				if(row["PS4"]!=null)
				{
					model.PS4=row["PS4"].ToString();
				}
				if(row["ENERGY_COST"]!=null)
				{
					model.ENERGY_COST=row["ENERGY_COST"].ToString();
				}
				if(row["WATER_COST"]!=null)
				{
					model.WATER_COST=row["WATER_COST"].ToString();
				}
				if(row["WASTE_COST"]!=null)
				{
					model.WASTE_COST=row["WASTE_COST"].ToString();
				}
				if(row["TQUS"]!=null)
				{
					model.TQUS=row["TQUS"].ToString();
				}
				if(row["QDU"]!=null)
				{
					model.QDU=row["QDU"].ToString();
				}
				if(row["CS7"]!=null)
				{
					model.CS7=row["CS7"].ToString();
				}
				if(row["MAN6"]!=null)
				{
					model.MAN6=row["MAN6"].ToString();
				}
				if(row["MAN5"]!=null)
				{
					model.MAN5=row["MAN5"].ToString();
				}
				if(row["MAN2"]!=null)
				{
					model.MAN2=row["MAN2"].ToString();
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
			strSql.Append("select ID,ComID,UId,ICT1,PC2,SUP3,SUP2,PS4,ENERGY_COST,WATER_COST,WASTE_COST,TQUS,QDU,CS7,MAN6,MAN5,MAN2,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProcessManu ");
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
			strSql.Append(" ID,ComID,UId,ICT1,PC2,SUP3,SUP2,PS4,ENERGY_COST,WATER_COST,WASTE_COST,TQUS,QDU,CS7,MAN6,MAN5,MAN2,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProcessManu ");
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
			strSql.Append("select count(1) FROM ProcessManu ");
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
			strSql.Append(")AS Row, T.*  from ProcessManu T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "ProcessManu");
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
		public List<ECommerce.Admin.Model.ProcessManu> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,ICT1,PC2,SUP3,SUP2,PS4,ENERGY_COST,WATER_COST,WASTE_COST,TQUS,QDU,CS7,MAN6,MAN5,MAN2,CreateDate,UpdateDate ");
			strSql.Append(" FROM ProcessManu ");
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
			List<ECommerce.Admin.Model.ProcessManu> list = new List<ECommerce.Admin.Model.ProcessManu>();
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
		public ECommerce.Admin.Model.ProcessManu ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.ProcessManu model=new ECommerce.Admin.Model.ProcessManu();
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
			model.ICT1=dataReader["ICT1"].ToString();
			model.PC2=dataReader["PC2"].ToString();
			model.SUP3=dataReader["SUP3"].ToString();
			model.SUP2=dataReader["SUP2"].ToString();
			model.PS4=dataReader["PS4"].ToString();
			model.ENERGY_COST=dataReader["ENERGY_COST"].ToString();
			model.WATER_COST=dataReader["WATER_COST"].ToString();
			model.WASTE_COST=dataReader["WASTE_COST"].ToString();
			model.TQUS=dataReader["TQUS"].ToString();
			model.QDU=dataReader["QDU"].ToString();
			model.CS7=dataReader["CS7"].ToString();
			model.MAN6=dataReader["MAN6"].ToString();
			model.MAN5=dataReader["MAN5"].ToString();
			model.MAN2=dataReader["MAN2"].ToString();
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

