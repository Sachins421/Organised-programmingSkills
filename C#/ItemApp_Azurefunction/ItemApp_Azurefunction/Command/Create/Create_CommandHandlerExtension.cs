using ItemApp_Azurefunction.Modal;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace ItemApp_Azurefunction.Action
{
    public class Create_CommandHandlerExtension : IRequestHandler<CreateCommand>
    {
        private IItemRepository _itemRepository;

        public Create_CommandHandlerExtension(IItemRepository itemRepository) => _itemRepository = itemRepository;
        public async Task Handle(CreateCommand command, CancellationToken cancellationToken)
        {
            //var request = ProductToActionExtension.ToModel(); //complaing for the parameter
            var request = command.ToModel();
            await _itemRepository.Create(request);
        }
    }   
}

        //public async  Task DeleteHandler(ActionRequest actionRequest)
        //{
        //    //var request = ProductToActionExtension.ToModel(); //complaing for the parameter
        //    var request = actionRequest.ToModel();
        //    await _itemRepository.Delete(actionRequest.No);
        //}
 