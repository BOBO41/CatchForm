
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
	/// 数据访问类:ComInfo
	/// </summary>
	public partial class ComInfo
	{
		public ComInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ID)+1 from ComInfo";
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
			strSql.Append("select count(1) from ComInfo where ID=@ID ");
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
		public int Add(ECommerce.Admin.Model.ComInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ComInfo(");
			strSql.Append("ComID,UId,ComName,Add1,Add2,Add3,City,Area,PostCode,Country,Phone,Fax,ComDesc,Industry,SubIndustry,SicCode,Industry2,SubIndustry2,SicCode2,Probe_sic,Probe_sic2,Probe_sic3,Employees,Domestic_company,Title,ContactFirstName,contactSurname,JobTitle,CreateDate,UpdateDate)");

			strSql.Append(" values (");
			strSql.Append("@ComID,@UId,@ComName,@Add1,@Add2,@Add3,@City,@Area,@PostCode,@Country,@Phone,@Fax,@ComDesc,@Industry,@SubIndustry,@SicCode,@Industry2,@SubIndustry2,@SicCode2,@Probe_sic,@Probe_sic2,@Probe_sic3,@Employees,@Domestic_company,@Title,@ContactFirstName,@contactSurname,@JobTitle,@CreateDate,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "ComName", DbType.String, model.ComName);
			db.AddInParameter(dbCommand, "Add1", DbType.String, model.Add1);
			db.AddInParameter(dbCommand, "Add2", DbType.String, model.Add2);
			db.AddInParameter(dbCommand, "Add3", DbType.String, model.Add3);
			db.AddInParameter(dbCommand, "City", DbType.String, model.City);
			db.AddInParameter(dbCommand, "Area", DbType.String, model.Area);
			db.AddInParameter(dbCommand, "PostCode", DbType.String, model.PostCode);
			db.AddInParameter(dbCommand, "Country", DbType.String, model.Country);
			db.AddInParameter(dbCommand, "Phone", DbType.String, model.Phone);
			db.AddInParameter(dbCommand, "Fax", DbType.String, model.Fax);
			db.AddInParameter(dbCommand, "ComDesc", DbType.String, model.ComDesc);
			db.AddInParameter(dbCommand, "Industry", DbType.String, model.Industry);
			db.AddInParameter(dbCommand, "SubIndustry", DbType.String, model.SubIndustry);
			db.AddInParameter(dbCommand, "SicCode", DbType.String, model.SicCode);
			db.AddInParameter(dbCommand, "Industry2", DbType.String, model.Industry2);
			db.AddInParameter(dbCommand, "SubIndustry2", DbType.String, model.SubIndustry2);
			db.AddInParameter(dbCommand, "SicCode2", DbType.String, model.SicCode2);
			db.AddInParameter(dbCommand, "Probe_sic", DbType.String, model.Probe_sic);
			db.AddInParameter(dbCommand, "Probe_sic2", DbType.String, model.Probe_sic2);
			db.AddInParameter(dbCommand, "Probe_sic3", DbType.String, model.Probe_sic3);
			db.AddInParameter(dbCommand, "Employees", DbType.String, model.Employees);
			db.AddInParameter(dbCommand, "Domestic_company", DbType.String, model.Domestic_company);
			db.AddInParameter(dbCommand, "Title", DbType.String, model.Title);
			db.AddInParameter(dbCommand, "ContactFirstName", DbType.String, model.ContactFirstName);
			db.AddInParameter(dbCommand, "contactSurname", DbType.String, model.contactSurname);
			db.AddInParameter(dbCommand, "JobTitle", DbType.String, model.JobTitle);
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
		public bool Update(ECommerce.Admin.Model.ComInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ComInfo set ");
			strSql.Append("ComID=@ComID,");
			strSql.Append("UId=@UId,");
			strSql.Append("ComName=@ComName,");
			strSql.Append("Add1=@Add1,");
			strSql.Append("Add2=@Add2,");
			strSql.Append("Add3=@Add3,");
			strSql.Append("City=@City,");
			strSql.Append("Area=@Area,");
			strSql.Append("PostCode=@PostCode,");
			strSql.Append("Country=@Country,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("ComDesc=@ComDesc,");
			strSql.Append("Industry=@Industry,");
			strSql.Append("SubIndustry=@SubIndustry,");
			strSql.Append("SicCode=@SicCode,");
			strSql.Append("Industry2=@Industry2,");
			strSql.Append("SubIndustry2=@SubIndustry2,");
			strSql.Append("SicCode2=@SicCode2,");
			strSql.Append("Probe_sic=@Probe_sic,");
			strSql.Append("Probe_sic2=@Probe_sic2,");
			strSql.Append("Probe_sic3=@Probe_sic3,");
			strSql.Append("Employees=@Employees,");
			strSql.Append("Domestic_company=@Domestic_company,");
			strSql.Append("Title=@Title,");
			strSql.Append("ContactFirstName=@ContactFirstName,");
			strSql.Append("contactSurname=@contactSurname,");
			strSql.Append("JobTitle=@JobTitle,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32, model.ID);
			db.AddInParameter(dbCommand, "ComID", DbType.String, model.ComID);
			db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
			db.AddInParameter(dbCommand, "ComName", DbType.String, model.ComName);
			db.AddInParameter(dbCommand, "Add1", DbType.String, model.Add1);
			db.AddInParameter(dbCommand, "Add2", DbType.String, model.Add2);
			db.AddInParameter(dbCommand, "Add3", DbType.String, model.Add3);
			db.AddInParameter(dbCommand, "City", DbType.String, model.City);
			db.AddInParameter(dbCommand, "Area", DbType.String, model.Area);
			db.AddInParameter(dbCommand, "PostCode", DbType.String, model.PostCode);
			db.AddInParameter(dbCommand, "Country", DbType.String, model.Country);
			db.AddInParameter(dbCommand, "Phone", DbType.String, model.Phone);
			db.AddInParameter(dbCommand, "Fax", DbType.String, model.Fax);
			db.AddInParameter(dbCommand, "ComDesc", DbType.String, model.ComDesc);
			db.AddInParameter(dbCommand, "Industry", DbType.String, model.Industry);
			db.AddInParameter(dbCommand, "SubIndustry", DbType.String, model.SubIndustry);
			db.AddInParameter(dbCommand, "SicCode", DbType.String, model.SicCode);
			db.AddInParameter(dbCommand, "Industry2", DbType.String, model.Industry2);
			db.AddInParameter(dbCommand, "SubIndustry2", DbType.String, model.SubIndustry2);
			db.AddInParameter(dbCommand, "SicCode2", DbType.String, model.SicCode2);
			db.AddInParameter(dbCommand, "Probe_sic", DbType.String, model.Probe_sic);
			db.AddInParameter(dbCommand, "Probe_sic2", DbType.String, model.Probe_sic2);
			db.AddInParameter(dbCommand, "Probe_sic3", DbType.String, model.Probe_sic3);
			db.AddInParameter(dbCommand, "Employees", DbType.String, model.Employees);
			db.AddInParameter(dbCommand, "Domestic_company", DbType.String, model.Domestic_company);
			db.AddInParameter(dbCommand, "Title", DbType.String, model.Title);
			db.AddInParameter(dbCommand, "ContactFirstName", DbType.String, model.ContactFirstName);
			db.AddInParameter(dbCommand, "contactSurname", DbType.String, model.contactSurname);
			db.AddInParameter(dbCommand, "JobTitle", DbType.String, model.JobTitle);
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
			strSql.Append("delete from ComInfo ");
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
			strSql.Append("delete from ComInfo ");
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
		public ECommerce.Admin.Model.ComInfo GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,ComName,Add1,Add2,Add3,City,Area,PostCode,Country,Phone,Fax,ComDesc,Industry,SubIndustry,SicCode,Industry2,SubIndustry2,SicCode2,Probe_sic,Probe_sic2,Probe_sic3,Employees,Domestic_company,Title,ContactFirstName,contactSurname,JobTitle,CreateDate,UpdateDate from ComInfo ");
			strSql.Append(" where ID=@ID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ID", DbType.Int32,ID);
			ECommerce.Admin.Model.ComInfo model=null;
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
		public ECommerce.Admin.Model.ComInfo DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.ComInfo model=new ECommerce.Admin.Model.ComInfo();
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
				if(row["ComName"]!=null)
				{
					model.ComName=row["ComName"].ToString();
				}
				if(row["Add1"]!=null)
				{
					model.Add1=row["Add1"].ToString();
				}
				if(row["Add2"]!=null)
				{
					model.Add2=row["Add2"].ToString();
				}
				if(row["Add3"]!=null)
				{
					model.Add3=row["Add3"].ToString();
				}
				if(row["City"]!=null)
				{
					model.City=row["City"].ToString();
				}
				if(row["Area"]!=null)
				{
					model.Area=row["Area"].ToString();
				}
				if(row["PostCode"]!=null)
				{
					model.PostCode=row["PostCode"].ToString();
				}
				if(row["Country"]!=null)
				{
					model.Country=row["Country"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Fax"]!=null)
				{
					model.Fax=row["Fax"].ToString();
				}
				if(row["ComDesc"]!=null)
				{
					model.ComDesc=row["ComDesc"].ToString();
				}
				if(row["Industry"]!=null)
				{
					model.Industry=row["Industry"].ToString();
				}
				if(row["SubIndustry"]!=null)
				{
					model.SubIndustry=row["SubIndustry"].ToString();
				}
				if(row["SicCode"]!=null)
				{
					model.SicCode=row["SicCode"].ToString();
				}
				if(row["Industry2"]!=null)
				{
					model.Industry2=row["Industry2"].ToString();
				}
				if(row["SubIndustry2"]!=null)
				{
					model.SubIndustry2=row["SubIndustry2"].ToString();
				}
				if(row["SicCode2"]!=null)
				{
					model.SicCode2=row["SicCode2"].ToString();
				}
				if(row["Probe_sic"]!=null)
				{
					model.Probe_sic=row["Probe_sic"].ToString();
				}
				if(row["Probe_sic2"]!=null)
				{
					model.Probe_sic2=row["Probe_sic2"].ToString();
				}
				if(row["Probe_sic3"]!=null)
				{
					model.Probe_sic3=row["Probe_sic3"].ToString();
				}
				if(row["Employees"]!=null)
				{
					model.Employees=row["Employees"].ToString();
				}
				if(row["Domestic_company"]!=null)
				{
					model.Domestic_company=row["Domestic_company"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["ContactFirstName"]!=null)
				{
					model.ContactFirstName=row["ContactFirstName"].ToString();
				}
				if(row["contactSurname"]!=null)
				{
					model.contactSurname=row["contactSurname"].ToString();
				}
				if(row["JobTitle"]!=null)
				{
					model.JobTitle=row["JobTitle"].ToString();
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
			strSql.Append("select ID,ComID,UId,ComName,Add1,Add2,Add3,City,Area,PostCode,Country,Phone,Fax,ComDesc,Industry,SubIndustry,SicCode,Industry2,SubIndustry2,SicCode2,Probe_sic,Probe_sic2,Probe_sic3,Employees,Domestic_company,Title,ContactFirstName,contactSurname,JobTitle,CreateDate,UpdateDate ");
			strSql.Append(" FROM ComInfo ");
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
			strSql.Append(" ID,ComID,UId,ComName,Add1,Add2,Add3,City,Area,PostCode,Country,Phone,Fax,ComDesc,Industry,SubIndustry,SicCode,Industry2,SubIndustry2,SicCode2,Probe_sic,Probe_sic2,Probe_sic3,Employees,Domestic_company,Title,ContactFirstName,contactSurname,JobTitle,CreateDate,UpdateDate ");
			strSql.Append(" FROM ComInfo ");
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
			strSql.Append("select count(1) FROM ComInfo ");
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
			strSql.Append(")AS Row, T.*  from ComInfo T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "ComInfo");
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
		public List<ECommerce.Admin.Model.ComInfo> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ComID,UId,ComName,Add1,Add2,Add3,City,Area,PostCode,Country,Phone,Fax,ComDesc,Industry,SubIndustry,SicCode,Industry2,SubIndustry2,SicCode2,Probe_sic,Probe_sic2,Probe_sic3,Employees,Domestic_company,Title,ContactFirstName,contactSurname,JobTitle,CreateDate,UpdateDate ");
			strSql.Append(" FROM ComInfo ");
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
			List<ECommerce.Admin.Model.ComInfo> list = new List<ECommerce.Admin.Model.ComInfo>();
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
		public ECommerce.Admin.Model.ComInfo ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.ComInfo model=new ECommerce.Admin.Model.ComInfo();
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
			model.ComName=dataReader["ComName"].ToString();
			model.Add1=dataReader["Add1"].ToString();
			model.Add2=dataReader["Add2"].ToString();
			model.Add3=dataReader["Add3"].ToString();
			model.City=dataReader["City"].ToString();
			model.Area=dataReader["Area"].ToString();
			model.PostCode=dataReader["PostCode"].ToString();
			model.Country=dataReader["Country"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			model.Fax=dataReader["Fax"].ToString();
			model.ComDesc=dataReader["ComDesc"].ToString();
			model.Industry=dataReader["Industry"].ToString();
			model.SubIndustry=dataReader["SubIndustry"].ToString();
			model.SicCode=dataReader["SicCode"].ToString();
			model.Industry2=dataReader["Industry2"].ToString();
			model.SubIndustry2=dataReader["SubIndustry2"].ToString();
			model.SicCode2=dataReader["SicCode2"].ToString();
			model.Probe_sic=dataReader["Probe_sic"].ToString();
			model.Probe_sic2=dataReader["Probe_sic2"].ToString();
			model.Probe_sic3=dataReader["Probe_sic3"].ToString();
			model.Employees=dataReader["Employees"].ToString();
			model.Domestic_company=dataReader["Domestic_company"].ToString();
			model.Title=dataReader["Title"].ToString();
			model.ContactFirstName=dataReader["ContactFirstName"].ToString();
			model.contactSurname=dataReader["contactSurname"].ToString();
			model.JobTitle=dataReader["JobTitle"].ToString();
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

	    public Model.ComInfo GetModel(string strWhere, List<SqlParameter> parameters)
	    {

	        StringBuilder strSql = new StringBuilder();
	        strSql.Append("select * from ComInfo ");
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
	        Model.ComInfo model = null;
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

