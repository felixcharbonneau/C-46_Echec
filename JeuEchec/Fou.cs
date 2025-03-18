namespace JeuEchec;

public class Fou : Piece
{
    public Fou(Couleur couleur) : base(couleur)
    {
        
    }

    public override bool coupEstPossible(Mouvement mouvement, int tour)
    {
        return mouvement.estDiagonal(1);
    }
}