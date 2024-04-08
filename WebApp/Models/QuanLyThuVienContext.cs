using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;

namespace WebApp.Models;

public partial class QuanLyThuVienContext : DbContext
{
    public QuanLyThuVienContext()
    {
    }

    public QuanLyThuVienContext(DbContextOptions<QuanLyThuVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDk> ChiTietDks { get; set; }

    public virtual DbSet<ChiTietPm> ChiTietPms { get; set; }

    public virtual DbSet<ChiTietPt> ChiTietPts { get; set; }

    public virtual DbSet<ChiTietPtl> ChiTietPtls { get; set; }

    public virtual DbSet<Chitietpn> Chitietpns { get; set; }

    public virtual DbSet<DkiMuonSach> DkiMuonSaches { get; set; }

    public virtual DbSet<DocGium> DocGia { get; set; }

    public virtual DbSet<DonViTl> DonViTls { get; set; }

    public virtual DbSet<KhoSachThanhLy> KhoSachThanhLies { get; set; }

    public virtual DbSet<LoginDg> LoginDgs { get; set; }

    public virtual DbSet<LoginNv> LoginNvs { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }

    public virtual DbSet<PhieuNhapSach> PhieuNhapSaches { get; set; }

    public virtual DbSet<PhieuThanhLy> PhieuThanhLies { get; set; }

    public virtual DbSet<PhieuTra> PhieuTras { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<TheDocGium> TheDocGia { get; set; }

    public virtual DbSet<TtSach> TtSaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=VOGIAHUY\\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDk>(entity =>
        {
            entity.HasKey(e => new { e.MaDk, e.MaSach }).HasName("ChiTietDk_MaDK_MaSach");

            entity.ToTable("ChiTietDk");

            entity.Property(e => e.MaDk).HasColumnName("MaDK");

            entity.HasOne(d => d.MaDkNavigation).WithMany(p => p.ChiTietDks)
                .HasForeignKey(d => d.MaDk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDk__MaDK__02FC7413");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietDks)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDk__MaSac__03F0984C");
        });

        modelBuilder.Entity<ChiTietPm>(entity =>
        {
            entity.HasKey(e => new { e.MaPm, e.MaSach }).HasName("ChiTietPM_MaPM_MaSach");

            entity.ToTable("ChiTietPM");

            entity.Property(e => e.MaPm).HasColumnName("MaPM");

            entity.HasOne(d => d.MaPmNavigation).WithMany(p => p.ChiTietPms)
                .HasForeignKey(d => d.MaPm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPM__MaPM__628FA481");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietPms)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPM__MaSac__6383C8BA");
        });

        modelBuilder.Entity<ChiTietPt>(entity =>
        {
            entity.HasKey(e => new { e.MaPt, e.MaSach }).HasName("ChiTietPT_MaPT_MaSach");

            entity.ToTable("ChiTietPT");

            entity.Property(e => e.MaPt).HasColumnName("MaPT");
            entity.Property(e => e.PhuThu).HasColumnType("money");

            entity.HasOne(d => d.MaPtNavigation).WithMany(p => p.ChiTietPts)
                .HasForeignKey(d => d.MaPt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPT__MaPT__6B24EA82");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietPts)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPT__MaSac__6C190EBB");
        });

        modelBuilder.Entity<ChiTietPtl>(entity =>
        {
            entity.HasKey(e => new { e.MaPtl, e.MaSachkho }).HasName("ChiTietPTL_MaPTL_MaSach");

            entity.ToTable("ChiTietPTL");

            entity.Property(e => e.MaPtl).HasColumnName("MaPTL");
            entity.Property(e => e.GiaTl)
                .HasColumnType("money")
                .HasColumnName("GiaTL");

            entity.HasOne(d => d.MaPtlNavigation).WithMany(p => p.ChiTietPtls)
                .HasForeignKey(d => d.MaPtl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPT__MaPTL__74AE54BC");

            entity.HasOne(d => d.MaSachkhoNavigation).WithMany(p => p.ChiTietPtls)
                .HasForeignKey(d => d.MaSachkho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPT__MaSac__75A278F5");
        });

        modelBuilder.Entity<Chitietpn>(entity =>
        {
            entity.HasKey(e => new { e.MaPn, e.MaSach }).HasName("ChiTietPN_MaPN_MaSach");

            entity.ToTable("CHITIETPN");

            entity.Property(e => e.MaPn).HasColumnName("MaPN");
            entity.Property(e => e.MaSach).HasColumnName("MaSACH");
            entity.Property(e => e.GiaSach).HasColumnType("money");
            entity.Property(e => e.SoLuongNhap).HasColumnName("SoLuongNHAP");

            entity.HasOne(d => d.MaPnNavigation).WithMany(p => p.Chitietpns)
                .HasForeignKey(d => d.MaPn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETPN__MaPN__59063A47");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.Chitietpns)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETPN__MaSAC__59FA5E80");
        });

        modelBuilder.Entity<DkiMuonSach>(entity =>
        {
            entity.HasKey(e => e.MaDk).HasName("PK__DkiMuonS__2725866C7F609515");

            entity.ToTable("DkiMuonSach");

            entity.Property(e => e.MaDk).HasColumnName("MaDK");
            entity.Property(e => e.NgayDkmuon).HasColumnName("NgayDKMuon");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");

            entity.HasOne(d => d.SdtNavigation).WithMany(p => p.DkiMuonSaches)
                .HasForeignKey(d => d.Sdt)
                .HasConstraintName("FK__DkiMuonSach__SDT__00200768");
        });

        modelBuilder.Entity<DocGium>(entity =>
        {
            entity.HasKey(e => e.MaDg).HasName("PK__DocGia__27258660DF589E82");

            entity.Property(e => e.MaDg).HasColumnName("MaDG");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(50);
            entity.Property(e => e.HoTenDg)
                .HasMaxLength(50)
                .HasColumnName("HoTenDG");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<DonViTl>(entity =>
        {
            entity.HasKey(e => e.MaDv).HasName("PK__DonViTL__2725865746E7E7EA");

            entity.ToTable("DonViTL");

            entity.Property(e => e.MaDv).HasColumnName("MaDV");
            entity.Property(e => e.DiaChiDv)
                .HasMaxLength(100)
                .HasColumnName("DiaChiDV");
            entity.Property(e => e.Sdtdv)
                .HasMaxLength(50)
                .HasColumnName("SDTDV");
            entity.Property(e => e.TenDv)
                .HasMaxLength(150)
                .HasColumnName("TenDV");
        });

        modelBuilder.Entity<KhoSachThanhLy>(entity =>
        {
            entity.HasKey(e => e.Masachkho).HasName("PK__KhoSachT__3E503873AFF5FD82");

            entity.ToTable("KhoSachThanhLy");

            entity.Property(e => e.Masachkho)
                .ValueGeneratedNever()
                .HasColumnName("masachkho");
            entity.Property(e => e.Soluongkhotl).HasColumnName("soluongkhotl");
        });

        modelBuilder.Entity<LoginDg>(entity =>
        {
            entity.HasKey(e => e.Sdt).HasName("PK__LOGIN_DG__CA1930A4AAA17DA6");

            entity.ToTable("LOGIN_DG");

            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.PasswordDg)
                .HasMaxLength(255)
                .HasColumnName("PASSWORD_DG");
        });

        modelBuilder.Entity<LoginNv>(entity =>
        {
            entity.HasKey(e => e.UsernameNv).HasName("PK__LOGIN_NV__296D7D76D2114FD1");

            entity.ToTable("LOGIN_NV");

            entity.Property(e => e.UsernameNv)
                .HasMaxLength(50)
                .HasColumnName("USERNAME_NV");
            entity.Property(e => e.Manv).HasColumnName("MANV");
            entity.Property(e => e.PasswordNv).HasColumnName("PASSWORD_NV");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.LoginNvs)
                .HasForeignKey(d => d.Manv)
                .HasConstraintName("FK__LOGIN_NV__MANV__7A672E12");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEB8CFE8FF8");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.DiaChiNcc)
                .HasMaxLength(100)
                .HasColumnName("DiaChiNCC");
            entity.Property(e => e.SdtNcc)
                .HasMaxLength(50)
                .HasColumnName("sdtNCC");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(150)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A25DBADC7");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(50);
            entity.Property(e => e.HoTenNv)
                .HasMaxLength(50)
                .HasColumnName("HoTenNV");
            entity.Property(e => e.Ngaysinh).HasColumnName("NGAYSINH");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<PhieuMuon>(entity =>
        {
            entity.HasKey(e => e.MaPm).HasName("PK__PhieuMuo__2725E7FF62C8D4F7");

            entity.ToTable("PhieuMuon");

            entity.Property(e => e.MaPm).HasColumnName("MaPM");
            entity.Property(e => e.MaDk).HasColumnName("MaDK");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuMuons)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PhieuMuon__MaNV__5EBF139D");

            entity.HasOne(d => d.MaTheNavigation).WithMany(p => p.PhieuMuons)
                .HasForeignKey(d => d.MaThe)
                .HasConstraintName("FK__PhieuMuon__MaThe__5FB337D6");
        });

        modelBuilder.Entity<PhieuNhapSach>(entity =>
        {
            entity.HasKey(e => e.MaPn).HasName("PK__PhieuNha__2725E7F0576113F5");

            entity.ToTable("PhieuNhapSach");

            entity.Property(e => e.MaPn).HasColumnName("MaPN");
            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.PhieuNhapSaches)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK__PhieuNhap__MaNCC__5441852A");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuNhapSaches)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PhieuNhapS__MaNV__534D60F1");
        });

        modelBuilder.Entity<PhieuThanhLy>(entity =>
        {
            entity.HasKey(e => e.MaPtl).HasName("PK__PhieuTha__3AE3D6DF7D1CA3E9");

            entity.ToTable("PhieuThanhLy");

            entity.Property(e => e.MaPtl).HasColumnName("MaPTL");
            entity.Property(e => e.MaDv).HasColumnName("MaDV");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayTl).HasColumnName("NgayTL");

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.PhieuThanhLies)
                .HasForeignKey(d => d.MaDv)
                .HasConstraintName("FK__PhieuThanh__MaDV__71D1E811");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuThanhLies)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PhieuThanh__MaNV__70DDC3D8");
        });

        modelBuilder.Entity<PhieuTra>(entity =>
        {
            entity.HasKey(e => e.MaPt).HasName("PK__PhieuTra__2725E7F6B9CC4CCB");

            entity.ToTable("PhieuTra");

            entity.Property(e => e.MaPt).HasColumnName("MaPT");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MaPm).HasColumnName("MaPM");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuTras)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PhieuTra__MaNV__6754599E");

            entity.HasOne(d => d.MaPmNavigation).WithMany(p => p.PhieuTras)
                .HasForeignKey(d => d.MaPm)
                .HasConstraintName("FK__PhieuTra__MaPM__66603565");

            entity.HasOne(d => d.MaTheNavigation).WithMany(p => p.PhieuTras)
                .HasForeignKey(d => d.MaThe)
                .HasConstraintName("FK__PhieuTra__MaThe__68487DD7");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK__Sach__B235742DF53D7FC2");

            entity.ToTable("Sach");

            entity.Property(e => e.NamXb).HasColumnName("NamXB");
            entity.Property(e => e.NgonNgu).HasMaxLength(50);
            entity.Property(e => e.Nxb)
                .HasMaxLength(100)
                .HasColumnName("NXB");
            entity.Property(e => e.SoLuongHientai).HasColumnName("SoLuongHIENTAI");
            entity.Property(e => e.TacGia).HasMaxLength(50);
            entity.Property(e => e.TenSach).HasMaxLength(150);
            entity.Property(e => e.TheLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<TheDocGium>(entity =>
        {
            entity.HasKey(e => e.MaThe).HasName("PK__TheDocGi__314EEAAF4E807265");

            entity.Property(e => e.MaDg).HasColumnName("MaDG");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayDk).HasColumnName("NgayDK");
            entity.Property(e => e.NgayHh).HasColumnName("NgayHH");

            entity.HasOne(d => d.MaDgNavigation).WithMany(p => p.TheDocGia)
                .HasForeignKey(d => d.MaDg)
                .HasConstraintName("FK__TheDocGia__MaDG__4E88ABD4");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.TheDocGia)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__TheDocGia__MaNV__4D94879B");
        });

        modelBuilder.Entity<TtSach>(entity =>
        {
            entity.HasKey(e => e.MaTtSach).HasName("PK__TT_SACH__07B84A8AC678A9F5");

            entity.ToTable("TT_SACH");

            entity.Property(e => e.MaTtSach).HasColumnName("MA_TT_SACH");
            entity.Property(e => e.Masach).HasColumnName("MASACH");
            entity.Property(e => e.Mota)
                .HasColumnType("ntext")
                .HasColumnName("MOTA");
            entity.Property(e => e.UrlImage)
                .HasColumnType("text")
                .HasColumnName("URL_IMAGE");

            entity.HasOne(d => d.MasachNavigation).WithMany(p => p.TtSaches)
                .HasForeignKey(d => d.Masach)
                .HasConstraintName("FK__TT_SACH__MASACH__7D439ABD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<WebAPI.DTOs.SachDTO> SachDTO { get; set; } = default!;
}
