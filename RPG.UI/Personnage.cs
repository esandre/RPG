namespace RPG.UI;

public class Personnage
{
    private readonly ushort _endurance;

    public Personnage(ushort endurance)
    {
        _endurance = endurance;
    }

    public uint Hp { get; private set; } = 11;
    private bool EstMort => Hp == 0;

    public void Attaquer(Personnage défenseur)
    {
        if(EstMort) return;
        if(défenseur.EstMort) return;
        défenseur.Hp -= 1;
    }
}