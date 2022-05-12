using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Kullanıcı soyadı boş geçilemez.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapın");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lüfen en az 3 karakter girişi yapın.");
            RuleFor(x => x.SurName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapın");
            RuleFor(x => x.SurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakterr girişi yapın.");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapın");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
        }
    }
}
