using RPG.UI;

namespace RPG.Test;

public class PersonnageTest
{
    [Fact(DisplayName = "Les personnages ont 11HP initiaux avec 1 END")]
    public void HpInitiaux()
    {
        // ETANT DONNE un personnage ayant 1 END
        var personnage = new Personnage(endurance: 1);

        // QUAND

        // ALORS ses HP sont de 11
        Assert.Equal(11u, personnage.Hp);
    }

    [Theory(DisplayName = "1 HP perdu à chaque coup")]
    [InlineData(1)]
    [InlineData(2)]
    public void PerteHpNCoups(ushort nombreCoups)
    {
        // ETANT DONNE 2 personnages, un attaquant et un défenseur
        var attaquant = new Personnage(0);
        var défenseur = new Personnage(0);
        var hpInitiaux = défenseur.Hp;

        // QUAND l'attaquant attaque le défenseur <nombreCoups> fois
        for (var i = 0; i < nombreCoups; i++)
        {
            attaquant.Attaquer(défenseur);
        }

        // ALORS le défenseur perd <nombreCoups> HP
        Assert.Equal(hpInitiaux - nombreCoups, défenseur.Hp);
    }

    [Fact(DisplayName = "Impossible de descendre sous zéro")]
    public void ZeroMinimumHp()
    {
        // ETANT DONNE 2 personnages, un attaquant et un défenseur
        var attaquant = new Personnage(0);
        var défenseur = new Personnage(0);

        // QUAND l'attaquant attaque le défenseur <hpTotal> + 1 fois
        const ushort hpMax = 10;
        for (var i = 0; i < hpMax + 1; i++)
        {
            attaquant.Attaquer(défenseur);
        }

        // ALORS le défenseur a 0 HP
        Assert.Equal(0u, défenseur.Hp);
    }

    [Fact(DisplayName = "Un mort n'attaque pas")]
    public void MortNAttaquePas()
    {
        // ETANT DONNE 2 personnages, un attaquant mort et un défenseur vivant
        var attaquant = new Personnage(0);
        while (attaquant.Hp > 0)
        {
            attaquant.Attaquer(attaquant);
        }

        var défenseur = new Personnage(0);
        var hpInitiaux = défenseur.Hp;

        // QUAND l'attaquant attaque le défenseur
        attaquant.Attaquer(défenseur);

        // ALORS le défenseur ne perd aucun HP
        Assert.Equal(hpInitiaux, défenseur.Hp);
    }
}