using System;
using System.Collections.Generic;

// Definire tip inregistrare pt fiecare produs
public record Product(string CodProdus, decimal Cantitate, UnitateDeMasura Unitate);

// Definire tip inregistrare pt contactul unei persoane
public record Contact(string Nume, string Prenume, string NumarTelefon, string Adresa);

// Definire enum pentru unitatatile de masura
public enum UnitateDeMasura
{
    Unitati,
    Kilograme
}

// Definirea tipului de inregistrare pentru o comanda
public record Comanda(Contact Contact, List<Product> Produse)
{
    public void AdaugaProdus(string codProdus, decimal cantitate, UnitateDeMasura unitate)
    {
        Produse.Add(new Product(codProdus, cantitate, unitate));
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Comanda> comenzi = new List<Comanda>();

        while (true)
        {
            Console.WriteLine("--- Meniu ---");
            Console.WriteLine("1. Creare comanda");
            Console.WriteLine("2. Afisare comenzi existente");
            Console.WriteLine("3. Iesire");
            Console.Write("Alegeti o optiune: ");

            string optiune = Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    // Crearea unui contact
                    Console.Write("Nume: ");
                    string nume = Console.ReadLine();
                    Console.Write("Prenume: ");
                    string prenume = Console.ReadLine();
                    Console.Write("Număr de telefon: ");
                    string numarTelefon = Console.ReadLine();
                    Console.Write("Adresă: ");
                    string adresa = Console.ReadLine();

                    Contact contact = new Contact(nume, prenume, numarTelefon, adresa);

                    Comanda comanda = new Comanda(contact, new List<Product>());

                    while (true)
                    {
                        Console.Write("Cod produs: ");
                        string codProdus = Console.ReadLine();
                        Console.Write("Cantitate: ");
                        decimal cantitate = decimal.Parse(Console.ReadLine());
                        Console.Write("Unitate de masura (Unitati/Kilograme): ");
                        UnitateDeMasura unitate = Enum.Parse<UnitateDeMasura>(Console.ReadLine(), true);

                        comanda.AdaugaProdus(codProdus, cantitate, unitate);

                        Console.Write("Adaugati alt produs? (Da/Nu): ");
                        string raspuns = Console.ReadLine();
                        if (raspuns.Equals("Nu", StringComparison.OrdinalIgnoreCase))
                            break;
                    }

                    comenzi.Add(comanda);
                    Console.WriteLine("Comanda a fost inregistrata.");
                    break;

                case "2":
                    Console.WriteLine("--> Comenzi existente");
                    foreach (var c in comenzi)
                    {
                        Console.WriteLine($"Nume client: {c.Contact.Nume} {c.Contact.Prenume}");
                        Console.WriteLine("Produse:");
                        foreach (var produs in c.Produse)
                        {
                            Console.WriteLine($"  Cod produs: {produs.CodProdus}, Cantitate: {produs.Cantitate} {produs.Unitate}");
                        }
                        Console.WriteLine();
                    }
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Optiune invalida. Incercati din nou.");
                    break;
            }
        }
    }
}
