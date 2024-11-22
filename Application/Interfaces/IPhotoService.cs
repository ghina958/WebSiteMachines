using CloudinaryDotNet.Actions;

namespace WebSiteMachines.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(Microsoft.AspNetCore.Http.IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(String publicUrl);
    }
}
