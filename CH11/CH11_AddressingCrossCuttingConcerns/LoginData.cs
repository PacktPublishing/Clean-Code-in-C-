using CH11_AddressingCrossCuttingConcerns.Attributes;

namespace CH11_AddressingCrossCuttingConcerns
{
    internal class LoginData
    {
        public string Login;
        [Reverse] public string Password;
    }
}
