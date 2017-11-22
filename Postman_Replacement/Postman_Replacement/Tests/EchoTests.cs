using System;
using NUnit.Framework;
using FluentAssertions;
using Postman_Replacement.Requests;
using Postman_Replacement.EchoResponses;
using RestSharp;
using System.Net;
using System.Linq;

using QuickType;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Postman_Replacement.Tests
{
    public class EchoTests
    {
        private RestSharp.Deserializers.JsonDeserializer ds = new RestSharp.Deserializers.JsonDeserializer();

        [Test]
        [Description("it returns 401")]
        public void authDigest()
        {
            // DigestAuth Request
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            IRestResponse response = EchoRequests.digest_Auth();
            stopwatch.ElapsedMilliseconds.Should().BeLessOrEqualTo(2000);

            Console.WriteLine(response.StatusCode.ToString());
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            response.Headers.FirstOrDefault(a => a.Name == "WWW-Authenticate").Should().NotBeNull();
            foreach (var Header in response.Headers)
            {
                Console.WriteLine(Header.Name + " : " + Header.Value);
            }
        }

        [Test]
        [Description("it returns 200")]
        public void authDigestSuccess()
        {
            // DigestAuth Success
            IRestResponse response = EchoRequests.digestAuthSuccess();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
                                    
            //Deserialize the response into a DigestAuthResponse object - we could do this if we didn't want to use Quicktype (but I prefer Quicktype)
            //Might be able to use Newtonsoft's deserializer here but not sure that would be necessary.
            var res = ds.Deserialize<DigestAuthResponse>(response);
            res.authenticated.Should().BeTrue();
        }

        [Test]
        [Description("Testing deflate")]
        public void testDeflate()
        {
            IRestResponse response = EchoRequests.deflateCompressedResponse();
            // For some reason this returns a bad response. Something about "Block length does not match with its complement."


            var res = DeflateCompressedResponse.FromJson(response.Content);
            res.Headers.Host.Should().Be("postman-echo.com");
            //res.Headers.Accept.Should().Be("*/*");
            res.Headers.AcceptEncoding.Should().Be("gzip, deflate");
        }

        [Test]
        [Description("Testing gzip compressed")]
        public void testGZip()
        {
            IRestResponse response = EchoRequests.gZipCompressedResponse();
            var res = DeflateCompressedResponse.FromJson(response.Content);
            res.Headers.Host.Should().Be("postman-echo.com");
            //res.Headers.Accept.Should().Be("*/*");
            res.Headers.AcceptEncoding.Should().Be("gzip, deflate");
        }
    }
}
