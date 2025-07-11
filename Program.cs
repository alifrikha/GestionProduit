using CsvHelper;
using GestionProduit.AccesDonnee;
using GestionProduit.Core;
using GestionProduit.Core.Service;
using GestionProduit.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace GestionProduit
{

    public class Program
    {
     

        static void Main(string[] args)
        {
            

            CategoriesRepository categoriesRepository = new CategoriesRepository();
            FournisseursRepository fournisseursRepository = new FournisseursRepository();
            ProduitsRepository produitsRepository = new ProduitsRepository();
            Produitservice produitservice = new Produitservice();
            Alerte alerte = new Alerte();
            int choix;
            while (true)
            {

                Console.WriteLine("voici le menu de chois ");
                Console.WriteLine("********menu*******");
                Console.WriteLine(" entrer '1' pour ajouter un produit");
                Console.WriteLine(" entrer '2' pour affichier les produit");
                Console.WriteLine("entrer '3' pour affichier le produit ");
                Console.WriteLine(" entrer '4' pour affichier par categorie les produit");
                Console.WriteLine(" entrer '5' pour modifier un produit");
                Console.WriteLine(" entrer '6' pour supprimer un produit");
                Console.WriteLine(" entrer '7' pour ajouter un fournisseur");
                Console.WriteLine(" entrer '8' pour modifier un fournisseur");
                Console.WriteLine(" entrer '9' pour supprimer un fournisseur");
                Console.WriteLine(" entrer '10' pour ajouter une categorie");
                Console.WriteLine(" entrer '11' pour modifier une categorie");
                Console.WriteLine(" entrer '12' pour supprimer un categorie");
                Console.WriteLine("entrer '13' pour affichier le somme de prix de tous produits");
                Console.WriteLine("entrer'14'pour mettre le tableau de produit sous forme de csv");
                Console.WriteLine("entrer votre choix");
                choix = int.Parse(Console.ReadLine());

                

                switch (choix)
                {

                    case 1:
                        Produitservice.SaisieProduit();
                       
                        break;
                    case 2:
                        produitsRepository.AffichierProduit();
                        alerte.AlerteAutomatique();
                        break;
                    case 3:
                        produitsRepository.RechercheProduit();

                        break;
                    case 4:
                        produitsRepository.AffichierProduitParCategorie();
                        break;
                    case 5:
                        produitsRepository.ModifierProduit();
                        break;
                    case 6:
                        produitsRepository.SupprimerProduit();

                        break;
                    case 7:
                        FournisseursService.SaisieFournisseur();
                        break; 
                    case 8:
                        fournisseursRepository.ModifierFournisseur();
                        break;
                    case 9:
                        fournisseursRepository.SupprimerFournisseur();
                        break;
                    case 10:
                        CategoriesService.SaisieCategorie();

                        break;
                    case 11:
                        categoriesRepository.ModifierCategorie();
                        break;
                    case 12:
                        categoriesRepository.SupprimerCategorie();
                        break;
                    case 13:
                        Console.WriteLine("totale = " + Produitservice.SommePrix());
                        break;
                    case 14:
                       List<Produits> produitsList = produitsRepository.AffichierProduit();
        //                var produitsList = new List<Produits>
        //{
        //    new Produits
        //    {
        //        ProduitId = 1,
        //        ProduitNom = "bmw",
        //        ProduitDesc = "car",v
        //        ProduitPrix = 350000,
        //        Quantite = 5,
        //        SeuilMin = 5,
        //        CategorieId = 14,
        //        FournisseurId = 25
        //    }
            
        //};
                        
                        string  filePath = "produits.csv";
                        CsvFileService.ExporterProduitCsv(  produitsList,  filePath);

                        break;
                    default:
                        Console.WriteLine("choix invalide , veuillez reessayer");
                        break;

                }

                Console.WriteLine("est ce que vous voulez a repeter (saisir 'o' or 'O' pour oui ,'n' or 'N' pour non) ");
                char ansewr = char.Parse(Console.ReadLine());
                if (ansewr == 'n' || ansewr == 'N')
                    break;




            }

        }

      

    }

    }



        
        
        














    



