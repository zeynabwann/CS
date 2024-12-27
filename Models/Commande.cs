namespace Models.Commande
{
    using Models.Client;
    using Models.CommandeProduit;
    using Models.Livraison;
    using Models.Facture;
    using Models.Paiement;
    public class Commande
{
    public int IdCommande { get; set; }
    public DateTime DateCommande { get; set; }
    public float MontantTotal { get; set; }
    public string? Statut { get; set; }

    public required Client Client { get; set; }
    
    public required ICollection<CommandeProduit> CommandeProduits { get; set; }
    public Livraison Livraison { get; set; }
    public Facture Facture { get; set; }
    public Paiement Paiement { get; set; }
        public object Livreur { get; internal set; }
        public object ClientId { get; internal set; }
    }

}