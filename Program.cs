using Imposto.Entities;
using System.Globalization;
using System;
using System.Collections.Generic;

class Program
{
    private static void Main(string[] args)
    {
        List<TaxPayer> list = new List<TaxPayer>();

        Console.Write("Enter the number of tax payers: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Tax payer #{i} data: ");
            Console.Write("Individual or Company (I/C)? ");
            char ch = char.Parse(Console.ReadLine().ToUpper());
            while(ch != 'I' && ch != 'C')
            {
                Console.WriteLine("Tax Payer Invalid!");
                Console.Write("Individual or Company (I/C)? ");
                ch = char.Parse(Console.ReadLine().ToUpper());

                if(ch == 'E')
                {
                    return;
                }
            }
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Anual Income: ");
            double income = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            if(ch == 'I')
            {               
                Console.Write("Health Expenditures: ");
                double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                list.Add(new Individual(name, income, healthExpenditures));
            }
            else
            {
                Console.Write("Number of Employees: ");
                int employees = int.Parse(Console.ReadLine());
                list.Add(new Company(name, income, employees));
            }
            Console.WriteLine();
        }
        double sum = 0;
        Console.WriteLine("TAXES PAID:");
        foreach(TaxPayer tp in list)
        {
            double tax = tp.Tax();
            Console.WriteLine($"{tp.Name} : {tp.Tax().ToString("F2", CultureInfo.InvariantCulture)}");
            sum += tax;
        }
        Console.Write($"TOTAL TAXES: {sum.ToString("F2", CultureInfo.InvariantCulture)}");
    }
}