
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
	/// 数据访问类:Financel
	/// </summary>
	public partial class Financel
	{
		public Financel()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ID)+1 from Financel";
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
			strSql.Append("select count(1) from Financel where ID=@ID ");
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
		public int Add(ECommerce.Admin.Model.Financel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Financel(");
			strSql.Append("ComID,UId,Fyear,HF1,HF2,HF28,GHF1,GHF2,GHF28,HF43,HF44,HF3,GHF3,HF40,GHF40,HF6,HF8,HF20,HF45,HF7,HF13,HF12,HF10,HF11,HF9,HF14,HF21,CreateDate,UpdateDate)");

			strSql.Append(" values (");
			strSql.Append("@ComID,@UId,@Fyear,@HF1,@HF2,@HF28,@GHF1,@GHF2,@GHF28,@HF43,@HF44,@HF3,@GHF3,@HF40,@GHF40,@HF6,@HF8,@HF20,@HF45,@HF7,@HF13,@HF12,@HF10,@HF11,@HF9,@HF14,@HF21,@CreateDate,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Fyear", DbType.String, model.Fyear);
			db.AddInParameter(dbCommand, "HF1", DbType.String, model.HF1);
			db.AddInParameter(dbCommand, "HF2", DbType.String, model.HF2);
			db.AddInParameter(dbCommand, "HF28", DbType.String, model.HF28);
			db.AddInParameter(dbCommand, "GHF1", DbType.String, model.GHF1);
			db.AddInParameter(dbCommand, "GHF2", DbType.String, model.GHF2);
			db.AddInParameter(dbCommand, "GHF28", DbType.String, model.GHF28);
			db.AddInParameter(dbCommand, "HF43", DbType.String, model.HF43);
			db.AddInParameter(dbCommand, "HF44", DbType.String, model.HF44);
			db.AddInParameter(dbCommand, "HF3", DbType.String, model.HF3);
			db.AddInParameter(dbCommand, "GHF3", DbType.String, model.GHF3);
			db.AddInParameter(dbCommand, "HF40", DbType.String, model.HF40);
			db.AddInParameter(dbCommand, "GHF40", DbType.String, model.GHF40);
			db.AddInParameter(dbCommand, "HF6", DbType.String, model.HF6);
			db.AddInParameter(dbCommand, "HF8", DbType.String, model.HF8);
			db.AddInParameter(dbCommand, "HF20", DbType.String, model.HF20);
			db.AddInParameter(dbCommand, "HF45", DbType.String, model.HF45);
			db.AddInParameter(dbCommand, "HF7", DbType.String, model.HF7);
			db.AddInParameter(dbCommand, "HF13", DbType.String, model.HF13);
			db.AddInParameter(dbCommand, "HF12", DbType.String, model.HF12);
			db.AddInParameter(dbCommand, "HF10", DbType.String, model.HF10);
			db.AddInParameter(dbCommand, "HF11", DbType.String, model.HF11);
			db.AddInParameter(dbCommand, "HF9", DbType.String, model.HF9);
			db.AddInParameter(dbCommand, "HF14", DbType.String, model.HF14);
			db.AddInParameter(dbCommand, "HF21", DbType.String, model.HF21);
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
		public bool Update(ECommerce.Admin.Model.Financel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Financel set ");
			strSql.Append("ComID=@ComID,");
			strSql.Append("UId=@UId,");
			strSql.Append("Fyear=@Fyear,");
			strSql.Append("HF1=@HF1,");
			strSql.Append("HF2=@HF2,");
			strSql.Append("HF28=@HF28,");
			strSql.Append("GHF1=@GHF1,");
			strSql.Append("GHF2=@GHF2,");
			strSql.Append("GHF28=@GHF28,");
			strSql.Append("HF43=@HF43,");
			strSql.Append("HF44=@HF44,");
			strSql.Append("HF3=@HF3,");
			strSql.Append("GHF3=@GHF3,");
			strSql.Append("HF40=@HF40,");
			strSql.Append("GHF40=@GHF40,");
			strSql.Append("HF6=@HF6,");
			strSql.Append("HF8=@HF8,");
			strSql.Append("HF20=@HF20,");
			strSql.Append("HF45=@HF45,");
			strSql.Append("HF7=@HF7,");
			strSql.Append("HF13=@HF13,");
			strSql.Append("HF12=@HF12,");
			strSql.Append("HF10=@HF10,");
			strSql.Append("HF11=@HF11,");
			strSql.Append("HF9=@HF9,");
			strSql.Append("HF14=@HF14,");
			strSql.Append("HF21=@HF21,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32, model.ID);
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "Fyear", DbType.String, model.Fyear);
			db.AddInParameter(dbCommand, "HF1", DbType.String, model.HF1);
			db.AddInParameter(dbCommand, "HF2", DbType.String, model.HF2);
			db.AddInParameter(dbCommand, "HF28", DbType.String, model.HF28);
			db.AddInParameter(dbCommand, "GHF1", DbType.String, model.GHF1);
			db.AddInParameter(dbCommand, "GHF2", DbType.String, model.GHF2);
			db.AddInParameter(dbCommand, "GHF28", DbType.String, model.GHF28);
			db.AddInParameter(dbCommand, "HF43", DbType.String, model.HF43);
			db.AddInParameter(dbCommand, "HF44", DbType.String, model.HF44);
			db.AddInParameter(dbCommand, "HF3", DbType.String, model.HF3);
			db.AddInParameter(dbCommand, "GHF3", DbType.String, model.GHF3);
			db.AddInParameter(dbCommand, "HF40", DbType.String, model.HF40);
			db.AddInParameter(dbCommand, "GHF40", DbType.String, model.GHF40);
			db.AddInParameter(dbCommand, "HF6", DbType.String, model.HF6);
			db.AddInParameter(dbCommand, "HF8", DbType.String, model.HF8);
			db.AddInParameter(dbCommand, "HF20", DbType.String, model.HF20);
			db.AddInParameter(dbCommand, "HF45", DbType.String, model.HF45);
			db.AddInParameter(dbCommand, "HF7", DbType.String, model.HF7);
			db.AddInParameter(dbCommand, "HF13", DbType.String, model.HF13);
			db.AddInParameter(dbCommand, "HF12", DbType.String, model.HF12);
			db.AddInParameter(dbCommand, "HF10", DbType.String, model.HF10);
			db.AddInParameter(dbCommand, "HF11", DbType.String, model.HF11);
			db.AddInParameter(dbCommand, "HF9", DbType.String, model.HF9);
			db.AddInParameter(dbCommand, "HF14", DbType.String, model.HF14);
			db.AddInParameter(dbCommand, "HF21", DbType.String, model.HF21);
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
			strSql.Append("delete from Financel ");
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
			strSql.Append("delete from Financel ");
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
		public ECommerce.Admin.Model.Financel GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Fyear,HF1,HF2,HF28,GHF1,GHF2,GHF28,HF43,HF44,HF3,GHF3,HF40,GHF40,HF6,HF8,HF20,HF45,HF7,HF13,HF12,HF10,HF11,HF9,HF14,HF21,CreateDate,UpdateDate from Financel ");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32,ID);
			ECommerce.Admin.Model.Financel model=null;
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
		public ECommerce.Admin.Model.Financel DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.Financel model=new ECommerce.Admin.Model.Financel();
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
				if(row["Fyear"]!=null)
				{
					model.Fyear=row["Fyear"].ToString();
				}
				if(row["HF1"]!=null)
				{
					model.HF1=row["HF1"].ToString();
				}
				if(row["HF2"]!=null)
				{
					model.HF2=row["HF2"].ToString();
				}
				if(row["HF28"]!=null)
				{
					model.HF28=row["HF28"].ToString();
				}
				if(row["GHF1"]!=null)
				{
					model.GHF1=row["GHF1"].ToString();
				}
				if(row["GHF2"]!=null)
				{
					model.GHF2=row["GHF2"].ToString();
				}
				if(row["GHF28"]!=null)
				{
					model.GHF28=row["GHF28"].ToString();
				}
				if(row["HF43"]!=null)
				{
					model.HF43=row["HF43"].ToString();
				}
				if(row["HF44"]!=null)
				{
					model.HF44=row["HF44"].ToString();
				}
				if(row["HF3"]!=null)
				{
					model.HF3=row["HF3"].ToString();
				}
				if(row["GHF3"]!=null)
				{
					model.GHF3=row["GHF3"].ToString();
				}
				if(row["HF40"]!=null)
				{
					model.HF40=row["HF40"].ToString();
				}
				if(row["GHF40"]!=null)
				{
					model.GHF40=row["GHF40"].ToString();
				}
				if(row["HF6"]!=null)
				{
					model.HF6=row["HF6"].ToString();
				}
				if(row["HF8"]!=null)
				{
					model.HF8=row["HF8"].ToString();
				}
				if(row["HF20"]!=null)
				{
					model.HF20=row["HF20"].ToString();
				}
				if(row["HF45"]!=null)
				{
					model.HF45=row["HF45"].ToString();
				}
				if(row["HF7"]!=null)
				{
					model.HF7=row["HF7"].ToString();
				}
				if(row["HF13"]!=null)
				{
					model.HF13=row["HF13"].ToString();
				}
				if(row["HF12"]!=null)
				{
					model.HF12=row["HF12"].ToString();
				}
				if(row["HF10"]!=null)
				{
					model.HF10=row["HF10"].ToString();
				}
				if(row["HF11"]!=null)
				{
					model.HF11=row["HF11"].ToString();
				}
				if(row["HF9"]!=null)
				{
					model.HF9=row["HF9"].ToString();
				}
				if(row["HF14"]!=null)
				{
					model.HF14=row["HF14"].ToString();
				}
				if(row["HF21"]!=null)
				{
					model.HF21=row["HF21"].ToString();
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
			strSql.Append("select ID,ComID,UId,Fyear,HF1,HF2,HF28,GHF1,GHF2,GHF28,HF43,HF44,HF3,GHF3,HF40,GHF40,HF6,HF8,HF20,HF45,HF7,HF13,HF12,HF10,HF11,HF9,HF14,HF21,CreateDate,UpdateDate ");
			strSql.Append(" FROM Financel ");
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
			strSql.Append(" ID,ComID,UId,Fyear,HF1,HF2,HF28,GHF1,GHF2,GHF28,HF43,HF44,HF3,GHF3,HF40,GHF40,HF6,HF8,HF20,HF45,HF7,HF13,HF12,HF10,HF11,HF9,HF14,HF21,CreateDate,UpdateDate ");
			strSql.Append(" FROM Financel ");
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
			strSql.Append("select count(1) FROM Financel ");
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
			strSql.Append(")AS Row, T.*  from Financel T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "Financel");
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
		public List<ECommerce.Admin.Model.Financel> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,Fyear,HF1,HF2,HF28,GHF1,GHF2,GHF28,HF43,HF44,HF3,GHF3,HF40,GHF40,HF6,HF8,HF20,HF45,HF7,HF13,HF12,HF10,HF11,HF9,HF14,HF21,CreateDate,UpdateDate ");
			strSql.Append(" FROM Financel ");
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
			List<ECommerce.Admin.Model.Financel> list = new List<ECommerce.Admin.Model.Financel>();
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
		public ECommerce.Admin.Model.Financel ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.Financel model=new ECommerce.Admin.Model.Financel();
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
			model.Fyear=dataReader["Fyear"].ToString();
			model.HF1=dataReader["HF1"].ToString();
			model.HF2=dataReader["HF2"].ToString();
			model.HF28=dataReader["HF28"].ToString();
			model.GHF1=dataReader["GHF1"].ToString();
			model.GHF2=dataReader["GHF2"].ToString();
			model.GHF28=dataReader["GHF28"].ToString();
			model.HF43=dataReader["HF43"].ToString();
			model.HF44=dataReader["HF44"].ToString();
			model.HF3=dataReader["HF3"].ToString();
			model.GHF3=dataReader["GHF3"].ToString();
			model.HF40=dataReader["HF40"].ToString();
			model.GHF40=dataReader["GHF40"].ToString();
			model.HF6=dataReader["HF6"].ToString();
			model.HF8=dataReader["HF8"].ToString();
			model.HF20=dataReader["HF20"].ToString();
			model.HF45=dataReader["HF45"].ToString();
			model.HF7=dataReader["HF7"].ToString();
			model.HF13=dataReader["HF13"].ToString();
			model.HF12=dataReader["HF12"].ToString();
			model.HF10=dataReader["HF10"].ToString();
			model.HF11=dataReader["HF11"].ToString();
			model.HF9=dataReader["HF9"].ToString();
			model.HF14=dataReader["HF14"].ToString();
			model.HF21=dataReader["HF21"].ToString();
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

        public Model.Financel GetModel(string strWhere, List<SqlParameter> parameters)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Financel ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            Model.Financel model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        #endregion
	}
}

