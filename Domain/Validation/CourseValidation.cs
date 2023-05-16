using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using FluentValidation;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Requests.Users.Organisation;
using Shared.Contracts.Requests.Users.Student;
using Shared.Models.Items;
using Shared.Models.Users;

namespace Domain.Validation
{
    public class CourseValidation : ItemValidation<Course>
    {
        public CourseValidation(CategoryRepo categoryRepo, SubcategoryRepo subcategoryRepo, ICountryRepo countryRepo,
            UserRepo<Organisation, GetOrganisationRequest, GetAllOrganisationsRequest> organisationRepo,
            ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo) :
            base(categoryRepo, subcategoryRepo, countryRepo, organisationRepo, itemRepo)
        {
            //active students are not needed for courses to be created
            RuleFor(x => x.Curriculum).NotEmpty().WithMessage("Curriculum must me filled");
            RuleFor(x => new { x.StartDate, x.EndDate }).Must(d => d.EndDate > d.StartDate).WithMessage("The course cannot end before it starts");
            RuleFor(x => x.ExpectedApplicants).Must(ea => ea > 0).WithMessage(" The number of applicants must be positive");
            RuleFor(x => new { x.ExpectedGraduates, x.ExpectedApplicants }).Must(eg => eg.ExpectedGraduates > 0 && eg.ExpectedGraduates <= eg.ExpectedApplicants).
                WithMessage(" The number of graduates must be positive and cannot be larger than the number of applicants");
            RuleFor(x => x.ActiveStudents).Must(a => a != null || a >= 0).WithMessage("The number  of active student smust be positive");

        }
    }
}
