using System;

namespace CQRSWithMediatRExample.DAL.CQRS.Queries.Response
{
    public class GetAllProductQueryResponse
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short? UnitsInStock { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
