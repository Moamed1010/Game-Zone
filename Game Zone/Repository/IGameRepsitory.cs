namespace Game_Zone.Repository
{
    public interface IGameRepsitory
    {
        IEnumerable<Game> GetAllGames();
        Task Create(CreateVM modle);
        Task<Game?> Udpate(EditVM modle);
        bool Delete(int id);
        Game? GetById(int id);

        Task<string> savecover(IFormFile cover);

    }
}
