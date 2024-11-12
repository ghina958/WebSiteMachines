using CloudinaryDotNet.Actions;

namespace WebSiteMachines.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(String publicUrl);
    }
}
