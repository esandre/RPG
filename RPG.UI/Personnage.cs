namespace RPG.UI;

public class Personnage
{
    public uint Hp { get; private set; } = 10;
    private bool EstMort => Hp == 0;

    public void Attaquer(Personnage défenseur)
    {
        if(EstMort) return;
        if(défenseur.EstMort) return;
        défenseur.Hp -= 1;
    }
}