namespace Models.Livraison
{
   using Models.Commande;
   using Models.Livreur;

    public class Livraison
{
    public int IdLivraison { get; set; }
    public DateTime DateLivraison { get; set; }
    public string AdresseLivraison { get; set; }
    public int IdCommande { get; set; }
    public Commande Commande { get; set; }

    public int IdLivreur { get; set; }
    public Livreur Livreur { get; set; }
}

}