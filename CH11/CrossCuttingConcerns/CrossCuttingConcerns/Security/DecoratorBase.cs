namespace CrossCuttingConcerns.Security
{
    public abstract class DecoratorBase : ISecureComponent
    {
        private readonly ISecureComponent _secureComponent;

        public DecoratorBase(ISecureComponent secureComponent)
        {
            _secureComponent = secureComponent;
        }

        public virtual void AddData(dynamic data)
        {
            _secureComponent.AddData(data);
        }

        public virtual int EditData(dynamic data)
        {
            return _secureComponent.EditData(data);
        }

        public virtual int DeleteData(dynamic data)
        {
            return _secureComponent.DeleteData(data);
        }

        public virtual dynamic GetData(dynamic data)
        {
            return _secureComponent.GetData(data);
        }
    }
}
