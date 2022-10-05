using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StickerAlbum.Command.Players;
using StickerAlbum.Common;
using StickerAlbum.Filters;
using StickerAlbum.Model.Players;
using StickerAlbum.ViewModel.Players;

namespace StickerAlbum.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerService _playerService;

        public PlayerController(
            IMapper mapper, 
            ILogger<PlayerController> logger, 
            IPlayerService playerService
            )
        {
            _mapper = mapper;
            _logger = logger;
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterPlayerViewModel model, [FromQuery] PagingOptions pagingOptions)
        {
            var filter = _mapper.Map<PlayerFilter>(model);
            var response = await _playerService.GetAllPlayer(filter, pagingOptions);

            if (response.IsError)
            {
                return Problem(string.Join(',', response.Errors), statusCode: 500);
            }

            var items = response.Result!.Items!
                .Select(x => _mapper.Map<PlayerViewModel>(x));
            return Ok(new CollectionResult<PlayerViewModel>
            {
                Items = items.ToList(),
                Total = response.Result.Total
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(Guid id)
        {
            var response = await _playerService.GetPlayer(id);

            if (response.IsError)
            {
                return Problem(string.Join(',', response.Errors), statusCode: 500);
            }

            var item = _mapper.Map<PlayerViewModel>(response.Result);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerViewModel model)
        {
            var command = new PlayerCreateCommand(model.Name, model.Height, model.Club, model.ImagePlayerId);

            var result = await _playerService.CreatePlayer(command);

            if (result.IsError)
            {
                return Problem(string.Join(',', result.Errors), statusCode: 500);
            }

            return Created(result.Result!.Id.ToString(), _mapper.Map<PlayerViewModel>(result.Result));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(Guid id, [FromBody] CreatePlayerViewModel model)
        {
            var command = new PlayerUpdateCommand(model.Name, model.Height, model.Club);

            await _playerService.UpdatePlayer(id, command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            await _playerService.DeletePlayer(id);
            return NoContent();
        }
    }

}
