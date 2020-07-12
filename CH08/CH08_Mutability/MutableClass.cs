namespace CH08_Mutability
{
    internal class MutableClass
    {
        private readonly int[] _intArray;

        public MutableClass(int[] intArray)
        {
            _intArray = intArray;
        }

        public int[] GetIntArray()
        {
            return _intArray;
        }
    }
}
