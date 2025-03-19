namespace JeuEchec;

public class Vue
{
    private FormMenu menu;

    public Vue()
    {
        menu = new FormMenu();
        Application.Run(new FormMenu());
    }
}