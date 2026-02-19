using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryApp.Application.Features.CategoryFeature.Command.DeleteCategory
{
    public record DeleteCategoryCommand(int id) : IRequest<bool>;

}
