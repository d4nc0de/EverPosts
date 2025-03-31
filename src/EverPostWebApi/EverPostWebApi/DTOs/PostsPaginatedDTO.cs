namespace EverPostWebApi.DTOs
{
    public class PostsPaginatedDTO
    {
        public List<Post> Data { get; set; }
        public int TotalRecords { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        /*
        Data = posts,
        TotalRecords = totalRecords,
        Page = page,
        PageSize = pageSize,
        TotalPages = (int) Math.Ceiling((double) totalRecords / pageSize)
        */
    }
}
