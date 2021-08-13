using Pattern.CQRS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pattern.CQRS.Services
{
   public interface IPlayersService
    {
        Task<IEnumerable<Player>> GetPlayersList();
        Task<Player> GetPlayerById(int id);
        Task<Player> CreatePlayer(Player player);
        Task<int> UpdatePlayer(Player player);
        Task<int> DeletePlayer(Player player);
    }
}
