using GestionProduit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionProduit.Core;
using GestionProduit.AccesDonnee;
using GestionProduit.Core.Service;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace GestionProduit.Core.Service
{
    public class Produitservice
    {
     
        
        public static void SaisieProduit()
        {
         
            Produits produit = new Produits();
            ProduitsRepository produitsRepository = new ProduitsRepository();
            do
            {

              
                    Console.WriteLine("entrer le id de produit");
                    produit.ProduitId = int.Parse(Console.ReadLine());
              
                Console.WriteLine("entrer le nom de produit");
                produit.ProduitNom = Console.ReadLine();
                Console.WriteLine("entrer le description de produit");
                produit.ProduitDesc = Console.ReadLine();

                Console.WriteLine("entrer le prix de produit");
                produit.ProduitPrix = decimal.Parse(Console.ReadLine());



                Console.WriteLine("entrer le quantite des produit");
                produit.Quantite = int.Parse(Console.ReadLine());

                Console.WriteLine("entrer le seuil min des produit");
                produit.SeuilMin = int.Parse(Console.ReadLine());

                Console.WriteLine("entrer le id de categorie");
                produit.CategorieId = int.Parse(Console.ReadLine());


                Console.WriteLine("entrer le id de fournisseur");
                produit.FournisseurId = int.Parse(Console.ReadLine());
                break;

            } while (EstNonNull(produit) && EstPositive(produit));
            produitsRepository.AjouterProduit(produit);

        }
        public static bool EstNonNull(Produits produit)
        {
            return produit.ProduitId != null &&
                produit.ProduitNom != null &&
                produit.ProduitDesc != null &&
                produit.ProduitPrix != null &&
                   produit.Quantite != null &&
                   produit.SeuilMin != null &&
                   produit.CategorieId != null &&
                   produit.FournisseurId != null;

        }
        public static bool EstPositive(Produits produit)
        {
            return produit.ProduitId > 0 &&
                produit.ProduitPrix > 0 &&
                produit.Quantite > 0 &&
                produit.SeuilMin > 0 &&
                produit.FournisseurId > 0 &&
                produit.CategorieId > 0;
        }


        public static decimal SommePrix() {
            decimal total = 0;
          //  string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
            {
                
             
                conn.Open();
                string querySum = "select sum(ProduitPrix * Quantite) from Produits ;";
                MySqlCommand cmd = new MySqlCommand(querySum, conn);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value) {

                    total = Convert.ToDecimal(result);

                        }

            }
            return total;
        }

    }
}
