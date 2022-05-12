using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
     public class WorkValidator:AbstractValidator<Work>
    {
        public WorkValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı boş geçilemez.");
            RuleFor(x => x.WorkName).NotEmpty().WithMessage("İş adı boş geçilemez.");
            //RuleFor(x => x.WorkId).NotEmpty().WithMessage("Id alanı boş geçilemez.");
            RuleFor(x => x.WorkStartDate).NotEmpty().WithMessage("İş başlangıç tarihi boş geçilemez.");
            RuleFor(x => x.WorkEndDate).NotEmpty().WithMessage("İş bitiş tarihi boş geçilemez.");
            RuleFor(x => x.WorkName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın.");
            RuleFor(x => x.WorkName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın.");
        }
    
    }
}
