namespace JeuEchec;

public class Cavalier : Piece
{
    public Cavalier(Couleur couleur) : base(couleur)
    {
        
    }

    public override bool coupEstPossible(Mouvement mouvement, int tour) {
        bool estPossible = (Math.Abs(mouvement.xFin - mouvement.xDebut) + Math.Abs(mouvement.yFin - mouvement.yDebut)) == 3;
        return mouvement.estDiagonal(2) && estPossible;
    }
    public override bool peutColision()
    {
        return false;
    }
}