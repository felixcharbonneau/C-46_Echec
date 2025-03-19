namespace JeuEchec;

public class Reine : Piece
{
    public Reine(Couleur couleur) : base(couleur)
    {
        
    }

    public override bool coupEstPossible(Mouvement mouvement)
    {
        return mouvement.estDiagonal(1) || mouvement.estHorizontal() || mouvement.estVertical();
    }
    public override string ToString()
    {
        return "D";
    }


}