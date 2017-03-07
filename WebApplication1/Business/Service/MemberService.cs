using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using DataAccess.Model;

using AlonsoLibary;
using AlonsoExt;

namespace Business.Service
{
    public class MemberService
    {

        public void Delete(string ID) {

            string strconn = @"Data Source=MEPOWERLMAY-PC\SQLEXPRESS;Initial Catalog=test;User Id=sa;Password=321456852;";
            string sql = "delte from Member where ID=" +ID; 
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;              
                cmd.ExecuteNonQuery();
            }
        }


        public void Edit(MemberModel model, long ID)
        {

            Dictionary<string, string> dics = new Dictionary<string, string>();
            SqlParameter[] SqlParameters;
            string sql = "";
            string strconn = @"Data Source=MEPOWERLMAY-PC\SQLEXPRESS;Initial Catalog=test;User Id=sa;Password=321456852;";
            if (ID == 0)
            {


                // add


                //dics.Add("ID", );
                dics.Add("UserName", model.UserName);
                dics.Add("Gender", model.Gender);

                sql = SqlHelper.GenerateSQL_Ins(dics, "Member", out SqlParameters);

                using (SqlConnection conn = new SqlConnection(strconn))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(SqlParameters);
                    cmd.ExecuteNonQuery();

                }

            }
            else
            {
                //update
                sql = SqlHelper.GenerateSQL_Update(dics, "Member", out SqlParameters);
                dics.Add("UserName", model.UserName);
                dics.Add("Gender", model.Gender);

                string where = " ID = " + ID.ToString();

                sql += where;
                using (SqlConnection conn = new SqlConnection(strconn))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(SqlParameters);
                    cmd.ExecuteNonQuery();

                }


            }

        }


        /// <summary>
        /// 取得單筆會員資料  bt ID
        /// </summary>
        /// <param name="ID">主key</param>
        /// <returns></returns>
        public MemberModel Get(string ID)
        {
            MemberModel model = new MemberModel();

            IEnumerable<MemberModel> GroupMemberModel = new List<MemberModel>();

            DataTable dt = new DataTable();
            string sql = "select * from Member where ID=" + ID;

            string strconn = @"Data Source=MEPOWERLMAY-PC\SQLEXPRESS;Initial Catalog=test;User Id=sa;Password=321456852;";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                dt.Load(cmd.ExecuteReader());
            }


            if (dt.Rows.Count > 0)
            {
                GroupMemberModel = dt.ToList<MemberModel>();
            }

            model = GroupMemberModel.FirstOrDefault();
            return model;
        }

        public IEnumerable<MemberModel> GetList()
        {

            IEnumerable<MemberModel> GroupMemberModel = new List<MemberModel>();

            DataTable dt = new DataTable();
            string sql = "select * from Member";

            string strconn = @"Data Source=MEPOWERLMAY-PC\SQLEXPRESS;Initial Catalog=test;User Id=sa;Password=321456852;";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                dt.Load(cmd.ExecuteReader());
            }


            if (dt.Rows.Count > 0)
            {
                GroupMemberModel = dt.ToList<MemberModel>();
            }

            return GroupMemberModel;
        }

    }
}
