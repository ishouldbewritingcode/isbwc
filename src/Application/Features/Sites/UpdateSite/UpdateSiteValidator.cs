using FluentValidation;

namespace isbwc.Application.Features.Sites.UpdateSite;

public sealed class UpdateSiteValidator : AbstractValidator<UpdateSiteRequest>
{
	public UpdateSiteValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(200);

		RuleFor(x => x.Title)
			.NotEmpty()
			.MaximumLength(200);
	}
}
