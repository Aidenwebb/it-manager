using AutoMapper;
using JsgItManager.Api.Resources;
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
}