using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Domino_55.Views
{
    public  abstract class TrackFeedbackView : UserControl
    {
        public abstract void Lock();
        public abstract void Release();
        public abstract void Occupy();
        public abstract void Free();
    }
}
