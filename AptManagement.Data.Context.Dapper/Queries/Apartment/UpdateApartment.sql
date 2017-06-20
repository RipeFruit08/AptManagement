UPDATE AptManagement.dbo.Apartment
SET
AptName   = @AptName,
AptNumber = @AptNumber,
TenantOne = @TenantOne,
TenantTwo = @TenantTwo
WHERE AptID = @AptID