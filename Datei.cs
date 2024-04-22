using System;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Klasse Dateioperationen mit den zugehörigen Methoden
/// </summary>
class Datei
{
    /// <summary>
    /// Methode für einzelne Datei öffnen
    /// </summary>
    public static void DateiOeffnenUndEinlesen()
    {
        try
        {
            // Dialog Datei öffnen anzeigen
            OpenFileDialog dialogDateiOeffnen = new OpenFileDialog();
            // Filter auf *.txt setzen
            dialogDateiOeffnen.Filter = "Textdateien (*.txt)|*.txt";
            // Titel des Fensters
            dialogDateiOeffnen.Title = "Bitte eine Datei auswählen";

            // Abfrage, ob Öffnen der Datei erfolgreich war
            if (dialogDateiOeffnen.ShowDialog() == DialogResult.OK)
            {
                // Setzen der Variable für den Dateinamen
                string dateiname = dialogDateiOeffnen.FileName;
                string dateiinhalt = "";

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
