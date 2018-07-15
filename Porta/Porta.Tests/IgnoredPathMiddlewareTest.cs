using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Porta.Interfaces.Repositories;
using Porta.Middlewares;
using Xunit;

namespace Porta.Tests
{
    public class IgnoredPathMiddlewareTest
    {
        private readonly TestServer _testServer;
        private readonly IIgnoredRoutesRepository _ignoredRoutesRepository;

        public IgnoredPathMiddlewareTest()
        {
            _testServer = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>());

            _ignoredRoutesRepository = (IIgnoredRoutesRepository) _testServer.Host.Services.GetService(typeof(IIgnoredRoutesRepository));
        }

        [Fact]
        public async void TestIgnoredRoute()
        {
            var nextCalled = false;
            var ignoredPathMiddleware = new IgnoredPathMiddleware(next: async (innerHttpContext) =>
            {
                nextCalled = true;
            }, _ignoredRoutesRepository);

            await ignoredPathMiddleware.Invoke(InitDefaultHttpContext("/favicon.ico", "GET"));
            Assert.False(nextCalled);
        }

        [Fact]
        public async void TestEmptyRoute()
        {
            var nextCalled = false;
            var ignoredPathMiddleware = new IgnoredPathMiddleware(next: async (innerHttpContext) =>
            {
                nextCalled = true;
            }, _ignoredRoutesRepository);

            await ignoredPathMiddleware.Invoke(new DefaultHttpContext());
            Assert.False(nextCalled);
        }

        [Fact]
        public async void TestValidRoute()
        {
            var nextCalled = false;
            var ignoredPathMiddleware = new IgnoredPathMiddleware(next: async (innerHttpContext) =>
            {
                nextCalled = true;
            }, _ignoredRoutesRepository);

            await ignoredPathMiddleware.Invoke(InitDefaultHttpContext("/not-ignored-route/", "GET"));
            Assert.True(nextCalled);
        }

        private HttpContext InitDefaultHttpContext(string path, string method)
        {
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            request.Method = "GET";
            request.Path = new PathString(path);
            return httpContext;
        }
    }
}
