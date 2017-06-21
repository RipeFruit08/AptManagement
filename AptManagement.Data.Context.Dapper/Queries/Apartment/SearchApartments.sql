SELECT AptID, AptName, AptNumber, TenantOne, TenantTwo
FROM AptManagement.dbo.Apartment
WHERE (AptName = @searchTerm OR
TenantOne LIKE @searchTerm + '%' OR
TenantTwo LIKE @searchTerm + '%')  OR @searchTerm IS NULL