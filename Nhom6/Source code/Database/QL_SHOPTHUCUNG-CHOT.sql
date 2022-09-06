create database QL_SHOPTHUCUNG1
go
use QL_SHOPTHUCUNG1
drop database QL_SHOPTHUCUNG1
go
create table NHACUNGCAP
(
	MACC nchar(8) primary key, --CHINH
	TENCC nchar(30),
	DIACHI nvarchar(30),
	DTHOAI nchar(12)
)
create table LOAISP
(
	MaLoai int IDENTITY NOT NULL,
	TenLoai nvarchar(30) null,
	constraint PKLoaiSP primary key CLUSTERED (MaLoai  ASC),
)
CREATE TABLE SANPHAM
(
	MaSP INT  IDENTITY(1,1) NOT NULL,
	TenSP NVARCHAR(50),
	HinhAnh  NVARCHAR(100),
	Soluong int,
	Gia  int,
	TinhTrang NVARCHAR(50),
	MoTa NVARCHAR(225),
	MaLoai  INT,
	CONSTRAINT [ChiTietSP] PRIMARY KEY CLUSTERED  (MaSP  ASC )	,
	CONSTRAINT FK_SP_LoaiSP FOREIGN KEY (MaLoai) REFERENCES LoaiSP(MaLoai)
)
SET IDENTITY_INSERT LoaiSP ON
insert into LOAISP(MaLoai,TenLoai)
VALUES(1,N'Chó'),
(2,N'Mèo'),
(3,N'Phụ kiện');
SET IDENTITY_INSERT LoaiSP OFF
select * from LOAISP
create table NHAPHANG
(
	MANHAP int primary key identity, --CHINH
	MACC nchar(8) not null, --NGOAI
	TIENDAUTU money,
	NGAYNHAP date,
	constraint fk_MANcCC foreign key (MACC) references NHACUNGCAP (MACC)
)
create table CTNHAPHANG
(
	MANHAP int not null,--CHINH,NGOAI
	MASP int not null ,--CHINH,NGOAI
	SOLUONG int,
	DONGIA money,
	constraint PK_MAHHDq2 primary key (MANHAP,MASP),
	constraint fk_MAHDD foreign key (MANHAP) references NHAPHANG(MANHAP),
	constraint FK_CTHD3 foreign key (MASP) references SANPHAM(MASP)
)

create table KHACHHANG
(
	MAKH nchar(10) not null primary key,--CHINH
	TENKH nvarchar(30),
	NGSINH Date,
	PHANLOAI nvarchar(30),
	DIACHI nvarchar(30),
	DTHOAI nchar(12)
)

create table NHANVIEN
(
	MANV nchar(10) not null primary key,--CHINH
	TENNV nvarchar(30),
	NGSINH Date,
	DIACHI nvarchar(30),
	DTHOAI nchar(12),
	LUONG money,
	TAIKHOAN nchar(50),
	MATKHAU nchar(50),
	CHUCVU nvarchar(30)
)
create table HOADON
(
	MAHD int primary key identity,
	MAKH nchar(10) not null,--NGOAI
	NGAYHD date,
	TONGTIEN money,
	MANV nchar(10) not null--NGOAI,
	constraint fk_MANVV foreign key (MANV) references NHANVIEN (MANV),
	constraint fk_MAKHH1 foreign key (MAKH) references KHACHHANG (MAKH)
)
create table CTHOADON
(
	MAHD int not null,--CHINH,NGOAI
	MASP int not null ,--CHINH,NGOAI
	SOLUONG int,
	DONGIA money,
	constraint PK_MAHHD2 primary key (MAHD,MASP),
	constraint fk_MAHDD123 foreign key (MAHD) references HOADON(MAHD),
	constraint	 FK_CTHD33 foreign key (MASP) references SANPHAM(MASP)
)

insert into NHACUNGCAP(MACC, TENCC, DIACHI,DTHOAI)
values ('NCC001', N'Xuong dong duong','Tân Phú','0969111250')

set dateformat dmy
insert into NHANVIEN(MANV, TENNV, NGSINH, DIACHI,DTHOAI,LUONG,TAIKHOAN,MATKHAU,CHUCVU)
values ('NV001', N'Nguyễn Duy Mạnh','30-03-2001','Tân Phú','0969564250','10000000','admin','1',N'Quản lý'),
('NV002', N'Nguyễn Hùng Cường','21-03-2001','Tân Phú','0121321314','1000000','hungcuong','1',N'Nhân viên')

select count(TaiKhoan) from NhanVien where TaiKhoan='duymanh' and MATKHAU='duymanh'

insert into SANPHAM(TenSP, HinhAnh,Soluong,Gia,TINHTRANG,MoTa, MALOAI)--// Chó
values (N'Husky thuần chủng', 'husky.jpg',3, 5999000,N'Còn hàng',N'Giống cái,3 tháng tuổi,màu đen', 1),
(N'Husky Màu Nâu', 'husky_brown.jpg',4, 6999000,N'Còn hàng',N'Giống cái,3 tháng tuổi,màu đen', 1),
(N'Husky Lai', 'husky_lai.jpg',5, 2000000,N'Còn hàng',N'Giống đực,2 tháng tuổi,màu đen-trắng', 1),
(N'Shiba Nâu', 'S003.jpg',2, 10000000,N'Còn hàng',N'Giống đực,3 tháng tuổi,màu nâu', 1),
(N'Corgi Thuần Chủng', 'Corgi01.jpg',1, 13000000,N'Còn hàng',N'Giống đực,5 tháng tuổi,màu nâu', 1)
insert into SANPHAM(TenSP, HinhAnh,Soluong,Gia,TINHTRANG,MoTa, MALOAI)--// Mèo
values (N'Mèo Anh Lông Dài Trắng', 'ALD01.jpg',2, 2000000,N'Còn hàng',N'Giống cái,3 tháng tuổi,màu trắng', 2),
(N'Mèo Anh Lông Dài Cam', 'ALD02.jpg',3, 4000000,N'Còn hàng',N'Giống đực,2 tháng tuổi,màu cam', 2),
(N'Mèo Scotish Xám', 'S001.jpg',5, 1200000,N'Còn hàng',N'Giống đực,10 tháng tuổi,màu xám', 2),
(N'Mèo Scotish Trắng', 'S002.jpg',1, 1500000,N'Còn hàng',N'Giống cái,4 tháng tuổi,màu trắng', 2),
(N'Mèo Munckin', 'M001.jpg',3, 2100000,N'Còn hàng',N'Giống cái,5 tháng tuổi,màu Xám', 2)
insert into SANPHAM(TenSP, HinhAnh,Soluong,Gia,TINHTRANG,MoTa, MALOAI)--// Phụ kiện
values (N'Hạt cho mèo Cat EYES', 'cateye.jpg',10, 50000,N'Còn hàng',N'Ngon, Bổ, Rẻ', 3),
(N'Hạt cho mèo ME-0', 'meo.jpg',15, 70000,N'Còn hàng',N'Ngon, Bổ, Rẻ', 3),
(N'Hạt cho chó Pedigree', 'pedigree.jpg',5, 100000,N'Còn hàng',N'Ngon, Bổ, Rẻ', 3),
(N'Hạt cho chó Royal Canin', 'royalcanin.jpg',13, 200000,N'Còn hàng',N'Ngon, Bổ, Rẻ', 3),
(N'Vòng cổ cho chó mèo', 'vongco1.jpg',50, 10000,N'Còn hàng',N'Tiện dụng, hợp thời trang', 3)
set dateformat dmy
insert into KHACHHANG(MAKH, TENKH,NGSINH,PHANLOAI,DIACHI, DTHOAI)
values ('KH003', N'Nguyễn Đắc Đạt', '30/08/2001',N'VIP',N'TP.HCM', '09332343234')
set dateformat dmy
insert into KHACHHANG(MAKH, TENKH,NGSINH,PHANLOAI,DIACHI, DTHOAI)
values ('KH002', N'Nguyễn Hùng Cường', '30/08/2001',N'Vãng lai',N'TP.HCM', '09332343234')



--====================================NHAP HÀNG
set dateformat dmy
insert into NHAPHANG(MACC, NGAYNHAP) values('NCC001', getdate()),
('NCC001', getdate())
insert into CTNHAPHANG (MANHAP, MASP,SOLUONG, DONGIA)
 values(3, 6, 3,1000000),
(3, 7, 2,3000000),
(3, 6, 3,1000000),
(3, 7, 2,3000000)

--====================================HÓA ĐƠN
set dateformat dmy
insert into HOADON (MAKH, NGAYHD, MANV) values('KH003', getdate(), 'NV001'),
('KH002', getdate(), 'NV001'),
('KH003', '15-11-2021', 'NV001'),
('KH002', '15-11-2021', 'NV001'),
('KH003', '15-12-2021', 'NV001'),
('KH002', '15-12-2021', 'NV001')
insert into CTHOADON (MAHD, MASP,SOLUONG, DONGIA) values(2, 6, 3,5999000),
(2, 7, 2,6999000),
(3, 6, 3,2000000),
(3, 7, 2,4000000),
(5, 6, 3,2000000),
(6, 7, 2,4000000)



select PHANLOAI from KHACHHANG, HOADON where KHACHHANG.MAKH = HOADON.MAKH and MAHD = 4


create trigger KT_SOLUONG on SANPHAM
for insert,update
as
begin
	     UPDATE SANPHAM
		 SET TINHTRANG = N'Hết hàng' where SOLUONG = 0
		UPDATE SANPHAM
		SET TINHTRANG = N'Còn hàng' where SOLUONG > 0
	
end
drop trigger KT_SOLUONG



UPDATE SANPHAM
		 SET Soluong = 2 where MASP = 2
		 UPDATE SANPHAM
		 SET Soluong = 2 where MASP = 1
		 select * from HOADON
		 Select * from SANPHAM
		 Update SanPham set soluong = (select (SANPHAM.SOLUONG - CTHOADON.SOLUONG) from HOADON, CTHOADON,SANPHAM where HOADON.MAHD = CTHOADON.MAHD and SANPHAM.MASP = CTHOADON.MASP and CTHOADON.MAHD = 4) where exists (select CTHOADON.masp from CTHOADON,SANPHAM where SANPHAM.MASP = CTHOADON.MASP) 


--SẮP XẾP NHẬP HÀNG THEO TIỀN ĐẦU TƯ
create proc show_HD_TongTien_Giam
as
	begin
		select MANHAP,nhaphang.MACC,TIENDAUTU,NGAYNHAP
		from NHAPHANG, NhaCungCap
		where NHAPHANG.MACC = NhaCungCap.MACC
		order by TIENDAUTU DESC
	end
go
exec show_HD_TongTien_Giam
set dateformat dmy
--TÌM KIẾM NCC THEO SỐ ĐIỆN THOẠI
select * from NHACUNGCAP where DTHOAI like '%0969%'

--Tìm kiếm theo mã cung cấp
create proc TimKiem_MaCC @mcc char(10)
as 
	begin
		select *
		from NHACUNGCAP
		where MACC = @mcc
	end
go
exec TimKiem_Macc 'NCC001'

--Tìm kiếm theo tên
select * from NHACUNGCAP where TENCC Like N'%Trại%'
--Sắp xếp theo tháng giảm
select * from NHAPHANG 
order by MONTH(NGAYNHAP) DESC

select count(MANHAP) FROM NHAPHANG


insert into NHAPHANG(MACC,TIENDAUTU,NGAYNHAP) values ('NCC002',43434343,getdate())
select * from NHapHang
select * from CTNHAPHANG
select * from HOADON
select * from CTHOADON
select * from SANPHAM

