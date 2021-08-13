using MediatR;
using Pattern.CQRS.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Pattern.CQRS.Features.Players.Commands
{
    public class UpdatePlayerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int? ShirtNo { get; set; }
        public string Name { get; set; }
        public int? Appearances { get; set; }
        public int? Goals { get; set; }

        public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, int>
        {
            private readonly IPlayersService _playerService;

            public UpdatePlayerCommandHandler(IPlayersService playerService)
            {
                _playerService = playerService;
            }

            public async Task<int> Handle(UpdatePlayerCommand command, CancellationToken cancellationToken)
            {
                var player = await _playerService.GetPlayerById(command.Id);
                if (player == null)
                    return default;

                player.ShirtNo = command.ShirtNo;
                player.Name = command.Name;
                player.Appearances = command.Appearances;
                player.Goals = command.Goals;

                return await _playerService.UpdatePlayer(player);
            }
        }
    }
}
