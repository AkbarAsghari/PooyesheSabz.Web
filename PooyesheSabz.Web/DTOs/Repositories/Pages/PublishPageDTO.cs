using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooyesheSabz.Web.DTOs.Repositories.Pages
{
    public class PublishPageDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public PageAuthorDTO Author { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
