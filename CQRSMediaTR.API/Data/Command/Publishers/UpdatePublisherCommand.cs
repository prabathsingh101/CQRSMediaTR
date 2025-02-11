using MediatR;

namespace CQRSMediaTR.API.Data.Command.Publishers
{
    public class UpdatePublisherCommand:IRequest<int>
    {
        public UpdatePublisherCommand(
            int publisherid,
            string name,
            string address,
            string phone,
            string email,
            int updatedby,
            DateTime updateddate)
        {
            this.PublisherID = publisherid;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.UpdatedBy = updatedby;
            this.UpdatedDate = updateddate;            
        }
        public int PublisherID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
