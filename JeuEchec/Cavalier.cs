namespace JeuEchec;

public class Cavalier : Piece
{
    public Cavalier(Couleur couleur) : base(couleur)
    {
        
    }

    public override bool coupEstPossible(Mouvement mouvement) {
        return mouvement.estDiagonal(2, 3,3);
    }
    public override bool peutColision()
    {
        return false;
    }
    public override string ToString()
    {
        return "C";
    }
}