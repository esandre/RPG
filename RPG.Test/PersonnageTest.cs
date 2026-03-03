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
        Assert.Equal(10, personnage.Hp);
    }

    [Fact(DisplayName = "1 HP perdu à chaque coup")]
    public void PerteHp()
    {
        // ETANT DONNE 2 personnage, un attaquant et un défenseur
        var attaquant = new Personnage();
        var défenseur = new Personnage();
        var hpInitiaux = défenseur.Hp;

        // QUAND l'attaquant attaque le défenseur
        attaquant.Attaquer(défenseur);

        // ALORS le défenseur perd 1 HP
        Assert.Equal(hpInitiaux - 1, défenseur.Hp);
    }

    [Fact(DisplayName = "2 HP perdu pour 2 coups")]
    public void Perte2Hp()
    {
        // ETANT DONNE 2 personnage, un attaquant et un défenseur
        var attaquant = new Personnage();
        var défenseur = new Personnage();
        var hpInitiaux = défenseur.Hp;

        // QUAND l'attaquant attaque le défenseur 2 fois
        attaquant.Attaquer(défenseur);
        attaquant.Attaquer(défenseur);

        // ALORS le défenseur perd 2 HP
        Assert.Equal(hpInitiaux - 2, défenseur.Hp);
    }
}