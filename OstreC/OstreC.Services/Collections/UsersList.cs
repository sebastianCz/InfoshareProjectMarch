namespace OstreC.Services
{
    //Used for deserialization during Login validations and when modifying users/deleting/adding users. 
    public class UsersList
    { 
        public List<User> Results { get; set; }
    }
}