using System;
using System.Collections.Generic;

namespace ShopBridge.Responses
{
    class Responses
    {
    }

    public interface IResponse
    {

    }

    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }

    public class SingleResponse<TModel> : ISingleResponse<TModel>
    {
        public SingleResponse()
        {

        }
        public SingleResponse(bool success, string message, TModel data)
        {
            this.Succeeded = success;
            this.Message = message ?? string.Empty;
            this.Model = data;
        }

        public SingleResponse(string message) : this(false, message, default(TModel))
        { }

        public SingleResponse(TModel data) : this(true, string.Empty, data)
        {
        }

        public string Message { get; set; }
        public string error { get; set; }

        public bool DidError { get; set; }
        public bool DidFieldError { get; set; }
        public string ErrorMessage { get; set; }
        public Boolean Succeeded { get; set; }
        public string Code { get; set; }
        public List<fieldErrorsstatus> fieldErrors { get; private set; }
        public TModel Model { get; set; }
    }
    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public string Message { get; set; }
        public string error { get; set; }
        public List<fieldErrorsstatus> fieldErrors { get; private set; }
        public bool DidError { get; set; }
        public bool DidFieldError { get; set; }

        public string ErrorMessage { get; set; }
        public Boolean Succeeded { get; set; }
        public IEnumerable<TModel> Model { get; set; }
    }

    public class fieldErrorsstatus
    {
        public string name { get; set; }
        public string status { get; set; }
    }


}
