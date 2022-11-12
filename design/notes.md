# Rough overview of idea

Rename "Institutions" to "Clients" in the codebase. Onwards will be referred to clients.

## Stage 1 - Domain Registration Management

### Story 1
As a tech managing multiple domains for multiple companies, I want to be able to quickly check which domains belong to each company

#### Implimentation Ideas

##### Classes

Client class:
string Name: "Contoso"

Registrar class:
string Name: "Porkbun"

Domain class:

string ApexDomainName: "mywebsite.com"
Client Owner: "Contoso"
Registrar Registrar: "Porkbun"


## Stage 2 - Domain Zone Manangement

### Story 1
As a tech managing multiple zones, I want to be able to quickly check which domain zones are being used for which services.

