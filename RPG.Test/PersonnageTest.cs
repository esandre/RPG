using RPG.UI;

namespace RPG.Test;

public class PersonnageTest
{
    /**
     * Les personnages ont 10 points de vie
        A zéro ils meurent.
        Ils peuvent s’attaquer et perdent 1 HP à chaque coup.
        
     */

    [Fact(DisplayName = "Les personnages ont 10HP initiaux")]
    public void HpInitiaux()
    {
        // ETANT DONNE un personnage
        var personnage = new Personnage();

        // QUAND

        // ALORS ses HP sont de 10
        Assert.Equal(10u, personnage.Hp);
    }

    [Theory(DisplayName = "1 HP perdu à chaque coup")]
    [InlineData(1)]
    [InlineData(2)]
    public void PerteHpNCoups(ushort nombreCoups)
    {
        // ETANT DONNE 2 personnages, un attaquant et un défenseur
        var attaquant = new Personnage();
        var défenseur = new Personnage();
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
        var attaquant = new Personnage();
        var défenseur = new Personnage();

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
        var attaquant = new Personnage();
        const ushort hpMax = 10;
        for (var i = 0; i < hpMax; i++)
        {
            attaquant.Attaquer(attaquant);
        }

        var défenseur = new Personnage();
        var hpInitiaux = défenseur.Hp;

        // QUAND l'attaquant attaque le défenseur
        attaquant.Attaquer(défenseur);

        // ALORS le défenseur ne perd aucun HP
        Assert.Equal(hpInitiaux, défenseur.Hp);
    }
}