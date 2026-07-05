using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindConsoleApp
{
    internal class Rectangle
    {
        private readonly double W, H;

        // new way for writing the ctor using Deconstruct 
        // Note : this is valid even if we didn't make the "Deconstruct" function , it's always available to be used 
        public Rectangle(int _w, int _h) => (W, H) = (_w, _h);            
        // {
        //     W = _w;
        //     H = _h;
        // }
        public override string ToString() => $"Width: {W}, Height: {H}";

        // It's a normal function called "Deconstruct" , it's name gives it an advantage of deconstructing objects ! 
        public void Deconstruct(out double _w, out double _h)
        {
            _w = W;
            _h = H;
        }
    }
}
