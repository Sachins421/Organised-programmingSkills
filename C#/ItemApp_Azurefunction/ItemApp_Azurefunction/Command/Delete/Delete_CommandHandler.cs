using ItemApp_Azurefunction.Action;
using ItemApp_Azurefunction.Modal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction.Command.Delete
{
    public class Delete_CommandHandler : IRequestHandler<DeleteCommand>
    {
            private IItemRepository _itemRepository;

            public Delete_CommandHandler(IItemRepository itemRepository) => _itemRepository = itemRepository;
            public async Task Handle(DeleteCommand command, CancellationToken cancellationToken)
            {
                //var request = ProductToActionExtension.ToModel(); //complaing for the parameter
                await _itemRepository.Delete(command.No);
            }
    }
}
