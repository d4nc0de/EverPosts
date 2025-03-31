namespace EverPostWebApi.DTOs
{
    public class PostCreateDto
    {
        public int UserId { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public List<Categorie> Categories{ get; set; }
    }
}
