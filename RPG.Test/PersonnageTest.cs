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
}