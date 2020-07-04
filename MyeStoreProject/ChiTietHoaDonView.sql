create view ChiTietHoaDonView AS
select lo.TenLoai, hh.TenHH,
	cthd.DonGia, cthd.SoLuong, cthd.GiamGia,
	cthd.DonGia * cthd.SoLuong * (1 - cthd.GiamGia)
	as ThanhTien
from ChiTietHD cthd JOIN HangHoa hh
	ON hh.MaHH = cthd.MaHH
	join Loai lo ON lo.MaLoai = hh.MaLoai