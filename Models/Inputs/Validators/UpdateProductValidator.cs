using FluentValidation;
using devReviews.API.Models;

namespace devReviews.API.Models.Inputs.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductInputModel>
    {
        public UpdateProductValidator()
        {    
             RuleFor(m => m.Description)
                .NotEmpty()
                    .WithMessage("Description must not ve null or empty")
                .MaximumLength(255)
                    .WithMessage("Description can only contain up to 255 characters");
        }
    }
}