/*
CREATE TABLE Account (
	AccountNo int,
    FirstName Char,
    LastName Char,
    City char,
	State char,
	DateOfOpening Date,
	Amount int,
	ChequeFacil char,
	AcountType char,
	Status char,
); 

--Stored Procedure

create proc dbo.[GenerateAccoutNo]
As
Begin
	Select Case when MAX(AccountNo) is null then 1
	else max(AccountNo) +1 end accno from Account;
end
go

-- Stored Procedure

create proc dbo.[CreateAccount]
			@AccountNo int,
			@FirstName char,
			@LastName char,
			@City char,
			@State char,
			@DateofOpening date,
			@Amount int,
			@chequeFacil char,
			@AccountType char,
			@Status char
As
Begin
Insert into Account(
					AccountNo,
					FirstName,
					LastName,
					City,
					State,
					DateOfOpening,
					Amount,
					ChequeFacil,
					AcountType,
					Status)

values (@AccountNo
					,@FirstName
					,@LastName
					,@City
					,@State
					,@DateofOpening
					,@Amount
					,@chequeFacil
					,@AccountType
					,@Status)
end

-- Stored Procedure

Create or alter proc dbo.[WithdrawAmount]
					@WithdrawAmount int,
					@AccountNo int,
					@result varchar(30) Output
as
begin
	declare @amount int;
	Select @amount =  Amount from Account
					 Where AccountNo = @AccountNo
	if @amount - @WithdrawAmount >= 1000 
		begin
			update Account set Amount = @amount - @WithdrawAmount where AccountNo = @AccountNo;
			set @result = 'Amount Debited...'
		end
	else
	   set	@result = 'Insuficient Balance.'

end

--Stored Procedure

Create or alter proc dbo.[DeletAccount]
						@AccountNo int,
						@result varchar(30) output
as 
begin
	if Exists (Select COUNT(1) from Account where AccountNo = @AccountNo) 
		begin
			delete Account where AccountNo = @AccountNo;
			set @result = 'Record deleted..'
		end
	else
		set @result = 'Record does not exist'
end



 */