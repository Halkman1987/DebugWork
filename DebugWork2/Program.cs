using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FinalTask
{
    class Program
    {

        static void Main()
        {
           

        }


    }
    class MotherBoard
    {
        public string Name ; 
    }
    class SystemUnit
    {
        private MotherBoard motherBoard;

        public SystemUnit(MotherBoard motherBoard)
        {
            this.motherBoard = motherBoard;
        }
        public SystemUnit()
        {
            motherBoard = new MotherBoard();
        }
    }

}

