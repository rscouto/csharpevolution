namespace CsharpEvolution.Tests01.Persistence
{
    public interface ICalculatorRepositorySettings
    {
        public string CalculatorCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }

    }
}
