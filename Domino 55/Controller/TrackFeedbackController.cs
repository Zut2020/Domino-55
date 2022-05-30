using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Domino_55.Model;
using Domino_55.Views;

namespace Domino_55.Controller
{
    internal class TrackFeedbackController
    {
        TrackSection trackSection;
        List<TrackFeedbackView> views = new List<TrackFeedbackView>();

        public void BindTrackSection(TrackSection trackSection)
        {
            this.trackSection = trackSection;
        }

        public void AddView(TrackFeedbackView view)
        {
            views.Add(view);
        }

        public void AddViews(IEnumerable<TrackFeedbackView> views)
        {
            this.views.AddRange(views);
        }

        public void Lock()
        {
            foreach (TrackFeedbackView view in views)
            {
                view.Lock();
            }
        }

        public void Release()
        {
            foreach (TrackFeedbackView view in views)
            {
                view?.Release();
            }
        }
    }
}
