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
    }
}