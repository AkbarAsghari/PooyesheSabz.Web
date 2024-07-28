using DNSLab.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooyesheSabz.Web.DTOs.Repositories.Pages
{
    public class LastContentsDTO
    {
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
    }
}
