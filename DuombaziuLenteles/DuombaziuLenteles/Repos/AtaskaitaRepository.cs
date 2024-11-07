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
    public class AtaskaitaRepository
    {
        public List<AtaskaiktaViewModel> getAtaskaitaSutartciu(int nuo, int iki)
        {
            List<AtaskaiktaViewModel> imones = new List<AtaskaiktaViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT
                                imone.pavadinimas,
                                zidinys.medziaga,
                                ROUND(AVG((zidinys.ilgis*zidinys.plotis*zidinys.aukstis)/1000)) as Vidutinis_židinių_tūris_dm3,
                                COUNT(if(darbuotojas.alga >= ?nuo and darbuotojas.alga <= ?iki,1,null)) as ct,
                                sum(if(darbuotojas.alga >= ?nuo and darbuotojas.alga <= ?iki,darbuotojas.alga,null)) as sm,
                                viso.visas,
                                visoviso.visasvisas
                                FROM imone
                                LEFT JOIN zidinys ON zidinys.medziaga

                                LEFT JOIN(
                                          SELECT imone.pavadinimas as pavadinimas,
                                          SUM(if(darbuotojas.alga >= ?nuo and darbuotojas.alga <= ?iki,darbuotojas.alga,null)) as visas
                                          FROM imone
                                          LEFT JOIN zidinys ON zidinys.medziaga
                                          RIGHT JOIN darbuotojas ON zidinys.id = darbuotojas.fk_ZIDINYSid AND darbuotojas.fk_IMONEid = imone.id
                                          GROUP BY imone.pavadinimas
                                         )as viso ON viso.pavadinimas = imone.pavadinimas
                                LEFT JOIN(
                                          SELECT
                                          SUM(if(darbuotojas.alga >= ?nuo and darbuotojas.alga <= ?iki,darbuotojas.alga,null)) as visasvisas
                                          FROM imone
                                          LEFT JOIN zidinys ON zidinys.medziaga
                                          RIGHT JOIN darbuotojas ON zidinys.id = darbuotojas.fk_ZIDINYSid AND darbuotojas.fk_IMONEid = imone.id
                                         )as visoviso ON visasvisas>0
         
                                RIGHT JOIN darbuotojas ON zidinys.id = darbuotojas.fk_ZIDINYSid AND darbuotojas.fk_IMONEid = imone.id
                                GROUP BY imone.pavadinimas, zidinys.medziaga
                                HAVING(COUNT(if(darbuotojas.alga >= ?nuo and darbuotojas.alga <= ?iki,1,null)))>0
                                ORDER BY Pavadinimas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nuo", MySqlDbType.Int32).Value = nuo;
            mySqlCommand.Parameters.Add("?iki", MySqlDbType.Int32).Value = iki;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                imones.Add(new AtaskaiktaViewModel
                {
                    Imone = Convert.ToString(item["pavadinimas"]),
                    medziaga = Convert.ToString(item["medziaga"]),
                    DarbuotojuUzdirbusiuTarpSuma = Convert.ToInt32(item["sm"]),
                    DarbuotojuUzdirbusiuTarp = Convert.ToInt32(item["ct"]),
                    viso = Convert.ToInt32(item["visas"]),
                    visoviso = Convert.ToInt32(item["visasvisas"]),
                    VZidTuris = Convert.ToInt32(item["Vidutinis_židinių_tūris_dm3"])
                });
            }
            return imones;
        }
    }
}