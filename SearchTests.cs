using RyłkoWeb_TestFramework.TestInfrastructure;
using Xunit;

namespace Tests.RylkoTests.SearchTests
{
    public class SearchTests : BaseXUnitTest
    {
        [Fact]
        public void SearchProductTest()
        {
            SearchPage.SearchProduct(availableProduct);
            SearchPage.ClearSearch();
            SearchPage.SearchProduct(unavailableProduct, available: false);
        }

        private const string availableProduct = "buty";
        private const string unavailableProduct = "okulary";
    }
}
