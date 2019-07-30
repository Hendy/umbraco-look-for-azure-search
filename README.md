# umbraco-look-for-azure-search
Indexing and Querying API of Umbraco data in Azure Search

1) Create skeleton schema* (*schema in this doc refers an Azure Search Index with all of its field specifications)

2) Create config API for user to specify custom schema to create (only operational in debug mode - as a safety check)

	user should be able to :	specify tag groups, (start with this one)
								specify text field names,
								specify numeric field names,
								specify date field names,
								specify geo field names

3) update config API to be able to create different schemas (max 3 available on free account)

4) Implement indexing mechanism

5) Implement querying model - deviates from Look for Examine in that multipe text/numeric/date and geo field may be used

6) Re-use result pattern from Look for Examine