﻿Create database Quan_Ly_Cafe
use Quan_Ly_Cafe
go
-- bảng phân quyền
CREATE TABLE tblPhanquyen (
    PK_iPhanquyenID INT PRIMARY KEY,
    sTenquyen VARCHAR(225) NOT NULL
);
-- bảng Nv
CREATE TABLE tblNhanvien (
    PK_iNhanvienID INT PRIMARY KEY,
    sTenNhanvien NVARCHAR(50) NOT NULL,
    sSodienthoai NVARCHAR(15) NOT NULL,
    sDiachi NVARCHAR(50) NOT NULL,
    dNgaysinh DATE NOT NULL,
    bGioitinh BIT NOT NULL
)

INSERT INTO tblNhanvien (PK_iNhanvienID, sTenNhanvien, sSodienthoai, sDiachi, dNgaysinh, bGioitinh) VALUES
(1, N'Nguyễn Văn A', '0987654321', N'123 Đường ABC, Quận 1, TP.HCM', '1990-05-15', 1),
(2, N'Trần Thị B', '0123456789', N'456 Đường XYZ, Quận 2, TP.HCM', '1995-10-20', 0),
(3, N'Lê Văn C', '0369871245', N'789 Đường DEF, Quận 3, TP.HCM', '1988-03-25', 1),
(4, N'Phạm Thị D', '0365874123', N'321 Đường GHI, Quận 4, TP.HCM', '1992-12-10', 0),
(5, N'Huỳnh Văn E', '0932145789', N'654 Đường JKL, Quận 5, TP.HCM', '1985-08-05', 1)
-- bang Tai khoan
CREATE TABLE tblTaikhoan (
    PK_iNhanvienID INT PRIMARY KEY,
    sMatkhau NVARCHAR(50) NOT NULL,
    PK_iPhanquyenID INT NOT NULL,
    FOREIGN KEY (PK_iNhanvienID) REFERENCES tblNhanvien(PK_iNhanvienID),
    FOREIGN KEY (PK_iPhanquyenID) REFERENCES tblPhanquyen(PK_iPhanquyenID)
);
insert into tblPhanquyen
values(1, N'Quản lý')
insert into tblPhanquyen
values(2, N'Nhân viên')


insert into tblTaikhoan
values(1, 123, 1)

-- bảng nhà cung cấp
CREATE TABLE tblNhacungcap (
    PK_iNhacungcapID INT PRIMARY KEY,
    sTenNhacungcap NVARCHAR(255) NOT NULL,
    sSodienthoai NVARCHAR(15) NOT NULL,
    sDiachi NVARCHAR(255) NOT NULL,
    sEmail NVARCHAR(255) NOT NULL
);

INSERT INTO tblNhacungcap (PK_iNhacungcapID, sTenNhacungcap, sSodienthoai, sDiachi, sEmail)
VALUES 
    (1, N'Nhà cung cấp A', '0987654321', N'Địa chỉ A', N'nccA@example.com'), -- Ví dụ bản ghi 1
    (2, N'Nhà cung cấp B', '0887654321', N'Địa chỉ B', N'nccB@example.com'), -- Ví dụ bản ghi 2
    (3, N'Nhà cung cấp C', '0456789123', N'Địa chỉ C', N'nccC@example.com'), -- Ví dụ bản ghi 3
    (4, N'Nhà cung cấp D', '0789456123', N'Địa chỉ D', N'nccD@example.com')
-- bảng phiếu nhậ 


-- bảng nguyên liệu 
CREATE TABLE tblNguyenlieu (
    PK_iNguyenlieuID INT PRIMARY KEY ,
    sTenNguyenlieu NVARCHAR(255) NOT NULL,
    fSoluong FLOAT NOT NULL,
    sDonvitinh NVARCHAR(20) NOT NULL
);
INSERT INTO tblNguyenlieu (PK_iNguyenlieuID, sTenNguyenlieu, fSoluong, sDonvitinh) 
VALUES 
(1, N'Cà phê', 500.0, N'gói'),
(2, N'Sữa', 200.0, N'lít'),
(3, N'Dương đường', 1000.0, N'kg');

CREATE TABLE tblPhieunhap (
    PK_iPhieunhapID INT PRIMARY KEY IDENTITY,
    PK_iNhanvienID INT NOT NULL,
    PK_iNhacungcapID INT NOT NULL,
    dNgaylap DATE NOT NULL,
    fTongtien FLOAT,
    FOREIGN KEY (PK_iNhanvienID) REFERENCES tblNhanvien(PK_iNhanvienID),
    FOREIGN KEY (PK_iNhacungcapID) REFERENCES tblNhacungcap(PK_iNhacungcapID)
);
--bamgr chi tiết phiếu nhập
CREATE TABLE tblChitietPhieunhap (
    PK_iPhieunhapID INT NOT NULL,
    PK_iNguyenlieuID INT NOT NULL,
    fSoluong FLOAT NOT NULL,
    fDongia FLOAT NOT NULL,
    PRIMARY KEY (PK_iPhieunhapID, PK_iNguyenlieuID),
    FOREIGN KEY (PK_iPhieunhapID) REFERENCES tblPhieunhap(PK_iPhieunhapID),
    FOREIGN KEY (PK_iNguyenlieuID) REFERENCES tblNguyenlieu(PK_iNguyenlieuID)
);

-- bảng đồ uống
CREATE TABLE tblDouong (
    PK_iDouongID INT PRIMARY KEY,
    sTenDouong VARCHAR(255) NOT NULL,
    fDonGia FLOAT NOT NULL,
);

-- bảng hóa đơn \
CREATE TABLE tblHoadon (
    PK_iHoadonID INT PRIMARY KEY IDENTITY,
    PK_iNhanvienID INT NOT NULL,
    dNgaylap DATE NOT NULL,
    fTongtien FLOAT,
    FOREIGN KEY (PK_iNhanvienID) REFERENCES tblNhanVien(PK_iNhanvienID)
);
-- bảng chi tiết hóa đơn
CREATE TABLE tblChitietHoadon (
    PK_iHoadonID INT NOT NULL,
    PK_iDouongID INT NOT NULL,
    iSoluong INT NOT NULL,
    fDonGia FLOAT NOT NULL,
    PRIMARY KEY (PK_iHoadonID, PK_iDouongID),
    FOREIGN KEY (PK_iHoadonID) REFERENCES tblHoadon(PK_iHoadonID),
    FOREIGN KEY (PK_iDouongID) REFERENCES tblDouong(PK_iDouongID)
);

--==================== TÀI KHOẢN =====================
CREATE PROCEDURE sp_getTK
AS
	SELECT nv.sTenNhanvien, tk.*, ltk.sTenquyen
	FROM tblTaikhoan tk 
	JOIN tblPhanquyen ltk ON ltk.PK_iPhanquyenID = tk.PK_iPhanquyenID
	JOIN tblNhanvien nv ON nv.PK_iNhanvienID = tk.PK_iNhanvienID 	


CREATE PROC prGetAccoun(@id int, @password nvarchar(50) )
AS
	BEGIN
		SELECT tk.PK_iNhanvienID, ltk.sTenquyen
		FROM tblTaikhoan tk 
		JOIN tblPhanquyen ltk ON ltk.PK_iPhanquyenID = tk.PK_iPhanquyenID
		JOIN tblNhanvien nv ON nv.PK_iNhanvienID = tk.PK_iNhanvienID 
		WHERE tk.PK_iNhanvienID = @id AND sMatkhau = @password;
	END
GO
create PROC prChangePassword( @id int, @oldPassword nvarchar(50),  @newPassword nvarchar(50))
AS
	BEGIN
		UPDATE tblTaiKhoan
		SET sMatkhau = @newPassword
		WHERE tblTaiKhoan.PK_iNhanvienID = @id AND sMatkhau = @oldPassword;
	END

create proc sp_delete (@iNhanvien int)
as 
begin
	delete tblTaikhoan
	where @iNhanvien = tblTaikhoan.PK_iNhanvienID
end

create PROCEDURE sp_get_taikhoan
AS
SELECT * FROM tblTaikhoan

create PROCEDURE sp_insertTK(
	@id int,
	@quyen int,
	@Matkhau nvarchar(50)
)
AS

begin
	INSERT INTO tblTaikhoan(PK_iNhanvienID, sMatkhau, PK_iPhanquyenID)
	VALUES (@id, @quyen, @Matkhau)
end


create PROCEDURE sp_update_taikhoan
(
    @Mataikhoan int,
    @Maquyen int,
    @Matkhau nvarchar(50)
)
AS
BEGIN
    UPDATE tblTaikhoan
    SET PK_iPhanquyenID = @Maquyen, sMatkhau = @Matkhau
    WHERE tblTaikhoan.PK_iNhanvienID = @Mataikhoan
END

-- ================================== PHIẾU NHẬP VÀ CHI TIẾT PHIẾU NHẬP  ===================
CREATE TYPE dbo.ChitietPhieunhapDetails AS TABLE
(
    PK_iNguyenlieuID INT,
    fSoluong FLOAT,
    fDongia FLOAT
);

CREATE PROCEDURE sp_InsertPhieunhap
    @iNhanvienID INT,
    @iNhacungcapID INT,
    @dNgaylap DATE,
    @ChitietPhieunhapDetails AS dbo.ChitietPhieunhapDetails READONLY
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @iPhieunhapID INT;
    DECLARE @fTongtien FLOAT;
    INSERT INTO tblPhieunhap (PK_iNhanvienID, PK_iNhacungcapID, dNgaylap)
    VALUES (@iNhanvienID, @iNhacungcapID, @dNgaylap);
    SET @iPhieunhapID = SCOPE_IDENTITY();
    INSERT INTO tblChitietPhieunhap (PK_iPhieunhapID, PK_iNguyenlieuID, fSoluong, fDongia)
    SELECT @iPhieunhapID, PK_iNguyenlieuID, fSoluong, fDongia
    FROM @ChitietPhieunhapDetails;
    -- Tính tổng tiền dựa trên các chi tiết phiếu nhập có cùng mã phiếu nhập
    SELECT @fTongtien = SUM(fSoluong * fDongia)
    FROM tblChitietPhieunhap
    WHERE PK_iPhieunhapID = @iPhieunhapID;
    -- Cập nhật tổng tiền cho phiếu nhập vừa thêm vào
    UPDATE tblPhieunhap
    SET fTongtien = @fTongtien
    WHERE PK_iPhieunhapID = @iPhieunhapID;
END;
-- Câu lệnh thực thi
DECLARE @ChitietPhieunhapDetails AS dbo.ChitietPhieunhapDetails;
-- Thêm dữ liệu vào biến bảng chi tiết phiếu nhập
INSERT INTO @ChitietPhieunhapDetails (PK_iNguyenlieuID, fSoluong, fDongia)
VALUES
    (1, 10, 100),
    (2, 20, 200),
    (3, 30, 300);
-- Gọi stored procedure để thêm mới dữ liệu
EXEC sp_InsertPhieunhap
    @iNhanvienID = 1,
    @iNhacungcapID = 1,
    @dNgaylap = '2024-04-09',
    @ChitietPhieunhapDetails = @ChitietPhieunhapDetails;

select * from tblPhieunhap
select * from tblChitietPhieunhap
-- ================================== HÓA ĐƠN VÀ CHI TIẾT HÓA ĐƠN  ===================
CREATE TYPE dbo.ChitietHoadonDetails AS TABLE
(
    PK_iDouongID INT,
    iSoluong INT,
    fDonGia FLOAT
);
CREATE PROCEDURE [dbo].[sp_InsertHoadon]
    @PK_iNhanvienID INT,
    @dNgaylap DATE,
    @ChitietHoadonDetails AS dbo.ChitietHoadonDetails READONLY
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Thêm hóa đơn vào bảng tblHoadon
    DECLARE @PK_iHoadonID INT;
    INSERT INTO tblHoadon (PK_iNhanvienID, dNgaylap)
    VALUES (@PK_iNhanvienID, @dNgaylap);
    SET @PK_iHoadonID = SCOPE_IDENTITY();
    
    -- Tính tổng tiền từ các chi tiết hóa đơn và cập nhật vào bảng tblHoadon
    DECLARE @fTongtien FLOAT;
    SELECT @fTongtien = SUM(iSoluong * fDonGia)
    FROM @ChitietHoadonDetails;
    
    UPDATE tblHoadon
    SET fTongtien = @fTongtien
    WHERE PK_iHoadonID = @PK_iHoadonID;

    -- Thêm chi tiết hóa đơn vào bảng tblChitietHoadon
    INSERT INTO tblChitietHoadon (PK_iHoadonID, PK_iDouongID, iSoluong, fDonGia)
    SELECT @PK_iHoadonID, PK_iDouongID, iSoluong, fDonGia
    FROM @ChitietHoadonDetails;
END;
-- ========================= SELECTPROCEDURE ============
SELECT PN.PK_iPhieunhapID, PN.PK_iNhanvienID, NV.sTenNhanVien, PN.PK_iNhacungcapID, NC.sTenNhacungcap, PN.dNgaylap, PN.fTongtien from tblPhieunhap PN 
INNER JOIN tblNhanvien NV ON PN.PK_iNhanvienID = NV.PK_iNhanvienID
INNER JOIN tblNhacungcap NC ON PN.PK_iNhacungcapID = NC.PK_iNhacungcapID
WHERE PN.PK_iNhanvienID = 2 AND PN.dNgaylap = '2024-04-01'
SELECT NL.sTenNguyenlieu, CT.fSoluong, CT.fDongia 
FROM tblChitietPhieunhap CT
INNER JOIN tblNguyenlieu NL ON CT.PK_iNguyenlieuID = NL.PK_iNguyenlieuID
WHERE CT.PK_iPhieunhapID = 2
-- <=> Chi tiết hóa đơn
CREATE PROCEDURE Usp_LayChiTietPhieuNhap
    @PhieuNhapID INT
AS
BEGIN
    SELECT  NL.sTenNguyenlieu, CT.fSoluong, CT.fDongia 
    FROM tblChitietPhieunhap CT
    INNER JOIN tblNguyenlieu NL ON CT.PK_iNguyenlieuID = NL.PK_iNguyenlieuID
    WHERE CT.PK_iPhieunhapID = @PhieuNhapID
END
CREATE PROCEDURE [dbo].[Usp_LayChiTietHoaDon]
    @HoaDonID INT
AS
BEGIN
    SELECT  NL.sTenDouong,NV.sTenNhanvien, NV.sSodienthoai, CT.iSoluong, CT.fDongia 
    FROM tblChitietHoadon CT
    INNER JOIN tblHoadon HD ON CT.PK_iHoadonID = HD.PK_iHoadonID
    INNER JOIN tblNhanvien NV ON HD.PK_iNhanvienID = NV.PK_iNhanvienID
    INNER JOIN tblDouong NL ON CT.PK_iDouongID = NL.PK_iDouongID
    WHERE CT.PK_iHoadonID = @HoaDonID
END
-- Danh sách hóa đơn theo ngày
CREATE PROCEDURE GetInvoicesByDate
AS
BEGIN
    SELECT 
        pn.PK_iPhieunhapID AS 'MaPhieuNhap',
        nv.sTenNhanvien AS 'TenNhanVien',
        ncc.sTenNhacungcap AS 'TenNhaCungCap',
        pn.dNgaylap AS 'NgayLap',
        pn.fTongtien AS 'TongTien',
        ctp.PK_iNguyenlieuID AS 'MaNguyenLieu',
        nl.sTenNguyenlieu AS 'TenNguyenLieu',
        nl.fSoluong AS 'SoLuong',
        nl.sDonvitinh AS 'DonViTinh',
        ctp.fDongia AS 'DonGia'
    FROM 
        tblPhieunhap pn
    INNER JOIN 
        tblNhanvien nv ON pn.PK_iNhanvienID = nv.PK_iNhanvienID
    INNER JOIN 
        tblNhacungcap ncc ON pn.PK_iNhacungcapID = ncc.PK_iNhacungcapID
    INNER JOIN 
        tblChitietPhieunhap ctp ON pn.PK_iPhieunhapID = ctp.PK_iPhieunhapID
    INNER JOIN 
        tblNguyenlieu nl ON ctp.PK_iNguyenlieuID = nl.PK_iNguyenlieuID
    ORDER BY 
        pn.dNgaylap, pn.PK_iPhieunhapID, ctp.PK_iNguyenlieuID;
END;

