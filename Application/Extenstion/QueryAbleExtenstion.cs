using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Share.Wapper;

namespace Application.Extenstion
{
    public static class QueryAbleExtenstion
    {
        public static async Task<PaginatedResponse<T>> ToPaginatedAsStringAsync<T>(this IQueryable<T> source, int pageNumber,
    int pageSize, string message) where T : class
        {
            if (source is null) throw new ApiException();
            pageNumber = pageNumber is 0 ? 1 : pageNumber;
            pageSize = pageSize is 0 ? 10 : pageSize;
            var count = await source.CountAsync();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            var messages = new List<string> { message };
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var json = JsonConvert.SerializeObject(items);
            return PaginatedResponse<T>.SuccessAsString(json, count, pageNumber, pageSize, messages);
        }

        public static async Task<PaginatedResponse<T>> ToPaginatedAsListAsync<T>(this IQueryable<T> source,
            int pageNumber,
            int pageSize, string message) where T : class
        {
            if (source is null) throw new ApiException();
            pageNumber = pageNumber is 0 ? 1 : pageNumber;
            pageSize = pageSize is 0 ? 10 : pageSize;
            var count = await source.CountAsync();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            var messages = new List<string> { message };
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return PaginatedResponse<T>.SuccessAsList(items, count, pageNumber, pageSize, messages);
        }
    }
}
