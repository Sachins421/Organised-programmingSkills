using Model.Data.Repositries;

namespace Model.Data.Wrapper
{
    public class IdAndLockTocken : MessageResponseWrapper
    {
        public Id Id { get; set; }
    }
}
