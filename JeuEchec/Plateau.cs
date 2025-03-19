namespace JeuEchec;

/// <summary>
/// Classe pour le plateau d'un jeu d'échec
/// </summary>
public class Plateau
{
    private int derniereCaptureOuMouvPion;//< dernier coup ou il a eu une capture ou un mouvement de pion
    /// <summary>
    /// Constructeur d'un nouveau plateau
    /// </summary>
    public Plateau()
    {
        this.derniereCaptureOuMouvPion = 0;
        //pions
        for (int i = 0; i < 8; i++)
        {
            this[i, 1] = new Pion(Couleur.BLANC);
            this[i, 6] = new Pion(Couleur.BLANC);
        }
        //Tours
        this[0,0] = new Tour(Couleur.BLANC);
        this[0,7] = new Tour(Couleur.BLANC);
        
        this[7,0] = new Tour(Couleur.NOIR);
        this[7,7] = new Tour(Couleur.NOIR);
        //Cavaliers
        this[0,1] = new Tour(Couleur.BLANC);
        this[0,6] = new Tour(Couleur.BLANC);
        
        this[7,1] = new Tour(Couleur.NOIR);
        this[7,6] = new Tour(Couleur.NOIR);
        //Fous
        this[0,2] = new Tour(Couleur.BLANC);
        this[0,5] = new Tour(Couleur.BLANC);
        
        this[7,2] = new Tour(Couleur.NOIR);
        this[7,5] = new Tour(Couleur.NOIR);
        //Reines
        this[0, 3] = new Reine(Couleur.BLANC);
        this[7,4] = new Reine(Couleur.NOIR);
        //Rois
        this[0, 4] = new Reine(Couleur.BLANC);
        this[7,3] = new Reine(Couleur.NOIR);
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
                this[i, j] = plateau[i, j];
            }
        }
        this.derniereCaptureOuMouvPion = plateau.derniereCaptureOuMouvPion;
    }
    /// <summary>
    /// Iterateur contenant les pieces du plateau
    /// </summary>
    /// <param name="x">Coordonnées en x de la piece</param>
    /// <param name="y">Coordonnées en y de la piece</param>
    public Piece this[int x, int y]
    {
        get{ return this[x, y]; }
        set{ this[x, y] = value; }
    }
    /// <summary>
    /// Determine si un mouvement provoque une capture
    /// </summary>
    /// <param name="mouvement">Mouvement a vérifier</param>
    /// <returns>Si le mouvement provoque une capture</returns>
    public bool provoqueCapture(Mouvement mouvement)
    {
        return this[mouvement.xFin,mouvement.yFin] is not null;
    }
    /// <summary>
    /// Verifie si une piece non capturable est en echec
    /// </summary>
    /// <param name="couleur">couleur des pièces à vérifier</param>
    /// <returns>Si une piece est en echec</returns>   
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
    /// <summary>
    /// Vérifie si une piece est en echec
    /// </summary>
    /// <param name="x">Coordonnées en x de la piece</param>
    /// <param name="y">Coordonnées en y de la piece</param>
    /// <returns>Si la piece est en echec</returns>
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
    /// <summary>
    /// Verifie si un coup est possible
    /// </summary>
    /// <param name="mouvement">Mouvement à effectuer</param>
    /// <param name="tour">Tour durant lequel effectuer le mouvement</param>
    /// <returns>Message contenant si le coup est possible ou le message d'erreur</returns>
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
    /// <summary>
    /// Pour joueur un Coup
    /// </summary>
    /// <param name="mouvement">coup à jouer</param>
    public void jouerCoup(Mouvement mouvement, int tour)
    {
        this[mouvement.xFin, mouvement.yFin] = this[mouvement.xDebut, mouvement.yDebut];
        this[mouvement.xDebut, mouvement.yDebut].dernierTourBouge = tour;
        this[mouvement.xDebut, mouvement.yDebut] = null;
    }

    /// <summary>
    /// Serilization du plateau
    /// </summary>
    /// <returns>Plateau sérialisé</returns>
    public override string ToString()
    {
        string plateau = "";
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (this[i,j] is not null)
                {
                    plateau += this[i,j].ToString() + ":" + i + "," + j + ";";
                }
            }
        }
        return plateau;
    }
}