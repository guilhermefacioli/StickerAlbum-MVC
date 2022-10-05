using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StickerAlbum.Command.Teams;
using StickerAlbum.Common;
using StickerAlbum.Filters;
using StickerAlbum.Model.Teams;
using StickerAlbum.ViewModel.Teams;

namespace StickerAlbum.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TeamController> _logger;
        private readonly ITeamService _teamService;

        public TeamController(
            IMapper mapper, 
            ILogger<TeamController> logger, 
            ITeamService teamService
            )
        {
            _mapper = mapper;
            _logger = logger;
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterTeamViewModel model,[FromQuery] PagingOptions pagingOptions)
        {
            var filter = _mapper.Map<Filter>(model);
            var response = await _teamService.GetAllTeam(filter, pagingOptions);

            if (response.IsError) 
            { 
                return Problem(string.Join(',', response.Errors), statusCode: 500); 
            }

            var items = response.Result!.Items!
                .Select(x => _mapper.Map<TeamViewModel>(x));

            return Ok(new CollectionResult<TeamViewModel>
            {
                Items = items.ToList(),
                Total = response.Result.Total
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(Guid id)
        {
            var response = await _teamService.GetTeam(id);

            if (response.IsError)
            {
                return Problem(string.Join(',', response.Errors), statusCode: 500);
            }

            var item = _mapper.Map<TeamViewModel>(response.Result);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamViewModel model)
        {
            var command = new TeamCreateCommand(model.Name, model.PrimaryColor, model.SecondaryColor);

            var result = await _teamService.CreateTeam(command);

            if (result.IsError)
            {
                return Problem(string.Join(',', result.Errors), statusCode: 500);
            }

            return Created(result.Result!.Id.ToString(), _mapper.Map<TeamViewModel>(result.Result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(Guid id, [FromBody] CreateTeamViewModel model)
        {
            var command = new TeamUpdateCommand(model.Name, model.PrimaryColor, model.SecondaryColor);

            await _teamService.UpdateTeam(id, command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {
            await _teamService.DeleteTeam(id);

            return NoContent();
        }
    }
}
