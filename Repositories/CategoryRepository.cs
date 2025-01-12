using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(SqlConnection connection)
            : base(connection)
        {
        }

        public List<Category> GetCategoryWithPostCount()
        {
            var query = @"
                    SELECT 
                        [Category].[Id],
                        [Category].[Name],
                        [Category].[Slug],
                        COUNT([Post].[Id]) AS PostCount
                    FROM 
                        [Category]
                    LEFT JOIN 
                        [Post] ON [Post].[CategoryId] = [Category].[Id]
                    GROUP BY 
                        [Category].[Id], [Category].[Name], [Category].[Slug]";

            var categories = _connection.Query<Category>(query).ToList();
            return categories;
        }

        public Category GetCategoryWithPosts(int categoryId)
        {
            var query = @"
                        SELECT
                            [Category].[Id] AS CategoryId,
                            [Category].[Name],
                            [Category].[Slug],
                            [Post].[Id] AS PostId,
                            [Post].[Title],
                            [Post].[Summary],
                            [Post].[Slug] AS PostSlug,
                            [Post].[CreateDate],
                            [Post].[LastUpdateDate]
                        FROM
                            [Category]
                        LEFT JOIN [Post] ON [Post].[CategoryId] = [Category].[Id]
                        WHERE
                            [Category].[Id] = @categoryId";
            
            var categoriesDict = new Dictionary<int, Category>();

            var categories = _connection.Query<Category, Post, Category>(
                query,
                (category, post) =>
                {
                    if (!categoriesDict.TryGetValue(category.Id, out var cat))
                    {
                        cat = category;
                        cat.Posts = new List<Post>();
                        categoriesDict.Add(category.Id, cat);
                    }

                    if (post != null)
                    {
                        cat.Posts.Add(post);
                    }

                    return cat;
                }, new { CategoryId = categoryId },
                splitOn: "PostId");

            return categories.FirstOrDefault();
        }
    }
}