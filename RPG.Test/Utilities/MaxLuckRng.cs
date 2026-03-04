using RPG.UI;

namespace RPG.Test.Utilities
{
    internal class MaxLuckRng : IRandomGenerator
    {
        public uint PickValueBetweenZeroAnd(uint max) => max;
    }
}
