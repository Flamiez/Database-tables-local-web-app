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
    public class AdresasRepository
    {
        public List<adresas> getAdresai()
        {
            List<adresas> adresai = new List<adresas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "adresas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach(DataRow item in dt.Rows)
            {
                adresai.Add(new adresas
                {
                    id_ADRESAS = Convert.ToInt32(item["id_ADRESAS"]),
                    fk_PIRKEJASid_PIRKEJAS = Convert.ToInt32(item["fk_PIRKEJASid_PIRKEJAS"]),
                    miestas = Convert.ToString(item["adresas"]),
                    pasto_kodas = Convert.ToInt32(item["pasto_kodas"])
                    
                }) ;
            }
            return adresai;
        }
        public List<AdresasViewModel> getPirkejoAdresai(int pirkejoID)
        {
            List<AdresasViewModel> adresai = new List<AdresasViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "adresas where fk_PIRKEJASid_PIRKEJAS="+pirkejoID;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                adresai.Add(new AdresasViewModel
                {
                    id_ADRESAS = Convert.ToInt32(item["id_ADRESAS"]),
                    fk_PIRKEJASid_PIRKEJAS = Convert.ToInt32(item["fk_PIRKEJASid_PIRKEJAS"]),
                    miestas = Convert.ToString(item["adresas"]),
                    pasto_kodas = Convert.ToInt32(item["pasto_kodas"]),
                    kiekis = Convert.ToInt32(item["kiekis"])

                }) ;
            }
            return adresai;
        }
        public bool deleteAdresas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM a USING adresas as a where a.id_ADRESAS=?fkid";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fkid", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();


            return true;
        }

        public bool insertAdresas(AdresasViewModel adresasViewModel)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO adresas(fk_PIRKEJASid_PIRKEJAS,id_ADRESAS,adresas,pasto_kodas)
                                        VALUES(
										?fkpirkejas,
										?idadresas,
										?miestas,
										?pkodas
										)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fkpirkejas", MySqlDbType.Int32).Value = adresasViewModel.fk_PIRKEJASid_PIRKEJAS;
            mySqlCommand.Parameters.Add("?idadresas", MySqlDbType.Int32).Value = adresasViewModel.id_ADRESAS;
            mySqlCommand.Parameters.Add("?miestas", MySqlDbType.String).Value = adresasViewModel.miestas;
            mySqlCommand.Parameters.Add("?pkodas", MySqlDbType.Int32).Value = adresasViewModel.pasto_kodas;

            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
    }
}