using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityWarehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Terminal Terminal = new Terminal();
            Terminal.SetPricing("A", 2M, 7M,4);
            Terminal.SetPricing("B", 12M);
            Terminal.SetPricing("C", 1.25M,6M,6);
            Terminal.SetPricing("D", 0.15M);

            // Test case ABCDABAA $32.40

            Terminal.Scan("A");
            Terminal.Scan("B");
            Terminal.Scan("C");
            Terminal.Scan("D");
            Terminal.Scan("A");
            Terminal.Scan("B");
            Terminal.Scan("A");
            Terminal.Scan("A");

            Console.WriteLine(string.Format("The Total for ABCDABAA is: {0:C}", Terminal.Total().ToString("c", new CultureInfo("en-US"))));

            Terminal.NextCustomer();

            // Test case CCCCCCC $7.25

            Terminal.Scan("C");
            Terminal.Scan("C");
            Terminal.Scan("C");
            Terminal.Scan("C");
            Terminal.Scan("C");
            Terminal.Scan("C");
            Terminal.Scan("C");

            Console.WriteLine(string.Format("The Total for CCCCCCC is: {0:C}", Terminal.Total().ToString("c", new CultureInfo("en-US"))));

            Terminal.NextCustomer();

            // Test case ABCD $15.40 
            Terminal.Scan("A");
            Terminal.Scan("B");
            Terminal.Scan("C");
            Terminal.Scan("D");

            Console.WriteLine(string.Format("The Total for ABCD is: {0:C}", Terminal.Total().ToString("c", new CultureInfo("en-US"))));
        }
    }
}
