using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly DataContext _dataContext;

            public Handler(IUserAccessor userAccessor, IPhotoAccessor photoAccessor, DataContext dataContext)
            {
                _userAccessor = userAccessor;
                _photoAccessor = photoAccessor;
                _dataContext = dataContext;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _dataContext.Users
                    .Include(u => u.Photos)
                    .FirstOrDefaultAsync(u => u.UserName == _userAccessor.GetUsername());

                if (user == null) return null;

                var photo = user.Photos.FirstOrDefault(p => p.Id == request.Id);
                if (photo == null) return null;

                if (photo.IsMain) return Result<Unit>.Failure("You cannot delete your main photo");

                var result = await _photoAccessor.DeletePhoto(photo.Id);
                if (result == null) return Result<Unit>.Failure("Problme deleting photo from Cloudinary");

                user.Photos.Remove(photo);
                var success = await _dataContext.SaveChangesAsync() > 0;

                if (success) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Problme deleting photo from API");
            }
        }
    }
}