using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Wnmp.Forms;

namespace Wnmp
{
    class Redis : Wnmp
    {
        public Redis(Label status_label) : base(status_label)
        {
            progLogSection = Log.LogSection.WNMP_REDIS;
        }
    }
}
