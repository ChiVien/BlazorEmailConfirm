namespace BlazorApp2.Server.Services.HinhAnhService
{
    public interface IHinhAnhService
    {
        Task<string> UploadFile(string file);
        bool DeleteFile(string filePath);
    }
}
