using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI_Exercise.Models
{
    /// <summary>
    /// BusinessIdSpecification class is used for validating a business Id.
    /// One thought was to have a IOrganization interface that Business class would
    /// implement but how would you then do with the DbContext or is there a more
    /// suitable TEntity implementation?
    /// </summary>
    public class BusinessIdSpecification : ISpecification<Business>
    {
        public IEnumerable<string> ReasonsForDissatisfaction { get; }              

        /// <summary>
        /// Checks whether a business Id contains a non-allowed pattern
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool IsSatisfied(Business entity)
        {
            return !ReasonsForDissatisfaction.Any(w=>entity.Id.Contains(w));
        }

        /// <summary>
        /// Strings that are not allowed in the business IDs'
        /// </summary>
        public BusinessIdSpecification()
        {
            ReasonsForDissatisfaction = new List<string> { "456", "1121" };
        }

        /// <summary>
        /// Outpus the starting index length of the dissatisfaction in the business Id
        /// </summary>
        /// <param name="business"></param>
        /// <returns></returns>
        public int[] FindFailedSatisfactionPositions(Business business)
        {
            foreach(string reason in ReasonsForDissatisfaction)
            {
                if (business.Id.Contains(reason))
                {
                    return new int[]{ business.Id.IndexOf(reason), reason.Length};
                }
            }
            return new int[] { };
        }
    }
}
