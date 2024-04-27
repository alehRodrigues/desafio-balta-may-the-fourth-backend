using StarisApi.DbContexts;
using StarisApi.Models.Characters;

namespace StarisApi.Repository
{
    public sealed class CharacterRepository : Repository<Character>
    {
        public CharacterRepository(MySqlContext context) : base(context)
        {
        }

        //public IList<Character> GetCharactersByPlanet(int planetId)
        //{
        //    return context.Characters.Where(x => x.PlanetId == planetId).ToList();
        //}
    }
}
