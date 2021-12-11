using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_04._12._21
{
    public class Book
    {
        private string name;
        private string author;
        private string publisher;
        public string Name { get { return name; } set { name = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string Publisher { get { return publisher; } set { publisher = value; } }
        public override string ToString()
        {
            return $"{Name}, {Author}, {Publisher}";
        }

    }
}
