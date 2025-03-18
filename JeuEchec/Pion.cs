namespace JeuEchec;

public class Pion : Piece
{
    public Pion(Couleur couleur) : base(couleur)
    {
        
    }

    public override bool coupEstPossible(Mouvement mouvement, int tour)
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
    
    public override bool captureEstPossible(Mouvement mouvement, int tour)
    {
        return mouvement.yFin-mouvement.yDebut == 1 && Math.Abs(mouvement.xFin-mouvement.xDebut) == 1;
    }

    public override bool peutEnPassant()
    {
        return true;
    }

    public override bool peutPromotion()
    {
        return true;
    }
}