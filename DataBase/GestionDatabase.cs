using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionProduit.AccesDonnee;
using GestionProduit.Core;
using GestionProduit.Core.Service;
using GestionProduit.Model;
using System.Security.Cryptography.X509Certificates;


namespace GestionProduit.Core
{
    public class GestionDatabase

    {

        // public GestionDatabase database;

        
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public MySqlConnection DatabaseConnexion()
        {
            try
            {

                return new MySqlConnection(connectionString);

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur " + ex.Message);
                return null;
            }
        }


        //fonction pour existance de tableau base de donnee  
        public MySqlConnection ConnexionSansBase()
        {
            string connStr = "server=localhost;user=root;password=ali123frikhaA;";
            return new MySqlConnection(connStr);
        }

        public void BaseDeDonneeTableau()
        {
            using (var conn = ConnexionSansBase())
            {
                conn.Open();
                string dbNom = "gestionproduit";

                string query = "SELECT schema_name FROM information_schema.SCHEMATA WHERE schema_name = @dbNom;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dbNom", dbNom);
                var result = cmd.ExecuteScalar();
                if (result == null)
                {
                    Console.WriteLine("base de donnee n existe pas ");
                    string createQuery = $"create database {dbNom};";
                    MySqlCommand createCmd = new MySqlCommand(createQuery, conn);
                    createCmd.ExecuteNonQuery();
                    Console.WriteLine("le base de donnee est cree avec succes");
                }
                else
                    Console.WriteLine("base de donnee est existe");
            }
        }
    
        

            //fonction pour existence de tableau produit
                public void ProduitTableau()
                {
                    using (var conn = DatabaseConnexion())
                    {
                        conn.Open();
                        string query = "show tables like 'Produits';";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        var result = cmd.ExecuteScalar();
                                  if (result == null)
                        {
                            Console.WriteLine("tableau de produits n existe pas ");
                            string createQuery = @"create table Produits ( ProduitId int  primary key not null,
                                    ProduitNom varchar(100),
                                    ProduitDesc text,
                                    ProduitPrix decimal(10,2),
                                    Quantite int ,
                                    SeuilMin int ,
                                    CategorieId int, 
                                    FournisseurId int,
                                    foreign key (CategorieId) references Categories(CategorieId) ,
                                    foreign key (FournisseurId) references Fournisseurs(FournisseurId)

                                    );";

                            MySqlCommand createCmd = new MySqlCommand(createQuery, conn);
                            createCmd.ExecuteNonQuery();
                            Console.WriteLine("le tableau de produit est cree avec succes");
                        }
                        else
                            Console.WriteLine("table produit est existe");

                    }

                }
        
        //fonction pour existance de la tableau fournisseur
        
        public void FournisseurTableau()
        {
            using (var conn =DatabaseConnexion())
            {
                conn.Open();
                string query = "show tables like 'Fournisseurs';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var result = cmd.ExecuteScalar();
                if (result == null)
                {
                    Console.WriteLine("tableau de fournisseur n existe pas");
                    string createQuery = @"create table Fournisseurs (FournisseurId int primary key not null,
                    FournisseurNom varchar(100) not null
                    );";
                    MySqlCommand createCmd = new MySqlCommand(createQuery, conn);
                    createCmd.ExecuteNonQuery();
                    Console.WriteLine("le tableau de fournisseur est cree avec succes");
                }
                else
                    Console.WriteLine("le tableau fournisseur est existe ");
            }



        }

        //fonction pour existance de la tableau categorie


        public void CategorieTableau()
        {
            using (var conn = DatabaseConnexion())
            {
                conn.Open();
                string query = "SHOW TABLES LIKE 'Categories';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var result = cmd.ExecuteScalar();
                if (result == null)
                {
                    Console.WriteLine("tableau de categorie n existe pas");
                    string createQuery = @"create table Categories ( CategorieId INT PRIMARY KEY NOT NULL,
                    CategorieNom varchar(100) not null
                    );";
                    MySqlCommand createCmd = new MySqlCommand(createQuery, conn);
                    createCmd.ExecuteNonQuery();
                    Console.WriteLine("le tableau de categorie est cree avec succes");
                }
                else
                    Console.WriteLine("le tableau categorie est existe ");
            }



        }

    }
}