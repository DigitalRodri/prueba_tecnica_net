﻿using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMarketPartiesRepository
    {
        public IEnumerable<Retailer> GetAllRetailers();
        Retailer GetRetailer(int reId);
    }
}
