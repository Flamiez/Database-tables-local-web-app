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
    public class tiekia_prekesRepository
    {
        public List<tiekia_prekes> getTiekiaPrekes()
        {
            List<tiekia_prekes> fkTiekiaPrekes = new List<tiekia_prekes>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "tiekia_prekes";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                fkTiekiaPrekes.Add(new tiekia_prekes
                {
                    fk_SANDELYSid_SANDELYS = Convert.ToInt32(item["fk_SANDELYSid_SANDELYS"]),
                    fk_TIEKEJASid = Convert.ToInt32(item["fk_TIEKEJASid"])

                });
            }
            return fkTiekiaPrekes;
        }

    }
}