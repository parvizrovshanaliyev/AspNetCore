using System;

namespace CQRSMediatR1.CQRS.Queries.Response
{
    public class GetByIdProductQueryResponse
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short? UnitsInStock { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime CreateTime { get; set; }
    }
}