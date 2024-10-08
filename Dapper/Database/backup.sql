USE [StudentDb]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 8/26/2024 9:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [nvarchar](150) NULL,
	[EmailAddress] [nvarchar](150) NULL,
	[City] [nvarchar](150) NULL,
	[CreationDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [StudentId] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeleteStuent]    Script Date: 8/26/2024 9:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[DeleteStuent]
(
@StudentId int
)
as
begin try
Delete from Student where StudentId=@StudentId
select 'Delete Sucessfully' as Response
end try
begin catch
Select ERROR_MESSAGE() as Response
end Catch
GO
/****** Object:  StoredProcedure [dbo].[GetStudentList]    Script Date: 8/26/2024 9:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[GetStudentList]
as
begin
select*from Student
end
GO
/****** Object:  StoredProcedure [dbo].[InsertStuent]    Script Date: 8/26/2024 9:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[InsertStuent]
(
@StudentName nvarchar(150),
@EmailAddress nvarchar(150),
@City nvarchar(150),
@CreatedBy int
)
as
begin try
insert into Student(StudentName,EmailAddress,City,CreationDate,CreatedBy)
values(@StudentName,@EmailAddress,@City,GetDate(),@CreatedBy)
select 'Save Sucessfully' as Response
end try
begin catch
Select ERROR_MESSAGE() as Response
end Catch
GO
/****** Object:  StoredProcedure [dbo].[UpdateStuent]    Script Date: 8/26/2024 9:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[UpdateStuent]  
(  
@StudentId int,  
@StudentName nvarchar(150),  
@EmailAddress nvarchar(150),  
@City nvarchar(150),  
@CreatedBy int  
)  
as  
begin try  
update Student Set StudentName=@StudentName,EmailAddress=@EmailAddress,City=@City,CreatedBy=@CreatedBy where StudentId=@StudentId  
select 'update Sucessfully' as Response  
end try  
begin catch  
Select ERROR_MESSAGE() as Response  
end Catch
GO
