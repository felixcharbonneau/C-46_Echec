namespace JeuEchec
{
    internal static class Program
    {
        /// <summary>
        ///  Le point d'entrée principal de l'application
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}