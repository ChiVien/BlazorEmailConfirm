namespace BlazorApp2.Client.Services.SinhvienServices
{
    public interface ISinhvientrungtuyen
    {
        List<ThiSinh> thisinhs { get; set; }
        Task Getthisinh();
        Task<ThiSinh> GetSingleThisinh(int id);
        Task CreateThiSinh(ThiSinh thiSinh,List<AnhUpload> anhUploads);
        Task UpdateThiSinh(ThiSinh thiSinh, List<AnhUpload> anhUploads);
        Task DeleteThiSinh(int id);
    }
}
