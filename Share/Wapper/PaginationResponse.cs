
namespace Share.Wapper
{
    public class PaginatedResponse<T> : Response
    {
        public PaginatedResponse(string json)
        {
            Json = json;
        }

        public PaginatedResponse(List<T>? data)
        {
            Data = data;
        }

        internal PaginatedResponse(bool succeeded, string json = null, List<string> messages = null, int count = 0,
            int page = 1, int pageSize = 10)
        {
            Json = json;
            CurrentPage = page;
            Succeed = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Messages = messages;
            if (succeeded is false)
            {
                Errors = messages;
                Messages = null;
            }
        }

        internal PaginatedResponse(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0,
            int page = 1, int pageSize = 10)
        {
            Data = data;
            CurrentPage = page;
            Succeed = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Messages = messages;
            if (succeeded is false)
            {
                Errors = messages;
                Messages = null;
            }
        }

        public List<T> Data { get; set; }
        public string? Json { get; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public static PaginatedResponse<T> Failure(string json, List<string> messages)
        {
            return new(false, json, messages);
        }

        public static PaginatedResponse<T> Failure(List<T> data, List<string> messages)
        {
            return new(false, data, messages);
        }

        public static PaginatedResponse<T> SuccessAsString(string json, int count, int page, int pageSize,
            List<string> message)
        {
            return new(true, json, message, count, page, pageSize);
        }

        public static PaginatedResponse<T> SuccessAsList(List<T> data, int count, int page, int pageSize,
            List<string> message)
        {
            return new(true, data, message, count, page, pageSize);
        }
    }
}
