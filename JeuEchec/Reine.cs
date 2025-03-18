namespace JeuEchec;

public class Reine : Piece
{
    public Reine(Couleur couleur) : base(couleur)
    {
        
    }

    public override bool coupEstPossible(Mouvement mouvement, int tour)
    {
        return mouvement.estDiagonal(1) || mouvement.estHorizontal() || mouvement.estVertical();
    }


}