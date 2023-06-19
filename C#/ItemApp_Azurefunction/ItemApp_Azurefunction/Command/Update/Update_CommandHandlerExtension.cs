using ItemApp_Azurefunction.Modal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ItemApp_Azurefunction.Command;
using ItemApp_Azurefunction.Action;
using MongoDB.Driver;
using ItemApp_Azurefunction.Query;

namespace ItemApp_Azurefunction.Command
{
    public class Update_CommandHandlerExtension : IRequestHandler<UpdateCommand>
    {
        private IItemRepository _itemRepository { get; set; }

        public Update_CommandHandlerExtension(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task Handle(UpdateCommand updateCommand, CancellationToken cancellationToken)
        {
            var request = updateCommand.ToModel(); //complaing for the parameter
            await _itemRepository.Update(request.No, request);
        }
    }
}
