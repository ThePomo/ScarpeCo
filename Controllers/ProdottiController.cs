using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class ProdottiController : Controller
{
    public IActionResult Index()
    {
        List<Prodotto> prodotti = ProdottiRepository.GetProdotti();
        return View(prodotti);
    }

    public IActionResult Dettagli(int id)
    {
        Prodotto prodotto = ProdottiRepository.GetProdottoById(id);
        if (prodotto == null)
        {
            return NotFound();
        }
        return View(prodotto);
    }

    public IActionResult Modifica(int id)
    {
        Prodotto prodotto = ProdottiRepository.GetProdottoById(id);
        if (prodotto == null)
        {
            return NotFound();
        }
        return View(prodotto);
    }

    [HttpPost]
    public IActionResult SalvaModifica(Prodotto modificato)
    {
        Prodotto prodottoEsistente = ProdottiRepository.GetProdottoById(modificato.Id);
        if (prodottoEsistente == null)
        {
            return NotFound();
        }

        prodottoEsistente.Nome = modificato.Nome;
        prodottoEsistente.Prezzo = Math.Round(modificato.Prezzo, 2);
        prodottoEsistente.Descrizione = modificato.Descrizione;
        prodottoEsistente.ImmagineCopertina = modificato.ImmagineCopertina;

        return RedirectToAction("Index");
    }

    //  FUNZIONE PER AGGIUNGERE PRODOTTI

    
    public IActionResult Aggiungi()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SalvaNuovo(Prodotto nuovoProdotto, List<string> ImmaginiAggiuntive)
    {
        if (!ModelState.IsValid)
        {
            return View("Aggiungi", nuovoProdotto);
        }

        
        nuovoProdotto.Id = ProdottiRepository.GetProdotti().Count + 1;

        if (ImmaginiAggiuntive != null && ImmaginiAggiuntive.Count >= 2)
        {
            nuovoProdotto.ImmaginiAggiuntive = new List<string> { ImmaginiAggiuntive[0], ImmaginiAggiuntive[1] };
        }
        else
        {
            nuovoProdotto.ImmaginiAggiuntive = new List<string>(); 
        }

        
        ProdottiRepository.AggiungiProdotto(nuovoProdotto);

        return RedirectToAction("Index");
    }
}