using Domain.Mapping.Dto;
using Domain.Mapping.GlassRequestDto;
using Model.Data.Wrapper;
using Service.Utilities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utilities.Helper
{
    public static class PrepareEventResponse
    {
        public static EventResponse CreateEventResponse(List<IdAndLockTocken> idAndLockTockens)
        {
         #pragma warning disable CS8603 // Possible null reference return.
            return idAndLockTockens.Where(id => id.IsEvent || !id.Success).Select(idAndLockTockens =>
             {
                 var response = new EventResponse();
                 response.Topic = idAndLockTockens.Topic;
                  #pragma warning disable CS8601 // Possible null reference assignment.
                 response.data = idAndLockTockens.Id != null ? new Service.Utilities.Response.Data
                 {
                     Event = new EventData
                     {
                         sourceInformation = idAndLockTockens.IsEvent ? new SourceInformation
                         {
                             Id = idAndLockTockens.Id.id,
                             SalesChannel = idAndLockTockens.Id.SalesChannel,
                             SalesCountryISO = idAndLockTockens.Id.SalesCountryISO,
                             LineNo = idAndLockTockens.Id.LineNo
                         } : null,

                     },

                 } : null;
                    #pragma warning restore CS8601 // Possible null reference assignment.
                 response.version = "1.0";
                 response.subject = idAndLockTockens.Subject;
                 response.id = Guid.NewGuid().ToString();
                 response.isCompressed = false;
                 response.lastUpdatedSetupTimeStamp = idAndLockTockens.LastUpdatedSetupTimeStamp;

                 return response;

             }).FirstOrDefault();


        }
    }
}