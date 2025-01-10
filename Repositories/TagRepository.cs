using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(SqlConnection connection)
            : base(connection)
        {
        }

        public List<Tag> GetTagsWithPostCount()
        {
            var query = @"
                    SELECT 
                        [Tag].[Id],
                        [Tag].[Name],
                        COUNT([Post].[Id]) AS PostCount
                    FROM 
                        [Tag]
                    LEFT JOIN 
                        [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
                    LEFT JOIN 
                        [Post] ON [Post].[Id] = [PostTag].[PostId]
                    GROUP BY 
                        [Tag].[Id], [Tag].[Name]";

            var tags = _connection.Query<Tag>(query).ToList();
            return tags;
        }
    }

}
