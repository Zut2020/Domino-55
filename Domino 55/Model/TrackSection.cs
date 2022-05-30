using Domino_55.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.Model
{
    internal class TrackSection
    {
        public TrackFeedbackController controller;
        public readonly string Name;

        public TrackSection(string name)
        {
            Name = name;
        }

        private bool occupied;
        private bool locked;

        public void BindController(TrackFeedbackController controller)
        {
            this.controller = controller;
        }

        internal void Lock()
        {
            controller.Lock();
            locked = true;
        }

        internal void Release()
        {
            controller.Release();
            locked = false;
        }
    }
}
