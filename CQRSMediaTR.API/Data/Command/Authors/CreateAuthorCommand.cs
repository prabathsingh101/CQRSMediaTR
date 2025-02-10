using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Command.Authors
{
    public class CreateAuthorCommand : IRequest<Author>
    {
        public CreateAuthorCommand(string firstname, string lastname, int createdBy)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.CreatedBy = createdBy;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreatedBy { get; set; }
    }
}
