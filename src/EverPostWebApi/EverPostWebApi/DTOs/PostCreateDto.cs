namespace EverPostWebApi.DTOs
{
    public class PostCreateDto
    {
        public int UserId { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string ImageRoute { get; set; }
    }
}
