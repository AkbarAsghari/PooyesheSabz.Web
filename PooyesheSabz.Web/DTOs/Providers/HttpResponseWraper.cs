﻿namespace PooyesheSabz.Web.DTOs.Providers
{
    public class HttpResponseWraper<T>
    {
        public HttpResponseWraper(T response, bool success, HttpResponseMessage httpResponseMessage)
        {
            this.Success = success;
            this.Response = response;
            this.HttpResponseMessage = httpResponseMessage;
        }
        public bool Success { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
