using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public  class Contactvalidatior : AbstractValidator<Contact>
    {
        public Contactvalidatior()
        {
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Mail Adresini boş geçemezsiniz.");
            RuleFor(x => x.ContactSUBJECT).NotEmpty().WithMessage("Konu Adını boş geçemezsiniz.");
            RuleFor(x => x.ContactUserName).NotEmpty().WithMessage("Kullanıcı Adını boş geçemezsiniz.");
            RuleFor(x => x.ContactSUBJECT).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.ContactUserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.ContactSUBJECT).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın");
        }
    }
}
