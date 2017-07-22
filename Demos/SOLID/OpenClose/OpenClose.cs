using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClose
{
    class OpenClose
    {
        static void Main(string[] args)
        {
            var data = new ShopService();
            string result = data.Buy("Kaffee", "Bar", 10);
            result = data.Buy("Auto", "Bank", 100000);
        }
    }

    public class ShopService
    {
        public string Buy(string what, string payment, int money)
        {
            if (what == "Kaffee")
                if (money > 6)
                    return "1 Pfund Kaffee";
                else
                    return "Geld reicht nicht";
            else if (what == "Auto")
                if (money > 80000 && payment == "Bank")
                    return "1 tolles Auto";
                else
                    return "Zuwenig Geld oder nur über Bank zu kaufen";
            else return "Nicht verfügbar";
        }
    }
}
