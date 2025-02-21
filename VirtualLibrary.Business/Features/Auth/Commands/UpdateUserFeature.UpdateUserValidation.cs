using FluentValidation;

namespace VirtualLibrary.Application.Features.Auth.Commands
{
    public partial class UpdateUserFeature
    {
        public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
        {
            public UpdateUserValidation()
            {
                RuleFor(x => x.CurrentUserName).NotEmpty();
                RuleFor(x => x.CurrentEmail).NotEmpty();                
            }
        }
    }
}
