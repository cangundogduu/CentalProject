using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators
{
    public class CarValidator: AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x=>x.ModelName).NotEmpty().WithMessage("Araba modeli boş bırakılamaz!");
            RuleFor(x => x.Transmission).NotEmpty().WithMessage("Vites türü boş bırakılamaz!");
            RuleFor(x => x.GasType).NotEmpty().WithMessage("Yakıt türü boş bırakılamaz!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş bırakılamaz!");
            RuleFor(x => x.Kilometer).NotEmpty().WithMessage("Yıl boş bırakılamaz!");
            RuleFor(x => x.GearType).NotEmpty().WithMessage("Vites boş bırakılamaz!");
            RuleFor(x => x.SaetCount).NotEmpty().WithMessage("Koltuk sayısı bırakılamaz!");
        }
    }
}
