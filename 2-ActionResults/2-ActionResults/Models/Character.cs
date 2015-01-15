using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace _2_ActionResults.Models
{
    [DataContract(Name = "Character", Namespace = "_2_ActionResults.Models")]
    public class Character
    {
        [DataMember(Name = "Name")]
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember(Name = "Level")]
        private int _level;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        [DataMember(Name = "HealthPoints")]
        private int _healthPoints;

        public int HealthPoints
        {
            get { return _healthPoints; }
            set { _healthPoints = value; }
        }

        [DataMember(Name = "Attributes")]
        private Dictionary<string, int> _attributes;
        public Dictionary<string, int> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        public Character()
        {
            Random _random = new Random();
            Name = "Blake Rollins";
            Level = _random.Next(40) + 1;
            HealthPoints = _random.Next(100) + 1;   

            Attributes = new Dictionary<string, int>();
            Attributes.Add("IQ", _random.Next(27) + 3);
            Attributes.Add("ME", _random.Next(27) + 3);
            Attributes.Add("MA", _random.Next(27) + 3);
            Attributes.Add("PS", _random.Next(27) + 3);
            Attributes.Add("PP", _random.Next(27) + 3);
            Attributes.Add("PE", _random.Next(27) + 3);
            Attributes.Add("PB", _random.Next(27) + 3);
            Attributes.Add("Spd", _random.Next(27) + 3);
        }

        public override string ToString()
        {
            return "Name: " + Name +
                "  Level: " + Level +
                "  HealthPoints: " + HealthPoints +

                "  IQ: " + Attributes["IQ"] +
                "  ME: " + Attributes["ME"] +
                "  MA: " + Attributes["MA"] +
                "  PS: " + Attributes["PS"] +
                "  PP: " + Attributes["PP"] +
                "  PE: " + Attributes["PE"] +
                "  PB: " + Attributes["PB"] +
                "  Spd: " + Attributes["Spd"];
        }

    }
}