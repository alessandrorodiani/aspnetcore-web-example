using System;
using Dapper;
using Microsoft.Extensions.Logging;
using MyDemoApp.Data.Model;
using Npgsql;

namespace MyDemoApp.Data
{
    public interface IAccessRepository
    {
        bool Login(string emailAddress, string password);
    }

    public class AccessRepository : IAccessRepository
    {
        private readonly ConfigModel _config;
        private readonly ILogger<AccessRepository> _logger;

        public AccessRepository(ConfigModel config, ILogger<AccessRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public bool Login(string emailAddress, string password)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_config.ConnectionString))
                {
                    conn.Open();

                    var found = conn.QuerySingleOrDefault<Access>(
                        @"SELECT * FROM public.access WHERE email=@Email and password=@Password");

                    return found != null;
                }
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, "Help!!");
                throw exception;
            }
        }
    }
}
