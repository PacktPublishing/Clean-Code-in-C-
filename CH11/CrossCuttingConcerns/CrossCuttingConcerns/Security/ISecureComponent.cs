namespace CrossCuttingConcerns.Security
{
    public interface ISecureComponent
    {
        void AddData(dynamic data);
        int EditData(dynamic data);
        int DeleteData(dynamic data);
        dynamic GetData(dynamic data);
    }
}
