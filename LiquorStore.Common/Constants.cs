namespace LiquorStore.Common;

public class Constants
{
    public const string SqlExceptionMessage = "Error en la base de datos del servidor.";
    public const string UnexpectedMessage = "Error inesperado en el servidor.";

    public struct Claims
    {
        public const string Role = "Role";
        public const string Purpuse = "purpuse";
        public const string PurpuseReset = "reset-password";
    }
}