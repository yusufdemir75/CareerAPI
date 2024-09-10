using CareerAPI.Application.Features.Commands.Advert.CreateAdvert;
using CareerAPI.Application.ViewModels.Adverts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Validators.Adverts
{
    public class CreateAdvertValidator : AbstractValidator<CreateAdvertCommandRequest>
    {
        public CreateAdvertValidator()
        {
            RuleFor(p => p.title)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen İlan Başlığını Boş geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Lütfen ilan başlığını 5-150 karakter arasında giriniz");

            RuleFor(p => p.companyName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Şirket Adını Boş geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Lütfen Şirket Adını 5-150 karakter arasında giriniz");

            RuleFor(p => p.Address)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Adresinizi Boş geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(15)
                    .WithMessage("Lütfen Adresinizi 15-150 karakter arasında giriniz");

            RuleFor(p => p.position)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Pozisyonu Boş geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Lütfen Pozisyonu 5-150 karakter arasında giriniz");

            RuleFor(p => p.requirements)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Gereklilikleri Boş geçmeyiniz");
        }
    }
}
