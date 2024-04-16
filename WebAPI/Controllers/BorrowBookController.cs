using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BorrowBookController : ControllerBase
    {
        private readonly QuanLyThuVienContext _context;
        private readonly IMapper _mapper;

        public BorrowBookController(IMapper mapper, QuanLyThuVienContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooksForBorrow([FromQuery] int[] maSach)
        {
            try
            {
                List<SachDTO> sachMuon = new List<SachDTO>();

                foreach (var id in maSach)
                {
                    var sachLoc = await _context.Saches
                        .Include(x => x.TtSaches)
                        .FirstOrDefaultAsync(item => item.MaSach == id);

                    if (sachLoc != null)
                    {
                        SachDTO sachDtos = _mapper.Map<SachDTO>(sachLoc);
                        sachMuon.Add(sachDtos);
                    }
                }

                if(sachMuon != null){
                    return Ok(sachMuon);
                }
                else
                {
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST: api/BorrowBook
        [HttpPost]
        public async Task<ActionResult> BorrowBook([FromBody] BorrowingData data)
        {
            try
            {
                // Thêm dữ liệu vào bảng DkiMuonSach
                DateTime now = DateTime.Now;

                DkiMuonSach dkMuon = new DkiMuonSach()
                {
                    Sdt = data.SdtUser,
                    NgayDkmuon = DateTime.Now,
                    NgayHen = now.AddDays(7),
                    Tinhtrang = 0
                };

                _context.DkiMuonSaches.Add(dkMuon);
                await _context.SaveChangesAsync();

                // Lấy giá trị của trường tự động tăng
                int maDk = dkMuon.MaDk;

                // Thêm dữ liệu vào bảng ChiTietDK
                // Lặp qua từng phần tử của hai mảng cùng một chỉ số
                for (int i = 0; i < Math.Min(data.MaSach.Length, data.SoLuongSach.Length); i++)
                {
                    // Lấy ra phần tử tương ứng từ mảng maSach và soLuongSach
                    int maSachItem = data.MaSach[i];
                    int soLuongSachItem = data.SoLuongSach[i];

                    // Tạo một đối tượng mới và thêm vào danh sách
                    ChiTietDk ctdk = new ChiTietDk()
                    {
                        MaDk = maDk,
                        MaSach = maSachItem,
                        Soluongmuon = soLuongSachItem,
                    };

                    _context.ChiTietDks.Add(ctdk);
                }

                // Luu vao database
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
