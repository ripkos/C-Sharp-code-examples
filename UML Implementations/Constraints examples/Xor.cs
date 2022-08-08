using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp4
{
    public class MiddleMan
    {
        private static List<List<string>> xors = new List<List<string>>() { 
        new List<string>()
        {
            typeof(LeftMan).Name,
            typeof(RightMan).Name
        }
        };
        private static bool IsViolatingXOR(MiddleMan m, string s)
        {
            var subject = m.GetType().GetProperty(s);
            if(subject is null)
            {
                throw new ArgumentNullException($"Invalid XOR implementation - No property {s}!");
            }
            var callingPropertyName = subject.Name;
            foreach (var list in xors)
            {
                if(list.Contains(callingPropertyName) && list.Count > 1)
                {
                    foreach (string propertyName in list)
                    {
                        if (propertyName!= callingPropertyName)
                        {
                            var possibleConflictProperty = m.GetType().GetProperty(propertyName);
                            if (possibleConflictProperty is null)
                            {
                                throw new ArgumentNullException($"Invalid XOR implementation - can not find property with name {propertyName}");
                            }
                            if(possibleConflictProperty.GetValue(m) is not null)
                            {
                                return true;
                            }


                        }
                    }
                }
            }
            return false;
        }
        private LeftMan _LeftMan;
        public LeftMan LeftMan { get => _LeftMan; set {
                if (value == null)
                {
                    throw new ArgumentNullException($"Passed null as a value!");
                }
                if(value!= _LeftMan)
                {
                    if (IsViolatingXOR(this, value.GetType().Name))
                    {
                        throw new ArgumentException($"Violating xor for {value} in {this} !");
                    }
                    _LeftMan = value;
                    value.MiddleMan = this;
                }

            } }
        private RightMan _RightMan;
        public RightMan RightMan { get => _RightMan; set {
                if (value == null)
                {
                    throw new ArgumentNullException($"Passed null as a value!");
                }
                if (value != _RightMan) {
                    if (IsViolatingXOR(this, value.GetType().Name))
                    {
                        throw new ArgumentException($"Violating xor for {value} in {this} !");
                    }
                    _RightMan = value;
                    value.MiddleMan = this;
                }

            } }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    public class LeftMan
    {
        public override string ToString()
        {
            return Name;
        }
        private MiddleMan _MiddleMan;
        public MiddleMan MiddleMan { get => _MiddleMan; set {
            if (value == null)
                {
                    throw new ArgumentNullException($"Passed null as a value!");
                }
            if (value != _MiddleMan)
                {
                    value.LeftMan = this;
                    if (_MiddleMan != null)
                    {
                        _MiddleMan.LeftMan = null;
                    }
                    _MiddleMan = value;
                }
            } }
        public string Name { get; set; }
    }
    public class RightMan
    {
        public override string ToString()
        {
            return Name;
        }
        private MiddleMan _MiddleMan;
        public MiddleMan MiddleMan
        {
            get => _MiddleMan; set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"Passed null as a value!");
                }
                if (value != _MiddleMan)
                {
                    value.RightMan = this;
                    if (_MiddleMan != null)
                    {
                        _MiddleMan.RightMan = null;
                    }

                    _MiddleMan = value;
                }
            }
        }
        public string Name { get; set; }
    }

}
