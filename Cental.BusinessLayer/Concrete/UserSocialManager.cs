using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    internal class UserSocialManager(IUserSocialDal _userSocialDal, IMapper _mapper) : IUserSocialService
    {
        public void TCreate(UserSocial entity)
        {
            _userSocialDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _userSocialDal.Delete(id);
        }

        public List<UserSocial> TGetAll()
        {
            return _userSocialDal.GetAll();
        }

        public List<ResultUserSocialDto> TGetAllSocialsByUserId(int userId)
        {
            var values= _userSocialDal.GetAllSocialsByUserId(userId);
            return _mapper.Map<List<ResultUserSocialDto>>(values);
        }

        public UserSocial TGetById(int id)
        {
            return _userSocialDal.GetById(id);
        }

        public void TUpdate(UserSocial entity)
        {
            _userSocialDal.Update(entity);
        }
    }
}
