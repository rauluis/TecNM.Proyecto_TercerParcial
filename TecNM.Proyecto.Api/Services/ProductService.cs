using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _ProductRepository;
    private readonly IProductCategoryRepository _ProductCategoryRepository;


    public ProductService(IProductRepository ProductRepository, IProductCategoryRepository ProductCategoryRepository)
    {
        _ProductRepository = ProductRepository;
        _ProductCategoryRepository = ProductCategoryRepository;

    }

    public async Task<ProductDto> SaveAsync(ProductDto productDto)
    {

        var productoCategory = await _ProductCategoryRepository.GetById(productDto.IdCategory);
        if (productoCategory == null)
            throw new Exception("Categoria del producto no encontrado");


        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Image = productDto.Image,
            Stock = productDto.Stock,
            IdCategory = productDto.IdCategory,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };

        product = await _ProductRepository.SaveAsync(product);
        productDto.Id = product.Id;
        return productDto;
    }

    public async Task<ProductDto> UpdateAsync(ProductDto productDto)
    {
        var product = await _ProductRepository.GetById(productDto.Id);
        if (product == null)
            throw new Exception("Product Not Found");

        var productoCategory = await _ProductCategoryRepository.GetById(productDto.IdCategory);
        if (productoCategory == null)
            throw new Exception("ProductCategory Not Found");

        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Price = productDto.Price;
        product.Image = productDto.Image;
        product.Stock = productDto.Stock;
        product.IdCategory = productDto.IdCategory;
        product.UpdatedBy = "";
        product.UpdateDate = DateTime.Now;
        await _ProductRepository.UpdateAsync(product);

        return productDto;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var categories = await _ProductRepository.GetAllAsync();
        var categoriesDto =
            categories.Select(c => new ProductDto(c)).ToList();
        return categoriesDto;
    }
    public async Task<bool> ProductExist(int id)
    {
        var product = await _ProductRepository.GetById(id);
        return (product != null);
    }
    public async Task<ProductDto> GetById(int id)
    {
        var product = await _ProductRepository.GetById(id);
        if (product == null)
            throw new Exception("Product product Not Found");
        var productDto = new ProductDto(product);
        return productDto;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _ProductRepository.DeleteAsync(id);
    }
}

