using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_2.Binding
{
	internal class ClassA
	{
        public int A { get; set; }
        public ClassA(int _A)
        {
            A = _A;
        }
		public void MyFun01()
		{
            Console.WriteLine("I am Base , [Parent]");
        }
		public virtual void MyFun02()
		{
			Console.WriteLine($"ClassA, A = {A}");
		}
	}
	internal class ClassB : ClassA
	{
		public int B { get; set; }
		public ClassB(int _A , int _B) : base(_A)
		{
			B = _B;
		}
		// Apply overriding using new keyword
		// static binding method
		public new void MyFun01()
		{
			Console.WriteLine("I am derived [Child]");
		}
		// Apply overriding using override keyword
		// must be non private virtual method
		// dynamic binding method
		public override void MyFun02()
		{
			Console.WriteLine($"ClassB, A = {A}, B = {B}");
		}
	}
	internal class ClassC : ClassB
	{

		// Important note : ClassC has 2 Parents , ClassB as a [Direct Parent] and ClassA as an [Indirect Parent] 

		public int C { get; set; }
        public ClassC(int _A , int _B , int _C) : base(_A, _B)
        {
			C = _C;
        }
		public new void MyFun01()
		{
			Console.WriteLine("I am derived [Grand Child]");
		}
		public override void MyFun02()
		{
			Console.WriteLine($"ClassC, A = {A}, B = {B}, C = {C}");
		}
	}

	internal class ClassD : ClassC
	{
        public int D { get; set; }
        public ClassD(int _A, int _B, int _C , int _D) : base(_A, _B , _C)
		{
           D = _D;
        }
		public new void MyFun01()
		{
            Console.WriteLine("Grand Grand Child");
        }
		public new virtual void MyFun02()                 // Very important , new virtual .. here we break the chain and start a new one 
		{
			Console.WriteLine($"ClassD, A = {A}, B = {B}, C = {C}, D = {D}");
		}
	}

	// Note : ClassE here has 4 parents : ClassD as a [Direct Parent] & ClassA , ClassB , ClassC as an [Indirect Parents] 
	internal class ClassE : ClassD
	{
		public int E { get; set; }
        public ClassE(int _A, int _B, int _C, int _D , int _E) : base(_A, _B, _C , _D)
		{
            E = _E;
        }

		public new void MyFun01()
		{
			Console.WriteLine("Grand Grand Grand Child");
		}

		// Note : if MyFun02 was not virtual in the last ClassD .. we cannot override it here , instead we can override the last 
		//        virtual one that was in ClassC .. So take care and see what is the function that we are overriding now
		//        now we are overriding the function that is in ClassD (because it's virtual .. ) 
		public override void MyFun02()
		{
			Console.WriteLine($"ClassE, A = {A}, B = {B}, C = {C}, D = {D}, E = {E}");
		}
	}
}
