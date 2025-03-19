namespace JeuEchec;

public class VuePartie
{
    private FormPartie partie;

    public VuePartie()
    {
        partie = new FormPartie();
        Application.Run(new FormPartie());
        
    }
}