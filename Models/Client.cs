namespace Models.Client
{
    using Models.Commande;  

    public class Client
    {
        public int IdClient { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Telephone { get; set; }
        public string? Adresse { get; set; }
        public float SoldeCompte { get; set; }

        public required ICollection<Commande> Commandes { get; set; }  
    }
}
