namespace JeuEchec;

public class Plateau
{
    private int derniereCaptureOuMouvPion;
    public Plateau()
    {
        
    }
    /// <summary>
    /// Constructeur de copie
    /// </summary>
    /// <param name="plateau">Plateau a copier</param>
    public Plateau(Plateau plateau)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                this[j, i] = plateau[i, j];
            }
        }
        this.derniereCaptureOuMouvPion = plateau.derniereCaptureOuMouvPion;
    }
    public Piece this[int x, int y]
    {
        get{ return this[x, y]; }
        set{ this[x, y] = value; }
    }
    public bool provoqueCapture(Mouvement mouvement)
    {
        return this[mouvement.xFin,mouvement.yFin] is not null;
    }
    public bool estEnEchec(Couleur couleur)
    {
        bool enEchec = false;
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                if (this[i,j] is not null && this[i,j].Couleur == couleur && this[i,j].estCapturable())
                {
                    if (estEnEchec(i,j))
                    {
                        enEchec = true;
                    }
                }
            }
        }
        return enEchec;
    }
    public bool estEnEchec(byte x, byte y)
    {
        bool estEnEchec = false;
        if (this[x, y] is not null)
        {
            for (byte i = 0; i < 8; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    if (this[i,j].Couleur != this[x,y].Couleur)
                    {
                        Mouvement mouvement = new Mouvement(i, j, x, y);
                        if (this[i, j].coupEstPossible(mouvement))
                        {
                            estEnEchec = true;
                        }
                    }
                }
            }
        }
        return estEnEchec;
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
        Couleur couleur = tour % 2 == 0 ? Couleur.BLANC : Couleur.NOIR;

        if (caseDebut is not null)
        {
            if (caseDebut.Couleur == couleur)
            {
                if (caseDebut.coupEstPossible(mouvement))
                {
                    if (provoqueCapture(mouvement) && caseDebut.Couleur == caseFin.Couleur)
                    {
                        message = "impossible de capturer une pièce alliée";
                    }
                    else
                    {
                        message = "possible";
                        mouvement.pieceCapture = this[mouvement.xFin, mouvement.yFin];
                    }
                }
                else if (caseDebut.captureEstPossible(mouvement) && provoqueCapture(mouvement))
                {
                    if (estPionFantome(mouvement))
                    {
                        if (caseDebut.peutEnPassant() && caseFin.dernierTourBouge == tour - 1)
                        {
                            if (caseDebut.Couleur != caseFin.Couleur)
                            {
                                message = "Possible";
                                mouvement.pieceCapture = this[mouvement.xFin, mouvement.yFin];
                            }
                        }
                    }
                    else
                    {
                        if (caseDebut.Couleur != caseFin.Couleur)
                        {
                            message = "Possible";
                            mouvement.pieceCapture = this[mouvement.xFin, mouvement.yFin];
                        }
                        else
                        {
                            message = "impossible de capturer une pièce alliée";
                        }
                    }
                }
            }
            else
            {
                message = "Impossible de bouger une pièce enemie";
            }
        }
        
        if (message == "Possible" && estEnEchec(couleur))
        {
            message = "Le coup vous met en échec";
        }

        return message;
    }
    public void jouerCoup(Mouvement mouvement)
    {
        this[mouvement.xFin, mouvement.yFin] = this[mouvement.xDebut, mouvement.yDebut];
        this[mouvement.xDebut, mouvement.yDebut] = null;
    }
}