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
    public class DeleteUserHandler : BaseHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUsersRepository _repository;

        public DeleteUserHandler(IUsersRepository usersRepository = null)
        {
            _repository = usersRepository ?? new UsersRepository();
        }

        public override DeleteUserResponse HandleCore(DeleteUserRequest request)
        {
            _repository.Delete(request.UserId);

            return new DeleteUserResponse();
        }

        public override bool Validate(DeleteUserRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new DeleteUserResponse { Errors = errors };

            return true;
        }

    }
}