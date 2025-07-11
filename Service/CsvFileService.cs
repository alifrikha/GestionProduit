using GestionProduit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace GestionProduit.Core.Service
{
    public class CsvFileService
    {
        public static void  ExporterProduitCsv( List<Produits>  produitsList, string  filePath)
        {
            

            if (produitsList == null)
            {
                Console.WriteLine(" La liste produitsList est NULL.");
                return;
            }

            Console.WriteLine($" produitsList contient {produitsList.Count} éléments.");

            if (produitsList.Count == 0)
            {
                Console.WriteLine(" La liste est vide (Count = 0).");
                return;
            }
            try
            {


                var csv = new StringBuilder();
                csv.AppendLine("ProduitId,ProduitNom,Produitdesc,Produitprix,Quantite,SeuilMin,CategorieId,FournisseurId");

                Console.WriteLine($"Nombre de produits à exporter : {produitsList.Count}");

                foreach (var produit in produitsList)
                {  Console.WriteLine("Début de la boucle foreach pour les produits");
                    
                    try
                    {

                        if (produit== null)
                        {
                            Console.WriteLine($"produitsList{produit} est NULL");
                        }



                        Console.WriteLine($"Produit : ID={produit.ProduitId}, Nom={produit.ProduitNom}");


                        string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",

                     produit.ProduitId,
                     EscapeCsv(produit.ProduitNom),
                     EscapeCsv(produit.ProduitDesc),
                     produit.ProduitPrix,
                     produit.Quantite,
                     produit.SeuilMin,
                     produit.CategorieId,
                     produit.FournisseurId

                     );
                        Console.WriteLine("produit.ProduitId: " + produit.ProduitId);

                        csv.AppendLine(line);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur dans la boucle foreach : " + ex.Message);
                    }
                }


                // Créer le dossier si nécessaire
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
                Console.WriteLine("Fichier CSV sauvegardé avec succès à: " + filePath);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'écriture du CSV : " + ex.Message);
            }
        }



        // mettre separateur
        public static string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value) ) return "";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

    }
}
