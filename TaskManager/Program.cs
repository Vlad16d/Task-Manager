using System;
using System.Windows.Forms;

namespace TaskManager
{
    static class Program
    {
        /// <summary>
        /// Podstawowa metoda uruchamiania aplikacji Windows Forms.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }
}