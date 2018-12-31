using System;
using System.Collections.Generic;
namespace Scouter.Structs
{
    public struct NameValPair
    {
        public string Name;
        public int Val;
        public NameValPair(string name, int val)
        {
            Name = name;
            Val = val;
        }
    }
}
