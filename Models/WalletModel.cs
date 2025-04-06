using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPT_TMS_GoFare.Models
{
    public class WalletModel
    {
        public int client_id;
        public int wallet_id;
        public decimal balance;
        public string status = "";
        public decimal loaned;
        public string created_at = "";
    }
}
