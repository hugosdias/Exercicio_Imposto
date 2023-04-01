using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imposto.Entities
{
    public class Company : TaxPayer
    {
        public int NumberOfEmployees { get; set; }
        public Company(string name, double anualIncome, int numberOfEmployee) : base(name, anualIncome)
        {
            Name = name;
            AnualIncome = anualIncome;
            NumberOfEmployees = numberOfEmployee;
        }

        public override double Tax()
        {
            if(NumberOfEmployees > 14)
            {
                return AnualIncome * 0.14;
            }
            else
            {
                return AnualIncome * 0.16;
            }
        }
        
    }
}