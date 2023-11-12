using API.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;

public static class MockHttpContext
{
    public static HttpContext CreateMockHttpContext(Func<string> userIdProvider = null!)
    {
        var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userIdProvider?.Invoke() ?? "defaultUserId") };
        var identity = new ClaimsIdentity(claims, "TestAuthentication");
        var user = new ClaimsPrincipal(identity);

        var mockHttpContext = new Mock<HttpContext>();
        mockHttpContext.Setup(c => c.User).Returns(user);

        var mockHttpRequest = new Mock<HttpRequest>();
        mockHttpRequest.SetupGet(c => c.HttpContext).Returns(mockHttpContext.Object);
        mockHttpContext.Setup(c => c.Request).Returns(mockHttpRequest.Object);

        var mockHttpResponse = new Mock<HttpResponse>();
        mockHttpContext.Setup(c => c.Response).Returns(mockHttpResponse.Object);

        var mockConnection = new Mock<ConnectionInfo>();
        mockHttpContext.Setup(c => c.Connection).Returns(mockConnection.Object);

        var mockSession = new Mock<ISession>();
        mockHttpContext.Setup(c => c.Session).Returns(mockSession.Object);

        var mockFeatures = new Mock<IFeatureCollection>();
        mockHttpContext.Setup(c => c.Features).Returns(mockFeatures.Object);

        return mockHttpContext.Object;
    }
}
