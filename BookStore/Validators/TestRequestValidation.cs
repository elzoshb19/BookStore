using BookStore.Models.Requests;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BookStore.Validators
{
    public class TestRequestValidation : AbstractValidator<GetAllBooksByAuthorRequest>
    {

        public TestRequestValidation()
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0).WithMessage("> 0");

            RuleFor(x => x.AfterDate)
                .NotEmpty()
                .NotNull();
                
        }
    }
}
