namespace JeuEchec;

/// <summary>
/// Classe abstraite pour une piece pour un jeu d'echec
/// </summary>
public abstract class Piece {
    private Couleur m_couleur;
    private int m_dernierTourBouge;
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="couleur">Couleur de la piece</param>
    public Piece(Couleur couleur)
    {
        this.m_couleur = couleur;
        this.m_dernierTourBouge = -1;
    }
    /// <summary>
    /// dernier tour durant lequel la piece a bougé
    /// </summary>
    public int dernierTourBouge {
        get { return m_dernierTourBouge; }
        set {
            this.m_dernierTourBouge = value;
        }
    }
    /// <summary>
    /// Couleur de la piece
    /// </summary>
    public Couleur Couleur
    {
        get { return m_couleur; }
        set { this.m_couleur = value; }
    }
    /// <summary>
    /// Determine si la piece peut effectuer le coup
    /// </summary>
    /// <param name="mouvement">Mouvement a effectuer</param>
    /// <param name="tour">Tour ou le mouvement est effectué</param>
    /// <returns>si le mouvement est possible</returns>
    public abstract bool coupEstPossible(Mouvement mouvement);
    /// <summary>
    /// Si la piece peut capturer avec ce mouvement
    /// </summary>
    /// <param name="mouvement">Mouvement a effectuer</param>
    /// <param name="tour">Tour ou le mouvement est effectué</param>
    /// <returns>Si la capture est possible</returns>
    public virtual bool captureEstPossible(Mouvement mouvement)
    {
        return this.coupEstPossible(mouvement);
    }
    /// <summary>
    /// Si la piece a des colisions
    /// </summary>
    /// <returns>true si la pièce a des colisions</returns>
    public virtual bool peutColision()
    {
        return true;
    }
    /// <summary>
    /// Si la piece peut initier un roque
    /// </summary>
    /// <returns>true si la piece peut initier un roque</returns>
    public virtual bool peutInitierRoque()
    {
        return false;
    }
    /// <summary>
    /// Si la piece peut effectuer une promotion
    /// </summary>
    /// <returns>true si la piece peut effectuer une promotion</returns>
    public virtual bool peutPromotion()
    {
        return false;
    }

    /// <summary>
    /// Si la piece peut faire un coup en passant
    /// </summary>
    /// <returns>true si la piece peut en passant</returns>
    public virtual bool peutEnPassant()
    {
        return false;
    }
    /// <summary>
    /// Si la piece peut etre capturée
    /// </summary>
    /// <returns>true par defaut</returns>
    public virtual bool estCapturable()
    {
        return true;
    }
    /// <summary>
    /// Serialisation d'une piece
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "Piece:";
    }
}