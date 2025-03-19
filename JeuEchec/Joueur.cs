namespace JeuEchec;

public class Joueur {
    private string nom;
    private short ELO;

    public override string ToString()
    {
        return this.nom + ":" + this.ELO;
    }
}