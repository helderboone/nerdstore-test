using Microsoft.Extensions.Configuration;
using System.IO;

namespace NerdStore.BDD.Tests.Config
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _config;

        public ConfigurationHelper()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public string VitrineUrl => $"{_config.GetSection("VitrineUrl").Value}";
        public string ProdutoUrl => $"{_config.GetSection("ProdutoUrl").Value}";
        public string CarrinhoUrl => $"{_config.GetSection("CarrinhoUrl").Value}";
        public string DomainUrl => $"{_config.GetSection("DomainUrl").Value}";
        public string RegisterUrl => $"{_config.GetSection("RegisterUrl").Value}";
        public string LoginUrl => $"{_config.GetSection("LoginUrl").Value}";
        public string WebDrivers => $"{_config.GetSection("WebDrivers").Value}";
        public string FolterPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public string FolderPicture => $"{FolterPath}{_config.GetSection("FolderPicture").Value}";
    }
}
