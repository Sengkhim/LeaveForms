
namespace Share.Wapper
{
    public class Response : IResponse
    {
        protected Response()
        {
        }

        public bool Succeed { get; set; }
        public List<string> Messages { get; set; }
        public List<string> Errors { get; set; }

        public static IResponse Fail()
        {
            return new Response { Succeed = false };
        }

        public static IResponse Fail(string error)
        {
            return new Response { Succeed = false, Errors = new List<string> { error } };
        }

        public static IResponse Fail(List<string> errors)
        {
            return new Response { Succeed = false, Errors = errors };
        }

        public static Task<IResponse> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public static Task<IResponse> FailAsync(string error)
        {
            return Task.FromResult(Fail(error));
        }

        public static Task<IResponse> FailAsync(List<string> errors)
        {
            return Task.FromResult(Fail(errors));
        }

        public static IResponse Success()
        {
            return new Response { Succeed = true };
        }

        public static IResponse Success(string message)
        {
            return new Response { Succeed = true, Messages = new List<string> { message } };
        }

        public static IResponse Success(List<string> messages)
        {
            return new Response { Succeed = true, Messages = messages };
        }

        public static Task<IResponse> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<IResponse> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<IResponse> SuccessAsync(List<string> messages)
        {
            return Task.FromResult(Success(messages));
        }
    }

    public class Response<T> : Response, IResponse<T>
    {
        public Response()
        {
        }

        public Response(List<string> messages)
        {
            Succeed = false;
            Messages = messages;
        }

        public Response(T data, List<string> messages = null)
        {
            Succeed = true;
            Messages = messages;
            Data = data;
        }

        public T Data { get; set; }

        public new static Response<T> Fail()
        {
            return new() { Succeed = false };
        }

        public new static Response<T> Fail(string errors)
        {
            return new() { Succeed = false, Errors = new List<string> { errors } };
        }

        public new static Response<T> Fail(List<string> errors)
        {
            return new() { Succeed = false, Errors = errors };
        }

        public new static Task<Response<T>> FailAsync(string error)
        {
            return Task.FromResult(Fail(error));
        }

        public new static Task<Response<T>> FailAsync(List<string> errors)
        {
            return Task.FromResult(Fail(errors));
        }

        public new static Response<Guid?> Success()
        {
            return new() { Succeed = true };
        }

        public new static Response<T> Success(string message)
        {
            return new() { Succeed = true, Messages = new List<string> { message } };
        }

        public new static Response<T> Success(List<string> messages)
        {
            return new() { Succeed = true, Messages = messages };
        }

        public new static Task<Response<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public new static Task<Response<T>> SuccessAsync(List<string> messages)
        {
            return Task.FromResult(Success(messages));
        }

        public static Response<T> Success(T data)
        {
            return new() { Succeed = true, Data = data };
        }

        public static Response<T> Success(T data, List<string> messages)
        {
            return new() { Succeed = true, Data = data, Messages = messages };
        }

        public static Task<Response<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Response<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, new List<string> { message }));
        }

        public static Task<Response<T>> SuccessAsync(T data, List<string> message)
        {
            return Task.FromResult(Success(data, message));
        }
    }
}
