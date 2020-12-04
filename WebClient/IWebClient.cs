using System;
using System.Net;
using System.Threading.Tasks;

namespace WebClient
{
    public interface IWebClient
    {
        bool Ping();
        string GetInputData();
        HttpStatusCode? WriteAnswer(string objectStr);

    }
}
