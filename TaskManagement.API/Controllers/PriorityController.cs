using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Models.Domain;
using TaskManagement.API.Models.DTO;
using TaskManagement.API.Repositories;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityRepository priorityRepository;
        private readonly IMapper mapper;

        public PriorityController(IPriorityRepository priorityRepository, IMapper mapper)
        {
            this.priorityRepository = priorityRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var priority = await priorityRepository.GetByIdAsync(id);
            if (priority == null)
            {
                return NotFound();
            }
            var priorityDto = mapper.Map<PriorityDto>(priority);
            return Ok(priorityDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var priorities = await priorityRepository.GetAllAsync();
            var priorityDtos = mapper.Map<IEnumerable<PriorityDto>>(priorities);
            return Ok(priorityDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPriorityRequestDto addPriorityRequestDto)
        {
            var priorityDomainModel = mapper.Map<Priority>(addPriorityRequestDto);
            var createdPriority = await priorityRepository.CreateAsync(priorityDomainModel);
            var createdPriorityDto = mapper.Map<AddPriorityRequestDto>(createdPriority);
            return CreatedAtAction(nameof(GetById), new { id = createdPriority.Id }, createdPriorityDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePriorityRequestDto updatePriorityRequestDto)
        {
            var priorityDomainModel = mapper.Map<Priority>(updatePriorityRequestDto);
            var updatedPriority = await priorityRepository.UpdateAsync(id, priorityDomainModel);
            if (updatedPriority == null)
            {
                return NotFound();
            }
            var updatedPriorityDto = mapper.Map<UpdatePriorityRequestDto>(updatedPriority);
            return Ok(updatedPriorityDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedPriority = await priorityRepository.DeleteAsync(id);
            if (deletedPriority == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PriorityDto>(deletedPriority));
        }
    }
}
