using PooyesheSabz.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooyesheSabz.Web.DTOs.Repositories.Supports
{
    public class SupportDTO
    {
        public Guid Id { get; set; }
        public string SupportType { get; set; }
        public DateTime CreateDate { get; set; }
        public bool HaveAnySuccessPayment { get; set; }
        public IEnumerable<SupportPaymentDTO> Payments { get; set; }
    }
}
