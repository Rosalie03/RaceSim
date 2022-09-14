using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IParticipant
    {
        string Name { get; }
        int Points { get; }
        IEquiqement equiqement { get; }

        TeamColors TeamColor { get; }

        enum TeamColors
        {
            red,
            green,
            blue,
        }

    }
}
