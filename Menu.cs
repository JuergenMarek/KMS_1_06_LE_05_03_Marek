using System;

/// <summary>
/// Hauptmenü
/// </summary>
class Mainmenu
{
    public static void Menu()
    {
        bool exit = false;

        while (!exit)
        {
            try
            {
                // Hauptmenü generieren
                Console.Clear();
                Console.WriteLine("Herzlich willkommen im Texteditor der Firma DocuEdit GmbH!");
                Console.WriteLine();
                Console.WriteLine("Hauptmenü:");
                Console.WriteLine("1___Einzelne Datei öffnen");
                Console.WriteLine("2___Ganzen Ordner öffnen");
                Console.WriteLine("3___Programmende");

                Console.Write("Bitte wählen Sie eine Option: ");
                string auswahl = Console.ReadLine();

                // Auswahl behandeln
                switch (auswahl)
                {
                    case "1":
                        Datei.DateiOeffnenUndEinlesen();
                        break;
                    case "2":
                        Ordner.OrdnerOeffnen();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine Option zwischen 1 und 3.");
                        Console.Write("Drücken Sie eine Taste, um zum Hauptmenü zurückzukehren.");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Es ist ein Fehler aufgetreten: {ex.Message}");
            }
        }
    }


}
