using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IParticipant
    {
        string Name { get; set;  }
        int Points { get; set;  }
        IEquiqement equiqement { get; set; }

        TeamColors TeamColor { get; set; }

        enum TeamColors
        {
            red,
            green,
            blue,
        }

    }
}
