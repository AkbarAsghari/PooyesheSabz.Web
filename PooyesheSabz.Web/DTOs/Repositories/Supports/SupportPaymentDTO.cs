using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooyesheSabz.Web.DTOs.Repositories.Supports
{
    public class SupportPaymentDTO
    {
        public int Amount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
