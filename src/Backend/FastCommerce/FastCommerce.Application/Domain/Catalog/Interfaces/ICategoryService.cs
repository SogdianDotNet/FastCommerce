using FastCommerce.Application.Domain.Catalog.Dtos;

namespace FastCommerce.Application.Domain.Catalog.Interfaces;

public interface ICategoryService
{
    Task<IReadOnlyCollection<CategoryDto>> GetAsync(CancellationToken cancellationToken = default);

    Task<CategoryDto> SaveAsync(CategoryDto categoryDto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid categoryId, CancellationToken cancellationToken = default);

    Task<CategoryDto> UpdateAsync(CategoryDto categoryDtoToUpdate, CancellationToken cancellationToken = default);

    Task DeactivateAsync(Guid categoryId, CancellationToken cancellationToken = default);
}
