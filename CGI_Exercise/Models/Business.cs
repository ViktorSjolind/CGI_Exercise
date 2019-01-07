using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI_Exercise.Models
{
    public class Business : DbContext
    {
        public string Id { get; }

        public Business(string id)
        {
            Id = id;
        }
        
    }
}
