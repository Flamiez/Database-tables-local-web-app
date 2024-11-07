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
    public class zidinysRepository
    {
        public List<zidinys> getZidiniai()
        {
            List<zidinys> zidiniai = new List<zidinys>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "zidinys";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                zidiniai.Add(new zidinys
                {
                    fk_ADRESASid_ADRESAS = Convert.ToInt32(item["fk_ADRESASid_ADRESAS"]),
                    id = Convert.ToInt32(item["id"]),
                    ilgis = Convert.ToInt32(item["ilgis"]),
                    aukstis = Convert.ToInt32(item["aukstis"]),
                    plotis = Convert.ToInt32(item["plotis"]),
                    vardas = Convert.ToString(item["vardas"]),
                    medziaga = Convert.ToString(item["medziaga"])
                    
                    
                });
            }
            return zidiniai;
        }

    }
}