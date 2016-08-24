using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Barcode_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string BarcodePrefix = "25160000";
            StreamWriter sw = new StreamWriter("barcode_cards.txt");
            sw.WriteLine("Номер карты\t\tШтрихкод");
            for (int i = 1; i <= 5000; i++)
            {
                string BarcodeResult = "";
                string TempBarcode = "";
                int a = 0;
                int b = 0;
                int c = 0;
                if (i < 10)
                {
                    TempBarcode = BarcodePrefix + "000" + i;
                }
                else if (i < 100)
                {
                    TempBarcode = BarcodePrefix + "00" + i;
                }
                else if (i < 1000)
                {
                    TempBarcode = BarcodePrefix + "0" + i;
                }
                else
                {
                    TempBarcode = BarcodePrefix + i;
                }
                
                for (int j = 0; j < TempBarcode.Length; j++)
                {
                    if (j % 2 != 0 )
                    {
                        a += (int)char.GetNumericValue(TempBarcode[j]);
                    }
                    else
                    {
                        b += (int)char.GetNumericValue(TempBarcode[j]);
                    }
                }
                string Sum = (a * 3 + b).ToString();
                c = 10 - ((int)char.GetNumericValue(Sum[Sum.Length - 1]));
                if (c == 10)
                {
                    c = 0;
                }
                BarcodeResult = TempBarcode + c;
                sw.Write(Convert.ToString(i));
                sw.Write("\t\t\t");
                sw.WriteLine(BarcodeResult);
            }
            sw.Close();
        }
    }
}
