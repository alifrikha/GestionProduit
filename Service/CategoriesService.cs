using GestionProduit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionProduit.Core;
using GestionProduit.AccesDonnee;
using GestionProduit.Core.Service;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace GestionProduit.Core.Service
{
    public class CategoriesService
    {
        public static void SaisieCategorie()
        {
            CategoriesRepository categoriesRepository = new CategoriesRepository();
           
                Categories categorie = new Categories();
            do {
                Console.WriteLine("entrer le id de categorie");
                categorie.CategorieId = int.Parse(Console.ReadLine()); 
            } while(categorie.CategorieId > 0 && categorie.CategorieId !=null);
            Console.WriteLine("entrer le nom de categorie");
            categorie.CategorieNom = Console.ReadLine();
            categoriesRepository.AjouterCategorie(categorie);


        }
    }
}
