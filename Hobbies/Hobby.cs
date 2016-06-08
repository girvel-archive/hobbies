using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobbies {
    public class Hobby {
        public string Name { get; set; }
        public int UsesN { get; set; }

        public Hobby(string name, int usesN = 0) {
            Name = name;
            UsesN = usesN;
        }

        public override string ToString() => Name;
    }
}
