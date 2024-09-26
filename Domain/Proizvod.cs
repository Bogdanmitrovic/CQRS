namespace CQRS.Domain;

public class Proizvod
{
    public Guid Id { get; set; }
    public string Naziv { get; set; } = default!;
    public string Opis { get; set; } = default!;
    public decimal Cena { get; set; }
    private Proizvod() { }
    public Proizvod(string naziv, string opis, decimal cena)
    {
        Id = Guid.NewGuid();
        Naziv = naziv;
        Opis = opis;
        Cena = cena;
    }
}