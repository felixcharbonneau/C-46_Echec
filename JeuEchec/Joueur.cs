namespace JeuEchec;

/// <summary>
/// Classe pour un joueur d'un jeu d'échec
/// </summary>
public class Joueur {
    private string m_nom;//<Nom du jouer
    private int m_ELO;//<ELO du joueur(score)

    public override string ToString()
    {
        return this.nom + ":" + this.ELO;
    }

    public int ELO
    {
        get => this.m_ELO;
        set => this.m_ELO = value;
    }
    public string nom
    {
        get => this.m_nom;
        set => this.m_nom = value;
    }
}