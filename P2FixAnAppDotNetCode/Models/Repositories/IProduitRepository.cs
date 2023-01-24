namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProduitRepository
    {
        Produit[] GetTousLesProduits();
        Produit GetUnProduits(int id);
        void MetAJourLaQuantiteDunProduit(int idProduit, int quantiteASupprimer);
    }
}
