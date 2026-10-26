using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.Openings.Request.Commands;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Openings.Handlers.Commands
{
    public class UpdateOpeningCommandHandler : IRequestHandler<UpdateOpeningCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOpeningCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateOpeningCommand request, CancellationToken cancellationToken)
        {
            var opening = await _unitOfWork.OpeningRepository.Get(request.Opening.Id, cancellationToken);

            if (opening is null)
                throw new NotFoundException(nameof(opening), request.Opening.Id);

            request.Opening.ApplyTo(opening);

            _unitOfWork.OpeningRepository.Update(opening);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
