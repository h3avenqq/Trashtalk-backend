using System.Collections.Generic;

namespace Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashList
{
    public class UserTrashListVm
    {
        public IList<UserTrashLookupDto> UserTrash { get; set; }
    }
}
