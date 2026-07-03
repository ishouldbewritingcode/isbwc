using FluentValidation;

namespace isbwc.Application.Features.Sites.CreateSite;

public sealed class CreateSiteValidator : AbstractValidator<CreateSiteCommand>
{
	public CreateSiteValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(200);

		RuleFor(x => x.Title)
			.NotEmpty()
			.MaximumLength(200);
	}
}
