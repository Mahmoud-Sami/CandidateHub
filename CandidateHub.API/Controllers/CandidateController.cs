using CandidateHub.Application.Requests;
using CandidateHub.Application.Response;
using CandidateHub.Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CandidateHub.API.Controllers
{
    [Route("api/candidate")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateService _candidateService;
        private readonly ILogger<CandidateController> _logger;


        public CandidateController(CandidateService candidateService, ILogger<CandidateController> logger)
        {
            _candidateService = candidateService;
            _logger = logger;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CandidateResponse>> UpsertCandidate([FromBody] CreateCandidateRequest candidateDto)
        {
            try
            {
                var isCandidateExists = await _candidateService._candidateRepository.IsExistsAsync(candidateDto.Email);

                var result = await _candidateService.CreateOrUpdateCandidateAsync(candidateDto);
                if (!result.IsSuccess)
                {
                    _logger.LogWarning($"Validation failed for candidate with email: {candidateDto.Email}");
                    return BadRequest(result);
                }

                if (!isCandidateExists)
                {
                    _logger.LogInformation($"Created new candidate with email: {candidateDto.Email}");
                    return CreatedAtAction(nameof(GetCandidateByEmail), new { Email = candidateDto.Email }, result);
                }
                else
                {
                    _logger.LogInformation($"Updated existing candidate with email: {candidateDto.Email}");
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error processing candidate with email: {candidateDto.Email}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error processing your request");
            }
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetCandidateByEmail(string email)
        {
            var result = await _candidateService.GetByEmailAsyn(email);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
