using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobbies {
    public static class FileHelper {
        public static string ToStr(IEnumerable<Hobby> hobbies) {
            return hobbies.Aggregate("", (current, hobby) => current + $"{hobby.UsesN}:{hobby.Name}\n");
        }

        public static IEnumerable<Hobby> FromStr(string str) {
            Console.WriteLine(str);
            return str.Split('\n').Select(hobby => new Hobby(hobby.Split(':')[0], Convert.ToInt32(hobby.Split(':')[1])));
        }
    }
}
