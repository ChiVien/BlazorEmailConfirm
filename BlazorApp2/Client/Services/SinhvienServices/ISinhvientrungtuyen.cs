namespace BlazorApp2.Client.Services.SinhvienServices
{
    public interface ISinhvientrungtuyen
    {
        List<ThiSinh> thisinhs { get; set; }
        Task Getthisinh();
        Task<ThiSinh> GetSingleThisinh(int id);
        Task CreateThiSinh(ThiSinh thiSinh);
        Task UpdateThiSinh(ThiSinh thiSinh);
        Task DeleteThiSinh(int id);
    }
}
