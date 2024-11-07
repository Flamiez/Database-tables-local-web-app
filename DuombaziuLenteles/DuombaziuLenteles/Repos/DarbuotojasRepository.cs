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
    public class DarbuotojasRepository
    {
        public List<DarbuotojasViewModel> getDarbuotojai()
        {
            List<DarbuotojasViewModel> darbuotojai = new List<DarbuotojasViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "darbuotojas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                darbuotojai.Add(new DarbuotojasViewModel
                {

                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    alga = Convert.ToInt32(item["alga"]),
                    asmens_kodas = Convert.ToInt32(item["asmens_kodas"]),
                    id = Convert.ToInt32(item["id"]),
                    telefono_numeris = Convert.ToString(item["telefono_numeris"]),
                    fk_IMONEid = Convert.ToInt32(item["fk_IMONEid"]),
                    fk_ZIDINYSid = Convert.ToInt32(item["fk_ZIDINYSid"])
                    


                });
            }
            return darbuotojai;
        }

        public bool addDarbuotojas(DarbuotojasEditViewModel darbuotojas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO " + Globals.dbPrefix + "darbuotojas(id,asmens_kodas,vardas,pavarde,telefono_numeris,alga,fk_IMONEid,fk_ZIDINYSid)VALUES(?asmid,?asmkod,?vardas,?pavarde,?tel,?alga,?imoneid,?zidinysid);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?asmid", MySqlDbType.Int32).Value = darbuotojas.id;
                mySqlCommand.Parameters.Add("?asmkod", MySqlDbType.Int32).Value = darbuotojas.asmens_kodas;
                mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = darbuotojas.vardas;
                mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = darbuotojas.pavarde;
                mySqlCommand.Parameters.Add("?tel", MySqlDbType.VarChar).Value = darbuotojas.telefono_numeris;
                mySqlCommand.Parameters.Add("?alga", MySqlDbType.Float).Value = darbuotojas.alga;
                mySqlCommand.Parameters.Add("?imoneid", MySqlDbType.Int32).Value = darbuotojas.fk_IMONEid;
                mySqlCommand.Parameters.Add("?zidinysid", MySqlDbType.Int32).Value = darbuotojas.fk_ZIDINYSid;
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

        public bool updateDarbuotojas(DarbuotojasEditViewModel darbuotojas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE " + Globals.dbPrefix + "darbuotojas a SET a.asmens_kodas=?asmkod,a.vardas=?vardas,a.pavarde=?pavarde,a.telefono_numeris=?tel, a.alga=?alga,a.fk_IMONEid=?imoneid,a.fk_ZIDINYSid = ?zidinysid WHERE a.id=?asmid";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?asmid", MySqlDbType.Int32).Value = darbuotojas.id;
                mySqlCommand.Parameters.Add("?asmkod", MySqlDbType.Int32).Value = darbuotojas.asmens_kodas;
                mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = darbuotojas.vardas;
                mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = darbuotojas.pavarde;
                mySqlCommand.Parameters.Add("?tel", MySqlDbType.VarChar).Value = darbuotojas.telefono_numeris;
                mySqlCommand.Parameters.Add("?alga", MySqlDbType.Float).Value = darbuotojas.alga;
                mySqlCommand.Parameters.Add("?imoneid", MySqlDbType.Int32).Value = darbuotojas.fk_IMONEid;
                mySqlCommand.Parameters.Add("?zidinysid", MySqlDbType.Int32).Value = darbuotojas.fk_ZIDINYSid;
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
        public DarbuotojasEditViewModel getDarbuotojas(int id)
        {
            DarbuotojasEditViewModel darbuotojas = new DarbuotojasEditViewModel();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "darbuotojas where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                darbuotojas.id = Convert.ToInt32(item["id"]);
                darbuotojas.asmens_kodas = Convert.ToInt32(item["asmens_kodas"]);
                darbuotojas.vardas = Convert.ToString(item["vardas"]);
                darbuotojas.pavarde = Convert.ToString(item["pavarde"]);
                darbuotojas.telefono_numeris = Convert.ToString(item["telefono_numeris"]);
                darbuotojas.alga = Convert.ToSingle(item["alga"]);
                darbuotojas.fk_IMONEid = Convert.ToInt32(item["fk_IMONEid"]);
                darbuotojas.fk_ZIDINYSid = Convert.ToInt32(item["fk_ZIDINYSid"]);

            }
            return darbuotojas;
        }

        public void deleteDarbuotojas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM darbuotojas where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}