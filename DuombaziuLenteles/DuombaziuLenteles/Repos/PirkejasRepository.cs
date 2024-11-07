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
    public class PirkejasRepository
    {
        public List<pirkejas> getPirkejai()
        {
            List<pirkejas> pirkejai = new List<pirkejas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "pirkejas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                pirkejai.Add(new pirkejas
                {
                    id_PIRKEJAS = Convert.ToInt32(item["id_PIRKEJAS"]),
                    asm_kodas = Convert.ToInt32(item["asm_kodas"]),
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    tel_numeris = Convert.ToString(item["tel_numeris"])

                });
            }
            return pirkejai;
        }
        public bool addPirkejas(pirkejas pirkejas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO " + Globals.dbPrefix + "pirkejas(id_PIRKEJAS,asm_kodas,vardas,pavarde,tel_numeris)VALUES(?asmid,?asmkod,?vardas,?pavarde,?tel);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?asmid", MySqlDbType.Int32).Value = pirkejas.id_PIRKEJAS;
                mySqlCommand.Parameters.Add("?asmkod", MySqlDbType.Int32).Value = pirkejas.asm_kodas;
                mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = pirkejas.vardas;
                mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = pirkejas.pavarde;
                mySqlCommand.Parameters.Add("?tel", MySqlDbType.VarChar).Value = pirkejas.tel_numeris;
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

        public bool updatePirkejas(pirkejas pirkejas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE " + Globals.dbPrefix + "pirkejas a SET a.id_PIRKEJAS=?asmid,a.vardas=?vardas,a.pavarde=?pavarde,a.tel_numeris=?tel WHERE a.asm_kodas=?asmkod";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?asmid", MySqlDbType.Int32).Value = pirkejas.id_PIRKEJAS;
                mySqlCommand.Parameters.Add("?asmkod", MySqlDbType.Int32).Value = pirkejas.asm_kodas;
                mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = pirkejas.vardas;
                mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = pirkejas.pavarde;
                mySqlCommand.Parameters.Add("?tel", MySqlDbType.VarChar).Value = pirkejas.tel_numeris;
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
        public pirkejas getPirkejas(int asmid)
        {
            pirkejas pirkejas = new pirkejas();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "pirkejas where id_PIRKEJAS=?asmid";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?asmid", MySqlDbType.VarChar).Value = asmid;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                pirkejas.id_PIRKEJAS = Convert.ToInt32(item["id_PIRKEJAS"]);
                pirkejas.asm_kodas = Convert.ToInt32(item["asm_kodas"]);
                pirkejas.vardas = Convert.ToString(item["vardas"]);
                pirkejas.pavarde = Convert.ToString(item["pavarde"]);
                pirkejas.tel_numeris = Convert.ToString(item["tel_numeris"]);

            }
            return pirkejas;
        }
        public int insertPirkejas(pirkejas pirkejas)
        {
            int insertedId = -1;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO " + Globals.dbPrefix + "pirkejas(id_PIRKEJAS,asm_kodas,vardas,pavarde,tel_numeris)VALUES(?id,?asmk,?vardas,?pavarde,?tel);";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?asmk", MySqlDbType.Int32).Value = pirkejas.asm_kodas;
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = pirkejas.id_PIRKEJAS;
            mySqlCommand.Parameters.Add("?tel", MySqlDbType.VarChar).Value = pirkejas.tel_numeris;
            mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = pirkejas.vardas;
            mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = pirkejas.pavarde;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            insertedId = Convert.ToInt32(mySqlCommand.LastInsertedId);
            return insertedId;
        }

        public void deletePirkejas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM " + Globals.dbPrefix + "pirkejas where id_PIRKEJAS=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }

}