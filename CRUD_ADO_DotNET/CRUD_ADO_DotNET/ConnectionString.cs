namespace CRUD_ADO_DotNET
{
    public static class ConnectionString
    {
        private static string cs = "Server=DESKTOP-MP7NKC7\\SQLEXPRESS;Database=CrudADOdb;Trusted_Connection=True;TrustServerCertificate=True;";
        public static string dbcs { get => cs; }
    }
}
