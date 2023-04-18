using System.Collections.Generic;

namespace ReactiveSystem.Example.PowerTest.Scripts
{
    public struct PowerTestSignal
    {
        
    }

    public struct PowerTestParamSignal
    {
        public float Value;
        public string Name;

        public PowerTestParamSignal(float value, string name)
        {
            Value = value;
            Name = name;
        }

    }


    public struct PowerTestReferenceSignal
    {
        public List<string> Reference;

        public PowerTestReferenceSignal(List<string> reference)
        {
            Reference = reference;
        }
    }
}