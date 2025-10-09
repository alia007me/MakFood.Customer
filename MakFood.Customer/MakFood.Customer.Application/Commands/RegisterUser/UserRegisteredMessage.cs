namespace MakFood.Customer.Application.Commands.RegisterUser
{
    public record UserRegisteredMessage
{
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
