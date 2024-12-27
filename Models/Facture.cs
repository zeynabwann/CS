namespace Models.Facture
{
    using Models.Commande;
    public class Facture
{
    public int IdFacture { get; set; }
    public DateTime DateFacture { get; set; }
    public float Montant { get; set; }
    public int IdCommande { get; set; }
    public Commande Commande { get; set; }
}

}