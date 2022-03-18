USE master
go

DROP DATABASE WebTraSua
go

CREATE DATABASE WebTraSua
go

USE WebTraSua
go

CREATE TABLE TinhTrang(
	ID int IDENTITY(1,1),
	maTinhTrang varchar(10) PRIMARY KEY,
	tenTinhTrang nvarchar(30)
)
go

INSERT INTO TinhTrang (maTinhTrang, tenTinhTrang) VALUES('active',N'Hoạt Động')
INSERT INTO TinhTrang (maTinhTrang, tenTinhTrang) VALUES('block',N'Khóa')
INSERT INTO TinhTrang (maTinhTrang, tenTinhTrang) VALUES('delete',N'Xóa')
go

CREATE TABLE NguoiDung(
	ID int IDENTITY (1,1) PRIMARY KEY,
	HoTen nvarchar(100),
	Email varchar(255) NOT NULL,
	MatKhau varchar(32),
	SDT varchar(13),
	DiaChi nvarchar(255),
	NgaySinh DateTime,
	GioiTinh nvarchar(4),
	maTinhTrang varchar(10),
	FOREIGN KEY (maTinhTrang) REFERENCES TinhTrang(maTinhTrang)
)
go

CREATE TABLE Administrator(
	ID int IDENTITY (1,1) PRIMARY KEY,
	TaiKhoan varchar(32),
	MatKhau varchar(32),
	HoTen nvarchar(100)
)
go

INSERT INTO Administrator (TaiKhoan, MatKhau, HoTen) VALUES ('admin', '21232f297a57a5a743894a0e4a801fc3','Administrator')

CREATE TABLE LoaiSanPham(
	ID int IDENTITY(1,1),
	maLoai varchar(10) PRIMARY KEY,
	tenLoai nvarchar(30)
)
go

INSERT LoaiSanPham(maLoai, tenLoai) VALUES('drink',N'Nước Uống')
INSERT LoaiSanPham(maLoai, tenLoai) VALUES('bakery',N'Bánh Tráng Miệng')
INSERT LoaiSanPham(maLoai, tenLoai) VALUES('food',N'Đồ Ăn Mặn')
go

CREATE TABLE SanPham(
	ID int IDENTITY (1,1) PRIMARY KEY,
	tenSP nvarchar(100),
	Gia numeric(10),
	Mota nvarchar(MAX),
	Anh varchar(MAX),
	ChonLoai nvarchar(MAX) DEFAULT '[]',
	ChonSize nvarchar(MAX) DEFAULT '[]',
	ChonDuong nvarchar(MAX) DEFAULT '[]',
	ChonDa nvarchar(MAX) DEFAULT '[]',
	ChonTopping nvarchar(MAX) DEFAULT '[]',
	GiamGia int DEFAULT 0,
	maLoai varchar(10),
	maTinhTrang varchar(10),
	FOREIGN KEY (maTinhTrang) REFERENCES TinhTrang(maTinhTrang),
	FOREIGN KEY (maLoai) REFERENCES LoaiSanPham(maLoai)
)
go

CREATE TABLE Topping(
	ID int IDENTITY(1,1) PRIMARY KEY,
	tenTP nvarchar(100),
	Gia numeric(10),
	maTinhTrang varchar(10),
	FOREIGN KEY (maTinhTrang) REFERENCES TinhTrang(maTinhTrang)
)
go

CREATE TABLE PTThanhToan(
	ID int IDENTITY(1,1),
	maPT varchar(10) PRIMARY KEY,
	tenPT nvarchar(10),
)
go

INSERT PTThanhToan(maPT, tenPT) VALUES('cod',N'Ship COD')
INSERT PTThanhToan(maPT, tenPT) VALUES('momo',N'MoMo')
go

CREATE TABLE HoaDon(
	ID int IDENTITY(1,1) PRIMARY KEY,
	ID_NguoiDung int,
	HoTen nvarchar(100),
	DiaChi nvarchar(255),
	SDT varchar(13),
	TinhTrang nvarchar(30),
	ThoiGianDat DateTime,
	ThoiGianNhan DateTime,
	maPT varchar(10),
	FOREIGN KEY (ID_NguoiDung) REFERENCES NguoiDung(ID),
	FOREIGN KEY (maPT) REFERENCES PTThanhToan(maPT)
)
go

CREATE TABLE CTHoaDon(
	ID int IDENTITY(1,1) PRIMARY KEY,
	ID_HoaDon int,
	ID_SanPham int,
	SoLuong int,
	Gia numeric(10),
	ChonLoai nvarchar(10),
	ChonSize nvarchar(10),
	ChonDuong nvarchar(10),
	ChonDa nvarchar(10),
	ChonTopping nvarchar(MAX) DEFAULT '[]',
	FOREIGN KEY (ID_HoaDon) REFERENCES HoaDon(ID),
	FOREIGN KEY (ID_SanPham) REFERENCES SanPham(ID)
)
go

CREATE TABLE ResetPass(
	ID int IDENTITY(1,1),
	maRS varchar(32) PRIMARY KEY,
	ID_NguoiDung int,
	ThoiHan varchar(20),
	FOREIGN KEY (ID_NguoiDung) REFERENCES NguoiDung(ID)
)