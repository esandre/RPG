namespace RPG.UI;

public class Personnage
{
    public int Hp { get; private set; } = 10;

    public void Attaquer(Personnage défenseur)
    {
        défenseur.Hp -= 1;
    }
}