using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Repositories;

public class InMemoryProductCategoryRepository:IProductCategoryRepository
{

    private readonly List<ProductCategory> _categories;
    public InMemoryProductCategoryRepository(){
        _categories = new List<ProductCategory>();
    }


    public async Task<ProductCategory> SaveAsync(ProductCategory category)
    {
        category.Id = _categories.Count +1;

        _categories.Add(category);

        return category;
    }

    public async Task<ProductCategory> UpdateAsync(ProductCategory category)
    {
        var index = _categories.FindIndex(x => x.Id == category.Id);
        if(index != -1)
            _categories[index] = category;
        return await Task.FromResult(category);
    }

    public async Task<List<ProductCategory>> GetAllAsync()
    {
        // var list = new List<ProductCategory>();
        // list.Add(new ProductCategory{Id = 1, Name = "Test", Description = "Test"});
        // list.Add(new ProductCategory{Id = 2, Name = "Test2", Description = "Test2"});
        return _categories;
    }

    public async Task<bool> DeleteAsync(int id)
    {   
        _categories.RemoveAll(x => x.Id == id);

        return true;        
    }

    public async Task<ProductCategory> GetById(int id)
    {
        //que obtenga el primero, pide una condicion. 
        var category = _categories.FirstOrDefault(x => x.Id == id);
        
        return await Task.FromResult(category);
    }
}