using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByndysoftTestNet
{
    public class Program
    {
        static void Main(string[] args)
        {
            var array = new double[] { double.NaN };
            Exception exception = null;
            try
            {
                var result = Program.SummMinimumElementOfArray(array);
            }
            catch (NotFiniteNumberException e)
            {
                exception = e;
            }
        }

        public static double SummMinimumElementOfArray(IEnumerable<double> array)
        {
            if (array.Count() == 0)
                throw new NullReferenceException("Пустой массив");
            if (array == null)
                throw new NotFiniteNumberException();
            if (array.Count() == 1)
                return array.Where(x => !double.IsNaN(x)).Sum();
            return GetSumm(FindMinElement(array)); 
        }

        private static double[] FindMinElement(IEnumerable<double> array)
        {
            var min1 = array.Where(x => !double.IsNaN(x)).Min();
            double min2;
            try
            {
                min2 = array.Where(x => !double.IsNaN(x)).Where(x => x != min1).Min();
            }
            catch (Exception ex)
            {
                min2 = 0;
            }
            return new double[] { min1, min2 };
        }

        private static double GetSumm(IEnumerable<double> array) => array.Sum();
    }
}
