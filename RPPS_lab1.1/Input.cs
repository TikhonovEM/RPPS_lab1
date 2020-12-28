using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPPS_lab1._1
{
    public class Input
    {
        public int K { get; set; }
        public decimal[] Sums { get; set; }
        public int[] Muls { get; set; }

        public Output GetOutput()
        {
            var output = new Output();

            output.SumResult = Sums.Sum() * K;

            var multiple = 1;
            foreach(var mul in Muls)
            {
                multiple *= mul;
            }
            output.MulResult = multiple;

            var list = new List<decimal>();
            list.AddRange(Sums.OrderBy(x => x));
            foreach (var mul in Muls.OrderByDescending(x => x))
                list.Add(Convert.ToDecimal(mul));
            /*var sorted = list.OrderBy(x => x);
            output.SortedInputs = sorted.ToArray();*/
            output.SortedInputs = list.ToArray();

            return output;
        }
    }

}
