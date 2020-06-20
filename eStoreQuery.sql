USE eStore20;

SELECT CONCAT(MaHH, ' - ', TenHH, ' - ', MoTa) as HangHoa,
	DonGia, 
	ISNULL(NgaySX, dateadd(year, -10, GETDATE())) NgaySX,
	CASE
		WHEN DonGia < 50 THEN N'Giá phải chăng'
		WHEN DonGia < 100 THEN N'Hơi mắc'
		ELSE N'Quá đắt'
	END as PhanLoai
FROM HangHoa
ORDER By DonGia

--Thống kê hàng hóa bán
SELECT hh.MaHH, TenHH, SUM(SoLuong * cthd.DonGia)
FROM ChiTietHD cthd JOIN HangHoa hh
				ON cthd.MaHH = hh.MaHH
GROUP BY hh.MaHH, TenHH

-----VIEW (Bảng ảo - Khung nhìn)
--Tạo view xem chi tiết hóa đơn
CREATE VIEW vChiTietHoaDon AS
SELECT MaHD, hh.MaHH, TenHH, SoLuong, cthd.DonGia,
	cthd.GiamGia, 
	SoLuong * cthd.DonGia * (1 - cthd.GiamGia) as ThanhTien
FROM ChiTietHD cthd JOIN HangHoa hh
				ON cthd.MaHH = hh.MaHH

--Demo lấy thông tin hóa đơn MaHD = 10248
select * from vChiTietHoaDon
where MaHD = 10248

--VD2: Lấy thông tin hàng hóa
CREATE VIEW vHangHoa AS
SELECT hh.MaHH, TenHH, DonGia, GiamGia, hh.Hinh,
	hh.MaLoai, TenLoai, 
	hh.MaNCC, TenCongTy as NhaCungCap
FROM HangHoa hh JOIN Loai lo ON hh.MaLoai = lo.MaLoai
	JOIN NhaCungCap ncc  ON ncc.MaNCC = hh.MaNCC

--demo
SELECT * FROM vHangHoa
WHERE DonGia BETWEEN 15 AND 155
ORDER BY TenLoai DESC, DonGia ASC, TenHH

---STORE PROCEDURE------
CREATE PROC spLayHoaDon
	@MaHD int
AS
BEGIN
	SELECT * FROM vChiTietHoaDon
	WHERE MaHD = @MaHD
END

--Demo SQL
spLayHoaDon 10248
EXEC spLayHoaDon 10248
EXECUTE spLayHoaDon 10248

--Tạo mới Loại
CREATE PROC spThemLoai
	@MaLoai int output,
	@TenLoai nvarchar(50),
	@MoTa nvarchar(max),
	@Hinh nvarchar(50)
AS BEGIN
	--chèn
	INSERT INTO Loai(TenLoai, MoTa, Hinh)
	VALUES(@TenLoai, @MoTa, @Hinh)
	--Lấy giá trị MaLoai vừa sinh ra
	SET @MaLoai = @@IDENTITY
END

--demo sql
declare @Ma int
EXEC spThemLoai @Ma output, N'Bia', null, null
PRINT CONCAT(N'Mã loại vừa sinh: ', @Ma)

--Viết store sửa loại
CREATE PROC spSuaLoai
	@MaLoai int,
	@TenLoai nvarchar(50),
	@MoTa nvarchar(max),
	@Hinh nvarchar(50)
AS BEGIN
	UPDATE Loai SET TenLoai = @TenLoai, MoTa = @MoTa
	WHERE MaLoai = @MaLoai
	IF @Hinh IS NOT NULL
	BEGIN
		UPDATE Loai SET Hinh = @Hinh
		WHERE MaLoai = @MaLoai	
	END
END

CREATE PROC spXoaLoai
	@MaLoai int
AS BEGIN
	DELETE FROM Loai WHERE MaLoai = @MaLoai
END

CREATE PROC spLayLoai
	@MaLoai int
AS BEGIN
	SELECT * FROM Loai WHERE MaLoai = @MaLoai
END

CREATE PROC spTimLoai
	@TuKhoa nvarchar(50)
AS BEGIN
	SELECT * FROM Loai 
	WHERE TenLoai LIKE N'%' + @TuKhoa + N'%'
END

--Viết hàm tính doanh số theo khách hàng
CREATE FUNCTION fDoanhSoTheoKhachHang
(
	@MaKH nvarchar(20)
)
RETURNS float
AS BEGIN
	DECLARE @DoanhSo float

	SELECT @DoanhSo = SUM(SoLuong * DonGia * (1 - GiamGia))
	FROM ChiTietHD cthd JOIN HoaDon hd 
			ON hd.MaHD = cthd.MaHD
	WHERE MaKH = @MaKH

	RETURN @DoanhSo
END

--Demo
select dbo.fDoanhSoTheoKhachHang('ANTON') DoanhThu
select MaKH, HoTen, dbo.fDoanhSoTheoKhachHang(MaKH) DoanhThu
from KhachHang

--Function trả về bảng
CREATE FUNCTION ThongKeDoanhThuTheoLoai(
	@Year int
)
RETURNS TABLE
AS RETURN
	SELECT lo.MaLoai, lo.TenLoai,
		SUM(SoLuong * cthd.DonGia * (1 - cthd.GiamGia)) DoanhThu
	FROM ChiTietHD cthd JOIN HangHoa hh ON hh.MaHH = cthd.MaHH
		JOIN Loai lo ON lo.MaLoai = hh.MaLoai
		JOIN HoaDon hd ON hd.MaHD = cthd.MaHD
	WHERE YEAR(NgayDat) = @Year
	GROUP BY lo.MaLoai, lo.TenLoai


CREATE FUNCTION ThongKeDoanhThuTheoNamThang(
	@Year int, @Month int
)
RETURNS @tmp TABLE(
	MaLoai int, TenLoai nvarchar(50), DoanhThu float
)
AS BEGIN
	INSERT INTO @tmp
	SELECT lo.MaLoai, lo.TenLoai,
		SUM(SoLuong * cthd.DonGia * (1 - cthd.GiamGia)) DoanhThu
	FROM ChiTietHD cthd JOIN HangHoa hh ON hh.MaHH = cthd.MaHH
		JOIN Loai lo ON lo.MaLoai = hh.MaLoai
		JOIN HoaDon hd ON hd.MaHD = cthd.MaHD
	WHERE YEAR(NgayDat) = @Year AND MONTH(NgayDat) = @Month
	GROUP BY lo.MaLoai, lo.TenLoai
	
	RETURN
END
SELECT * FROM dbo.ThongKeDoanhThuTheoLoai(1996)

--Viết trigger tự động cập nhập thành tiền khi
--thêm/xóa/sửa chi tiết hóa đơn
CREATE TRIGGER trgCapNhapThanhTien ON ChiTietHD
	AFTER INSERT, UPDATE, DELETE
AS BEGIN
	DECLARE @MaHD int;
	DECLARE @Tong float;

	WITH BANG_TAM AS(
		SELECT MaHD FROM inserted
		UNION SELECT MaHD FROM deleted
	)

	SELECT @MaHD = MaHD FROM BANG_TAM

	SELECT @Tong = SUM(SoLuong * DonGia * (1 - GiamGia))
	FROM ChiTietHD WHERE MaHD = @MaHD

	UPDATE HoaDon SET ThanhTien = @Tong
	FROM HoaDon WHERE MaHD = @MaHD

END

select ThanhTien, MaHD  from HoaDon