using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository(SqlConnection connection) : base(connection)
        {
        }

        public List<Post> GetPostsWithCategory()
        {
            var query = @"
                        SELECT 
                            [Post].[Id] AS PostId,
                            [Post].[Title],
                            [Post].[CategoryId] AS PostCategoryId,
                            [Category].[Id] AS CategoryId,
                            [Category].[Name] AS CategoryName
                        FROM 
                            [Post]
                        INNER JOIN 
                            [Category] ON [Post].[CategoryId] = [Category].[Id]";

            var postCategories = _connection.Query<PostCategory>(query).ToList();

            var posts = postCategories.Select(pc => new Post
                {
                Id = pc.PostId,
                Title = pc.Title,
                CategoryId = pc.CategoryId,
                Category = new Category { Id = pc.CategoryId, Name = pc.CategoryName }
                }).ToList();

            return posts;
        }

        public List<Post> GetPostsWithTags()
        {
            var query = @"
                SELECT 
                    p.Id AS PostId,
                    p.Title,
                    t.Id AS TagId,
                    t.Name AS TagName
                FROM 
                    Post p
                INNER JOIN 
                    PostTag pt ON p.Id = pt.PostId
                INNER JOIN 
                    Tag t ON pt.TagId = t.Id";

            var postTags = _connection.Query<PostTagResult>(
                query).ToList();

            var posts = postTags.GroupBy(pt => new { pt.PostId, pt.Title })
                                .Select(g => new Post
                                {
                                    Id = g.Key.PostId,
                                    Title = g.Key.Title,
                                    Tags = g.Select(pt => new Tag { Id = pt.TagId, Name = pt.TagName }).ToList()
                                }).ToList();

            return posts;
        }
    }
}
