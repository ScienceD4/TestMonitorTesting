using NUnit.Framework;
using RestSharp;
using System.Net;

namespace BussinesObject.Api.Utils;

public static class RequestHelper
{
    public static void CheckResponse(RestResponse response, bool isEmptyContent = false, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        Assert.Multiple(() =>
        {
            Assert.That(response, Is.Not.Null);
            if (isEmptyContent) { Assert.That(response.Content, Is.Empty); }
            else { Assert.That(response.Content, Is.Not.Empty); }
            Assert.That(response.StatusCode, Is.EqualTo(statusCode));
        });
    }
}