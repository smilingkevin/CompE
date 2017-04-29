namespace CompE.Domain
{
    public class Transistor
    {
        private InputPin _base = new InputPin();
        private InputPin _collector = new InputPin();
        private OutputPin _emitter = new OutputPin();

        public Transistor()
        {
        }

        public InputPin Base
        {
            get
            {
                return _base;
            }
            set
            {
                _base = value;
                _emitter.Value = _base.Value && _collector.Value;
            }
        }
        public InputPin Collector
        {
            get
            {
                return _collector;
            }
            set
            {
                _collector = value;
                _emitter.Value = _base.Value && _collector.Value;
            }
        }
        public OutputPin Emitter {
            get
            {
                return _emitter;
            }
            set
            {
                _emitter = value;
            }
        }
    }
}
