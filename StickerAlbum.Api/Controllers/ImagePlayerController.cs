using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StickerAlbum.Command.ImagePlayers;
using StickerAlbum.Common;
using StickerAlbum.Filters;
using StickerAlbum.Model.ImagePlayers;
using StickerAlbum.ViewModel.ImagePlayers;

namespace StickerAlbum.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagePlayerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ImagePlayerController> _logger;
        private readonly IImagePlayerService _imagePlayerService;

        public ImagePlayerController(
            IMapper mapper, 
            ILogger<ImagePlayerController> logger, 
            IImagePlayerService imagePlayerService
            )
        {
            _mapper = mapper;
            _logger = logger;
            _imagePlayerService = imagePlayerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterImagePlayerViewModel model, [FromQuery] PagingOptions pagingOptions)
        {
            var filter = _mapper.Map<Filter>(model);
            var response = await _imagePlayerService.GetAllImage(filter, pagingOptions);

            if (response.IsError)
            {
                return Problem(string.Join(',', response.Errors), statusCode: 500);
            }

            var items = response.Result!.Items!
                .Select(x => _mapper.Map<ImagePlayerViewModel>(x));

            return Ok(new CollectionResult<ImagePlayerViewModel>
            {
                Items = items.ToList(),
                Total = response.Result.Total
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(Guid id)
        {
            var response = await _imagePlayerService.GetImage(id);

            if (response.IsError)
            {
                return Problem(string.Join(',', response.Errors), statusCode: 500);
            }

            var item = _mapper.Map<ImagePlayerViewModel>(response.Result);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImagePlayer(IFormFile file, [FromForm] CreateImagePlayerViewModel model)
        {
            var command = new ImagePlayerCreateCommand(
                Guid.NewGuid(), model.Name, model.Path, file);

            var result = await _imagePlayerService.CreateImage(command);
            
            if (result.IsError)
            {
                return Problem(string.Join(',', result.Errors), statusCode: 500);
            }

            return Created(result.Result!.Id.ToString(), _mapper.Map<ImagePlayerViewModel>(result.Result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            await _imagePlayerService.DeleteImage(id);
            return NoContent();
        }
    }
}
