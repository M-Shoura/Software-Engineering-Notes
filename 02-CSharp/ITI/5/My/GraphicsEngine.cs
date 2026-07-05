using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace My
{
    internal class GraphicsEngine
    {
        #region Version 1 

        // private int Data { get; } 
        // private GraphicsEngine(int data)          // this ctor cannot be used for making objects outside the class 
        // {                                        // but can be used inside a method in the same class ! 
        //     Data = data;
        // }
        // 
        // public static GraphicsEngine Obj = null; 
        // // variable that has a scope for the whole class , remembers it's value and not tied to a specific object 
        // public static GraphicsEngine GetObject()           // must be a static function to be used outside with the name of the class
        // {
        //     if (Obj == null)
        //         Obj = new GraphicsEngine(123);
        //     return Obj;
        // }

        #endregion

        #region Version 2

        // private int Data { get; } 
        // private GraphicsEngine(int data)           
        // {                                         
        //     Data = data;
        // }
        // public static GraphicsEngine Obj = null;
        // static GraphicsEngine()
        // {
        //     Obj = new GraphicsEngine(123);
        // }
        // public static GraphicsEngine SingleTon { get => Obj; }

        #endregion

        #region Version 3

        private int Data { get; } 
        private GraphicsEngine(int data)           
        {                                         
            Data = data;
        }
        public static GraphicsEngine Singleton { get; } = new GraphicsEngine(123);
        // here this is a static property 
        // some things happened when writing this code 
        // - we have a static backing field now 
        // - we now have a static ctor , that has the first line initializing the static field
        // - we have a getter for this property

        #endregion
    }
}
