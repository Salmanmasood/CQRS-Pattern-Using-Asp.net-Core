using MediatR;
using Pattern.CQRS.Services;
using System.Threading;
using System.Threading.Tasks;
namespace Pattern.CQRS.Features.Players.Commands
{
    public class DeletePlayerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int? ShirtNo { get; set; }
        public string Name { get; set; }
        public int? Appearances { get; set; }
        public int? Goals { get; set; }

        public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, int>
        {
            private readonly IPlayersService _playerService;

            public DeletePlayerCommandHandler(IPlayersService playerService)
            {
                _playerService = playerService;
            }

            public async Task<int> Handle(DeletePlayerCommand command, CancellationToken cancellationToken)
            {
                var player = await _playerService.GetPlayerById(command.Id);
                if (player == null)
                    return default;

                return await _playerService.DeletePlayer(player);
            }
        }
    }
}
