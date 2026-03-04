using RPG.Test.Utilities;

namespace RPG.Test;

public class PersonnageTest
{
    [Theory(DisplayName = "Les personnages ont (10 + END + 2*lvl) HP initiaux")]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    [InlineData(2, 2)]
    [InlineData(ushort.MaxValue, ushort.MaxValue)]
    public void HpInitiaux(ushort endurance, ushort level)
    {
        // ETANT DONNE un personnage ayant 1 END
        var personnage = new PersonnageBuilder { Level = level, Endurance = endurance }.Build();

        // QUAND

        // ALORS ses HP sont de 10 + <endurance>
        Assert.Equal(10u + 2*level + endurance, personnage.Hp);
    }

    [Theory(DisplayName = "1 + (2*lvl) + FOR HP perdus au maximum à chaque coup")]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 1)]
    [InlineData(2, 1, 1)]
    [InlineData(2, 2, 1)]
    [InlineData(1, 1, 2)]
    [InlineData(1, 2, 2)]
    [InlineData(2, 1, 2)]
    [InlineData(2, 2, 2)]
    public void PerteHpNCoups(ushort nombreCoups, ushort level, ushort force)
    {
        // ETANT DONNE 2 personnages, un attaquant et un défenseur 
        var attaquant = new PersonnageBuilder { Level = level, Force = force }.Build();
        var défenseur = PersonnageBuilder.SacDeFrappe;
        var hpInitiaux = défenseur.Hp;

        // QUAND l'attaquant attaque le défenseur <nombreCoups> fois en ayant le maximum de chance
        for (var i = 0; i < nombreCoups; i++)
        {
            attaquant.Attaquer(défenseur, new MaxLuckRng());
        }

        // ALORS le défenseur perd 1 + (2*lvl) + FOR * <nombreCoups> HP
        Assert.Equal(hpInitiaux - (nombreCoups * (1 + 2*level + force)), défenseur.Hp);
    }

    [Fact]
    public void DegatsPasDeChance()
    {
        // ETANT DONNE 2 personnages, un attaquant et un défenseur
        var attaquant = PersonnageBuilder.Stub;
        var défenseur = PersonnageBuilder.SacDeFrappe;
        var hpInitiaux = défenseur.Hp;

        // ET un absence cruelle de chance
        var rng = new MinLuckRng();

        // QUAND l'attaquant attaque le défenseur 1 fois
        attaquant.Attaquer(défenseur, rng);

        // ALORS le défenseur perd 0HP
        Assert.Equal(hpInitiaux, défenseur.Hp);
    }

    [Fact(DisplayName = "Impossible de descendre sous zéro")]
    public void ZeroMinimumHp()
    {
        // ETANT DONNE 2 personnages, un attaquant et un défenseur
        var attaquant = PersonnageBuilder.Stub;
        var défenseur = PersonnageBuilder.Stub;

        // QUAND l'attaquant attaque le défenseur <hpTotal> + 1 fois
        const ushort hpMax = 10;
        for (var i = 0; i < hpMax + 1; i++)
        {
            attaquant.Attaquer(défenseur, new MaxLuckRng());
        }

        // ALORS le défenseur a 0 HP
        Assert.Equal(0u, défenseur.Hp);
    }

    [Fact(DisplayName = "Un mort n'attaque pas")]
    public void MortNAttaquePas()
    {
        // ETANT DONNE 2 personnages, un attaquant mort et un défenseur vivant
        var attaquant = PersonnageBuilder.Stub;
        attaquant.Tuer();

        var défenseur = PersonnageBuilder.Stub;
        var hpInitiaux = défenseur.Hp;

        // QUAND l'attaquant attaque le défenseur
        attaquant.Attaquer(défenseur, new MaxLuckRng());

        // ALORS le défenseur ne perd aucun HP
        Assert.Equal(hpInitiaux, défenseur.Hp);
    }
}