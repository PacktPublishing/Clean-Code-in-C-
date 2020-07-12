namespace CH07_DependencyInjection
{
    public class Client
    {
        private IService _service;

        public Client() { }

        public Client(IService service)
        {
            _service = service;
        }

        public IService Service
        {
            get { return _service; }
            set
            {
                _service = value;
            }
        }

        public string GetServiceName(IService service)
        {
            return service.WhoAreYou();
        }
    }
}
