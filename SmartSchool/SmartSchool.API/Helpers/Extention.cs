using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SmartSchool.API.Helpers
{
    public static class Extention
    {
        public static void AddPagination(this HttpResponse httpResponse, 
                                              int currentPage,
                                              int itemsPerPage,
                                              int totalItems,
                                              int totalPage)
        {
            var paginationHeader = new PaginationHeader(
                                               currentPage,
                                               itemsPerPage,
                                               totalItems,
                                               totalPage
        );

            var camelCaseFormater = new JsonSerializerSettings();
            camelCaseFormater.ContractResolver = new CamelCasePropertyNamesContractResolver();

            httpResponse.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormater));
            httpResponse.Headers.Add("Access-Control-Expose-Header", "Pagination");
        }
    }
}