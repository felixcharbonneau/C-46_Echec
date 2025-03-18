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
        return this[mouvement.xFin,mouvement.yFin] is not null;
    }

    public bool estPionFantome(Mouvement mouvement)
    {
        bool estFantome = false;
        
        if (this[mouvement.xFin, mouvement.yFin].Couleur == Couleur.BLANC)
        {
            estFantome = this[mouvement.xFin, mouvement.yFin].Equals(this[mouvement.xFin + 1, mouvement.yFin]);
        }
        else if (this[mouvement.xFin, mouvement.yFin].Couleur == Couleur.NOIR)
        {
            estFantome = this[mouvement.xFin, mouvement.yFin].Equals(this[mouvement.xFin - 1, mouvement.yFin]);
        }
        
        return estFantome;
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
                    if (caseDebut.Couleur != caseFin.Couleur)
                    {

                    }
                    else
                    {
                        message = "Impossible de capturer une piece alliée";
                    }
                }
            }else if (provoqueCapture(mouvement) && caseDebut.captureEstPossible(mouvement, tour))
            {
                if (estPionFantome(mouvement) && caseDebut.peutEnPassant() && caseFin.dernierTourBouge == tour - 1)
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