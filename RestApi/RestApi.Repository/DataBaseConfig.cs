using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Repository
{
    public static class DataBaseConfig
    {
        public static string DatabaseName { get; } = "RestApi";
        public static string ConnectionString { get; } = "mongodb://localhost:27017";
    }
}
