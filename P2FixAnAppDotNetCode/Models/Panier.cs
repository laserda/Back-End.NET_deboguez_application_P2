using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// La classe Panier
    /// </summary>
    public class Panier : IPanier
    {
        //Ajouter par Igor
        private static List<LignePanier> _lignesDuPanier;

        public Panier()
        {
            _lignesDuPanier = new List<LignePanier>();
        }

        /// <summary>
        /// Propriété en lecture seule pour affichage seulement
        /// </summary>
        public IEnumerable<LignePanier> Lignes => GetListeDesLignesDuPanier();

        /// <summary>
        /// Retour la liste des lignes du panier
        /// </summary>
        /// <returns></returns>
        private List<LignePanier> GetListeDesLignesDuPanier()
        {
            //return new List<LignePanier>();
            return _lignesDuPanier;
        }

        /// <summary>
        /// Ajoute un produit dans le panier ou incrémente sa quantité dans le panier si déjà présent
        /// </summary>//
        public void AjouterElement(Produit produit, int quantite)
        {
            // TODO implementer la méthode
            //Ajouter par Igor
            var rechercherProduit = _lignesDuPanier.FirstOrDefault(l => l.Produit.Id == produit.Id);
            if (rechercherProduit != null)
            {
                rechercherProduit.Quantite += quantite;
            }
            else
            {
                _lignesDuPanier.Add(new LignePanier
                {
                    Produit = produit,
                    Quantite = quantite
                });
            }
            

        }

        /// <summary>
        /// Supprimer un produit du panier
        /// </summary>
        public void SupprimerLigne(Produit produit) =>
            GetListeDesLignesDuPanier().RemoveAll(l => l.Produit.Id == produit.Id);

        /// <summary>
        /// Récupère la valeur totale du panier
        /// </summary>
        public double GetValeurTotale()
        {
            // TODO implementer la méthode
            //Ajouter par IGOR
            return _lignesDuPanier.Sum(l => l.Produit.Prix*l.Quantite);
        }

        /// <summary>
        /// Récupère la valeur moyenne du panier
        /// </summary>
        public double GetValeurMoyenne()
        {
            // TODO implementer la méthode
            //Ajouter par IGOR
            try
            {
                return _lignesDuPanier.Average(l => l.Produit.Prix*l.Quantite);
            }
            catch (Exception e)
            {
                return 0.0;
            }
            
        }

        /// <summary>
        /// Cherche un produit donné dans le panier et le retourne si trouvé
        /// </summary>
        public Produit TrouveProduitDansLesLignesDuPanier(int idProduit)
        {
            // TODO implementer la méthode
            return null;
        }

        /// <summary>
        /// Retourne une ligne de panier à partir de son indice
        /// </summary>
        public LignePanier GetLignePanierParIndice(int indice)
        {
            return Lignes.ToArray()[indice];
        }

        /// <summary>
        /// Vide un panier de tous ses produits
        /// </summary>
        public void Vider()
        {
            List<LignePanier> lignePaniers = GetListeDesLignesDuPanier();
            lignePaniers.Clear();
        }
    }

    public class LignePanier
    {
        public int CommandeLigneId { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }
    }
}
