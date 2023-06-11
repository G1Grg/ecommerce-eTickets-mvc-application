namespace eTickets.Data.Base
{
    // This interface is created because there are some elements that are common in all the models. 
    // For example Id is common in all the model name
    public interface IEntityBase
    {
        int Id { get; set; }
    }
}
