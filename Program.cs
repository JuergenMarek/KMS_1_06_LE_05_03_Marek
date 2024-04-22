using System;
/// <summary>
/// Hauptmenü
/// </summary>
class Program
{
    // STA-Modus aktivieren; notwendig wenn Konsole mit grafischer Oberfläche gemischt wird
    [STAThread]
    static void Main()
    {
        Mainmenu.Menu();
    }

    
}
