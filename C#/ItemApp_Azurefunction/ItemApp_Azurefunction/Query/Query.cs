﻿using Amazon.Runtime.Internal;
using MediatR;


namespace ItemApp_Azurefunction.Query
{
    public class QueryR : IRequest<Response>
    {
        public string Id { get; set; }

        public string No { get; set; }

        public string ItemName { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }
        
    }

  
}
