namespace CH07_DependencyInjection
{
    public class ServiceOne : IService
    {
        public string WhoAreYou()
        {
            return "CH07_DependencyInjection.ServiceOne()";
        }
    }
}
