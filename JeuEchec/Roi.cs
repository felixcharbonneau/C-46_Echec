namespace JeuEchec;

/// <summary>
/// Classe pour un roi dans un jeu d'échec
/// </summary>
public class Roi : Piece
{
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="couleur">Couleur de la pièce</param>
    public Roi(Couleur couleur) : base(couleur)
    {
    }

    public override bool coupEstPossible(Mouvement mouvement)
    {
        return mouvement.estHorizontal(1) || mouvement.estVertical(1) || mouvement.estDiagonal(1,2,2);
    }

    public override bool peutInitierRoque()
    {
        return true;
    }

    public override string ToString()
    {
        return "R";
    }
}