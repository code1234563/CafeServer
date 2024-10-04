
create database WPF_QuanLyCafe
go
use WPF_QuanLyCafe
go

create table KHUVUC
(
MAKHUVUC INT IDENTITY(1,1),
TENKHUVUC NVARCHAR(100),
)
go
create index idx_khuvuc
on KHUVUC(MAKHUVUC,TENKHUVUC)
GO
create procedure sp_loadkhuvuc
as
begin
select MAKHUVUC,TENKHUVUC from KHUVUC
end
go
create table BAN
(
MABAN INT IDENTITY(1,1),
TENBAN NVARCHAR(100),
TRANGTHAI NVARCHAR(100),
MAKHUVUC INT
)
go
create index idx_ban
on BAN(MABAN,TENBAN,TRANGTHAI,MAKHUVUC);
GO
create procedure sp_loadbantheokhuvuc
@makhuvuc int
as
begin
select MABAN,TENBAN,TRANGTHAI,MAKHUVUC from BAN where MAKHUVUC=@makhuvuc order by MABAN asc
end
go

create procedure sp_bandanhmuc
@makhuvuc int
as
begin
select MABAN,TENBAN from BAN where MAKHUVUC=@makhuvuc order by MABAN asc
end
go

create table DANHMUCTHUCDON
(
MADM INT IDENTITY(1,1),
TENDM NVARCHAR(100)
)
go
create index idx_DANHMUC
on DANHMUCTHUCDON(MADM,TENDM)
GO
create procedure sp_danhmucloadthucdon
as
begin
select MADM,TENDM from DANHMUCTHUCDON
end
go
create table THUCDON
(
MATHUCDON INT IDENTITY (1,1),
TENTHUCDON NVARCHAR(100),
DONGIA FLOAT,
GIAMGIA int DEFAULT(0),
MADM INT
)
go
create index idx_THUCDON
on THUCDON(MATHUCDON,TENTHUCDON,DONGIA,GIAMGIA,MADM)
GO
CREATE procedure sp_loadthucdon
@madm int
as
begin
select MATHUCDON,TENTHUCDON,DONGIA,GIAMGIA from THUCDON where MADM=@madm
end
go



create table HOADON
(
IDHOADON INT IDENTITY(1,1),
NGAYLAP DATE,
TONGTIEN FLOAT,
MABAN INT,
TRANGTHAIHOADON int default(0), -- 0 là chưa thanh toán 1 là thanh toán rồi 
INHOADON INT default(0), -- 0 là chưa in 1 là kích hoạt cho Server in, nếu là 2 thì do Server tính và ko cần làm gì, sau khi in xong sẽ cập nhật nó lên là 3
GIOLAP varchar(50),
IDNHANVIEN VARCHAR(100)
)
go
create procedure sp_themhoadon
@ngaylap date,@maban int
as
begin
insert into HOADON(NGAYLAP,MABAN,GIOLAP) values(@ngaylap,@maban,(select convert(varchar(10), GETDATE(), 108)))
update BAN set TRANGTHAI=N'Có người' where MABAN=@maban
end
go

create table CTHD
(
IDCTHD int identity(1,1),
IDHOADON int,
MATHUCDON INT,
SOLUONG int,
GIAMGIA int default(0)
)
go

create procedure sp_themcthdban
@idhoadon int,@mathucdon int,@soluong int,@giamgia int
as
begin
if(@mathucdon in (select MATHUCDON from CTHD where IDHOADON=@idhoadon and MATHUCDON=@mathucdon and GIAMGIA=@giamgia))
begin
declare @soluongcu int,@soluongmoi int,@tongsoluong int
set @soluongcu=(select SOLUONG from CTHD where IDHOADON=@idhoadon and MATHUCDON=@mathucdon and GIAMGIA=@giamgia)
set @soluongmoi=@soluong
set @tongsoluong=@soluongcu+@soluongmoi
update CTHD set SOLUONG=@tongsoluong where IDHOADON=@idhoadon and MATHUCDON=@mathucdon and GIAMGIA=@giamgia
end
else
begin
insert into CTHD(IDHOADON,MATHUCDON,SOLUONG,GIAMGIA) values(@idhoadon,@mathucdon,@soluong,@giamgia)
end
end
go

create procedure sp_xoachitiethoadon
@idhoadon int,@mathucdon int,@giamgia int
as
begin
delete from CTHD where IDHOADON=@idhoadon and MATHUCDON=@mathucdon and GIAMGIA=@giamgia
end
go
create procedure sp_loaddanhsachthucdoncuaban
@maban int,@mahoadon int
as
begin
select THUCDON.TENTHUCDON,THUCDON.DONGIA * ((100 - CAST(CTHD.GIAMGIA AS float))/100) as 'DONGIA',CTHD.SOLUONG ,THUCDON.MATHUCDON,CTHD.GIAMGIA,THUCDON.DONGIA as 'GiaMD',(THUCDON.DONGIA * ((100 - CAST(CTHD.GIAMGIA AS float))/100)) * CTHD.SOLUONG as 'TTien'
from HOADON
inner join CTHD on HOADON.IDHOADON=CTHD.IDHOADON
inner join THUCDON on THUCDON.MATHUCDON=CTHD.MATHUCDON
where HOADON.IDHOADON=@mahoadon and HOADON.MABAN=@maban
end
go    

exec sp_loaddanhsachthucdoncuaban_rpt 51,74,'11:05 PM'

create procedure sp_loaddanhsachthucdoncuaban_rpt
@maban int,@mahoadon int,@giora varchar(50)
as
begin
select THUCDON.TENTHUCDON,THUCDON.DONGIA,CTHD.SOLUONG ,THUCDON.MATHUCDON,CTHD.GIAMGIA,TAIKHOAN.HOTEN,HOADON.NGAYLAP,SUBSTRING(HOADON.GIOLAP,1,5) AS 'GIOLAP',BAN.TENBAN,KHUVUC.TENKHUVUC,@giora as 'GIORA',(THUCDON.DONGIA * ((100 - CAST(CTHD.GIAMGIA AS float))/100))*CTHD.SOLUONG AS 'TTIEN'
from HOADON
inner join TAIKHOAN on TAIKHOAN.TENDANGNHAP=HOADON.IDNHANVIEN
inner join BAN on BAN.MABAN=HOADON.MABAN
inner join KHUVUC on KHUVUC.MAKHUVUC=BAN.MAKHUVUC
inner join CTHD on HOADON.IDHOADON=CTHD.IDHOADON
inner join THUCDON on THUCDON.MATHUCDON=CTHD.MATHUCDON
where HOADON.IDHOADON=@mahoadon and HOADON.MABAN=@maban
end
go           


create procedure sp_loaddanhsachthucdoncuaban_thongke
@mahoadon int
as
begin
select THUCDON.TENTHUCDON,THUCDON.DONGIA * ((100 - CAST(CTHD.GIAMGIA AS float))/100) as 'DONGIA',CTHD.SOLUONG ,THUCDON.MATHUCDON,CTHD.GIAMGIA
from HOADON
inner join CTHD on HOADON.IDHOADON=CTHD.IDHOADON
inner join THUCDON on THUCDON.MATHUCDON=CTHD.MATHUCDON
where HOADON.IDHOADON=@mahoadon
end
go        

CREATE procedure sp_layidhoadontheo_khuvucban
@maban int,@makhuvuc int
as
begin
select HOADON.IDHOADON
from HOADON
inner join BAN on HOADON.MABAN=BAN.MABAN
where BAN.MABAN=@maban and BAN.MAKHUVUC=@makhuvuc and HOADON.TRANGTHAIHOADON=0
end
go



create procedure sp_thanhtoanban
@maban int,@mahoadon int,@tongtien float,@idnhanvien varchar(50)
as
begin
update HOADON set TRANGTHAIHOADON=1,TONGTIEN=@tongtien,IDNHANVIEN=@idnhanvien,INHOADON=2 where IDHOADON=@mahoadon and MABAN=@maban
update BAN set TRANGTHAI=N'Trống' where MABAN=@maban
end
go

create procedure sp_thanhtoanbanclient
@maban int,@mahoadon int,@tongtien float,@idnhanvien varchar(50)
as
begin
update HOADON set TRANGTHAIHOADON=1,TONGTIEN=@tongtien,IDNHANVIEN=@idnhanvien,INHOADON=1 where IDHOADON=@mahoadon and MABAN=@maban
update BAN set TRANGTHAI=N'Trống' where MABAN=@maban
end
go

create procedure sp_danhsachkhuvuccobantrong
as
begin
select BAN.TENBAN,KHUVUC.TENKHUVUC,BAN.TRANGTHAI 
from BAN
inner join KHUVUC on BAN.MAKHUVUC=KHUVUC.MAKHUVUC
where BAN.TRANGTHAI=N'Trống'
order by TENKHUVUC asc 
end
go

--Phần danh mục (WPF)
-- Khu vực

create procedure sp_loadkhuvuc_danhmuc
as
begin
select KHUVUC.MAKHUVUC,KHUVUC.TENKHUVUC,COUNT(BAN.MABAN) as 'SLBAN'
from KHUVUC
left join BAN on KHUVUC.MAKHUVUC=BAN.MAKHUVUC
group by KHUVUC.MAKHUVUC,KHUVUC.TENKHUVUC
order by KHUVUC.MAKHUVUC
end
go
create procedure sp_themkhuvuc
@tenkhuvuc nvarchar(200)
as
begin
insert into KHUVUC(TENKHUVUC) values (@tenkhuvuc)
end
go
create procedure sp_xoakhuvuc
@makhuvuc int
as
begin
delete from KHUVUC where MAKHUVUC=@makhuvuc
end
go
-- Bàn
--create procedure sp_bandanhmuc
--@makhuvuc int
--as
--begin
--select MABAN,TENBAN from BAN where MAKHUVUC=@makhuvuc
--end
--go
create procedure sp_thembandanhmuc
@tenban nvarchar(50),@makhuvuc int
as
begin
insert into BAN(TENBAN,MAKHUVUC,TRANGTHAI) values(@tenban,@makhuvuc,N'Trống')
end
go
create procedure sp_suaban
@idban int,@tenban nvarchar(50)
as
begin
update BAN SET TENBAN=@tenban where MABAN=@idban
end
go
create procedure sp_xoabandanhmuc
@maban int
as
begin
delete from BAN where MABAN=@maban
end
go
-- Danh mục thực đơn + thực đơn
create procedure sp_themdanhmucthucdon
@tendanhmuc nvarchar(100)
as
begin
insert into DANHMUCTHUCDON(TENDM) values(@tendanhmuc)
end
go
create procedure sp_xoadanhmucthucdon
@iddanhmuc int
as
begin
delete from DANHMUCTHUCDON where MADM=@iddanhmuc
end
go
create procedure sp_themthucdon
@tenthucdon nvarchar(100),@dongia float,@iddm int
as
begin
insert into THUCDON(TENTHUCDON,DONGIA,MADM) values(@tenthucdon,@dongia,@iddm)
end
go
create procedure sp_xoathucdon
@mathucdon int 
as
begin
delete from THUCDON where MATHUCDON=@mathucdon
end
go

--create procedure sp_xoachitiethoadon
--@idhoadon int,@mathucdon int
--as
--begin
--delete from CTHD where IDHOADON=@idhoadon and MATHUCDON=@mathucdon
--end
--go


create procedure sp_xoahoadonkhihetmon
@idhoadon int,@idban int
as
begin
delete from CTHD where IDHOADON=@idhoadon
delete from HOADON where IDHOADON=@idhoadon
update BAN set TRANGTHAI=N'Trống' where MABAN=@idban
end
go

create procedure sp_loadbantrangthaitrong
@makhuvuc int
as
begin
select * from BAN where TRANGTHAI=N'Trống' and MAKHUVUC=@makhuvuc
end
go

create procedure sp_loadbantrangthaiconguoi
@makhuvuc int
as
begin
select * from BAN where TRANGTHAI=N'Có người'and MAKHUVUC=@makhuvuc
end
go

create procedure sp_chuyenbantable
@mabanmoi int,@mabancu int
as
begin
update HOADON set MABAN=@mabanmoi where MABAN=@mabancu and HOADON.TRANGTHAIHOADON=0
update BAN set TRANGTHAI=N'Trống' where MABAN=@mabancu
update BAN set TRANGTHAI=N'Có người' where MABAN=@mabanmoi
end
go


create procedure [dbo].[sp_loadbancangop]
@makhuvuc int,@maban int
as
begin
select *,HOADON.IDHOADON 
from BAN 
inner join HOADON on BAN.MABAN=HOADON.MABAN
where TRANGTHAI=N'Có người'and MAKHUVUC=@makhuvuc and BAN.MABAN<> @maban and HOADON.TRANGTHAIHOADON=0
end
go

create procedure sp_loadcthdbangop
@mabangop int
as
begin
declare @hoadonbangop int
set @hoadonbangop=(select IDHOADON from HOADON where MABAN=@mabangop and TRANGTHAIHOADON=0)
select * from CTHD where IDHOADON=@hoadonbangop
end
go

create procedure sp_xoahoadongopban
@maban int
as
begin
declare @hoadonbangop int
set @hoadonbangop=(select IDHOADON from HOADON where MABAN=@maban and TRANGTHAIHOADON=0)
delete from CTHD where IDHOADON=@hoadonbangop
delete from HOADON where IDHOADON=@hoadonbangop
update BAN set TRANGTHAI=N'Trống' where MABAN=@maban
end
go

create procedure sp_themgiamgia
@mathucdon int , @giamgia int
as
begin
update THUCDON set GIAMGIA=@giamgia where MATHUCDON=@mathucdon
end
go

create procedure sp_xoagiamgia
@mathucdon int
as
begin
update THUCDON set GIAMGIA=0 where MATHUCDON=@mathucdon
end
go

create procedure sp_suagiathucdon
@mathucdon int,@dongia float
as
begin
update THUCDON set DONGIA=@dongia where MATHUCDON=@mathucdon
end
go

--tài khoản
create table TAIKHOAN
(
TENDANGNHAP VARCHAR(100),
HOTEN NVARCHAR(100),
MATKHAU VARCHAR(100),
QUYEN VARCHAR(100)
CONSTRAINT PK_TENDANGNHAP PRIMARY KEY(TENDANGNHAP)
)
go
create procedure sp_loadtaikhoan
as
begin
select * from TAIKHOAN
end
go
create procedure sp_themtaikhoan
@tentaikhoan varchar(100),@matkhau varchar(100),@quyen varchar(100),@hoten nvarchar(100)
as
begin
insert into TAIKHOAN(TENDANGNHAP,MATKHAU,QUYEN,HOTEN) values(@tentaikhoan,@matkhau,@quyen,@hoten)
end
go
create procedure sp_xoataikhoan
@tentaikhoan varchar(100)
as
begin
delete from TAIKHOAN where TAIKHOAN.TENDANGNHAP=@tentaikhoan
end
go
create procedure sp_resetmatkhau
@tentaikhoan varchar(100)
as
begin
update TAIKHOAN set MATKHAU='202cb962ac59075b964b07152d234b70' where TENDANGNHAP=@tentaikhoan
end
go


create procedure sp_kiemtradangnhap
@tendangnhap varchar(100)
as
begin
select * from TAIKHOAN where TENDANGNHAP=@tendangnhap
end
go

--Thống kê món theo ngày

create procedure sp_thongkemontheongay
@ngay int
as
begin
select THUCDON.TENTHUCDON,SUM(CTHD.SOLUONG) as 'SOLUONG',sum((THUCDON.DONGIA * ((100 - CAST(CTHD.GIAMGIA AS float))/100)) * CTHD.SOLUONG) as 'TongTien'
from HOADON
inner join CTHD on HOADON.IDHOADON=CTHD.IDHOADON
inner join THUCDON on CTHD.MATHUCDON=THUCDON.MATHUCDON
where HOADON.TRANGTHAIHOADON=1 AND YEAR(HOADON.NGAYLAP)=YEAR(GETDATE()) and MONTH(HOADON.NGAYLAP)=MONTH(GETDATE()) and DAY(HOADON.NGAYLAP)=@ngay
group by THUCDON.TENTHUCDON,THUCDON.DONGIA
order by TENTHUCDON
end
go

--Thống kê món theo tháng
create procedure sp_thongkemontheothang
@thang int
as
begin
select THUCDON.TENTHUCDON,SUM(CTHD.SOLUONG) as 'SOLUONG',sum((THUCDON.DONGIA * ((100 - CAST(CTHD.GIAMGIA AS float))/100)) * CTHD.SOLUONG) as 'TongTien'
from HOADON
inner join CTHD on HOADON.IDHOADON=CTHD.IDHOADON
inner join THUCDON on CTHD.MATHUCDON=THUCDON.MATHUCDON
where HOADON.TRANGTHAIHOADON=1 AND YEAR(HOADON.NGAYLAP)=YEAR(GETDATE()) and MONTH(HOADON.NGAYLAP)=@thang
group by THUCDON.TENTHUCDON,THUCDON.DONGIA
order by TENTHUCDON
end
go

--Thống kê món theo năm
create procedure sp_thongkemontheonam
@nam date
as
begin
select THUCDON.TENTHUCDON,SUM(CTHD.SOLUONG) as 'SOLUONG',sum((THUCDON.DONGIA * ((100 - CAST(CTHD.GIAMGIA AS float))/100)) * CTHD.SOLUONG) as 'TongTien'
from HOADON
inner join CTHD on HOADON.IDHOADON=CTHD.IDHOADON
inner join THUCDON on CTHD.MATHUCDON=THUCDON.MATHUCDON
where HOADON.TRANGTHAIHOADON=1 AND HOADON.NGAYLAP=@nam
group by THUCDON.TENTHUCDON,THUCDON.DONGIA
order by TENTHUCDON
end
go
--Doanh Thu Theo Ngay
create procedure sp_doanhthutheongay
@ngay int
as
begin
select KHUVUC.TENKHUVUC,BAN.TENBAN,HOADON.TONGTIEN,HOADON.NGAYLAP,HOADON.GIOLAP,HOADON.IDHOADON
from HOADON
inner join BAN on HOADON.MABAN=BAN.MABAN
inner join KHUVUC on BAN.MAKHUVUC=KHUVUC.MAKHUVUC
where HOADON.TRANGTHAIHOADON=1 and YEAR(HOADON.NGAYLAP)=YEAR(GETDATE()) and MONTH(HOADON.NGAYLAP)=MONTH(GETDATE()) and DAY(HOADON.NGAYLAP)=@ngay
end
go



--Doanh Thu Theo Tháng
create procedure sp_danhthutheothang
@thang int
as
begin
select KHUVUC.TENKHUVUC,BAN.TENBAN,HOADON.TONGTIEN,HOADON.NGAYLAP,HOADON.GIOLAP,HOADON.IDHOADON
from HOADON
inner join BAN on HOADON.MABAN=BAN.MABAN
inner join KHUVUC on BAN.MAKHUVUC=KHUVUC.MAKHUVUC
where HOADON.TRANGTHAIHOADON=1 and YEAR(HOADON.NGAYLAP)=YEAR(GETDATE()) and MONTH(HOADON.NGAYLAP)=@thang
end
go

--Doanh Thu Theo Năm 
create procedure sp_doanhthutheonam
@nam date
as
begin
select KHUVUC.TENKHUVUC,BAN.TENBAN,HOADON.TONGTIEN,HOADON.NGAYLAP,HOADON.GIOLAP,HOADON.IDHOADON
from HOADON
inner join BAN on HOADON.MABAN=BAN.MABAN
inner join KHUVUC on BAN.MAKHUVUC=KHUVUC.MAKHUVUC
where HOADON.TRANGTHAIHOADON=1 and HOADON.NGAYLAP=@nam
end
go

create procedure sp_capnhathoadondain
@idhoadon int
as
begin
update HOADON set INHOADON=3 where IDHOADON=@idhoadon
end
go

create procedure sp_loadhoadoncanin
as
begin
select IDHOADON,INHOADON,MABAN 
from HOADON
where HOADON.TRANGTHAIHOADON=1 and HOADON.INHOADON=1 and NGAYLAP=CAST(GETDATE() as date)
end
go

delete from KHUVUC
delete from BAN
delete from DANHMUCTHUCDON
delete from THUCDON
delete from CTHD
delete from HOADON