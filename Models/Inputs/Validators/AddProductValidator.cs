using FluentValidation;
using devReviews.API.Models;

namespace devReviews.API.Models.Inputs.Validators
{
    public class AddProductValidator : AbstractValidator<AddProductInputModel>
    {
        public AddProductValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                    .WithMessage("Title must not ve null or empty")
                .MaximumLength(50)
                    .WithMessage("Title can only contain up to 50 characters");
            
             RuleFor(m => m.Description)
                .NotEmpty()
                    .WithMessage("Description must not ve null or empty")
                .MaximumLength(255)
                    .WithMessage("Description can only contain up to 255 characters");
        }
    }
}