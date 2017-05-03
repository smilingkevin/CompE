using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompE.Domain
{
    public interface ISpeaker
    {
        List<IListener> Listeners { get; set; }
    }
}
