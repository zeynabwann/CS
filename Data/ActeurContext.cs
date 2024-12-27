using Microsoft.EntityFrameworkCore;
using Models.Client;
using Models.Commande;
using Models.Produit;
using Models.Paiement;

using Models.Livreur;
using Models.CommandeProduit;
using Models.Livraison;

namespace Data.ActeurContext
{
    public class ActeurContext : DbContext
    {
        public ActeurContext(DbContextOptions<ActeurContext> options) : base(options) { }

        public DbSet<HttpClient> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<CommandeProduit> CommandesProduits { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
        public DbSet<Livreur> Livreurs { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Commande>()
            .HasOne(c => c.Client)       
            .WithMany(cl => cl.Commandes) 
            .HasForeignKey(c => c.Client); 

        
 
        modelBuilder.Entity<Livraison>()
            .HasOne(l => l.Livreur)     
            .WithMany(l => l.Livraisons) 
            .HasForeignKey(l => l.IdLivreur); 

        modelBuilder.Entity<Commande>()
            .HasOne(c => c.Livraison)   
            .WithOne(l => l.Commande)   
            .HasForeignKey<Livraison>(l => l.Commande); 

        modelBuilder.Entity<CommandeProduit>()
            .HasKey(cp => new { cp.Commande, cp.Produit }); 

        modelBuilder.Entity<CommandeProduit>()
            .HasOne(cp => cp.Commande)       
            .WithMany(c => c.CommandeProduits) 
            .HasForeignKey(cp => cp.IdCommande);

        modelBuilder.Entity<CommandeProduit>()
            .HasOne(cp => cp.Produit)       
            .WithMany(p => p.CommandeProduits) 
            .HasForeignKey(cp => cp.IdProduit);
    }
        }
    }


