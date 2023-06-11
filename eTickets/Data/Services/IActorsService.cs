using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    // Retreiving data from the controller is not a good practice. 
    // So Interface service is created 
    // Later this interface is inherited to Controller
    public interface IActorsService: IEntityBaseRepository<Actor>
    {   
       
    }
}
