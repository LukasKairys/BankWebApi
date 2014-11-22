using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Dto;
using WebAPI.Messages.UserMessages;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Handlers.UsersHandlers
{
    public class GetUserHandler : BaseHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IUsersRepository _repository;

        public GetUserHandler(IUsersRepository usersRepository = null)
        {
            _repository = usersRepository ?? new UsersRepository();
        }

        public override GetUserResponse HandleCore(GetUserRequest request)
        {
            User user = _repository.Get(request.UserId);

            return new GetUserResponse {UserFound = user };
        }

        public override bool Validate(GetUserRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new GetUserResponse { Errors = errors };

            return true;
        }

    }
}