using AutoMapper;
using CategoryService.Data;
using CategoryService.Dtos;
using CategoryService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CategoryReadDto>> GetAllCategories()
    {
        Console.WriteLine("Getting All Categories...");

        var categories = _repository.Get();

        return Ok(_mapper.Map<IEnumerable<CategoryReadDto>>(categories));
    }

    [HttpGet("{id}", Name = "GetCategoryById")]
    public ActionResult<CategoryReadDto> GetCategoryById(long id)
    {
        Category category = _repository.GetById(id);

        if(category is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CategoryReadDto>(category));
    }

    [HttpPost]
    public ActionResult<CategoryReadDto> CreateCategory(CategoryCreateDto categoryCreateDto)
    {
        Category category = _mapper.Map<Category>(categoryCreateDto);

        _repository.Add(category);
        _repository.Save();

        CategoryReadDto categoryReadDto = _mapper.Map<CategoryReadDto>(category);

        return CreatedAtRoute(nameof(GetCategoryById), new { id = categoryReadDto.Id }, categoryReadDto);
    }

}