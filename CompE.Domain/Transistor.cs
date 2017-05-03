using System;
using System.Collections.Generic;

namespace CompE.Domain
{
    public class Transistor : IListener, ISpeaker
    {
        public Pin Base { get; set; }
        public Pin Emitter { get; set; }
        public Pin Collector { get; set; }
        public List<IListener> Listeners { get; set; }

        public Transistor()
        {
            Base = new Pin();
            Emitter = new Pin();
            Collector = new Pin();
            Listeners = new List<IListener>();

            Base.Listeners.Add(this);
            Collector.Listeners.Add(this);    
        }

        public void Update()
        {
            Emitter.Value = Base.Value && Collector.Value;
            Listeners.ForEach(x => x.Update());
        }
    }
}
