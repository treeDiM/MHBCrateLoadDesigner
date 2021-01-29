#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MHB.CrateLoadDesigner.Engine;
#endregion

namespace MHB.CrateLoadDesigner.Exporters
{
    public abstract class Exporter : IDisposable
    {
        public abstract void Export(Project proj, string outputFilePath);

        public void Dispose()
        {
        }
    }
}
