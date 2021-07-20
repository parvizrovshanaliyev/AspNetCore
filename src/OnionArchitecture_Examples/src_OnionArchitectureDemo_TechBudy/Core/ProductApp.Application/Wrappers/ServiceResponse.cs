using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Wrappers
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Value { get; set; }

        public ServiceResponse(T value)
        {
            Value = value;
        }

        protected ServiceResponse()
        {
            
        }
    }


    public class PagedResponse<T>:ServiceResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }


        public PagedResponse(T value):base(value)
        {
        }

        public PagedResponse()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PagedResponse(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PagedResponse(T value,int pageNumber, int pageSize):base(value)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
