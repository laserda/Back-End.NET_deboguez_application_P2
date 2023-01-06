namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface IProduitService
    {
        Produit[] GetTousLesProduits();
        Produit GetProduitParId(int id);
        void MetAJourLesQuantitesDuPanier(Panier panier);
    }
}
