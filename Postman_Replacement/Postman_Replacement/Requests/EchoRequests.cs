using RestSharp;

namespace Postman_Replacement.Requests
{
    public class EchoRequests
    {
        public static IRestResponse digest_Auth()
        {
            var client = new RestClient("https://postman-echo.com/digest-auth");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "9d73ce17-ea54-0c57-75c4-23f6a9ef8649");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"code\"\r\n\r\nxWnkliVQJURqB2x1\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"grant_type\"\r\n\r\nauthorization_code\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"redirect_uri\"\r\n\r\nhttps://www.getpostman.com/oauth2/callback\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"client_id\"\r\n\r\nabc123\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"client_secret\"\r\n\r\nssh-secret\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse digestAuthSuccess()
        {
            var client = new RestClient("https://postman-echo.com/digest-auth");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "1129cb37-3933-6d9c-1241-6a303787b9c4");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "Digest username=\"postman\", realm=\"Users\", nonce=\"ni1LiL0O37PRRhofWdCLmwFsnEtH1lew\", uri=\"/digest-auth\", response=\"254679099562cf07df9b6f5d8d15db44\", opaque=\"\"");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse deflateCompressedResponse()
        {
            var client = new RestClient("https://postman-echo.com/deflate");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "b3897e1e-57fb-7b61-67ad-5f2efcdd7a5a");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse gZipCompressedResponse()
        {
            var client = new RestClient("https://postman-echo.com/gzip");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "b3897e1e-57fb-7b61-67ad-5f2efcdd7a5a");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
