using System;
using System.Transactions;
using static System.Math;
using static System.DateTime;

namespace D00_ex00
{
    class Program
    {
        static void Main(string[] args)
        {
            //double sum = double.Parse(args[0]);
            //double rate = double.Parse(args[1]);
            //int term = Int32.Parse(args[2]);
            //int selectedMonth = Int32.Parse(args[3]);
            //double payment = Double.Parse(args[4]);  

            double sum = 1000000;
            double rate = 12;
            int term = 10;
            int selectedMonth = 5;
            double payment = 100000;
            
            //Console.WriteLine(NormalPay(term, sum, rate));
            Console.WriteLine(LessPay(term, sum, rate, selectedMonth, payment));
        }

        static double NormalPay(int term, double sum, double rate)
        {
            var currentDate = DateTime.Parse("2021-05-01");
            double daysPeriod = 0;
            double everyMonthPercent = 0;
            double res = 0;
            double everyMonthPay = 0;
            double ostatok = sum;
            double od = 0;
            
            Console.WriteLine("Date          month                OD                     %            Ostatok");
            for (var i = 0; i < term; i++)
            {
                daysPeriod = (currentDate.AddMonths(1) - currentDate).TotalDays;
                everyMonthPercent = EveryMonthPercent(ostatok, rate, Int32.Parse(daysPeriod.ToString()), currentDate);
                everyMonthPay = EveryMonthPay(sum, rate/12/100 ,term);
                ostatok -= (everyMonthPay- everyMonthPercent);
                res += everyMonthPercent;
                od = everyMonthPay - everyMonthPercent;
                Console.WriteLine(currentDate.AddMonths(1).ToString("dd.MM.yyyy")+ "   " + everyMonthPay +  "   "+ od +"     " + everyMonthPercent + "   " + ostatok );
                currentDate = currentDate.AddMonths(1);
            }

            return res;
        }
        
        static double LessPay(int term, double sum, double rate, int selectMonth, double payment)
        {
            var currentDate = DateTime.Parse("2021-05-01");
            double daysPeriod = 0;
            double everyMonthPercent = 0;
            double res = 0;
            double everyMonthPay = 0;
            double ostatok = sum;
            double od = 0;
            
            
            Console.WriteLine("Date          month                OD                     %            Ostatok");
            for (var i = 0; i < term; i++)
            {
                if (i == selectMonth-1)
                {
                    ostatok -= payment;
                    sum -= payment;
                }
                daysPeriod = (currentDate.AddMonths(1) - currentDate).TotalDays;
                everyMonthPercent = EveryMonthPercent(ostatok, rate, Int32.Parse(daysPeriod.ToString()), currentDate);
                everyMonthPay = EveryMonthPay(sum, rate/12/100 ,term);
                ostatok -= (everyMonthPay- everyMonthPercent);
                res += everyMonthPercent;
                od = everyMonthPay - everyMonthPercent;
                Console.WriteLine(currentDate.AddMonths(1).ToString("dd.MM.yyyy")+ "   " + everyMonthPay +  "   "+ od +"     " + everyMonthPercent + "   " + ostatok );
                currentDate = currentDate.AddMonths(1);
            }

            return res;
        }

        static double LessDate()
        {
            return 0;
        }

        static double EveryMonthPay(double sum, double monthRate, int term)
        {
            return sum * monthRate * Pow(1 + monthRate, term) / (Pow(1 + monthRate, term) - 1);
        }

        static double EveryMonthPercent(double sum, double rate, int daysPeriod, DateTime current )
        {
            return (sum * rate * daysPeriod) / (100 * (DateTime.IsLeapYear(current.Year) ? 366 : 365));
        }

        double CountMonth(double monthRate, double sumPay, double sum)
        {
            return Log(monthRate + 1, sumPay / sumPay - monthRate * sum);
        }
        
        // get parametrs.
        // create function of everyMonthPay
    }
}