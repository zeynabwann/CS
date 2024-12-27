using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.ActeurContext;
using Models.Client;
using Models.Commande;
namespace Client.Controllers
{
    public class ClientController : Controller
    {
        private readonly ActeurContext _context;

        public ClientController(ActeurContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var clients = await _context.Clients.ToListAsync();
            return View(clients);
        }

        public async Task<IActionResult> Client(int id)
        {
            var client = await _context.Clients
                .Include(c => c.Commandes)   
                .FirstOrDefaultAsync(m => m.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        public async Task<IActionResult> Commandes(int id)
        {
            var commandes = await _context.Commandes
                .Where(c => c.IdClient == id)
                .Include(c => c.Livreur)
                .Include(c => c.CommandeProduits)
                .Include(c => c.Livraison)
                .Include(c => c.Paiements)
                .ToListAsync();

            return View(commandes);
        }

        public async Task<IActionResult> CreerCommande(Commande commande)
        {
             if (ModelState.IsValid)
            {
                commande.ClientId = GetCurrentClientId();  
                _context.Commandes.Add(commande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  
            }
            return View(commande);
        }

 public async Task<IActionResult> SuiviCommande(int id)
        {
            var commande = await _context.Commandes
                .Include(c => c.Livraison)
                .Include(c => c.Paiement)   
                .FirstOrDefaultAsync(c => c.Id == id && c.ClientId == GetCurrentClientId());

            if (commande == null)
            {
                return NotFound("non trouvé");
            }

            return View(commande);  
        }

        public async Task<IActionResult> EnregistrerPaiement(int commandeId, Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                paiement.CommandeId = commandeId;  
                _context.Paiement.Add(paiement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SuiviCommande), new { id = commandeId });
            }
            return View( new { id = commandeId });  
        }

         public async Task<IActionResult> DeclarerCommandeReçue(int id)
        {
            var commande = await _context.Commandes
                .Include(c => c.Livraison)
                .FirstOrDefaultAsync(c => c.Id == id && c.ClientId == GetCurrentClientId());

            if (commande == null)
            {
                return NotFound();
            }

            commande.Livraison.Status = "Reçu";  
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(SuiviCommande), new { id = id });
        }


        private object GetCurrentClientId()
        {
            throw new NotImplementedException();
        }
    }
}

    
