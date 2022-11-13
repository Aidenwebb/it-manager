using AutoMapper;
using ItManager.Api.Resources;
using ItManager.Api.Validators;
using ItManager.Core.Models;
using ItManager.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItManager.Api.Controllers;

public class InstitutionsController : ControllerBase
{

    private readonly IClientService _clientService;
    private readonly IMapper _mapper;
    
    public InstitutionsController(IClientService institutionService, IMapper mapper)
    {
        _clientService = institutionService;
        _mapper = mapper;
    }
    
    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<InstitutionResource>>> GetAllClients()
    {
        var institutions = await _clientService.GetAllClients();
        var institutionResources = _mapper.Map<IEnumerable<Client>, IEnumerable<InstitutionResource>>(institutions);
        return Ok(institutionResources);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<InstitutionResource>> GetClientById(Guid id)
    {
        var institution = await _clientService.GetClientByIdAsync(id);

        if (institution is null)
        {
            return NotFound();
        }

        var institutionResource = _mapper.Map<Client, InstitutionResource>(institution);
        return Ok(institutionResource);
    }
    
    [HttpPost("")]
    public async Task<ActionResult<InstitutionResource>> CreateClient([FromBody] SaveInstitutionResource saveInstitutionResource)
    {
        var validator = new SaveInstitutionResourceValidator();
        var validationResult = await validator.ValidateAsync(saveInstitutionResource);

        if (!validationResult.IsValid)
        {
            BadRequest(validationResult.Errors);
        }
            
        var institutionToCreate = _mapper.Map<SaveInstitutionResource, Client>(saveInstitutionResource);
        var newInstitution = await _clientService.CreateClientAsync(institutionToCreate);
        var institution = await _clientService.GetClientByIdAsync(newInstitution.Id);
        var institutionResource = _mapper.Map<Client, InstitutionResource>(institution);
        return Ok(institutionResource);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<InstitutionResource>> UpdateClient(Guid id, [FromBody] SaveInstitutionResource saveInstitutionResource)
    {
        var validator = new SaveInstitutionResourceValidator();
        var validationResult = await validator.ValidateAsync(saveInstitutionResource);

        if (!validationResult.IsValid)
        {
            BadRequest(validationResult.Errors);
        }
            
        var institutionToBeUpdated = await _clientService.GetClientByIdAsync(id);

        if (institutionToBeUpdated is null)
        {
            return NotFound();
        }

        var institution = _mapper.Map<SaveInstitutionResource, Client>(saveInstitutionResource);
        await _clientService.UpdateClientAsync(institutionToBeUpdated, institution);
        var updatedInstitution = await _clientService.GetClientByIdAsync(id);
        var updatedInstitutionResource = _mapper.Map<Client, InstitutionResource>(updatedInstitution);
        return Ok(updatedInstitutionResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        var institution = await _clientService.GetClientByIdAsync(id);

        if (institution is null)
        {
            return NotFound();
        }

        await _clientService.DeleteClientAsync(institution);
        return NoContent();
    }
}