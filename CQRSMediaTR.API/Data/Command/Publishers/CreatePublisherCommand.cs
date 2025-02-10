using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Command.Publishers
{
    public class CreatePublisherCommand : IRequest<Publisher>
    {
        public CreatePublisherCommand(string name, string address, string phone, string email, int createdby)
        {
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.CreatedBy = createdby; 
        }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? CreatedBy { get; set; }
    }
}
