using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chambers.Partners.Domain.Providers
{
    public class InMemoryDealerProvider : IDealerProvider
    {
        private Dictionary<int, Dealer> _dealers = new Dictionary<int, Dealer>()
        {
            { 1, new Dealer(1, "Mr Dealer") },
            { 2, new Dealer(2, "Mrs Dealer") },
        };

        public Task<Dealer> GetAsync(int dealerId)
        {
            if (_dealers.ContainsKey(dealerId))
            {
                return Task.FromResult(_dealers[dealerId]);
            }
            throw new Exception("The dealer does not exist");
        }

        public Task<List<Dealer>> GetAllAsync()
        {
            return Task.FromResult(_dealers.Values.ToList());
        }
    }
}
