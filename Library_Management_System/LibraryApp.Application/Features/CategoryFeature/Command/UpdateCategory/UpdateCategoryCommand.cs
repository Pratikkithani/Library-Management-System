using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryApp.Application.Features.CategoryFeature.Command.UpdateCategory
{
    public record UpdateCategoryCommand(int Id, string Name, string Description) : IRequest<bool>;

}
