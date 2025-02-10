using MediatR;

namespace CQRSMediaTR.API.Data.Command.Authors
{
    public class UpdateAuthorCommand : IRequest<int>
    {
        public UpdateAuthorCommand(int authorid, string firstname, string lastname, DateTime? updatedDate, int? updatedBy)
        {
            this.AuthorId = authorid;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.UpdatedDate = updatedDate;
            this.UpdatedBy = updatedBy;
        }
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
