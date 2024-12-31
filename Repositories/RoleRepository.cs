using Blog.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(SqlConnection connection) : base(connection)
        {
        }
    }
}
