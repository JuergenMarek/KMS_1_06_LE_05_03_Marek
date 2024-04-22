using System;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Klasse Dateioperationen mit den zugehörigen Methoden
/// </summary>
class Ordner
{
    /// <summary>
    /// Methode für ganzen Ordner öffnen
    /// </summary>
    public static void OrdnerOeffnen()
    {
        try
        {
            // Fenster für Ordner öffnen anzeigen
            FolderBrowserDialog dialogOrdnerOeffnen = new FolderBrowserDialog();
            dialogOrdnerOeffnen.Description = "Einen Ordner auswählen";

            if (dialogOrdnerOeffnen.ShowDialog() == DialogResult.OK)
            {
                // Wenn erfolgreich ausgewählt, anzeigen des Ordnerinhalts mit Filter *.txt
                string ordnerpfad = dialogOrdnerOeffnen.SelectedPath;
                string[] dateien = Directory.GetFiles(ordnerpfad, "*.txt");

                // Auswahl der einzelnen Datei aufrufen
                DateiAuswahl(dateien);
            }
            else
            {
                Console.WriteLine("Fehler beim Öffnen des Ordner.");
                Console.Write("Drücken Sie eine Taste, um zum Hauptmenü zurückzukehren.");
                Console.ReadKey();
            }
        }
        // Exceptionhandling
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Öffnen des Ordners: {ex.Message}");
            Console.Write("Drücken Sie eine Taste, um zum Hauptmenü zurückzukehren.");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Auflistung der im ausgewählten Ordner vorhandenen Dateien
    /// </summary>
    /// <param name="dateien">Liste der vorhandenen Dateien im ausgewählten Ordner</param>
    private static void DateiAuswahl(string[] dateien)
    {
        // Auflistung der gefundenen Textdateien am Bildschirm
        Console.WriteLine("Gefundene Textdateien:");
        for (int i = 0; i < dateien.Length; i++)
        {
            Console.WriteLine($"{i + 1}) {Path.GetFileName(dateien[i])}");
        }

        // Abfrage für Dateiauswahl
        Console.Write("Bitte wählen Sie eine Datei anhand ihrer Nummer aus: ");
        int dateiID;

        // Bedingung für richtig eingegebene Dateinummer (>=1 und <= Dateianzahl)
        if (int.TryParse(Console.ReadLine(), out dateiID) && dateiID >= 1 && dateiID <= dateien.Length)
        {
            // Index der Datei bestimmen (ID -1)
            string ausgewaehlteDatei = dateien[dateiID - 1];

            // Übergabe der ausgewählten Datei an Mehode DateiEinlesen
            DateiEinlesenUndAusgeben(ausgewaehlteDatei);
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe. Die Datei wurde nicht bearbeitet.");
        }
    }

    /// <summary>
    /// Methode für Datei einlesen und Inhalt am Bildschirm ausgeben
    /// </summary>
    /// <param name="ausgewaehlteDatei">Die Datei, die ausgewählt wurde</param>
    public static void DateiEinlesenUndAusgeben(string ausgewaehlteDatei)
    {
        // Setzen der Variable für den Dateinamen
        string dateiname = ausgewaehlteDatei;
        string dateiinhalt = "";

        try
        {
            // Einlesen des Dateiinhalts und Ausgabe am Bildschirm
            using (StreamReader einlesen = new StreamReader(dateiname))
            {
                Console.WriteLine("Dateiinhalt:");
                dateiinhalt = einlesen.ReadLine();
                Console.WriteLine(dateiinhalt);
            }

            // Übergeben des Dateinamens an die nächste Methode
            Aktionen.AuswahlBearbeiten(dateiname, dateiinhalt);
        }

        // Exceptionhandling
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Öffnen der Datei: {ex.Message}");
            Console.Write("Drücken Sie eine Taste, um zum Hauptmenü zurückzukehren.");
            Console.ReadKey();
        }
    }   
}
