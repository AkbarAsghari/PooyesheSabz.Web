using PooyesheSabz.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooyesheSabz.Web.DTOs.Repositories.Supports
{
    public class NewSupportDTO
    {
        public SupportTypeEnum SupportType { get; set; }
        public int Amount { get; set; }
    }
}
