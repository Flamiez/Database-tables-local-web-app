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
    public class saskaita_fakturaRepository
    {
        public List<saskaita_faktura> getSaskaitosFakturos()
        {
            List<saskaita_faktura> saskaitos_fakturos = new List<saskaita_faktura>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "saskaita_faktura";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                saskaitos_fakturos.Add(new saskaita_faktura
                {

                    fk_PIRKEJASid_PIRKEJAS = Convert.ToInt32(item["fk_PIRKEJASid_PIRKEJAS"]),
                    fk_IMONEid = Convert.ToInt32(item["fk_IMONEid"]),
                    id = Convert.ToInt32(item["id"]),
                    kaina = Convert.ToInt32(item["kaina"]),
                    pasirasymo_data = Convert.ToDateTime(item["pasirasymo_data"])


                });
            }
            return saskaitos_fakturos;
        }

    }
}