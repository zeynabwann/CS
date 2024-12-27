namespace Models.CommandeProduit
{ 
    using Models.Commande;
    using Models.Produit;

    public class CommandeProduit
{
    public int IdCommande { get; set; }
    public Commande Commande { get; set; }

    public int IdProduit { get; set; }
    public Produit Produit { get; set; }

    public int Quantite { get; set; }
}

}