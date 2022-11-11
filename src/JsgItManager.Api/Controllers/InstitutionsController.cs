using AutoMapper;
using JsgItManager.Api.Resources;
using JsgItManager.Api.Validators;
using JsgItManager.Core.Models;
using JsgItManager.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace JsgItManager.Api.Controllers;

public class InstitutionsController : Controller
{

    private readonly IInstitutionService _institutionService;
    private readonly IMapper _mapper;
    
    public InstitutionsController(IInstitutionService institutionService, IMapper mapper)
    {
        _institutionService = institutionService;
        _mapper = mapper;
    }
    
    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<InstitutionResource>>> GetAllInstitutions()
    {
        var institutions = await _institutionService.GetAllInstitutions();
        var institutionResources = _mapper.Map<IEnumerable<Institution>, IEnumerable<InstitutionResource>>(institutions);
        return Ok(institutionResources);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<InstitutionResource>> GetInstitutionById(Guid id)
    {
        var institution = await _institutionService.GetInstitutionByIdAsync(id);
        var institutionResource = _mapper.Map<Institution, InstitutionResource>(institution);
        return Ok(institutionResource);
    }
    
    [HttpPost("")]
    public async Task<ActionResult<InstitutionResource>> CreateInstitution([FromBody] SaveInstitutionResource saveInstitutionResource)
    {
        var validator = new SaveInstitutionResourceValidator();
        var validationResult = await validator.ValidateAsync(saveInstitutionResource);

        if (!validationResult.IsValid)
        {
            BadRequest(validationResult.Errors);
        }
            
        var institutionToCreate = _mapper.Map<SaveInstitutionResource, Institution>(saveInstitutionResource);
        var newInstitution = await _institutionService.CreateInstitutionAsync(institutionToCreate);
        var institution = await _institutionService.GetInstitutionByIdAsync(newInstitution.Id);
        var institutionResource = _mapper.Map<Institution, InstitutionResource>(institution);
        return Ok(institutionResource);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<InstitutionResource>> UpdateInstitution(Guid id, [FromBody] SaveInstitutionResource saveInstitutionResource)
    {
        var validator = new SaveInstitutionResourceValidator();
        var validationResult = await validator.ValidateAsync(saveInstitutionResource);

        if (!validationResult.IsValid)
        {
            BadRequest(validationResult.Errors);
        }
            
        var institutionToBeUpdated = await _institutionService.GetInstitutionByIdAsync(id);
        var institution = _mapper.Map<SaveInstitutionResource, Institution>(saveInstitutionResource);
        await _institutionService.UpdateInstitutionAsync(institutionToBeUpdated, institution);
        var updatedInstitution = await _institutionService.GetInstitutionByIdAsync(id);
        var updatedInstitutionResource = _mapper.Map<Institution, InstitutionResource>(updatedInstitution);
        return Ok(updatedInstitutionResource);
    }
}