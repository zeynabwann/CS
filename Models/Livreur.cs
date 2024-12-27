namespace Models.Livreur
{
    using Models.Livraison;
    public class Livreur
{
    public int IdLivreur { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Telephone { get; set; }
    public ICollection<Livraison> Livraisons { get; set; }
}

}