using System.Collections.Generic;

public class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Prezzo { get; set; }
    public string Descrizione { get; set; }
    public string ImmagineCopertina { get; set; }
    public List<string> ImmaginiAggiuntive { get; set; }
}