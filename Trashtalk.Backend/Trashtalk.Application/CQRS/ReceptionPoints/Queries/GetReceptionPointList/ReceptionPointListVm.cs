using System.Collections.Generic;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Queries.GetReceptionPointList
{
    public class ReceptionPointListVm
    {
        public IList<ReceptionPointLookupDto> ReceptionPoints { get; set; }
    }
}
