﻿namespace Ruuvi.Settings
{
    public interface IMongoDbSettings
    {
        public string DatabaseName { get; set; }

        public string ConnectionString { get; set; }
    }
}
