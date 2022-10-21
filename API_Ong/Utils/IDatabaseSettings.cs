namespace API_Ong.Utils
{
    public interface IDatabaseSettings
    {
        string PessoaCollectionName { get; set; } 
        string AnimalCollectionName { get; set; }
        string ConnectionString { get; set; } 
        string DatabaseName { get; set; } 
    }
}
