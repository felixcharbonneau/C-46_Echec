namespace JeuEchec;

public class Plateau
{
    private int derniereCaptureOuMouvPion;

    public Piece this[int x, int y]
    {
        get{ return this[x, y]; }
        set{ this[x, y] = value; }
    }
    
    
    
    public bool provoqueCapture(Mouvement mouvement)
    {
        bool provoqueCapture = false;
        if (this[mouvement.xFin,mouvement.yFin] is not null && this[mouvement.xDebut,mouvement.yDebut] is not null){
            provoqueCapture = this[mouvement.xFin,mouvement.yFin].Couleur == this[mouvement.xDebut,mouvement.yDebut].Couleur;
        }
        return  provoqueCapture; 
    }

    public string coupEstPossible(Mouvement mouvement, int tour)
    {
        Piece caseDebut = this[mouvement.xDebut,mouvement.yDebut];
        Piece caseFin = this[mouvement.xFin,mouvement.yFin];
        string message = "";
        
        if (caseDebut is not null)
        {
            if (caseDebut.coupEstPossible(mouvement, tour))
            {
                if (provoqueCapture(mouvement))
                {
                    
                }
            }
            else
            {
                message = "La piece ne peut pas effectuer ce deplacement";
            }
        }
        else
        {
            message = "Aucune piece sur la case de début";
        }
        return message;
    }
    
    
}