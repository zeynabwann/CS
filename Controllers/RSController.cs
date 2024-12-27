using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.ActeurContext;
using Models.Commande;
using Models.Produit;
using Models.Livreur;
using Models.Livraison;
using System.Linq;

namespace RS.Controllers
{
    public class RsController : Controller
    {
        private readonly ActeurContext _context;

        public RsController(ActeurContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var commandes = await _context.Commandes
                .Include(c => c.Client)
                .Include(c => c.Livraison)
                .Include(c => c.Livreur)
                .ToListAsync();

            return View(commandes);
        }

      public async Task<IActionResult> EnregistrerProduit(Produit produit)
{
    if (ModelState.IsValid) 
    {
        _context.Produits.Add(produit);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index)); 
    }
    return View(produit);
}


        private object GetCurrentClientId()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> PrepareColis(int id)
        {
            var commande = await _context.Commandes
                .Include(c => c.CommandeProduits)
                .ThenInclude(cp => cp.Produit)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (commande == null)
            {
                return NotFound();
            }

            foreach (var cp in commande.CommandeProduits)
            {
                cp.Produit.QuantiteEnStock -= cp.Quantite;
            }

            commande.Status = "En préparation";  
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PlanifierLivraison(int id)
        {
            var commande = await _context.Commandes
                .Include(c => c.Livraison)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (commande == null)
            {
                return NotFound();
            }

            commande.Livraison.Status = "Planifiée";  
            commande.Livraison.DateLivraison = DateTime.Now; 

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> TransfertCommandeLivree(int id)
        {
            var commande = await _context.Commandes
                .Include(c => c.Livraison)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (commande == null)
            {
                return NotFound();
            }

            commande.Livraison.Status = "Livrée";  
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
