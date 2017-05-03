using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompE.Domain;

namespace CompE.Testing
{
    [TestClass]
    public class GateTests
    {
        [TestMethod]
        public void PinConstructor()
        {
            Pin pin = new Pin();
            Assert.AreEqual(pin.Value, false);
            Assert.IsNotNull(pin.Listeners);
            Assert.AreEqual(pin.Listeners.Count, 0);
        }

        [TestMethod]
        public void TransistorConstructor()
        {
            Transistor transistor = new Transistor();
            Assert.IsNotNull(transistor.Base);
            Assert.IsNotNull(transistor.Collector);
            Assert.IsNotNull(transistor.Emitter);
            Assert.AreEqual(transistor.Base.Listeners.Count, 1);
            Assert.AreEqual(transistor.Collector.Listeners.Count, 1);
            Assert.AreEqual(transistor.Emitter.Listeners.Count, 0);

            Assert.AreEqual(transistor.Base.Value, false);
            Assert.AreEqual(transistor.Collector.Value, false);
            Assert.AreEqual(transistor.Emitter.Value, false);

            transistor.Base.Value = true;
            Assert.AreEqual(transistor.Base.Value, true);
            Assert.AreEqual(transistor.Collector.Value, false);
            Assert.AreEqual(transistor.Emitter.Value, false);

            transistor.Base.Value = false;
            transistor.Collector.Value = true;
            Assert.AreEqual(transistor.Base.Value, false);
            Assert.AreEqual(transistor.Collector.Value, true);
            Assert.AreEqual(transistor.Emitter.Value, false);

            transistor.Base.Value = true;
            transistor.Collector.Value = true;
            Assert.AreEqual(transistor.Base.Value, true);
            Assert.AreEqual(transistor.Collector.Value, true);
            Assert.AreEqual(transistor.Emitter.Value, true);
        }

        [TestMethod]
        public void AndGateConstructor()
        {
            AndGate gate = new AndGate();
            Assert.IsNotNull(gate.A);
            Assert.IsNotNull(gate.B);
            Assert.AreEqual(gate.A.Emitter, gate.B.Collector);

            gate.SetInput(0, false);
            gate.SetInput(1, false);
            Assert.AreEqual(gate.GetOutput(), false);

            gate.SetInput(0, true);
            gate.SetInput(1, false);
            Assert.AreEqual(gate.GetOutput(), false);

            gate.SetInput(0, false);
            gate.SetInput(1, true);
            Assert.AreEqual(gate.GetOutput(), false);

            gate.SetInput(0, true);
            gate.SetInput(1, true);
            Assert.AreEqual(gate.GetOutput(), true);
        }

        [TestMethod]
        public void OrGateConstructor()
        {
            OrGate gate = new OrGate();
            Assert.IsNotNull(gate.A);
            Assert.IsNotNull(gate.B);
            Assert.AreEqual(gate.A.Collector, gate.B.Collector);

            gate.SetInput(0, false);
            gate.SetInput(1, false);
            Assert.AreEqual(gate.GetOutput(), false);

            gate.SetInput(0, true);
            gate.SetInput(1, false);
            Assert.AreEqual(gate.GetOutput(), true);

            gate.SetInput(0, false);
            gate.SetInput(1, true);
            Assert.AreEqual(gate.GetOutput(), true);

            gate.SetInput(0, true);
            gate.SetInput(1, true);
            Assert.AreEqual(gate.GetOutput(), true);
        }
    }
}
