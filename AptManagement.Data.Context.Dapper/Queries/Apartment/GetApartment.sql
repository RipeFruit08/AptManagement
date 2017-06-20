SELECT 
AptID,
AptName,
AptNumber,
TenantOne,
TenantTwo
FROM AptManagement.dbo.Apartment
WHERE AptID = @AptID