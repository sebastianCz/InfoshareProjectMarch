namespace OstreCWEB.Services.GameService
{
    public interface IGameService
    {
        public Task CreateNewGame(int storyId, string userId);
    }
}
