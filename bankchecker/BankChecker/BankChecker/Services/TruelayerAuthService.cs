namespace BankChecker.Services;

class TruelayerAuthService : ITruelayerAuthService
{
    public string GetToken(string accountId)
    {
        return "eyJhbGciOiJSUzI1NiIsImtpZCI6IjE0NTk4OUIwNTdDOUMzMzg0MDc4MDBBOEJBNkNCOUZFQjMzRTk1MTBSUzI1NiIsInR5cCI6ImF0K2p3dCIsIng1dCI6IkZGbUpzRmZKd3poQWVBQ291bXk1X3JNLWxSQSJ9.eyJuYmYiOjE2NzEwMjAxMzAsImV4cCI6MTY3MTAyMzczMCwiaXNzIjoiaHR0cHM6Ly9hdXRoLnRydWVsYXllci1zYW5kYm94LmNvbSIsImF1ZCI6ImRhdGFfYXBpIiwiY2xpZW50X2lkIjoic2FuZGJveC1jaGFyaXR5cm91bmR1cC01ZWVhNDYiLCJzdWIiOiJnTWVxUTF2THkva1JZZHhOTjBLakxUaEoyUjc4Y1MxMEZmTlV0RTN5RkdrPSIsImF1dGhfdGltZSI6MTY3MTAyMDEyMywiaWRwIjoibG9jYWwiLCJqdGkiOiI3QUQ2NTA3NUJFNTUyN0JDNDVEQUExQTFCNzMyRDRCQiIsInNpZCI6ImF1dGgtbWdoZDBGUXJlU2Q3OUhKbHFTeEdEbnlLdTNKbXNJUVJFQkx6OGtxYUljQSIsImlhdCI6MTY3MTAyMDEzMCwiY29ubmVjdG9yX2lkIjoibW9jayIsImNyZWRlbnRpYWxzX2tleSI6IjFkYjQwMjk4MmNhZWZjN2U5YmNiM2ZkODQyYThjNTBhOGYzNjY5OTVkMzU4YmUwZGY5ZWJhMDU1M2QzZDA0MDMiLCJwcml2YWN5X3BvbGljeSI6Ik5vdjIwMjAiLCJjb25zZW50X2lkIjoiOTJjOTkzMWQtMDNkNi00OTAzLWJmZmItOWZlMTllYWIwMWZmIiwiY29uc2VudF9leHBpcnlfdGltZSI6MTY3ODc5NjEyMywic2NvcGUiOlsiaW5mbyIsImFjY291bnRzIiwiYmFsYW5jZSIsImNhcmRzIiwidHJhbnNhY3Rpb25zIiwiZGlyZWN0X2RlYml0cyIsInN0YW5kaW5nX29yZGVycyIsIm9mZmxpbmVfYWNjZXNzIl0sImFtciI6WyJwd2QiXX0.aicUm68cFrU9v3Cfkm7nvwNM8IuEhE8w6hm_tLvT1tjgVtEEnEYpuu-H-pjXENDo83R9kx4IEQ0tuQrHOQ0kqGea7M6tk_hZJd5_-fMDQFklwe1gI6nplWP2i5eWKnPvydt2Wdql8avK5fHnWBP7iQ5roodfiTzSrhAmiV7XlRZGqNjwuSJQeQRrSvgD_eG4ZEInk6_PlfPMk8mvKSjp60VZ8CJ6GG09aIAKBW-E9narmvrlplI-tPQHLNR3M1-tot8W5DwaBO7VtBBCnkE50j9-q_GnzP3-eYQdQQt4R6uhvG8QB6ujwCiVaKM0rirNq3hPOUSA3bEunnkNEMa71g";
    }
}