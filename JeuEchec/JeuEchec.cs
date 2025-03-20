namespace JeuEchec
{
    public class JeuEchec
    {
        /// <summary>
        ///  Le point d'entrée principal de l'application
        /// </summary>
        [STAThread]
        static void Main()
        {
            JeuEchec jeuEchec = new JeuEchec();
            
            
        }

        public JeuEchec()
        {
            Vue Vue = new Vue();
            Modele modele = new Modele();
        }

        public static void nouvellePartie()
        {
            Guid guid = Guid.NewGuid();
            Modele.nouvellePartie(guid);
        }

        
    }
}