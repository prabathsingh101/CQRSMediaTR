using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Command
{
    public class CreateProductCommand: IRequest<Product>
    {
        public CreateProductCommand(string name, string description)
        {
            Name = name;
            Description = description;          
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
