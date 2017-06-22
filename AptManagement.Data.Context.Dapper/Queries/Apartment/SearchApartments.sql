SELECT AptID, AptName, AptNumber, TenantOne, TenantTwo
FROM AptManagement.dbo.Apartment
WHERE (
	AptName = @searchTerm OR
	AptName + CONVERT(varchar(2), AptNumber) = @searchTerm OR
	AptName + '-' + CONVERT(varchar(2), AptNumber) LIKE @searchTerm OR
	TenantOne LIKE @searchTerm + '%' OR
	TenantTwo LIKE @searchTerm + '%'
)
OR @searchTerm IS NULL
ORDER BY AptName, AptNumber ASC