namespace JeuEchec;

/// <summary>
/// Classe pour un pion d'un jeu d'échec
/// </summary>
public class Pion : Piece
{
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="couleur">Couleur de la piece</param>
    public Pion(Couleur couleur) : base(couleur)
    {
        
    }
    /// <summary>
    /// Determine si le coup est possible
    /// </summary>
    /// <param name="mouvement">Mouvement a déterminer</param>
    /// <returns>true si le coup est possible</returns>
    public override bool coupEstPossible(Mouvement mouvement)
    {
        bool estPossible = false;
        if ((mouvement.estVertical() && mouvement.yFin-mouvement.yDebut == 2) && this.dernierTourBouge == -1) {
            estPossible = true;
        }else if (mouvement.yFin-mouvement.yDebut == 0 && Math.Abs(mouvement.xFin-mouvement.xDebut)==1)
        {
            estPossible = true;
        }else if (mouvement.xFin-mouvement.xDebut == 1 && mouvement.yFin-mouvement.yDebut == 0)
        {
            estPossible = true;
        }
        return estPossible;
    }
    /// <summary>
    /// Si le pion peut effectuer une capture avec le mouvement
    /// </summary>
    /// <param name="mouvement">Mouvement a effectuer</param>
    /// <returns>Si la capture est possible</returns>
    public override bool captureEstPossible(Mouvement mouvement)
    {
        return mouvement.yFin-mouvement.yDebut == 1 && Math.Abs(mouvement.xFin-mouvement.xDebut) == 1;
    }
    /// <summary>
    /// Si le pion peut effectuer un coup en passant
    /// </summary>
    /// <returns>true</returns>
    public override bool peutEnPassant()
    {
        return true;
    }
    /// <summary>
    /// Le pion peut effectuer une promotion
    /// </summary>
    /// <returns>true</returns>
    public override bool peutPromotion()
    {
        return true;
    }
    /// <summary>
    /// Serialisation du pion
    /// </summary>
    /// <returns>P</returns>
    public override string ToString()
    {
        return "P";
    }
}