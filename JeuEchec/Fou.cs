namespace JeuEchec;

public class Fou : Piece
{
    public Fou(Couleur couleur) : base(couleur)
    {
        
    }

    public override bool coupEstPossible(Mouvement mouvement)
    {
        return mouvement.estDiagonal(1);
    }
    public override string ToString()
    {
        return "F";
    }
}