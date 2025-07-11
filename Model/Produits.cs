using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProduit.Model
{
    public class Produits
    {
        public int ProduitId { get; set; }
        public string ProduitNom { get; set; }
        public  string ProduitDesc { get; set; }
        public decimal ProduitPrix { get; set; }
        public int Quantite { get; set; }
        public int SeuilMin { get; set; }
        public int CategorieId { get; set; }
        public int FournisseurId { get; set; }
    }
}
