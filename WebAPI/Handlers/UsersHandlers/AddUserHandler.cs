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
    public class AddUserHandler : BaseHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IUsersRepository _repository;

        public AddUserHandler(IUsersRepository usersRepository = null)
        {
            _repository = usersRepository ?? new UsersRepository();
        }

        public override AddUserResponse HandleCore(AddUserRequest request)
        {
            _repository.Insert(request.User);

            return new AddUserResponse();
        }

        public override bool Validate(AddUserRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new AddUserResponse { Errors = errors };

            return true;
        }

    }
}