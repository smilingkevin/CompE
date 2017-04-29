namespace CompE.Domain
{
    public enum PinType
    {
        Input,
        Output
    }

    public class Pin
    {
        public string Label { get; set; }
        public PinType Type { get; set; }
        public Pin Connection { get; set; }

        protected bool _value;

        public Pin()
        {
            _value = false;
        }
    }

    public class InputPin : Pin
    {
        public InputPin() : base()
        {
            Type = PinType.Input;
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
            }
        }
    }

    public class OutputPin : Pin
    {
        public OutputPin() : base()
        {
            Type = PinType.Output;
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
                if (Connection != null)
                {
                    ((InputPin)Connection).Value = _value;
                }
            }
        }
    }
}
