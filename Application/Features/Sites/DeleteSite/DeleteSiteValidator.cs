using FluentValidation;

namespace isbwc.Application.Features.Sites.DeleteSite;

public sealed class DeleteSiteValidator : AbstractValidator<DeleteSiteCommand>
{
	public DeleteSiteValidator()
	{
		RuleFor(x => x.SiteId).NotEmpty();
	}
}
