using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    internal class LineException : Exception
    {
        public int Line { get; set; }

        public LineException(int line, string message) : base(message)
        {
            Line = line;
        }

        public void Print() 
        {
            Console.WriteLine($"A riga {Line} {Message}");
        }
    }
}
