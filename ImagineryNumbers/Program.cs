using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ImagineryNumbers {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("{0}",Math.Sqrt(-9.0));
			Complex comp = Complex.Sqrt(-9.0);
			Console.WriteLine("{0},{1}",comp,comp.Magnitude);
			string magnitude = "Magnitude is the distance of the point from the origin(that is, 0,0, or the point at which the x-axis and the y-axis intersect). ";
			string phase = "Phase is the angle between the real axis and the line drawn from the origin to the point.";
			for(double i = -5;i<=5;++i) {
				for(double r = -5;r<=5;++r) {
					Complex cn = new Complex(r,i);
					Console.Write("({0},{1:0.00},{2:0.00})",cn,cn.Magnitude,cn.Phase);
				}
				Console.WriteLine();
			}
		}
	}
}
