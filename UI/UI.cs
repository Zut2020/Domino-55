using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_55.UI
{
    public class UI
    {
        private static UI instance = null;
        private static readonly object instanceLock = new object();
        public static UI Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UI();
                    }
                    return instance;
                }
            }
        }

        internal MainWindow mainWindow;
    }
}
