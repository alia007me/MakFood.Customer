namespace MakFood.Customer.Application.Queries.GetActiveFriendships
{
    public record GetActiveFriendshipsDto(Guid FriendshipId,
                                          string ReceiverName,
                                          string SenderName,
                                          string CurrentStatus,
                                          DateTime CreatedInTime);
    

}
