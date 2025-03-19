namespace JeuEchec;

public class Partie
{
    private int tour;
    private Joueur joueurBlanc;
    private Joueur joueurNoir;
    private Plateau plateau;
    private List<Mouvement> mouvements;
    private List<string> plateausPrecedents;

    public Partie(Joueur joueurBlanc, Joueur joueurNoir)
    {
        this.joueurBlanc = joueurBlanc;
        this.joueurNoir = joueurNoir;
        this.plateau = new Plateau();
    }

    ~Partie()
    {
        
    }
    
    public string jouerCoup(byte xDebut, byte xFin, byte yDebut, byte yFin)
    {
        Mouvement mouvement = new Mouvement(xDebut, xFin, yDebut, yFin);
        string message = plateau.coupEstPossible(mouvement,tour);

        if (message == "Possible")
        {
            message += plateau.ToString();
            tour++;
            plateau.jouerCoup(mouvement, tour);
            mouvements.Add(mouvement);
            string plateauString = plateau.ToString();
            plateausPrecedents.Add(plateauString);
            message += ":" + plateauString;
        }
        
        return message;
    }   
    
}