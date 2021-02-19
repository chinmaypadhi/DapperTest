create database acharyaVihar
use acharyaVihar

create table tblBranch (intID int identity primary key not null,vchBranchName varchar(45),vchBranchDesc varchar(35))

create table tblStudent(intStudentID int primary key not null,intBranchID int foreign key references tblBranch(intID),vchStudentName varchar(56), vchAddress varchar(45))

/////////////////////////////////////////////////////////
ALTER procedure [dbo].[SP_Branch_DML]
		@p_CHRACTION CHAR(10),
		@P_intID int=null,
		@P_vchBranchName  varchar(50)=NULL,
		@p_vchBranchDesc varchar(100)=Null,
		
		
		@P_VCHMSGOUT VARCHAR(500) = successful OUTPUT
	AS
BEGIN
	BEGIN TRY
		BEGIN TRAN 
			IF(@P_CHRACTION='SUBINS')
				BEGIN
									
					INSERT tblBranch(
						vchBranchName,
						vchBranchDesc)
					VALUES(
						@P_vchBranchName,
						@P_vchBranchDesc
						)
		
					set @P_VCHMSGOUT=1
				
				END
			IF(@P_CHRACTION='SUBEDIT')
				BEGIN
					UPDATE 		tblBranch SET 	
						vchBranchName=@P_vchBranchName,
						vchBranchDesc=@P_vchBranchDesc
						WHERE 
						intID=@P_intID
					
		
					set @P_VCHMSGOUT=1
				
				END
			COMMIT TRAN  
		END TRY
	BEGIN CATCH
		IF @@TRANCOUNT>0
		BEGIN
			SET @P_vchMsgOut = 59 -- DATABASE ERROR
			ROLLBACK
			--EXEC USP_DB_TRACE_ERROR_LOG
		END
	END CATCH
END
/////////////////////////////////////////////////////////////////////////

ALTER procedure [dbo].[SP_Branch_Report]
		@p_CHRACTION CHAR(10),
		@P_intID INT=NULL,
		@P_vchBranchName  varchar(50)=NULL,
		@p_vchBranchDesc varchar(100)=Null,
		
		
		@P_VCHMSGOUT VARCHAR(500) = successful OUTPUT
	AS
BEGIN
	BEGIN TRY
		BEGIN TRAN 
			IF(@P_CHRACTION='BALL')
				BEGIN
					SELECT intID,
						vchBranchName,
						vchBranchDesc FROM 
						tblBranch

					
		
				
				
				END

			ELSE IF(@P_CHRACTION='BDTL')
				BEGIN
					SELECT intID,
						vchBranchName,
						vchBranchDesc FROM 
						tblBranch
						WHERE intID=@P_intID
				END
			ELSE IF(@P_CHRACTION='BDTLDD')
				BEGIN
					
					SELECT intID,
						vchBranchName FROM 
						tblBranch
						
				END
			COMMIT TRAN  
		END TRY
	BEGIN CATCH
		IF @@TRANCOUNT>0
		BEGIN
			SET @P_vchMsgOut = 59 -- DATABASE ERROR
			ROLLBACK
			--EXEC USP_DB_TRACE_ERROR_LOG
		END
	END CATCH
END
///////////////////////////////////////////////////////////////////////////////////////

ALTER procedure [dbo].[SP_Student_DML]
		@p_CHRACTION CHAR(10),
		@P_intStudentID int=null,
		@P_intBranchID int =null,
		@P_vchStudentName varchar(50)=null,
		@P_vchAddress varchar(50)=null,

		
		@P_VCHMSGOUT VARCHAR(500) = successful OUTPUT
	AS
BEGIN
	BEGIN TRY
		BEGIN TRAN 
			IF(@P_CHRACTION='STUDINS')
				BEGIN
									
					INSERT tblStudent(
						intBranchID ,
						vchStudentName,
						vchAddress )
					VALUES(
						@P_intBranchID ,
						@P_vchStudentName,
						@P_vchAddress
						)
		
					set @P_VCHMSGOUT=1
				
				END
			--IF(@P_CHRACTION='SUBEDIT')
			--	BEGIN
			--		UPDATE 		tblBranch SET 	
			--			vchBranchName=@P_vchBranchName,
			--			vchBranchDesc=@P_vchBranchDesc
			--			WHERE 
			--			intID=@P_intID
					
		
			--		set @P_VCHMSGOUT=1
				
			--	END
			COMMIT TRAN  
		END TRY
	BEGIN CATCH
		IF @@TRANCOUNT>0
		BEGIN
			SET @P_vchMsgOut = 59 -- DATABASE ERROR
			ROLLBACK
			--EXEC USP_DB_TRACE_ERROR_LOG
		END
	END CATCH
END
////////////////////////////////////////////////////////

ALTER procedure [dbo].[SP_Student_Report]
		@p_CHRACTION CHAR(10),
		@P_intStudentID int=null,
		@P_intBranchID int =null,
		@P_vchStudentName varchar(50)=null,
		@P_vchAddress varchar(50)=null,
		
		@P_VCHMSGOUT VARCHAR(500) = successful OUTPUT
	AS
BEGIN
	BEGIN TRY
		BEGIN TRAN 
			IF(@P_CHRACTION='BALL')
				BEGIN
					SELECT intStudentID ,
							intBranchID,
							vchStudentName ,
							vchAddress
						FROM tblStudent

					
		
				
				
				END

			--IF(@P_CHRACTION='BDTL')
			--	BEGIN
			--		SELECT intID,
			--			vchBranchName,
			--			vchBranchDesc FROM 
			--			tblBranch
			--			WHERE intID=@P_intID

					
		
				
				
			--	END
			
			COMMIT TRAN  
		END TRY
	BEGIN CATCH
		IF @@TRANCOUNT>0
		BEGIN
			SET @P_vchMsgOut = 59 -- DATABASE ERROR
			ROLLBACK
			--EXEC USP_DB_TRACE_ERROR_LOG
		END
	END CATCH
END
