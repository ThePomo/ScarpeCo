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
        prodottoEsistente.Prezzo = modificato.Prezzo;
        prodottoEsistente.Descrizione = modificato.Descrizione;
        prodottoEsistente.ImmagineCopertina = modificato.ImmagineCopertina;

        return RedirectToAction("Index");
    }
}