namespace Models.Produit
{
    using Models.CommandeProduit;
    public class Produit
{
    public int IdProduit { get; set; }
    public string Libelle { get; set; }
    public int QuantiteEnStock { get; set; }
    public float PrixUnitaire { get; set; }
    public int QuantiteSeuil { get; set; }
    public string Images { get; set; }

    public ICollection<CommandeProduit> CommandeProduits { get; set; }
}

}