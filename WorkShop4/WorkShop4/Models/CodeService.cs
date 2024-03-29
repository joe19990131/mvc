﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkShop4.Models
{
    public class CodeService
    {
        public List<SelectListItem> GetClassCodeTable()
        {
            DataTable dt = new DataTable();
            string sql = @"Select Distinct BOOK_CLASS_ID AS BookClassId ,BOOK_CLASS_NAME As BookClass 
                           From BOOK_CLASS ORDER BY BOOK_CLASS_NAME
                           ";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.Add(new SqlParameter("@Class", Class));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapBookClassData(dt);
        }
     
        private List<SelectListItem> MapBookClassData(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["BookClassId"].ToString() + '-' + row["BookClass"].ToString(),
                    Value = row["BookClassId"].ToString()
                });
            }
            return result;
        }



        public List<SelectListItem> GetBookKeeperTable()
        {
            DataTable dt = new DataTable();
            string sql = @"Select Distinct USER_ID AS UserId ,USER_ENAME As UserEname 
                           From MEMBER_M ORDER BY USER_ENAME
                           ";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.Add(new SqlParameter("@Class", Class));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapBookKeeperData(dt);
        }
        private List<SelectListItem> MapBookKeeperData(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["UserEname"].ToString(),
                    Value = row["UserEname"].ToString()
                });
            }
            return result;
        }


        public List<SelectListItem> GetBookStatusTable()
        {
            DataTable dt = new DataTable();
            string sql = @"Select Distinct CODE_NAME AS CodeName  
                           From BOOK_CODE
                            where CODE_TYPE LIKE 'BOOK_STATUS'
                           ";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.Add(new SqlParameter("@Class", Class));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapBookStatusData(dt);
        }
        private List<SelectListItem> MapBookStatusData(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["CodeName"].ToString(),
                    Value = row["CodeName"].ToString()
                });
            }
            return result;
        }


        private string GetDBConnectionString()
        {
            return
               System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        
    }
}