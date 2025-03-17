namespace JeuEchec;

public class Mouvement
{
    private byte xDebut;
    private byte yDebut;
    private byte xFin;
    private byte yFin;
    private Piece pieceCapture;
    private bool estReversible;

    /// <summary>
    /// Determine si le mouvement est horizontal
    /// </summary>
    /// <param name="min">nombre de case minimal pour le mouvement</param>
    /// <param name="max">nombre de case maximal pour le mouvement</param>
    /// <returns>true si le mouvement est horizontal</returns>
    public bool estHorizontal(byte min, byte max) {
        return yDebut == yFin && xFin-xDebut <= max && xFin-xDebut >= min;
    }
    /// <summary>
    /// Determine si le mouvement est vertical
    /// </summary>
    /// <param name="min">nombre de case minimal pour le mouvement</param>
    /// <param name="max">nombre de case maximal pour le mouvement</param>
    /// <returns>true si le mouvement est vertical</returns>
    public bool estVertical(byte min, byte max)
    {
        return xDebut == xFin && yFin-yDebut <= max && yFin-yDebut >= min;
    }

    /// <summary>
    /// Determine si le mouvement est diagonal
    /// </summary>
    /// <param name="pente">Pente du mouvement</param>
    /// <returns>true si le mouvement est diagonal</returns>
    public bool estDiagonal(double pente)
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
        
        return estDiagonal;
    }
}