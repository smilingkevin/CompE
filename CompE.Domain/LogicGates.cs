using System.Collections.Generic;

namespace CompE.Domain
{
    public class LogicGate
    {
        public List<InputPin> Inputs { get; set; }
        public OutputPin Output { get; set; }

        public LogicGate()
        {
            Inputs = new List<InputPin>();
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
            A.Emitter.Connection = B.Collector;
        }
    }
}
