using GestionProduit.AccesDonnee;
using GestionProduit.Core;
using GestionProduit.Core.Service;
using GestionProduit.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionProduit.Core.Service
{
    public class FournisseursService
    {
        public static void SaisieFournisseur()
        {
            FournisseursRepository fournisseursRepository = new FournisseursRepository();
            Fournisseurs fournisseur = new Fournisseurs();
            do {
                Console.WriteLine("entrer le id de fournisseur");
                fournisseur.FournisseurId = int.Parse(Console.ReadLine());
            } while ( fournisseur.FournisseurId > 0  && fournisseur.FournisseurId != null);
            Console.WriteLine("enter le nom de fournisseur");
            fournisseur.FournisseurNom = Console.ReadLine();
            fournisseursRepository.AjouterFournisseur(fournisseur);

        }
    }
}
