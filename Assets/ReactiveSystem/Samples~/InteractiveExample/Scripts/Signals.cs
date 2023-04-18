using UnityEngine;

namespace ReactiveSystem.Example.PowerTest.Scripts
{
    public struct CubeActionSignal
    {
        public Color Color;
        public CubeActionSignal(Color color)
        {
            Color = color;
        }
    }

    public struct MaxColumCubesSignal
    {
        public int MaxAmount;
        public MaxColumCubesSignal(int maxAmount)
        {
            MaxAmount = maxAmount;
        }
    }
}