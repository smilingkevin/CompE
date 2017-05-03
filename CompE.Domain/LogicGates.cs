using System.Collections.Generic;

namespace CompE.Domain
{
    public class LogicGate
    {
        public List<Pin> Inputs { get; set; }
        public Pin Output { get; set; }

        public void SetInput(int i, bool value)
        {
            Inputs[i].Value = value;
        }

        public bool GetOutput()
        {
            return Output.Value;
        }

        public LogicGate()
        {
            Inputs = new List<Pin>();
        }
    }

    public class AndGate : LogicGate
    {
        public Transistor A = new Transistor();
        public Transistor B = new Transistor();

        public AndGate() : base()
        {
            Inputs.Add(A.Base);
            Inputs.Add(B.Base);
            Output = B.Emitter;

            A.Collector.Value = true;
            A.Emitter = B.Collector;
        }
    }

    public class OrGate : LogicGate
    {
        public Transistor A = new Transistor();
        public Transistor B = new Transistor();

        private Junction junction = new Junction();

        public OrGate() : base()
        {
            Inputs.Add(A.Base);
            Inputs.Add(B.Base);
            Output = junction;

            A.Collector = B.Collector;
            A.Collector.Value = true;
            B.Collector.Value = true;

            A.Listeners.Add(junction);
            B.Listeners.Add(junction);

            junction.Inputs.Add(A.Emitter);
            junction.Inputs.Add(B.Emitter);
        }
    }
}
