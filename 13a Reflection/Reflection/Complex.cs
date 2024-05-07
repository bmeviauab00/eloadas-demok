
namespace MiscDemos
{
    public class Complex
    {
        public double Re;
        public double Im;

        public Complex()
        { }

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public void Print()
        {
            Console.WriteLine("{0}+{1}j", Re, Im);
        }
    }
}
