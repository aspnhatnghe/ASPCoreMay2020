USE eStore20;
GO
--Viết store lấy hàng hóa theo loại và nhà cung cấp
CREATE PROC spLayHangHoa(
	@MaLoai int,
	@MaNCC nvarchar(50)
)AS BEGIN
	SELECT * FROM HangHoa
	WHERE MaLoai = @MaLoai AND MaNCC = @MaNCC
END
GO

--Thêm loại
CREATE PROC spThemLoai
	@MaLoai int output, -- truyền ngược từ SP ra
	@TenLoai nvarchar(50),
	@MoTa nvarchar(max),
	@Hinh nvarchar(50)
AS BEGIN
	--Bước 1: Thêm vào CSDL
	INSERT INTO Loai(TenLoai, Hinh, MoTa)
	VALUES(@TenLoai, @Hinh, @MoTa)
	--Bước 2: Lấy giá trị vừa tăng
	SELECT @MaLoai = @@IDENTITY
END
GO


--Sửa loại
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
GO

CREATE PROC spXoaLoai
	@MaLoai int
AS BEGIN
	DELETE Loai WHERE MaLoai = @MaLoai
END
GO

CREATE PROC spLayLoai
	@MaLoai int
AS BEGIN
	SELECT * FROM Loai WHERE MaLoai = @MaLoai
END
GO

CREATE PROC spLayTatCaLoai	
AS BEGIN
	SELECT * FROM Loai ORDER BY TenLoai
END
GO

--Tìm hàng hóa gần đúng theo tên
CREATE PROC spTimHangHoa
	@TuKhoa nvarchar(50)
AS BEGIN
	SELECT * FROM HangHoa
	WHERE TenHH LIKE N'%' + @TuKhoa + N'%'
END
GO

---HÀM (FUNCTION)
--Hàm tính doanh số bán hàng theo mã
CREATE FUNCTION TinhDoanhSoTheoHangHoa(
	@MaHH int
) RETURNS float
AS BEGIN
	--B1: Khai báo biến giữ kiểu trả về
	DECLARE @DoanhSo float
	--B2: Tính toán
	SELECT @DoanhSo = SUM(SoLuong*DonGia*(1 - GiamGia))
	FROM ChiTietHD WHERE MaHH = @MaHH
	--B3: Trả về
	RETURN @DoanhSo
END
GO


CREATE PROC spLayHangHoaTheoTrang
	@TuKhoa nvarchar(50),
	@PageIndex int, @PageSize int
AS BEGIN
	DECLARE @Start int;
	--SET @PageIndex = 2;
	--SET @PageSize = 7;
	SET @Start = (@PageIndex - 1) * @PageSize;

	SELECT * FROM (
		SELECT MaHH, TenHH, DonGia, 
			ROW_NUMBER() OVER(ORDER BY MaHH) as STT
		FROM HangHoa WHERE TenHH LIKE N'%' + @TuKhoa + N'%'
	) as tmp
	WHERE tmp.STT BETWEEN  @Start AND (@Start + @PageSize)
END
GO

CREATE PROCEDURE spTimLoai
	@TenLoai nvarchar(50)
AS BEGIN
	SELECT * FROM Loai 
	WHERE TenLoai LIKE N'%' + @TenLoai + '%'
END
GO

CREATE VIEW vChiTietHoaDon
AS
	SELECT cthd.*, TenHH, TenLoai, TenCongTy
	FROM ChiTietHD cthd JOIN HangHoa hh
		ON cthd.MaHH = hh.MaHH
		JOIN Loai lo ON lo.MaLoai = hh.MaLoai
		JOIN NhaCungCap ncc ON ncc.MaNCC = hh.MaNCC
Go

---Xem hóa đơn bằng Stored Procedure
CREATE PROC spChiTietHoaDon
	@MaHD int
AS BEGIN
	SELECT cthd.*, TenHH, hh.Hinh, TenLoai, TenCongTy
	FROM ChiTietHD cthd JOIN HangHoa hh
		ON cthd.MaHH = hh.MaHH
		JOIN Loai lo ON lo.MaLoai = hh.MaLoai
		JOIN NhaCungCap ncc ON ncc.MaNCC = hh.MaNCC
	WHERE MaHD = @MaHD
END
GO