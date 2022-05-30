using Domino_55.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Model
{
    internal class Route
    {
        public List<TurnoutAction> turnoutList = new List<TurnoutAction>();
        public List<TrackSection> trackSections = new List<TrackSection>();
        private bool firstLock = false;

        public void AddTurnoutAction(TurnoutAction turnoutAction)
        {
            turnoutList.Add(turnoutAction);
        }

        public void AddTrackSection(TrackSection trackSection)
        {
            trackSections.Add(trackSection);
        }

        public async void Lock()
        {

            foreach (TurnoutAction turnoutAction in turnoutList)
            {
                Turnout turnout = turnoutAction.turnout;
                await Task.Run(() =>
                {
                    TurnoutStepper.Instance.SetTurnoutAndLock(turnout, turnoutAction.direction);
                });
            }
            foreach (TrackSection trackSection in trackSections)
            {
                trackSection.Lock();
            }

            firstLock = true;
        }

        public void Release()
        {
            foreach (TurnoutAction turnoutAction in turnoutList)
            {
                turnoutAction.turnout.Release();
            }
            foreach (TrackSection trackSection in trackSections)
            {
                trackSection.Release();
            }
            firstLock = false;
        }
    }
}
