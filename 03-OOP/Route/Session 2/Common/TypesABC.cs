using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    internal class TypeA
    {
        private int A;
        private protected int X;
        protected int Y;
        internal protected int Z;
    }

    public class TypeB
    {
        public static void TEST()
        {
            TypeA typeA = new TypeA();         // I can use TypeA class here because it's internal class can be used inside the project
                                               // but if we want to use it outside the project in other project in the solution , then
                                               // it must be public class 

            // typeA.X = 1;         // not accessable 
            // typeA.Y = 1;         // not accessable 
            typeA.Z = 1;            // Accessable because it is internal protected 
        }
    }

    internal class TypeC : TypeA
    {
        public TypeC()
        {
            X = 1;         // Can be used 
            Y = 1;         // Can be used 
            Z = 1;         // can be used (regardless of assembly , it has internal protected access modifier)
        }
    }
}