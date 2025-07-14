using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using MediatR;

namespace LibraryApp.Application.Features.CategoryFeature.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.Id);
            if (category == null)
            {
                throw new NotFoundException($"Category with Id::{request.Id} not found");
            }

            category.Name = request.Name;
            category.Description = request.Description;

            await _categoryRepository.UpdateCategoryAsync(category.CategoryId, category);
            return true;
        }
    }

}
