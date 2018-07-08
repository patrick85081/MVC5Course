using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public static class QuerableExtension
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> source, int page = 1, int pageSize = 10) =>
            source.Skip((page - 1) * pageSize)
                .Take(pageSize);

        public static int GetPageCount<T>(this IQueryable<T> source, int pageSize = 10) =>
            source.Count() / pageSize;
    }
}