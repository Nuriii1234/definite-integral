using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace definite_integral
{

    internal class Tdefinite_integral
    {
        double Function(double x)
        {
            double y = x / (Math.Pow(x, 4) + 81);
            return y;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        double Rectangle_method(double X0, double X1, double h)
        {
            double F = 0;
            for (double i = X0; i <= X1; i +=h)
            {
                F += Function((i + i + h) / 2);
            }
            Console.WriteLine("Rectangle_method, h = " + h + ", F = " + h * F);
            return h * F;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        double Trapezoid_method(double X0, double X1, double h)
        {
            double F = 0;
            for (double i = X0; i <= X1; i += h)
            {
                if (i == X0 || i == X1)
                {
                    F += Function(i) / 2;
                }
                else 
                {
                    F += Function(i);
                }
            }
            Console.WriteLine("Trapezoid_method, h = " + h + ", F = " + h * F);
            return h * F;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        double Simpson_method(double X0, double X1, double h)
        {
            double F = 0;
            for (int i = 0; i <= Math.Abs(X0 - X1) / h; i++)
            {
                double X = i * h;
                if (X == X0 || X == X1)
                {
                    F += Function(X);
                }
                else if (i % 2 != 0)
                {
                    F += 4 * Function(X);
                }
                else
                {
                    F += 2 * Function(X);
                }
            }
            Console.WriteLine("Simpson_method, h = " + h + ", F = " + h * F / 3);
            return h * F / 3;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        double Error_Rectangle_method(double X0, double X1, double h)
        {
            double R;
            R = (X1 - X0) * h * h * 0.0125 / 24;
            Console.WriteLine("Error_Rectangle_method, h = " + h + ", R = " + R);
            return R;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        double Error_Trapezoid_method(double X0, double X1, double h)
        {
            double R;
            R = (X1 - X0) * h * h * 0.0125 / 12;
            Console.WriteLine("Error_Trapezoid_method, h = " + h + ", R = " + R);
            return R;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        double Error_Simpson_method(double X0, double X1, double h)
        {
            double R;
            R = (X1 - X0) * Math.Pow(h,4) * 0.0291 / 180;
            Console.WriteLine("Error_Simpson_method, h = " + h + ", R = " + R);
            return R;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        double Runge_Romberg_Richardson_method(double X0, double X1, double h1, double h2)
        {
            double I = 0;
            Console.WriteLine("Choose a method:" + "\n" + "1. Rectangle method" + "\n" + "2. Trapezoid method" + "\n" + "3. Simpson method");
            int w = int.Parse(Console.ReadLine());
            switch (w)
            {
                case 1:
                    {
                        I = Rectangle_method(X0, X1, h2) + ((Rectangle_method(X0, X1, h2) - Rectangle_method(X0, X1, h1)) / (Math.Pow(2,2) - 1));    
                        Console.WriteLine("Rectangle method, I = " + I);
                        Absolute_mistake(I);
                        break;
                    }
                case 2:
                    {
                        I = Trapezoid_method(X0, X1, h2) + ((Trapezoid_method(X0, X1, h2) - Trapezoid_method(X0, X1, h1)) / (Math.Pow(2, 2) - 1));
                        Console.WriteLine("Trapezoid method, I = " + I);
                        Absolute_mistake(I);
                        break;
                    }
                case 3:
                    {
                        I = Simpson_method(X0, X1, h2) + ((Simpson_method(X0, X1, h2) - Simpson_method(X0, X1, h1)) / (Math.Pow(2, 4) - 1));
                        Console.WriteLine("Simpson method, I = " + I);
                        Absolute_mistake(I);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("default");
                        break;
                    }
            }
            return I;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        void Absolute_mistake(double I)
        {
            Console.WriteLine(Math.Abs(0.0232347 - I));
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        void Method(double X0, double X1, double h1, double h2)
        {
            Rectangle_method(X0, X1, h1);
            Trapezoid_method(X0, X1, h1);
            Simpson_method(X0, X1, h1);
            Console.WriteLine(" ");
            Rectangle_method(X0, X1, h2);
            Trapezoid_method(X0, X1, h2);
            Simpson_method(X0, X1, h2);
            Console.WriteLine(" ");
            Error_Rectangle_method(X0, X1, h1);
            Error_Trapezoid_method(X0, X1, h1);
            Error_Simpson_method(X0, X1, h1);
            Console.WriteLine(" ");
            Error_Rectangle_method(X0, X1, h2);
            Error_Trapezoid_method(X0, X1, h2);
            Error_Simpson_method(X0, X1, h2);
            Console.WriteLine(" ");
            Console.WriteLine("The value of the integral: " + 0.0232347);
            Runge_Romberg_Richardson_method(X0, X1, h1, h2);

        }
        //-------------------------------------------------------------------------------------------------------------------------------------------
        public void Start()
        {
            double X0, X1, h1, h2;
            /*
            Console.WriteLine("Enter a value X0");
            X0 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a value X1");
            X1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a value h1");
            h1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a value h2");
            h2 = double.Parse(Console.ReadLine());
            */
            X0 = 0;
            X1 = 2;
            h1 = 0.5;
            h2 = 0.25;
            Method(X0, X1, h1, h2);
        }
    }
}
