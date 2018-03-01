using Actio.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Action.Api.Test.Unit
{
    public class HomeControllerTest
    {
        [Fact]
        public void Home_controller_get_should_return_string()
        {
            var homeController = new HomeController();
            var content = homeController.Get();
            var contentResult = content as ContentResult;
            contentResult.Should().NotBeNull();
            contentResult.Content.Should().BeEquivalentTo("Hello simple microservice");
        }
    }
}