using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Model 
{
    public class Driver : IParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public IEquiqement equiqement { set; get; }
        public IParticipant.TeamColors TeamColor { get; set; }


        public Driver(string name, int points, IEquiqement equiqement, IParticipant.TeamColors teamColor)
        {
           this.Name = name;
           this.Points = points; 
           this.equiqement = equiqement;   
           this.TeamColor = teamColor;

        }
    }
}
