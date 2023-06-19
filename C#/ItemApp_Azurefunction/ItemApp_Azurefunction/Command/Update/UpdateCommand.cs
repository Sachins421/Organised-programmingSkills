using MediatR;

namespace ItemApp_Azurefunction.Command
{
    public class UpdateCommand : IRequest
    {
        public string Id { get; set; }

        public string No { get; set; }

        public string ItemName { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
