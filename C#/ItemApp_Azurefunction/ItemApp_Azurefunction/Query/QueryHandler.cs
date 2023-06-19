using Amazon.Runtime.Internal;
using ItemApp_Azurefunction.Modal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction.Query
{
    public class QueryHandler : IRequestHandler<QueryR, Response>
    {
        private IItemRepository _itemRepository;

        public QueryHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Response> Handle(QueryR query, CancellationToken cancellationToken)
        {
            var result = await _itemRepository.Read(query.No);
            return result.ToModel();
           
        }
    }
}
