using Domain.Common.OptionResponse;
using Domain.Entity;
using MediatR;

namespace Application.UsesCases.Query
{
    public class GetRoleByEmailQuery : IRequest<Option<User>>
    {
        public string Email { get; set; }

        public GetRoleByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
