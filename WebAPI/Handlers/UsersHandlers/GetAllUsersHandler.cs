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
    public class GetAllUsersHandler : BaseHandler<GetAllUsersRequest, GetAllUsersResponse>
    {
        private readonly IUsersRepository _repository;

        public GetAllUsersHandler(IUsersRepository usersRepository = null)
        {
            _repository = usersRepository ?? new UsersRepository();
        }

        public override GetAllUsersResponse HandleCore(GetAllUsersRequest request)
        {
            List<User> users = _repository.GetAll();

            return new GetAllUsersResponse { Users = users };
        }

        public override bool Validate(GetAllUsersRequest request)
        {
            List<ErrorDto> errors = new List<ErrorDto>();

            Response = new GetAllUsersResponse { Errors = errors };

            return true;
        }

    }
}