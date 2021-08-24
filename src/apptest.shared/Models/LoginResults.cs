using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apptest.shared.Models
{
    public class LoginResults
    {

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
