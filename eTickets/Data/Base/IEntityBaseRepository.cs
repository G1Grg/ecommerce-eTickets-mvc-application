namespace eTickets.Data.Base
{
    // This entity is a generic repository<T>. Since we are referring to Classes, we will define it's type  Class. T:Class
    // IEntityBaseRepository will inherit the base entity from IEntityBase
    // new() define all the methods that are defines in IActorsServices
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        //Return type IEnumerable and method is Getall()
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        // update data in database for the new actor data

        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
