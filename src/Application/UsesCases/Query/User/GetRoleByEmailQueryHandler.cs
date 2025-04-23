using Application.Interface;
using Domain.Common.OptionResponse;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Application.UsesCases.Query
{
    public class GetRoleByEmailQueryHandler : IRequestHandler<GetRoleByEmailQuery, Option<User>>
    {
        private readonly IDataBaseService _dataBaseService;

        public GetRoleByEmailQueryHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<Option<User>> Handle(GetRoleByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Email))
                    return new Failed<User>("El correo no puede estar vacio");

                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!emailRegex.IsMatch(request.Email))
                    return new Failed<User>("El formato del correo electronico no es valido");

                // Filtrar el usuario por correo
                var user = await _dataBaseService.Users
                    .Include(u => u.Role) // Aseg�rate de incluir la relaci�n con Role si es necesario
                    .FirstOrDefaultAsync(u => u.Email == request.Email);

                if (user == null)
                    return new Failed<User>($"No se encontro un usuario con el email {request.Email}");

                return new Success<User>(user);
            }
            catch (Exception ex)
            {
                return new Failed<User>("Ocurrio un error en el sistema, por favor intente m�s tarde");
            }
        }
    }
}
