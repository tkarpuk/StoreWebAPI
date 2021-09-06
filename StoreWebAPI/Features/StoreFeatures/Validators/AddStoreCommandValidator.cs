﻿using FluentValidation;
using StoreWebAPI.Features.StoreFeatures.Commands;

namespace StoreWebAPI.Features.StoreFeatures.Validators
{
    public class AddStoreCommandValidator : AbstractValidator<AddStoreCommand>
    {
        public AddStoreCommandValidator()
        {
            RuleFor(c => c.Store.Name).NotEmpty().WithMessage("Name of Store can't be empty.");
            RuleFor(c => c.Store.Adress).NotEmpty().WithMessage("Adress of Store can't be empty.");
        }
    }
}
