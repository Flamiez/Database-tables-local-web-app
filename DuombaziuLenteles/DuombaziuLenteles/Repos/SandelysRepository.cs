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
    public class SandelysRepository
    {
        public List<SandelysViewModel> getSandeliai()
        {
            List<SandelysViewModel> sandeliai = new List<SandelysViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select m.id_SANDELYS, m.pavadinimas, m.adresas, m.talpa, m.pastatymo_metai,m.skirtingu_saugomu_medziagu_kiekis,m.fk_IMONEid, mm.pavadinimas AS pav from sandelys m LEFT JOIN imone mm ON mm.id=m.fk_IMONEid";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                sandeliai.Add(new SandelysViewModel
                {
                  id_SANDELYS = Convert.ToInt32(item["id_SANDELYS"]),                  
                  pavadinimas = Convert.ToString(item["pavadinimas"]),
                  adresas = Convert.ToString(item["adresas"]),
                  talpa = Convert.ToInt32(item["talpa"]),
                  pastatymo_metai = Convert.ToDateTime(item["pastatymo_metai"]),
                  skirtingu_saugomu_medziagu_kiekis = Convert.ToInt32(item["skirtingu_saugomu_medziagu_kiekis"]),
                  fk_IMONEid = Convert.ToInt32(item["fk_IMONEid"]),
                  Imone = Convert.ToString(item["pav"])
                  


                });
            }
            return sandeliai;
        }
        public bool addSandelys(SandelysEditViewModel imone)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO " + Globals.dbPrefix + "sandelys(id_SANDELYS,pavadinimas,adresas,talpa,pastatymo_metai,skirtingu_saugomu_medziagu_kiekis,fk_IMONEid)VALUES(?id_SANDELYS,?pavadinimas,?adresas,?talpa,?pastatymo_metai,?skirtingu_saugomu_medziagu_kiekis,?fk_IMONEid)";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?id_SANDELYS", MySqlDbType.Int32).Value = imone.id_SANDELYS;
                mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.String).Value = imone.pavadinimas;
                mySqlCommand.Parameters.Add("?adresas", MySqlDbType.String).Value = imone.adresas;
                mySqlCommand.Parameters.Add("?talpa", MySqlDbType.Int32).Value = imone.talpa;
                mySqlCommand.Parameters.Add("?pastatymo_metai", MySqlDbType.Date).Value = imone.pastatymo_metai;
                mySqlCommand.Parameters.Add("?skirtingu_saugomu_medziagu_kiekis", MySqlDbType.Int32).Value = imone.skirtingu_saugomu_medziagu_kiekis;
                mySqlCommand.Parameters.Add("?fk_IMONEid", MySqlDbType.Int32).Value = imone.fk_IMONEid;
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

        public bool updateSandelys(SandelysEditViewModel imone, int id)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE sandelys SET pavadinimas=?pavadinimas,adresas=?adresas,talpa=?talpa, pastatymo_metai=?pastatymo_metai,skirtingu_saugomu_medziagu_kiekis=?skirtingu_saugomu_medziagu_kiekis,fk_IMONEid=?fk_IMONEid WHERE id_SANDELYS="+id;
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.String).Value = imone.pavadinimas;
                mySqlCommand.Parameters.Add("?adresas", MySqlDbType.String).Value = imone.adresas;
                mySqlCommand.Parameters.Add("?talpa", MySqlDbType.Int32).Value = imone.talpa;
                mySqlCommand.Parameters.Add("?pastatymo_metai", MySqlDbType.Date).Value = imone.pastatymo_metai;
                mySqlCommand.Parameters.Add("?skirtingu_saugomu_medziagu_kiekis", MySqlDbType.Int32).Value = imone.skirtingu_saugomu_medziagu_kiekis;
                mySqlCommand.Parameters.Add("?fk_IMONEid", MySqlDbType.Int32).Value = imone.fk_IMONEid;
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
        public SandelysEditViewModel getSandelys(int id)
        {
            SandelysEditViewModel imone = new SandelysEditViewModel();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM sandelys WHERE id_SANDELYS=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);

            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                imone.fk_IMONEid = Convert.ToInt32(item["fk_IMONEid"]);
                imone.id_SANDELYS = Convert.ToInt32(item["id_SANDELYS"]);
                imone.pavadinimas = Convert.ToString(item["pavadinimas"]);
                imone.talpa = Convert.ToInt32(item["talpa"]);
                imone.pastatymo_metai = Convert.ToDateTime(item["pastatymo_metai"]);
                imone.skirtingu_saugomu_medziagu_kiekis = Convert.ToInt32(item["skirtingu_saugomu_medziagu_kiekis"]);
                imone.adresas = Convert.ToString(item["adresas"]);


            }
            return imone;
        }

        public void deleteSandelys(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM " + Globals.dbPrefix + "sandelys where id_SANDELYS=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

    }
}