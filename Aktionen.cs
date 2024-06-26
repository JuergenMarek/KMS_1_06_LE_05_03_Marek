﻿using System;
using System.IO;
using System.Windows.Forms;

class Aktionen
{
    /// <summary>
    /// Methode für Auswahl Bearbeiten j/n
    /// </summary>
    /// <param name="dateiname">Ausgewählte Datei</param>
    /// <param name="dateiinhalt">Inhalt der ausgewählten Datei</param>
    public static void AuswahlBearbeiten(string dateiname, string dateiinhalt)
    {
        // Abfrage für Bearbeitung der Datei
        Console.Write("Möchten Sie die Datei bearbeiten? (j/n): ");
        string auswahlBearbeiten = Console.ReadLine();

        switch (auswahlBearbeiten.ToLower())
        {
            case "j":
                AuswahlHinzufuegenOderLoeschen(dateiname, dateiinhalt);
                break;

            case "n":
                break;

            default:
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie nur j oder n ein.");
                break;
        }
    }

    /// <summary>
    /// Auswahl ob Text hinzugefügt oder gelöscht werden soll
    /// </summary>
    /// <param name="dateiname">Ausgewählte Datei</param>
    /// <param name="dateiinhalt">Inhalt der ausgewählten Datei</param>
    private static void AuswahlHinzufuegenOderLoeschen(string dateiname, string dateiinhalt)
    {
        // Abfrage welche Operation mit dem Text
        Console.WriteLine("Wollen Sie:");
        Console.WriteLine("1___Text hinzufügen");
        Console.WriteLine("2___Text entfernen");
        Console.Write("Bitte wählen Sie eine Option: ");
        string auswahlTextoperation = Console.ReadLine();

        // Auswahl abhandeln
        switch (auswahlTextoperation)
        {
            case "1":
                // Einlesen des neuen Texts
                Console.WriteLine();
                Console.Write("Bitte geben Sie den hinzuzufügenden Text ein: ");
                string neuerText = Console.ReadLine();

                //Hinzufügen des neuen Texts zum bestehenden Text
                dateiinhalt = dateiinhalt + " " + neuerText;
                DateiSpeichern(dateiname, dateiinhalt);
                break;

            case "2":
                // Eingabe für zu löschenden Text
                Console.WriteLine();
                Console.Write("Bitte geben Sie den zu löschenden Text ein: ");
                string textZuLoeschen = Console.ReadLine();

                // Ersetzen des zu löschenden Text mit ""
                dateiinhalt = dateiinhalt.Replace(textZuLoeschen, "");
                DateiSpeichern(dateiname, dateiinhalt);
                break;

            default:
                Console.WriteLine("Ungültige Eingabe. Die Datei wurde nicht bearbeitet.");
                break;
        }
    }

    /// <summary>
    /// Methode für das Speichern des modifizierten Texts
    /// </summary>
    /// <param name="dateiname">Ausgewählte Datei</param>
    /// <param name="dateiinhalt">Inhalt der ausgewählten Datei</param>
    private static void DateiSpeichern(string dateiname, string dateiinhalt)
    {
        // Abfrage, ob gesamter Text in gleiche oder neue Datei geschrieben werden soll
        Console.WriteLine();
        Console.WriteLine("Möchten Sie den Text:");
        Console.WriteLine("1___In die gleiche Datei speichern");
        Console.WriteLine("2___In eine neue Datei speichern");
        Console.Write("Bitte Auswahl eingeben: ");
        string auswahlTextSpeichern = Console.ReadLine();

        switch (auswahlTextSpeichern)
        {
            // Dateiinhalt n gleiche Datei speichern
            case "1":
                File.WriteAllText(dateiname, dateiinhalt);
                Console.WriteLine("Datei gespeichert.");
                Console.Write("Drücken Sie eine Taste, um zum Hauptmenü zurückzukehren.");
                Console.ReadKey();
                break;

            // In neue Datei speichern
            case "2":
                // Fenster für Datei speichern öffnen
                SaveFileDialog dialogDateiSpeichern = new SaveFileDialog();
                dialogDateiSpeichern.Filter = "Textdateien (*.txt)|*.txt";
                dialogDateiSpeichern.Title = "Datei speichern unter";

                if (dialogDateiSpeichern.ShowDialog() == DialogResult.OK)
                {
                    // Speichern des Dateiinhalts in die neue Datei
                    File.WriteAllText(dialogDateiSpeichern.FileName, dateiinhalt);
                    Console.WriteLine("Datei gespeichert.");
                    Console.Write("Drücken Sie eine Taste, um zum Hauptmenü zurückzukehren.");
                    Console.ReadKey();
                }
                // Fehlermeldung, wenn Datei nicht gespeichert werden konnte
                else
                {
                    Console.WriteLine("Fehler. Die Datei wurde nicht gespeichert.");
                    Console.Write("Drücken Sie eine Taste, um zum Hauptmenü zurückzukehren.");
                    Console.ReadKey();
                }
                break;

            default:
                Console.WriteLine("Ungültige Eingabe. Die Datei wurde nicht bearbeitet.");
                break;
        }
    }
}
