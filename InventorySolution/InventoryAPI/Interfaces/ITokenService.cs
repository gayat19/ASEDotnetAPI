namespace InventoryAPI.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(string username, string userRole);
    }
}
