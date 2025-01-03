using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Blog.Repositories
{
    public class JoinRepository<TKey1, TKey2, TModel> where TModel : class
    {
        private readonly SqlConnection _connection;
        private readonly string _tableName;
        private readonly string _key1Column;
        private readonly string _key2Column;

        public JoinRepository(SqlConnection connection, string tableName, string key1Column, string key2Column)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
            _key1Column = key1Column ?? throw new ArgumentNullException(nameof(key1Column));
            _key2Column = key2Column ?? throw new ArgumentNullException(nameof(key2Column));
        }

        public void CreateRelation(TKey1 key1, TKey2 key2)
        {
            string query = $@"
            IF EXISTS (SELECT 1 FROM {_tableName} WHERE {_key1Column} = @Key1 AND {_key2Column} = @Key2)
                THROW 50000, 'Relationship already exists', 1;
            INSERT INTO {_tableName} ({_key1Column}, {_key2Column})
            VALUES (@Key1, @Key2);";

            try
            {
                _connection.Execute(query, new { Key1 = key1, Key2 = key2 });
                Console.WriteLine("Relationship successfully created!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error creating the relationship: " + ex.Message);
            }
        }
        public TModel GetRelation(TKey1 key1, TKey2 key2)
        {
            string query = $@"SELECT * FROM {_tableName} WHERE {_key1Column} = @Key1 AND {_key2Column} = @Key2;";

            return _connection.QuerySingleOrDefault<TModel>(query, new { Key1 = key1, Key2 = key2 });
        }

        public void DeleteRelation(TKey1 key1, TKey2 key2)
        {
            string query = $@"DELETE FROM {_tableName} WHERE {_key1Column} = @Key1 AND {_key2Column} = @Key2;";

            try
            {
                _connection.Execute(query, new { Key1 = key1, Key2 = key2 });
                Console.WriteLine("Relationship successfully deleted!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error deleting the relationship: " + ex.Message);
            }
        }

        public bool RelationExists(TKey1 key1, TKey2 key2)
        {
            string query = $@"SELECT COUNT(1) FROM {_tableName} WHERE {_key1Column} = @Key1 AND {_key2Column} = @Key2;";

            return _connection.ExecuteScalar<int>(query, new { Key1 = key1, Key2 = key2 }) > 0;
        }

    }
}
