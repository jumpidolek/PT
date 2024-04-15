namespace PetStore.Data.Users;

public class Customer : User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DeliveryAddress { get; set; }
    public string BillingInformation { get; set; }
    public DateOnly DateOfBirth { get; set; }
}