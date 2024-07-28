namespace PooyesheSabz.Web.DTOs.Repositories.Pages
{
    public class PageSummaryDTO
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublieshed { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
