namespace RPG.UI;

public class Personnage
{
    public Personnage(ushort level, ushort endurance)
    {
        Hp = 10u + endurance + 2u * level;
    }

    public uint Hp { get; private set; }
    private bool EstMort => Hp == 0;

    public void Attaquer(Personnage défenseur)
    {
        if(EstMort) return;
        if(défenseur.EstMort) return;
        défenseur.Hp -= 1;
    }
}