namespace JeuEchec;

public class Mouvement
{
    private byte m_xDebut;
    private byte m_yDebut;
    private byte m_xFin;
    private byte m_yFin;
    private Piece m_pieceCapture;
    private bool m_estReversible;

    public Mouvement(byte xDebut, byte xFin,byte yDebut, byte yFin)
    {
        this.m_xDebut = xDebut;
        this.m_yDebut = xDebut;
        this.m_xFin = xFin;
        this.m_yFin = yFin;
    }
    public byte xDebut
    {
        get { return m_xDebut; }
        set { m_xDebut = value; }
    }
    public byte xFin
    {
        get { return m_xFin; }
        set { m_xFin = value; }
    }
    public byte yDebut
    {
        get { return m_yDebut; }
        set { m_yDebut = value; }
    }
    public byte yFin
    {
        get { return m_yFin; }
        set { m_yFin = value; }
    }

    public Piece pieceCapture
    {
        get { return m_pieceCapture; }
        set { m_pieceCapture = value; }
    }

    /// <summary>
    /// Determine si le mouvement est horizontal
    /// </summary>
    /// <param name="min">nombre de case minimal pour le mouvement</param>
    /// <param name="max">nombre de case maximal pour le mouvement</param>
    /// <returns>true si le mouvement est horizontal</returns>
    public bool estHorizontal(byte min = 0, byte max = 8) {
        return yDebut == yFin && xFin-xDebut <= max && xFin-xDebut >= min;
    }
    /// <summary>
    /// Determine si le mouvement est vertical
    /// </summary>
    /// <param name="min">nombre de case minimal pour le mouvement</param>
    /// <param name="max">nombre de case maximal pour le mouvement</param>
    /// <returns>true si le mouvement est vertical</returns>
    public bool estVertical(byte min = 0, byte max = 8)
    {
        return xDebut == xFin && yFin-yDebut <= max && yFin-yDebut >= min;
    }

    /// <summary>
    /// Determine si le mouvement est diagonal
    /// </summary>
    /// <param name="pente">Pente du mouvement</param>
    /// <returns>true si le mouvement est diagonal</returns>
    public bool estDiagonal(double pente, byte min = 2, byte max = 16)
    {
        bool estDiagonal = true;
        //Eviter une division par 0
        if (xDebut==xFin && yDebut==yFin) {
            estDiagonal = false;
        }else if (Math.Abs(((double)Math.Abs(xFin - xDebut) / (double)Math.Abs(yFin - yDebut)) - pente) < 0.0001)
        {
            estDiagonal = false;
        }
        else if (Math.Abs(((double)Math.Abs(yFin - yDebut) / (double)Math.Abs(xFin - xDebut)) - pente) < 0.0001) {
            estDiagonal = false;            
        }
        int deplacement = Math.Abs(yFin-yDebut)+Math.Abs(xFin-xDebut);
        
        
        
        return estDiagonal && deplacement >= min && deplacement <= max;
    }
}