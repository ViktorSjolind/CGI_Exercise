using CGI_Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI_Exercise
{
    /// <summary>
    /// Application that checks if a business id contains an illegal pattern.
    /// That's how interpreted the exercise. 
    /// Author: Viktor Sjölind
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<Business> businesses = new List<Business>();
            businesses.Add(new Business("FI11111111"));
            businesses.Add(new Business("FI11114563"));
            businesses.Add(new Business("FI11214563"));
            businesses.Add(new Business("FI11314563"));

            BusinessIdSpecification businessIdSpecification = new BusinessIdSpecification();
            int[] matchIndexes;
            bool satisfied;
            foreach (Business business in businesses)
            {
                satisfied = businessIdSpecification.IsSatisfied(business);
                Console.WriteLine($"{business.Id} is satisfied: {satisfied}");

                if (!satisfied)
                {
                    matchIndexes = businessIdSpecification.FindFailedSatisfactionPositions(business);
                    Console.WriteLine($"{business.Id.Substring(matchIndexes[0], matchIndexes[1])}");
                    Console.WriteLine($"[{matchIndexes[0]}],[{matchIndexes[1]}]");
                }
                 
            }
            
        }


    }
}
