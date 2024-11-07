using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using DuombaziuLenteles.Models;
using MySql.Data.MySqlClient;
using DuombaziuLenteles.ViewModels;

namespace DuombaziuLenteles.Repos
{
    public class DraudimasRepository
    {
        public List<DraudimasViewModel> getDraudimai()
        {
            List<DraudimasViewModel> draudimai = new List<DraudimasViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"select m.id, m.galiojimo_laikotarpis, m.pasirasymo_data, mm.vardas AS pavadinimas FROM draudimas m LEFT JOIN zidinys mm ON mm.id=m.fk_ZIDINYSid";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                draudimai.Add(new DraudimasViewModel
                {
                    id = Convert.ToInt32(item["id"]),
                    //fk_ZIDINYSid = Convert.ToInt32(item["fk_ZIDINYSid"]),
                    galiojimo_laikotarpis = Convert.ToDateTime(item["galiojimo_laikotarpis"]),
                    pasirasymo_data = Convert.ToDateTime(item["pasirasymo_data"]),
                    zidinys = Convert.ToString(item["pavadinimas"])


                });
            }
            return draudimai;
        }

        public bool addDraudimas(DraudimasEditViewModel draudimas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO " + Globals.dbPrefix + "draudimas(id,fk_ZIDINYSid,pasirasymo_data,galiojimo_laikotarpis)VALUES(?id,?zidid,?pdata,?glaik);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = draudimas.id;
                mySqlCommand.Parameters.Add("?zidid", MySqlDbType.Int32).Value = draudimas.fk_ZIDINYSid;
                mySqlCommand.Parameters.Add("?pdata", MySqlDbType.Date).Value = draudimas.pasirasymo_data;
                mySqlCommand.Parameters.Add("?glaik", MySqlDbType.Date).Value = draudimas.galiojimo_laikotarpis;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateDraudimas(DraudimasEditViewModel draudimas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE " + Globals.dbPrefix + "draudimas a SET a.fk_ZIDINYSid=?zidid ,a.galiojimo_laikotarpis=?glaik,a.pasirasymo_data=?pdata WHERE a.id=?id";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = draudimas.id;
                mySqlCommand.Parameters.Add("?zidid", MySqlDbType.Int32).Value = draudimas.fk_ZIDINYSid;
                mySqlCommand.Parameters.Add("?pdata", MySqlDbType.Date).Value = draudimas.pasirasymo_data;
                mySqlCommand.Parameters.Add("?glaik", MySqlDbType.Date).Value = draudimas.galiojimo_laikotarpis;

                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DraudimasEditViewModel getDraudimas(int id)
        {
            DraudimasEditViewModel draudimas = new DraudimasEditViewModel();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* FROM draudimas m WHERE m.id=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);

            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                draudimas.id = Convert.ToInt32(item["id"]);
                draudimas.fk_ZIDINYSid = Convert.ToInt32(item["fk_ZIDINYSid"]);
                draudimas.galiojimo_laikotarpis = Convert.ToDateTime(item["galiojimo_laikotarpis"]);
                draudimas.pasirasymo_data = Convert.ToDateTime(item["pasirasymo_data"]);


            }
            return draudimas;
        }

        public void deleteDraudimas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM " + Globals.dbPrefix + "draudimas where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}