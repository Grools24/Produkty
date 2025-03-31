using System;
using System.Collections.Generic;

namespace eeeeeeeeeeeeeee
{
    class Produkt
    {
        public class Product
        {
            public string Nazwa { get; set; } = string.Empty;
            public int Ilosc { get; set; }
            public double Cena { get; set; }
        }

        static List<Product> ekwipunek = new List<Product>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWybierz opcję:");
                Console.WriteLine("1. Dodaj produkt");
                Console.WriteLine("2. Usuń produkt");
                Console.WriteLine("3. Wyświetl listę produktów");
                Console.WriteLine("4. Aktualizuj produkt");
                Console.WriteLine("5. Oblicz wartość magazynu");
                Console.WriteLine("6. Wyjście");
                Console.Write("Twój wybór: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        RemoveProduct();
                        break;
                    case "3":
                        DisplayProducts();
                        break;
                    case "4":
                        UpdateProduct();
                        break;
                    case "5":
                        CalculateInventoryValue();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void AddProduct()
        {
            try
            {
                Console.Write("Podaj nazwę produktu: ");
                string? nazwa = Console.ReadLine();
                if (string.IsNullOrEmpty(nazwa))
                {
                    Console.WriteLine("Nazwa produktu nie może być pusta.");
                    return;
                }

                Console.Write("Podaj ilość: ");
                if (!int.TryParse(Console.ReadLine(), out int ilosc))
                {
                    Console.WriteLine("Nieprawidłowa ilość.");
                    return;
                }

                Console.Write("Podaj cenę jednostkową: ");
                if (!double.TryParse(Console.ReadLine(), out double cena))
                {
                    Console.WriteLine("Nieprawidłowa cena.");
                    return;
                }

                ekwipunek.Add(new Product { Nazwa = nazwa, Ilosc = ilosc, Cena = cena });
                Console.WriteLine("Produkt został dodany!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }

        static void RemoveProduct()
        {
            Console.Write("Podaj nazwę produktu do usunięcia: ");
            string? nazwa = Console.ReadLine();
            if (string.IsNullOrEmpty(nazwa))
            {
                Console.WriteLine("Nazwa produktu nie może być pusta.");
                return;
            }

            var produkt = ekwipunek.Find(p => p.Nazwa == nazwa);
            if (produkt != null)
            {
                ekwipunek.Remove(produkt);
                Console.WriteLine("Produkt został usunięty.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono produktu o tej nazwie.");
            }
        }

        static void DisplayProducts()
        {
            Console.WriteLine("\nLista produktów:");
            foreach (var produkt in ekwipunek)
            {
                Console.WriteLine($"Nazwa: {produkt.Nazwa}, Ilość: {produkt.Ilosc}, Cena jednostkowa: {produkt.Cena:F2}");
            }
        }

        static void UpdateProduct()
        {
            Console.Write("Podaj nazwę produktu do aktualizacji: ");
            string? nazwa = Console.ReadLine();
            if (string.IsNullOrEmpty(nazwa))
            {
                Console.WriteLine("Nazwa produktu nie może być pusta.");
                return;
            }

            var produkt = ekwipunek.Find(p => p.Nazwa == nazwa);
            if (produkt != null)
            {
                Console.Write("Podaj nową ilość (lub pozostaw puste, aby nie zmieniać): ");
                string? iloscInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(iloscInput) && int.TryParse(iloscInput, out int ilosc))
                {
                    produkt.Ilosc = ilosc;
                }

                Console.Write("Podaj nową cenę jednostkową (lub pozostaw puste, aby nie zmieniać): ");
                string? cenaInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(cenaInput) && double.TryParse(cenaInput, out double cena))
                {
                    produkt.Cena = cena;
                }

                Console.WriteLine("Produkt został zaktualizowany.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono produktu o tej nazwie.");
            }
        }

        static void CalculateInventoryValue()
        {
            double totalValue = 0;

            foreach (var produkt in ekwipunek)
            {
                totalValue += produkt.Ilosc * produkt.Cena;
            }

            Console.WriteLine($"Całkowita wartość magazynu: {totalValue:F2}");
        }
    }
}