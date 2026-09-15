using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Enums;
using EasyTask.Models.RoleFeatures;

namespace EasyTask.Features.RoleFeatures.AssignAllFeaturesToRole.Commands
{
    public record AssignAllFeaturesToRoleCommand(Role? RoleId) : IRequestBase<bool>;
    public class AssignAllFeaturesToRoleCommandHandler : RequestHandlerBase<RoleFeature, AssignAllFeaturesToRoleCommand, bool>
    {
        public AssignAllFeaturesToRoleCommandHandler(RequestHandlerBaseParameters<RoleFeature> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AssignAllFeaturesToRoleCommand request, CancellationToken cancellationToken)
        {
            Role role = request.RoleId ?? Role.Candidate;

            if (!Enum.IsDefined(typeof(Role), role))
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            var allFeatures = Enum.GetValues(typeof(Feature)).Cast<Feature>().ToList();

            var selectableFeatures = EnumHelper.ToSelectableList<Feature>();

            var assignedFeatures = _repository
                .Get(rf => rf.RoleId == role)
                .Select(rf => rf.Features)
                .ToList();
            List<RoleFeature> roleFeatures = new List<RoleFeature>();
            var newFeatures = allFeatures.Except(assignedFeatures).ToList();

            foreach (var feature in newFeatures)
            {
                var roleFeature = new RoleFeature
                {
                    RoleId = role,
                    Features = feature
                };

                roleFeatures.Add(roleFeature);
            }
            _repository.AddRange(roleFeatures);
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
