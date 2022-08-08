using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Model
{
    internal class Model
    {
        List<Turnout> turnouts = new List<Turnout>();
        List<Signal> signals = new List<Signal>();
        TurnoutStepper stepper = new TurnoutStepper();

        public Model()
        {
            turnouts.Add(new Turnout(1));
            turnouts.Add(new Turnout(2));
            turnouts.Add(new Turnout(4));
        }

        private static Model instance = null;
        private static readonly object instanceLock = new object();
        public static Model Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new Model();
                    }
                    return instance;
                }
            }
        }

        internal async void SetTurnout(int number, Turnout.Direction direction)
        {
            await Task.Run(() =>
            {
                Turnout turnout = turnouts.Find(x => x.number == number);
                if (turnout != null) stepper.SetTurnout(turnout, direction);
            });
        }

        internal void SetRoute(char startSignal, char endSignal)
        {

        }

        internal void SetSignalFree(char signal)
        {

        }

        internal void SetSignalStop(char signal)
        {

        }

        internal void Stop()
        {
            Z21.Z21.Instance.Stop();
        }

        internal void DccOn()
        {
            Z21.Z21.Instance.PowerOn();
        }

        internal Turnout.Direction GetTurnoutDirection(int number)
        {
            Turnout turnout = turnouts.Find(x => x.number == number);
            if (turnout != null) return turnout.DirectionProperty;
            else throw new NullReferenceException("turnout referenced null");
        }
    }
}
