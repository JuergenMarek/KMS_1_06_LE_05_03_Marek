using System;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Klasse Dateioperationen mit den zugehörigen Methoden
/// </summary>
class Dateioperationen
{
    /// <summary>
    /// Methode für einzelne Datei öffnen
    /// </summary>
    public static void EinzelneDateiOeffnen()
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

                // Einlesen des Dateiinhalts und Ausgabe am Bildschirm
                using (StreamReader einlesen = new StreamReader(dateiname))
                {
                    Console.WriteLine("Dateiinhalt:");
                    Console.WriteLine(einlesen.ReadToEnd());
                }

                // Abfrage für Bearbeitung der Datei
                Console.Write("Möchten Sie die Datei bearbeiten? (j/n): ");
                string auswahlBearbeiten = Console.ReadLine();

                if (auswahlBearbeiten.ToLower() == "j")
                {
                    // Abfrage für welche Operation des Texts
                    Console.WriteLine("1___Text hinzufügen");
                    Console.WriteLine("2___Text entfernen");
                    Console.Write("Bitte wählen Sie eine Option: ");
                    string auswahlTextoperation = Console.ReadLine();

                    switch (auswahlTextoperation)
                    {
                        // Operation Text hinzufügen
                        case "1":
                            // Einlesen des neuen Texts
                            Console.Write("Bitte geben Sie den hinzuzufügenden Text ein: ");
                            string neuerText = Console.ReadLine();

                            // Abfrage, ob gesamter Text in gleiche oder neue Datei geschrieben werden soll
                            Console.WriteLine("Möchten Sie den Text:");
                            Console.WriteLine("1___In die gleiche Datei speichern");
                            Console.WriteLine("2___In eine neue Datei speichern");
                            Console.Write("Bitte Auswahl eingeben: ");
                            string auswahlTextHinzufuegen = Console.ReadLine();

                            // Wenn Auswahl = 1 --> gleiche Datei
                            if (auswahlTextHinzufuegen == "1")
                            {
                                File.AppendAllText(dateiname, neuerText);
                            }
                            // Wenn Auswahl = 2 --> neue Datei
                            else if (auswahlTextHinzufuegen == "2")
                            {
                                // Fenster für Datei speichern öffnen
                                SaveFileDialog dialogDateiSpeichern = new SaveFileDialog();
                                dialogDateiSpeichern.Filter = "Textdateien (*.txt)|*.txt";
                                dialogDateiSpeichern.Title = "Datei speichern unter";

                                if (dialogDateiSpeichern.ShowDialog() == DialogResult.OK)
                                {
                                    // Speichern des vorhandenen Texts plus neuer Text
                                    File.WriteAllText(dialogDateiSpeichern.FileName, File.ReadAllText(dateiname) +
                                        Environment.NewLine + neuerText);
                                }
                            }
                            // Fehlermeldung, wenn Datei nicht gespeichert werden konnte
                            else
                            {
                                Console.WriteLine("Ungültige Eingabe. Der Text wurde nicht zur Datei hinzugefügt.");
                            }
                            break;

                        // Operation Text löschen
                        case "2":
                            // Eingabe für zu löschenden Text
                            Console.Write("Bitte geben Sie den zu löschenden Text ein: ");
                            string textZuLoeschen = Console.ReadLine();

                            // Einlesen des Dateiinhalts
                            string dateiinhalt = File.ReadAllText(dateiname);
                            // Ersetzen des zu löschenden Text mit ""
                            dateiinhalt = dateiinhalt.Replace(textZuLoeschen, "");
                            // Abfrage, ob in gleiche oder neue Datei gespeichert werden soll
                            Console.WriteLine("Möchten Sie:");
                            Console.WriteLine("1___In die gleiche Datei speichern");
                            Console.WriteLine("2___In eine neue Datei speichern");
                            Console.Write("Bitte Auswahl eingeben: ");
                            string auswahlTextloeschen = Console.ReadLine();

                            // Wenn Auswahl = 1 --> gleiche Datei
                            if (auswahlTextloeschen == "1")
                            {
                                File.WriteAllText(dateiname, dateiinhalt);
                            }
                            // Wenn Auswahl = 2 --> neue Datei
                            else if (auswahlTextloeschen == "2")
                            {
                                // Fenster für Datei speichern öffnen
                                SaveFileDialog dialogDateiSpeichern = new SaveFileDialog();
                                dialogDateiSpeichern.Filter = "Textdateien (*.txt)|*.txt";
                                dialogDateiSpeichern.Title = "Datei speichern unter";

                                if (dialogDateiSpeichern.ShowDialog() == DialogResult.OK)
                                {
                                    // Speichern des Texts
                                    File.WriteAllText(dialogDateiSpeichern.FileName, dateiinhalt);
                                }
                            }
                            // Fehlermeldung, wenn Speichern nicht erfolgreich war
                            else
                            {
                                Console.WriteLine("Ungültige Eingabe. Die Datei wurde nicht gespeichert.");
                            }
                            break;
                        default:
                            Console.WriteLine("Ungültige Eingabe. Die Datei wurde nicht bearbeitet.");
                            break;
                    }
                }
            }
        }
        // Exceptionhandling
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Öffnen der Datei: {ex.Message}");
        }
    }

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

                Console.WriteLine("Gefundene Textdateien:");
                for (int i = 0; i < dateien.Length; i++)
                {
                    Console.WriteLine($"{i + 1}) {Path.GetFileName(dateien[i])}");
                }

                // Abfrage für Dateiauswahl
                Console.Write("Bitte wählen Sie eine Datei aus: ");
                int dateiID;

                // Bedingung für richtig eingegebene Dateinummer (>=1 und <= Dateianzahl)
                if (int.TryParse(Console.ReadLine(), out dateiID) && dateiID >= 1 && dateiID <= dateien.Length)
                {
                    // Index der Datei bestimmen (ID -1)
                    string ausgewaehlteDatei = dateien[dateiID - 1];

                    // Ausgabe des Dateiinhalts
                    Console.WriteLine("Dateiinhalt:");
                    Console.WriteLine(File.ReadAllText(ausgewaehlteDatei));

                    // Abfrage, ob Bearbeitung gewünscht
                    Console.Write("Möchten Sie die Datei bearbeiten? (j/n): ");
                    string auswahlBearbeiten = Console.ReadLine();

                    if (auswahlBearbeiten.ToLower() == "j")
                    {
                        // Abfrage, welche Textoperation gewünscht ist
                        Console.WriteLine("1___Text hinzufügen");
                        Console.WriteLine("2___Text entfernen");
                        Console.Write("Bitte wählen Sie eine Option: ");
                        string auswahlOperation = Console.ReadLine();

                        // Abhnandlung der Auswahl
                        switch (auswahlOperation)
                        {
                            case "1":
                                // Eingabe des hinzuzufügenden Texts
                                Console.Write("Bitte geben Sie den hinzuzufügenden Text ein: ");
                                string neuerText = Console.ReadLine();

                                // Abfrage, ob in gleiche oder neue Datei gespeichert werden soll
                                Console.WriteLine("Möchten Sie den Text:");
                                Console.WriteLine("1___In die gleiche Datei speichern");
                                Console.WriteLine("2___In eine neue Datei speichern");
                                Console.Write("Bitte Auswahl eingeben: ");
                                string auswahlTextHinzufuegen = Console.ReadLine();

                                // Wenn speichern in gleiche Datei gewählt wurde
                                if (auswahlTextHinzufuegen == "1")
                                {
                                    File.AppendAllText(ausgewaehlteDatei, neuerText);
                                }
                                // Wenn Speichern in neue Datei ausgwählt wurde
                                else if (auswahlTextHinzufuegen == "2")
                                {
                                    // Anzeigen des Fensters für Datei speichern
                                    SaveFileDialog dialogDateiSpeichern = new SaveFileDialog();
                                    dialogDateiSpeichern.Filter = "Textdateien (*.txt)|*.txt";
                                    dialogDateiSpeichern.Title = "Datei speichern unter";

                                    // Wenn ok --> Datei speichern
                                    if (dialogDateiSpeichern.ShowDialog() == DialogResult.OK)
                                    {
                                        File.AppendAllText(dialogDateiSpeichern.FileName, neuerText);
                                    }
                                }
                                // Fehlermeldung, wenn falsche Auswahl getroffen wurde
                                else
                                {
                                    Console.WriteLine("Ungültige Eingabe. Der Text wurde nicht zur Datei hinzugefügt.");
                                }
                                break;
                            case "2":
                                // Eingabe des zu löschenden Texts
                                Console.Write("Bitte geben Sie den zu löschenden Text ein: ");
                                string textZuLoeschen = Console.ReadLine();

                                // Einlesen des Dateiinhalts
                                string dateiinhalt = File.ReadAllText(ausgewaehlteDatei);

                                // Ersetzen des zu löschenden Texts mit ""
                                dateiinhalt = dateiinhalt.Replace(textZuLoeschen, "");

                                // Abfrage, ob in gleiche oder in neue Datei gespeichert werden soll
                                Console.WriteLine("Möchten Sie den Text:");
                                Console.WriteLine("1___In die gleiche Datei speichern");
                                Console.WriteLine("2___In eine neue Datei speichern");
                                Console.Write("Bitte Auswahl eingeben: ");
                                string auswahlTextLoeschen = Console.ReadLine();

                                // Wenn speichern in gleiche Datei gewählt wurde
                                if (auswahlTextLoeschen == "1")
                                {
                                    File.WriteAllText(ausgewaehlteDatei, dateiinhalt);
                                }
                                // Wenn Speichern in neue Datei ausgwählt wurde
                                else if (auswahlTextLoeschen == "2")
                                {
                                    // Anzeigen des Fensters für Datei speichern
                                    SaveFileDialog dialogDateiSpeichern = new SaveFileDialog();
                                    dialogDateiSpeichern.Filter = "Textdateien (*.txt)|*.txt";
                                    dialogDateiSpeichern.Title = "Datei speichern unter";

                                    // Wenn ok --> Datei speichern
                                    if (dialogDateiSpeichern.ShowDialog() == DialogResult.OK)
                                    {
                                        File.WriteAllText(dialogDateiSpeichern.FileName, dateiinhalt);
                                    }
                                }
                                // Fehlermeldung, wenn falsche Auswahl getroffen wurde
                                else
                                {
                                    Console.WriteLine("Ungültige Eingabe. Die Datei wurde nicht gespeichert.");
                                }
                                break;
                            default:
                                Console.WriteLine("Ungültige Eingabe. Die Datei wurde nicht bearbeitet.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Die Datei wurde nicht bearbeitet.");
                }
            }
        }
        // Exceptionhandling
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Öffnen des Ordners: {ex.Message}");
        }
    }
}
