using MediatR;
using Pattern.CQRS.Models;
using Pattern.CQRS.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Pattern.CQRS.Features.Players.Queries
{
    public class GetPlayerByIdQuery : IRequest<Player>
    {
        public int Id { get; set; }

        public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player>
        {
            private readonly IPlayersService _playerService;

            public GetPlayerByIdQueryHandler(IPlayersService playerService)
            {
                _playerService = playerService;
            }

            public async Task<Player> Handle(GetPlayerByIdQuery query, CancellationToken cancellationToken)
            {
                return await _playerService.GetPlayerById(query.Id);
            }
        }
    }
}
