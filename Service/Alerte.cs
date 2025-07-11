using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProduit.Core.Service
{
    public class Alerte
    {

        public void AlerteAutomatique()
        {
            try
            {
              

                using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
                {
                    conn.Open();
                    string query = "select * from Produits where Quantite < SeuilMin ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("attention !!... faible stock ");
                        Console.WriteLine($"{reader["ProduitNom"]} :quantite = {reader["Quantite"]} est inferieur a seuil minimal {reader["SeuilMin"]}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error " + ex);
            }

        }
    }
}
