﻿namespace API_Ong.Utils
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string PessoaCollectionName { get; set; }
        public string AnimalCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
