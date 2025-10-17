namespace MakFood.Customer.Application.Queries.GetRequests
{
    public record GetRequestDto (Guid FriendshipId,string ReceiverName,string SenderName, string CurrentStatus, DateTime CreatedInTime);
    

}
