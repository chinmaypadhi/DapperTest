﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyMCE.Models.ConnectionFactory
{
    public class DapperORM
    {
        public static IDbConnection connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["MCEConectionString"].ConnectionString);
            }
        }

        public static string ExecuteDML(String procedureName, DynamicParameters param = null, String OutputParamer = null)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    con.Open();
                    var result =  con.Query(procedureName, param, commandType: CommandType.StoredProcedure);

                    var msgout = param.Get<string>(OutputParamer);
                    //msgout = "1";
                    return msgout.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> ExecuteDMLAsync(String procedureName, DynamicParameters param = null, String OutputParamer = null)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    con.Open();
                    var result = await con.QueryAsync(procedureName, param, commandType: CommandType.StoredProcedure);

                    var msgout = param.Get<string>(OutputParamer);
                    return msgout.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DapperORM.ReturnList<EmployeeModel> <=  IEnumerable<EmployeeModel>
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (IDbConnection con = connection)
            {
                con.Open();
                return  con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static async Task<IEnumerable<T>> ReturnListAsync<T>(string procedureName, DynamicParameters param = null)
        {
            using (IDbConnection con = connection)
            {
                con.Open();
                return await con.QueryAsync<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }

        }


        //Return Single Row
        public static  T ReturnDetails<T>(String procedureName, DynamicParameters param = null, String OutputParamer = null)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    con.Open();
                    return con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Return Single Row
        public static async Task<T> ReturnDetailsAsync<T>(String procedureName, DynamicParameters param = null, String OutputParamer = null)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    con.Open();
                    var result = await con.QueryAsync<T>(procedureName, param, commandType: CommandType.StoredProcedure);
                    return result.SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}