namespace Blog.Management.Application.Contracts.Comment.Dtos
{
    public class CreateCommentDto
    {
        public string Text { get; set; }
        public long authorId { get; set; }
        public long articleId { get; set; }
    }
}
