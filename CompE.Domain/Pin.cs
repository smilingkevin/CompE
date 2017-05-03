using System;
using System.Collections.Generic;
using System.Linq;

namespace CompE.Domain
{
    public class Pin : ISpeaker
    {
        public string Label { get; set; }
        public List<IListener> Listeners { get; set; }

        protected bool _value;

        public Pin()
        {
            _value = false;
            Listeners = new List<IListener>();
        }

        public bool Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                Listeners.ForEach(x => x.Update());
            }
        }
    }

    public class Junction : Pin, IListener
    {
        public List<Pin> Inputs { get; set; }

        public Junction()
        {
            Inputs = new List<Pin>();
        }

        public void Update()
        {
            Value = Inputs.Exists(x => x.Value == true);
        }
    }
}
