using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace Lab16Final
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
