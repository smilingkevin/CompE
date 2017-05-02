using System;

namespace CompE.Domain
{
    public class Pin : IListener
    {
        public string Label { get; set; }
        public IListener Connection { get; set; }

        protected bool _value;

        public Pin()
        {
            _value = false;
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
                Connection.Update();
            }
        }


        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
