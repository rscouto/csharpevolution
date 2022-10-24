namespace CsharpEvolution.Tests01.Persistence
{
    public interface ICalculatorRepositorySettings
    {
        public string RpgStoreItemInventoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }

    }
}
