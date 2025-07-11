using GestionProduit.AccesDonnee;
using GestionProduit.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
namespace GestionProduit.Core
{
    public class ProduitsRepository
    {

        Produits produit = new Produits();
        
        //  fonction pour ajoutr
        public void AjouterProduit(Produits produit)
        {
            try
            {

                string query = @"insert into Produits(ProduitId,ProduitNom,ProduitDesc,ProduitPrix,Quantite,SeuilMin,CategorieId,FournisseurId) 
        values(@ProduitId,@ProduitNom,@ProduitDesc,@ProduitPrix,@Quantite,@SeuilMin,@categorieId,@FournisseurId);";


                using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProduitId", produit.ProduitId);
                    cmd.Parameters.AddWithValue("@ProduitNom", produit.ProduitNom);
                    cmd.Parameters.AddWithValue("@ProduitDesc", produit.ProduitDesc);
                    cmd.Parameters.AddWithValue("@ProduitPrix", produit.ProduitPrix);
                    cmd.Parameters.AddWithValue("@Quantite", produit.Quantite);
                    cmd.Parameters.AddWithValue("@SeuilMin", produit.SeuilMin);
                    cmd.Parameters.AddWithValue("@CategorieId", produit.CategorieId);
                    cmd.Parameters.AddWithValue("@FournisseurId", produit.FournisseurId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("produit est ajoute avec succes");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur " + ex);
            }
        }
        // fonction pour affichier
        public List<Produits> AffichierProduit()
        {
            List<Produits> produitsList = new List<Produits>();

            try
            {
                GestionDatabase database = new GestionDatabase();
                using (var conn = database.DatabaseConnexion())
                {
                    conn.Open();
                    string affichier_query = @"
                SELECT p.ProduitId, p.ProduitNom, p.ProduitDesc, p.ProduitPrix, 
                       p.Quantite, p.SeuilMin, p.CategorieId, p.FournisseurId
                FROM Produits p
                JOIN Categories c ON p.CategorieId = c.CategorieId
                JOIN Fournisseurs f ON p.FournisseurId = f.FournisseurId;";
                    MySqlCommand cmd = new MySqlCommand(affichier_query, conn);
                    var reader = cmd.ExecuteReader();
                    Console.WriteLine(" ********************list des produits*******************");
                    Console.WriteLine("ProduitId | ProduitNom |ProduitDesc | ProduitPrix |Quantite |SeuitlMin |CategorieId |FournisseurId");
                    Console.WriteLine();
                    while (reader.Read())
                    {

                        Console.WriteLine($"{reader["ProduitId"]} | {reader["ProduitNom"]} | {reader["ProduitDesc"]} | {reader["ProduitPrix"]} | {reader["Quantite"]} | {reader["SeuilMin"]} | {reader["CategorieId"]} | {reader["FournisseurId"]}");
                    }



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur " + ex);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
            return produitsList;

        }
        //  fonction pour affichier par categorie
        public void AffichierProduitParCategorie()
        {
            try
            {
                int categorie_id;
                Console.WriteLine("entrer le id de categorie");
                categorie_id = int.Parse(Console.ReadLine());
                GestionDatabase database = new GestionDatabase();
                using (var conn = database.DatabaseConnexion())
                {
                    conn.Open();
                    string Query = @"
                SELECT p.ProduitId, p.ProduitNom, p.ProduitDesc, p.ProduitPrix, 
                       p.Quantite, p.SeuilMin, p.CategorieId, p.FournisseurId
                FROM Produits p
                JOIN Categories c ON p.CategorieId = c.CategorieId
                JOIN Fournisseurs f ON p.FournisseurId = f.FournisseurId
                  where p.CategorieId =@categorie_id;";
                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@categorie_id", categorie_id);
                    var reader = cmd.ExecuteReader();
                    Console.WriteLine($"******list des produits de la categorie {categorie_id}********");
                    Console.WriteLine("ProduitId | ProduitNom |ProduitDesc | ProduitPrix |Quantite |SeuilMin |CategorieId |FournisseurId");
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ProduitId"]} | {reader["ProduitNom"]} | {reader["ProduitDesc"]} | {reader["ProduitPrix"]} | {reader["Quantite"]} | {reader["SeuilMin"]} | {reader["CategorieId"]} | {reader["FournisseurId"]}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur" + ex);
            }
        }
        //  fonction pour modifier le produit
        public void ModifierProduit()
        {
            try
            {

                Console.WriteLine("entrer le id de produit a modifier");
                int produit_id = int.Parse(Console.ReadLine());

                Console.WriteLine("entrer le nouveau nom de produit");
                string produit_nom = Console.ReadLine();
                Console.WriteLine("entrer la  description de produit");
                string produit_desc = Console.ReadLine();
                Console.WriteLine("entrer le nouveau prix de produit");
                decimal produit_prix = decimal.Parse(Console.ReadLine());
                Console.WriteLine("entrer la nouvelle quantite des produit");
                int quantite = int.Parse(Console.ReadLine());
                Console.WriteLine("entrer le nouveau seuil min des produit");
                int seuil_min = int.Parse(Console.ReadLine());
                Console.WriteLine("entrer le nouveau id de categorie");
                int categorie_id = int.Parse(Console.ReadLine());
                Console.WriteLine("entrer le nouveau id de fournisseur");
                int fournisseur_id = int.Parse(Console.ReadLine());
                string query = @"UPDATE Produits SET 
                                        ProduitNom = @produit_nom, 
                                     ProduitDesc = @produit_desc, 
                                     ProduitPrix = @produit_prix, 
                                     Quantite = @quantite, 
                                     SeuilMin = @seuil_min, 
                                     CategorieId = @categorie_id, 
                                     FournisseurId = @fournisseur_id 
                                     WHERE ProduitId = @produit_id;";

                using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@produit_id", produit_id);
                    cmd.Parameters.AddWithValue("@produit_nom", produit_nom);
                    cmd.Parameters.AddWithValue("@produit_desc", produit_desc);
                    cmd.Parameters.AddWithValue("@produit_prix", produit_prix);
                    cmd.Parameters.AddWithValue("@quantite", quantite);
                    cmd.Parameters.AddWithValue("@seuil_min", seuil_min);
                    cmd.Parameters.AddWithValue("@categorie_id", categorie_id);
                    cmd.Parameters.AddWithValue("@fournisseur_id", fournisseur_id);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Produit modifié avec succès.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur" + ex);
            }
        }

        // fonction pour supprimer le produit
        public void SupprimerProduit()
        {
            try
            {
                Console.WriteLine("enter le id de produit a supprimer");
                int produitIdSupprimer = int.Parse(Console.ReadLine());
                string query_supprimer = "delete from Produits where ProduitId=@produitIdSupprimer";


                using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query_supprimer, conn);
                    cmd.Parameters.AddWithValue("@produitIdSupprimer", produitIdSupprimer);
                    cmd.ExecuteNonQuery();

                }
                Console.WriteLine("produit est supprime avec succes");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur " + ex);
            }
        }
        //  fonction pour recherche a produit
        public void RechercheProduit()
        {
            Console.WriteLine("entrer le nom de produit");
            string NomProduit = Console.ReadLine();


            using (MySqlConnection conn = new MySqlConnection(GestionDatabase.connectionString))
            {
                conn.Open();
                string queryRecherche = "select * from Produits where ProduitNom like @NomProduit;";
                MySqlCommand cmd = new MySqlCommand(queryRecherche, conn);
                cmd.Parameters.AddWithValue("@NomProduit", NomProduit);
                var reader = cmd.ExecuteReader();
                Console.WriteLine("ProduitId | ProduitNom |ProduitDesc | ProduitPrix |Quantite |SeuilMin |CategorieId |FournisseurId");
                
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProduitId"]} | {reader["ProduitNom"]} | {reader["ProduitDesc"]} | {reader["ProduitPrix"]} | {reader["Quantite"]} | {reader["SeuilMin"]} | {reader["CategorieId"]} | {reader["FournisseurId"]}");
                }
            }

        }


    }
}




