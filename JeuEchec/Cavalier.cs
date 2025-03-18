namespace JeuEchec;

public class Cavalier : Piece
{
    public Cavalier(Couleur couleur) : base(couleur)
    {
        
    }

    public override bool coupEstPossible(Mouvement mouvement, int tour)
    {
        return mouvement.estDiagonal(2);
    }
    public override bool peutColision()
    {
        return false;
    }
}