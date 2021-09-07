# BankingKata
- two operations : deposit and withdraw
- return account statement

# Examples
**Given** a client makes a *deposit* of *100* on *01/01/2020*  
**And** a *deposit* of *200* on *02/01/2020*  
**And** a *withdraw* of *50* on *03/01/2020*  
**When** he prints his account statement  
**Then** he would see:  
|**Date**|**Amount**|**Balance**|  
| ------ | -------- | --------- |
|03/01/2020|-50|250|  
|02/01/2020|200|300|  
|01/01/2020|100|100|  

# Idea
Refactoring to implement CQRS pattern

Related article :
[Du code legacy vers CQRS, est-ce possible ?](https://www.arolla.fr/blog/2021/09/du-code-legacy-vers-cqrs-est-ce-possible/)
