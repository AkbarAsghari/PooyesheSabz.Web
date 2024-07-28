namespace PooyesheSabz.Web.DTOs.Repositories.Pages
{
    public class CreatePageDTO
    {
        public string URL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
        public string Body { get; set; }
    }
}
