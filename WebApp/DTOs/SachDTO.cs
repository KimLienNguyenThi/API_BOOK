using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class SachDTO
    {
        [Key]
        public int MaSach { get; set; }

        public string? TenSach { get; set; }

        public string? TheLoai { get; set; }

        public string? TacGia { get; set; }

        public string? NgonNgu { get; set; }

        public string? Nxb { get; set; }

        public int? NamXb { get; set; }

        public int? SoLuongHientai { get; set; }

        public string? UrlImage { get; set; }

        public string? Mota { get; set; }
    }
}
