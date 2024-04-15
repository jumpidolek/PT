namespace PetStore.Data.Users;

public class User
{
    public Guid Id { get; init; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}