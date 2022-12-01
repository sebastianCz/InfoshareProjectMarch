namespace OstreCWEB.Data.Repository
{
    internal class User
    {
        public int Id { get; set; }
        public bool LoggedIn { get; set; }
        public string UserName  { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } 
        public List<int> StoriesCreatedIds { get; set; }
        public List<int> CharactersCreatedIds { get; set; }
        public int StoriesCompletedTotal { get; set; }
        public int DamageDealt { get; set; }
        public int DamageReceived { get; set; }

        public User()
        {

        }
        public User(int id,bool loggedIn,string userName,string password,string email, List<int> storiesCreatedIds, List<int> charactersCreatedIds,int storiesCompleted,int damageDealt,int damageReceived)
        {
            Id = id;
            LoggedIn = loggedIn;
            UserName = userName;
            Password = password;
            Email = email;
            StoriesCreatedIds = storiesCreatedIds;
            CharactersCreatedIds = charactersCreatedIds;
            StoriesCompletedTotal = storiesCompleted;
            DamageDealt = damageDealt;
            DamageReceived = damageReceived;
        }
    }
}
