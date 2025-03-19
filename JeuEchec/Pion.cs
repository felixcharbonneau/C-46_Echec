namespace JeuEchec;

public class Pion : Piece
{
    public Pion(Couleur couleur) : base(couleur)
    {
        
    }

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
    public override string ToString()
    {
        return "P";
    }
}