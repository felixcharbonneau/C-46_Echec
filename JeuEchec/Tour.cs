namespace JeuEchec;

public class Tour : Piece
{
    public Tour(Couleur couleur) : base(couleur)
    {
        
    }

    public override bool coupEstPossible(Mouvement mouvement)
    {
        return mouvement.estHorizontal() || mouvement.estVertical();
    }
}