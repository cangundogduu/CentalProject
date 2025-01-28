﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators
{
    public class CustomErorDescriber: IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir küçük harf (a-z) içermelidir."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir rakam (0-9) içermelidir."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir büyük harf (A-Z) içermelidir."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir özel karakter(*,+,!...) içermelidir."
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Description = $"Şifre en az {length} karakterden oluşmalıdır."
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Description = $"{email} daha önce sisteme kayıt olmuştur."
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Description = $"{userName} daha önce sisteme kayıt olmuştur."
            };
        }
    }
}
