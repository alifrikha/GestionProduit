using GestionProduit;
using GestionProduit.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProduit.Core
{

    //CategorieRepository
    public class CategoriesRepository
    {

        Categories categorie = new Categories();
        
        //fonction pour ajouter une categorie 
        public void AjouterCategorie(Categories categorie)
        {
            try
            {
                

                string query = @"insert into Categories(CategorieId,CategorieNom) values (@CategorieId ,@CategorieNom)";

  
                using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CategorieId", categorie.CategorieId);
                    cmd.Parameters.AddWithValue("@CategorieNom", categorie.CategorieNom);
                    cmd.ExecuteNonQuery();

                }
                Console.WriteLine("categorie est ajoutee avec succes");
            }
            catch (Exception ex)
            {

                Console.WriteLine("data error" + ex);

            }
        }

        //fonction pour modifier une categorie
        public void ModifierCategorie()
        {
            try
            {
                Console.WriteLine("entrer le id de categorie a modifier");
                int categorie_id = int.Parse(Console.ReadLine());
                Console.WriteLine("entrer le noveau  nom de categorie ");
                string categorie_nom = Console.ReadLine();
                string query = @"update Catgories set
                            CategorieNom = @categorie_nom 
                             where CategorieId = @categorie_id;";

                
                using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@categorie_id", categorie_id);
                    cmd.Parameters.AddWithValue("@categorie_nom", categorie_nom);
                    cmd.ExecuteNonQuery();
                }
                 Console.WriteLine("categorie est modifie avec succes");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error " + ex);
            }
        }
        //fonction pour supprimer categorie

        public void SupprimerCategorie()
        {
            try
            {
                Console.WriteLine("entrer le id de categorie a supprimer");
                int categorie_id = int.Parse(Console.ReadLine());

                string query = "delete from Categories where CategorieId =@categorie_id";

                
                using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@categorie_id", categorie_id);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("categorie est supprime avec succes ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur" + ex);
            }
        }
    }
}
    