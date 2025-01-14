namespace Blog.Models
{
    public class PostCategory
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int PostCategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
