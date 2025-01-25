using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Command
{
    public class UpdateProductCommand: IRequest<Product>
    {
        public UpdateProductCommand(int id,string name, string description)
        {
            Id = id;        
            Name = name;
            Description = description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
