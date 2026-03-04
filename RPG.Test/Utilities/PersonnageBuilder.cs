using RPG.UI;

namespace RPG.Test.Utilities
{
    public record PersonnageBuilder
    {
        public static Personnage Stub => new PersonnageBuilder().Build();
        public static Personnage SacDeFrappe => new PersonnageBuilder { Endurance = ushort.MaxValue, Level = ushort.MaxValue }.Build();

        public ushort Level { get; init; }
        public ushort Endurance { get; init; }
        public ushort Force { get; init; }

        public Personnage Build()
        {
            return new Personnage(Level, Endurance, Force);
        }
    }

    public static class PersonnageExtensions {
        public static void Tuer(this Personnage p)
        {
            while (p.Hp > 0)
            {
                p.Attaquer(p, new MaxLuckRng());
            }
        }
    }
}
