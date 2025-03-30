namespace EverPostWebApi.DTOs
{
    public class PostGetDto
    {
        public int UserId { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string ImageRoute { get; set; }
        public int totalComments { get; set; }
    }
}
