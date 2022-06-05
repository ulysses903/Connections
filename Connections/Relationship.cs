using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class Relationship
    {
        public int StartElement { get; private set; }
        public int EndElement { get; private set; }

        public Relationship(int startElement, int endElement)
        {
            StartElement = startElement;
            EndElement = endElement;
        }
    }
}
