namespace JeuEchec;

public class Modele {
    private List<Joueur> joueurs;
    private List<Partie> parties;

    public string jouerCoup(byte xDebut, byte xFin, byte yDebut, byte yFin, Partie partie)
    {
        return partie.jouerCoup(xDebut, xFin, yDebut, yFin);
    }
}