using FluentValidation;
using property_api.V1.UseCase.GetMultipleProperties.Boundaries;

namespace property_api.V1.Validation
{
    public class GetMultiplePropertiesValidator : AbstractValidator<GetMultiplePropertiesUseCaseRequest>
    {
        public GetMultiplePropertiesValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(propertyRequest => propertyRequest.PropertyReferences).NotNull().NotEmpty()
                .WithMessage("'{PropertyName}' must not contain null or empty values such as whitespace")
                .DependentRules(() =>
                    {
                        RuleFor(propertyRequest => propertyRequest.PropertyReferences != null
                                ? propertyRequest.PropertyReferences.Count
                                : (int?) null)
                            .ExclusiveBetween(0, 201)
                            .WithMessage(propertyRequest => "The number of '" + nameof(propertyRequest.PropertyReferences) +
                                                            "' given must be more than 0 and less than 200. ({PropertyValue} given)");

                        RuleForEach(x => x.PropertyReferences).NotNull().NotEmpty()
                            .WithMessage("'{PropertyName}' must not contain null or empty values such as whitespace ('{PropertyValue}') given");
                    });
        }
    }
}
