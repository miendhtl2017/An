create database QLCP

Create table TaiKhoan(
Username varchar(50)not null primary key,	
TenHT Nvarchar(30) not null ,
Password Nvarchar(30)NOT NULL DEFAULT 0 ,
Type int not null default 0 --1 : admin && 0 : staff
);
create table Loai(
MaLoai int identity primary key,
TenLoai nvarchar(30))

Create table Menu(
MaDU char(10)not null primary key,
TenDU Nvarchar(50),
MaLoai int,
DonGia int,
FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai)
);
Create table Ban(
MaBan int identity not null primary key,
TenBan nvarchar(10) not null,
TTBan Nvarchar(30)
);

Create table HoaDon(
MaHD int identity not null primary key,
MaBan int not null,
TGTT date,
status int NOT NULL default 0, -- 1: đã thanh toán && 0: chưa thanh toán
FOREIGN KEY (MaBan) REFERENCES Ban(MaBan)
);
create table ChiTietHD(
MaCTHD int identity primary key,
MaDU char(10) not null,
MaHD int not null,
Count int,
FOREIGN KEY (MaDU) REFERENCES Menu(MaDU),
foreign KEY (MaHD) REFERENCES HoaDon(MaHD))

	
insert into TaiKhoan values
('k1' , N'Nguyễn Thị Thảo', '1', '1'),
('ntn001' , N'Nguyễn Thảo Nhi', '123', '0'),
('nvt002' , N'Nguyễn Văn Trỗi', '101', '0'),
('lqt003' , N'Lê Quỳnh Trang', '133', '0'),
('hvq004', N'Hoàng Văn Quang' , '321', '0');
	
insert into Loai values
( N'Sinh Tố'),
( N'Cà phê đá xay'),
( N'Trà sữa'),
( N'Nước ngọt'),
( N'Nước Ép'),
( N'Cà Phê'),
( N'Bia')
	
insert into Menu values
('DU001' ,N'Coca' ,'4' , '20000'),
('DU002' ,N'Capuchino' ,'2' , '35000'),
('DU003' ,N'Cà phê sữa' ,'2' , '32000'),
('DU004' ,N'Sinh tố xoài' ,'1' , '30000'),
('DU005' ,N'Nước ép dưa hấu' ,'5' , '25000'),
('DU006' ,N'Nước ép bưởi' ,'5' , '25000'),
('DU007' ,N'Trà sữa trân châu ' ,'3', '40000'),
('DU008' ,N'Trà sữa vị đào' ,'3' , '45000'),
('DU009' ,N'Bia Trúc Bạch ' ,'7', '35000'),
('DU010' ,N'Bia Sài Gòn' ,'7', '35000'),
('DU011' ,N'Đen Đá ' ,'6', '28000'),
('DU012' ,N'Đen Nóng ' ,'6', '28000')
;


insert into Ban values
('A01', N'Có khách'),
('A02', N'Có khách'),
('A03', N'Có khách'),
('A04', N'Có khách'),
('B01', N'Có khách'),
('B02', N'Trống'),
('B03', N'Trống'),
('B04', N'Trống'),
('B05', N'Trống')


insert into HoaDon values
('1',GETDATE(),'0'),

('2',GETDATE(),'0'),

('3',GETDATE(),'0'),

('4',GETDATE(),'0'),

('5',GETDATE(),'0'),

('6',GETDATE(),'1'),

('7', GETDATE(),'1')


insert into ChiTietHD values
('DU004','4','6'),
('DU004','5','6'),
('DU003','2','4'),
('DU005','2','5'),
('DU006','6','1'),
('DU008','7','4'),
('DU007','2','2'),
('DU002','3','3')


drop table ChiTietHD
drop table HoaDon
drop table TaiKhoan
drop table Menu
drop table Loai
drop table Ban
--tạo thủ tục in bàn

create proc sp_getban

as select * from dbo.Ban
go

exec dbo.sp_getban
--tạo 1 thủ tục in tài khoản
go
create proc UP_Login
@username nvarchar(100),@password nvarchar(100)
as
begin
 select * from TaiKhoan where Username = @username and Password = @password
end
go
-----------------------------------------------------------
select * from Menu
select * from ChiTietHD where MaHD = 5

select * from HoaDon where MaBan = 'B01'
select * from HoaDon where MaBan = B02   
SELECT f.TenDU, bi.count, f.DonGia, f.DonGia*bi.count AS totalPrice FROM ChiTietHD AS bi,
 HoaDon AS b, Menu AS f WHERE bi.MaHD = b.MaHD AND bi.MaDU = f.MaDU AND b.MaBan = '"+ MaBan +"'
 select * from HoaDon where MaBan = 5 and status = 0

--thêm cột discount vào bảng hóa đơn
alter table HoaDon
add discount int

alter table HoaDon
add totalPrice float
DROP COLUMN TongTien

DELETE FROM HoaDon WHERE MaHD = 53 and MaBan=1
DELETE FROM Loai
DELETE FROM Menu
DELETE FROM ChiTietHD WHERE MaHD =30
update HoaDon set discount = 0

update HoaDon set totalPrice = 0
 
 select * from HoaDon
  select * from ChiTietHD
  
-- tạo thủ tục thêm hóa đơn
create proc sp_InsertHD
	@maban int
AS
BEGIN
	INSERT dbo.HoaDon(MaBan, TGTT ,status, discount)
	 values(@maban, GETDATE(),0 , 0)
END

drop proc sp_InsertHD
EXEC sp_InsertHD 3

SELECT MAX(MaHD) FROM HoaDon

--tạo thủ tục thêm chi tiết hóa đơn và kiểm tra
Create PROC USP_ThemChiTietHaDon
@maHD int, @maDU char(10), @count INT
AS
BEGIN
	DECLARE @tonTaiCTHD INT
	DECLARE @countDoUong INT = 1
	SELECT @tonTaiCTHD =  MaCTHD,@countDoUong = b.Count 
	from ChiTietHD as b 
	where MaHD = @maHD and MaDU = @maDU 
	IF(@tonTaiCTHD > 0)
	begin
			DECLARE @dem INT = @countDoUong + @count
			IF(@dem > 0)
				UPDATE ChiTietHD SET Count = @dem where MaDU=@maDU
			ELSE	
				Delete ChiTietHD where MaHD = @maHD AND MaDU = @maDU
		END
	ELSE
		BEGIN
			INSERT dbo.ChiTietHD(MaHD, MaDU, Count) VALUES(@maHD, @maDU, @count)
		END
END

drop PROC USP_ThemChiTietHaDon
Drop TRIGGER UTG_UpdateChiTietHD


--tạo trigger update Chitiet hóa đơn
CREATE TRIGGER UTG_UpdateChiTietHD
on dbo.ChiTietHD FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @maHD INT
	
	SELECT @maHD = MaHD FROM inserted
	
	DECLARE @maban INT
	
	SELECT @maban = MaBan FROM HoaDon WHERE MaHD = @maHD and status = 0
	
	UPDATE Ban SET TTBan = N'Có Khách' WHERE MaBan = @maban
END
Go

select UTG_UpdateChiTietHD

-- tạo trigger update Hóa đơn
create TRIGGER UTG_UpdateBill
ON HoaDon FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = MaHD FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = MaBan FROM HoaDon WHERE MaHD = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM HoaDon WHERE MaBan = @idTable AND status = 0
	
	IF (@count = 0)
	begin
		UPDATE Ban SET TTBan = N'Trống' WHERE MaBan = @idTable
	end
END
Go

----------------------------------
drop TRIGGER UTG_UpdateBill
-----------------------------------
select * from Menu where MaLoai = 1 
SELECT MAX(MaHD) FROM HoaDon
select * from Menu where MaLoai =5
UPDATE HoaDon SET TGTT=GETDATE(), status = 0 WHERE MaHD = 5
select * from dbo.HoaDon where status = 0 and MaBan = 3
delete Ban
delete HoaDon
delete ChiTietHD

select * FROM HoaDon WHERE MaBan = 3 AND status = 0      

-- tạo thủ tục chuyển bàn
create PROC USP_ChuyenBan
@idBan1 INT, @idBan2 INT
AS 
BEGIN
	Declare @idHoaDonBan1 int 
	DECLARE @idHoaDonBan2 int

	declare @hoaDonTam1 int = 1
	declare @hoaDonTam2 int = 1

	select @idHoaDonBan2 = MaHD from dbo.HoaDon where MaBan = @idBan2 AND status = 0
	select @idHoaDonBan1 = MaHD from dbo.HoaDon where MaBan = @idBan1 AND status = 0

	IF(@idHoaDonBan1 is null)
		BEGIN
			INSERT dbo.HoaDon(MaBan, TGTT, status) VALUES(@idBan1, GETDATE(), 0)
			select @idHoaDonBan1= MAX(MaHD) from dbo.HoaDon Where MaBan = @idBan1 And status = 0
		END
	IF(@idHoaDonBan2 is null)
		BEGIN
			INSERT dbo.HoaDon(MaBan, TGTT, status) VALUES(@idBan2, GETDATE(), 0)
			select @idHoaDonBan2= MAX(MaHD) from dbo.HoaDon Where MaBan = @idBan2 And status = 0
		END

	select @hoaDonTam2 = COUNT(*) from dbo.ChiTietHD WHERE MaHD = @idHoaDonBan2

	Select MaCTHD INTO BangChuaIDTTHD from dbo.ChiTietHD Where MaHD = @idHoaDonBan2

	UPDATE dbo.ChiTietHD SET MaHD = @idHoaDonBan2 WHERE MaHD = @idHoaDonBan1
	UPDATE dbo.ChiTietHD SET  MaHD = @idHoaDonBan1 WHERE MaHD IN (Select * from BangChuaIDTTHD)

	DROP TABLE BangChuaIDTTHD

	DELETE FROM ChiTietHD WHERE MaHD = @idHoaDonBan1
	DELETE FROM HoaDon WHERE MaHD = @idHoaDonBan1

	IF(@hoaDonTam1 = 0)
		BEGIN
			UPDATE dbo.Ban SET TTBan= N'Trống' WHERE MaBan = @idBan2
		END

	IF(@hoaDonTam2 = 0)
	BEGIN
		UPDATE dbo.Ban SET TTBan = N'Trống' WHERE MaBan = @idBan1
	END

END
go

drop PROC USP_GopBan

-- tạo thủ tục gộp bàn
go
alter PROC USP_GopBan
@idBan1 INT, @idBan2 INT
AS
BEGIN
	Declare @idHoaDonBan1 int 
	DECLARE @idHoaDonBan2 int
	Declare @idDoUongBan1 nvarchar(50)
	Declare @idDoUongBan2 nvarchar(50)
	Declare @soLuong1 int  = 0
	Declare @soLuong2 int = 0

	select @idHoaDonBan2 = MaHD from HoaDon where MaBan = @idBan2 AND status = 0
	select @idHoaDonBan1 = MaHD from dbo.HoaDon where MaBan = @idBan1 AND status = 0

	Select @idDoUongBan1 = MaDU from ChiTietHD WHere MaHD = @idHoaDonBan1
	Select @idDoUongBan2 = MaDU from ChiTietHD WHere MaHD = @idHoaDonBan2

	SELECT @soLuong1 = count FROM ChiTietHD WHERE MaHD = @idHoaDonBan1 AND MaDU = @idDoUongBan1
	SELECT @soLuong2 = count FROM ChiTietHD WHERE MaHD = @idHoaDonBan2 AND MaDU = @idDoUongBan2

	IF(@idHoaDonBan1 IS NOT NULL)
		BEGIN
			UPDATE dbo.ChiTietHD Set count = @soLuong1 + @soLuong2 WHERE MaHD = @idHoaDonBan1 AND MaDU = @idDoUongBan1
			UPDATE dbo.HoaDon Set status= 1 WHERE MaBan = @idBan2
			DELETE FROM ChiTietHD WHERE MaHD = @idHoaDonBan2
			DELETE FROM HoaDon WHERE MaHD = @idHoaDonBan2
		END
	IF(@idHoaDonBan2 IS NOT NULL)
		BEGIN

			UPDATE dbo.ChiTietHD Set count = @soLuong1 + @soLuong2 WHERE MaHD = @idHoaDonBan2 AND MaDU = @idDoUongBan2
			UPDATE dbo.HoaDon Set status = 1 WHERE MaBan = @idBan1

			DELETE FROM ChiTietHD WHERE MaHD = @idHoaDonBan1
			DELETE FROM HoaDon WHERE MaHD = @idHoaDonBan1
		END	
END
GO
--tạo thủ tục lấy hóa đơn theo ngày
Alter PROC USP_LayDanhHoaDonTheoNgay
@ngayVao DATE
AS
BEGIN
SELECT B.TenBan[Tên bàn], A.totalPrice [Tổng tiền], A.TGTT [Ngày thanh toán]
FROM HoaDon AS A, Ban AS B 
WHERE A.status = 1 AND A.MaBan = B.MaBan AND A.TGTT = @ngayVao
END


delete PROC USP_LayDanhHoaDonTheoNgay

go
--tạo 1 thủ tục update tài khoản
CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @tenHT NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.TaiKhoan WHERE Username = @userName AND Password = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = ' ')
		BEGIN
			UPDATE dbo.TaiKhoan SET TenHT = @tenHT WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.TaiKhoan SET TenHT = @tenHT, Password = @newPassword WHERE Username = @userName
	end
END
GO

alter PROC USP_LayDanhsachDU
AS
BEGIN
SELECT * FROM Menu
END

INSERT dbo.Menu(MaDu , TenDU , MaLoai , DonGia) values({0}, N'{1}',{2} ,{3})

update Menu set MaDu = N'{0}' , TenDU=N'{1}' , MaLoai={2} , DonGia = {3}


--tạo trigger xóa đồ uống tại chi tiết hóa đơn
CREATE TRIGGER UTG_DeleteBillInfo
ON ChiTietHD FOR DELETE
AS 
BEGIN
	DECLARE @idBillInfo INT
	
	DECLARE @idBill INT
	
	SELECT @idBillInfo = MaCTHD, @idBill = Deleted.MaHD FROM Deleted
	
	DECLARE @idTable INT
	
	SELECT @idTable = MaBan FROM HoaDon WHERE MaHD = @idBill
	
	DECLARE @count INT = 0
	
	SELECT @count = COUNT(*) FROM ChiTietHD AS bi, dbo.HoaDon AS b WHERE b.MaHD = bi.MaHD AND b.MaHD = @idBill AND b.status = 0
	
	IF (@count = 0)
		UPDATE Ban SET TTBan = N'Trống' WHERE MaBan = @idTable
END
GO

--tạo hàm chuyển đổi từ chữ có dấu về ko dấu--------------------------------
CREATE FUNCTION [dbo].[fuConvertToUnsign1] 
( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL 
RETURN @strInput IF @strInput = '' 
RETURN @strInput D
ECLARE @RT NVARCHAR(4000) 
DECLARE @SIGN_CHARS NCHAR(136) 
DECLARE @UNSIGN_CHARS NCHAR (136) 
SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
DECLARE @COUNTER int 
DECLARE @COUNTER1 int 
SET @COUNTER = 1 
WHILE (@COUNTER <=LEN(@strInput)) 
BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
------------------------------------------------------------
select * from Menu where dbo.fuConvertToUnsign1(TenDU) like N'%' + dbo.fuConvertToUnsign1(N'{0}')+'%'
----------------------------------------------------------------
CREATE TRIGGER KT_INSERT  ON ChiTietHD
INSTEAD OF INSERT 
AS
Declare @MaCTHD char(10);
Declare @MaHD char(10);
Declare @MaDU char(10);
Declare @SL int;
Declare @trungma int;

Select @MaDU = MaDU FROM inserted;
Select @MaHD = MaHD FROM inserted;
Select @trungma = COUNT(*) from ChiTietHD WHERE MaHD = @MaHD and MaDU = @MaDU;
Select @SL = inserted.Count FROM inserted

if (@trungma >0)
BEGIN
PRINT N'Cảnh báo : Trùng mã ,bạn không thể thêm vào';
RollBack Tran
Return
END


drop TRIGGER KT_INSERT