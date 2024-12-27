namespace Models.Paiement
{
    using Models.Commande;
    public class Paiement
{
    public int IdPaiement { get; set; }
    public string TypePaiement { get; set; } 
    public float Montant { get; set; }
    public string Reference { get; set; }
    public DateTime DatePaiement { get; set; }
    public int IdCommande { get; set; }
    public Commande Commande { get; set; }
}

}