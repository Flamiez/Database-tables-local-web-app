using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using DuombaziuLenteles.Models;
using DuombaziuLenteles.ViewModels;
using MySql.Data.MySqlClient;

namespace DuombaziuLenteles.Repos
{
    public class ImoneRepository
    {
        public List<imone> getImones()
        {
            List<imone> imones = new List<imone>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "imone";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                imones.Add(new imone
                {
                    biudzetas = Convert.ToSingle(item["biudzetas"]),
                    id = Convert.ToInt32(item["id"]),
                    max_galimas_darbuotoju_kiekis = Convert.ToInt32(item["max_galimas_darbuotoju_kiekis"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"])


                });
            }
            return imones;
        }
        public bool addImone(imone imone)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO " + Globals.dbPrefix + "imone(id,pavadinimas,biudzetas,max_galimas_darbuotoju_kiekis)VALUES(?id,?pavadinimas,?biudzetas,?max_galimas_darbuotoju_kiekis);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = imone.id;
                mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.String).Value = imone.pavadinimas;
                mySqlCommand.Parameters.Add("?biudzetas", MySqlDbType.Float).Value = imone.biudzetas;
                mySqlCommand.Parameters.Add("?max_galimas_darbuotoju_kiekis", MySqlDbType.Int32).Value = imone.max_galimas_darbuotoju_kiekis;
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

        public bool updateImone(imone imone)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE " + Globals.dbPrefix + "imone a SET a.id=?id ,a.pavadinimas=?pavadinimas,a.biudzetas=?biudzetas,a.max_galimas_darbuotoju_kiekis =?max_galimas_darbuotoju_kiekis WHERE a.id=?id";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = imone.id;
                mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.String).Value = imone.pavadinimas;
                mySqlCommand.Parameters.Add("?biudzetas", MySqlDbType.Float).Value = imone.biudzetas;
                mySqlCommand.Parameters.Add("?max_galimas_darbuotoju_kiekis", MySqlDbType.Int32).Value = imone.max_galimas_darbuotoju_kiekis;

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
        public imone getImone(int id)
        {
            imone imone = new imone();
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

                imone.id = Convert.ToInt32(item["id"]);
                imone.biudzetas = Convert.ToSingle(item["biudzetas"]);
                imone.pavadinimas = Convert.ToString(item["pavadinimas"]);
                imone.max_galimas_darbuotoju_kiekis = Convert.ToInt32(item["max_galimas_darbuotoju_kiekis"]);


            }
            return imone;
        }

        public void deleteImone(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM " + Globals.dbPrefix + "imone where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }

}
