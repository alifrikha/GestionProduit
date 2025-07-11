using GestionProduit;
using GestionProduit.Core;
using GestionProduit.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace GestionProduit.AccesDonnee
{
    public class FournisseursRepository
    { 
        Fournisseurs fournisseur =new Fournisseurs();
    
         
        //AjouuterFournisseur
        public void AjouterFournisseur(Fournisseurs fournisseur)
        {
            try
            {
               

                string query = @"insert into Fournisseurs(FournisseurId,FournisseurNom)values(@FournisseurId,@FournisseurNom);";

               
                using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FournisseurId", fournisseur.FournisseurId);
                    cmd.Parameters.AddWithValue("@FournisseurNom", fournisseur.FournisseurNom);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("fournisseur est ajoute avec succes");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error " + ex);
            }
        }
        //fonction pour modifier fournisseur
       public  void ModifierFournisseur()
        {
            try
            {
                Console.WriteLine("entrer le id de fournisseur a modifier");
                int fournisseur_id = int.Parse(Console.ReadLine());
                Console.WriteLine("entrer le nouveau nom de fournisseur");
                string fournisseur_nom = Console.ReadLine();
                string query = @"update Fournisseurs set
                            FournisseurNom = @fournisseur_nom 
                             where FournisseurId = @fournisseur_id;";

                
                using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fournisseur_id", fournisseur_id);
                    cmd.Parameters.AddWithValue("@fournisseur_nom", fournisseur_nom);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("fournisseur est modifie avec succes");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error " + ex);
            }
        }

        //fonction pour supprimer fournisseur
        public void SupprimerFournisseur()
        {
            try
            {
                Console.WriteLine("entrer le id de fournisseur a supprimer");
                int fournisseurId = int.Parse(Console.ReadLine());
                string query = @"delete from Fournisseurs where FournisseurId =@fournisseurId";

                
                using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fournisseurId", fournisseurId);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("fournisseur est supprime avec succes");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur" + ex);
            }
        }

    }
}
