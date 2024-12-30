using Blog.Models;
using Blog.Repositories.Interfaces;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Blog.Repositories
{
    public class Repository<TModel> where TModel : class, IRepository
    {
        protected readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<TModel> Get()
            => _connection.GetAll<TModel>();

        public TModel Get(int id)
            => _connection.Get<TModel>(id);

        public void Create(TModel model)
        {
            _connection.Insert(model);
            Console.WriteLine("User created successfully!");
        }

        public void Update(TModel model)
        {
            if (model.Id != 0)
                _connection.Update<TModel>(model);
        }

        public void Delete(TModel model)
        {
            if (model.Id != 0)
                _connection.Delete<TModel>(model);
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;

            var item = _connection.Get<TModel>(id);
            _connection.Delete<TModel>(item);
        }
    }
}
