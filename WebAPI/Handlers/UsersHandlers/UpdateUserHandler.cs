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
    public class UpdateUserHandler : BaseHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUsersRepository _repository;

        public UpdateUserHandler(IUsersRepository usersRepository = null)
        {
            _repository = usersRepository ?? new UsersRepository();
        }

        public override UpdateUserResponse HandleCore(UpdateUserRequest request)
        {
            _repository.Update(request.User);

            return new UpdateUserResponse();
        }

        public override bool Validate(UpdateUserRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new UpdateUserResponse { Errors = errors };

            return true;
        }

    }
}