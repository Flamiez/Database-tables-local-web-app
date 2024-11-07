using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using DuombaziuLenteles.Models;
using MySql.Data.MySqlClient;

namespace DuombaziuLenteles.Repos
{
    public class sutartisRepository
    {
        public List<sutartis> getSutartys()
        {
            List<sutartis> sutartys = new List<sutartis>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "sutartis";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                sutartys.Add(new sutartis
                {

                    fk_TIEKEJASid = Convert.ToInt32(item["fk_TIEKEJASid"]),
                    fk_IMONEid = Convert.ToInt32(item["fk_IMONEid"]),
                    id = Convert.ToInt32(item["id"]),
                    kaina = Convert.ToInt32(item["kaina"]),
                    pasirasymo_data = Convert.ToDateTime(item["pasirasymo_data"])


                });
            }
            return sutartys;
        }

    }
}