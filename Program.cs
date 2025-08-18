using Conta_Certa.Utils;

namespace Conta_Certa
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Cria o banco de dados
            Database.CreateDatabase();

            // Agenda as cobranças
            Task.Run(() => CobrancasScheduler.GenCobrancasDoMes());

            Application.Run(new Main());
        }
    }
}