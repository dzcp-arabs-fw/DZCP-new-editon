using Xunit;
using DZCP.API;
using DZCP.Loader;
using DZCP.Plugins;

namespace DZCP.Loader.Tests
{
    public class LoaderTests
    {
        [Fact]
        public void LoadAll_WithValidPlugin_LoadsSuccessfully()
        {
            // Arrange
            var loader = new PluginManager("test_plugins");
            
            // Act
            loader.LoadAll();
            
            // Assert
            Assert.NotEmpty(loader.LoadedPlugins);
        }
    }
}