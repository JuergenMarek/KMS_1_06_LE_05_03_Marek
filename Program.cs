using System;
/// <summary>
/// Hauptmenü
/// </summary>
class Program
{
    // STA-Modus aktivieren; notwendig wenn Konsole mit grafischer Oberfläche gemischt wird
    [STAThread]
    static void Main(string[] args)
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
                        Dateioperationen.EinzelneDateiOeffnen();
                        break;
                    case "2":
                        Dateioperationen.OrdnerOeffnen();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine Option zwischen 1 und 3.");
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
