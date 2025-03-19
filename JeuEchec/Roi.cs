namespace JeuEchec;

public class Roi : Piece
{
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