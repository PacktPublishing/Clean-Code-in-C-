using System.Diagnostics;

namespace CH3.Coupling
{
    /// <summary>
    /// This class demonstrates tight coupling.
    /// </summary>
    public class TightCouplingA
    {
        /// <summary>
        /// The instance variable _name is declared public.
        /// </summary>
        /// <remarks>
        /// You should never do this. Instance variables should
        /// always be private, and modified via the constructor,
        /// properties or methods.
        /// </remarks>
        public string _name;

        /// <summary>
        /// Gets and sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                if (!_name.Equals(string.Empty))
                    return _name;
                else
                    return "String is empty!";
            }
            set
            {
                if (value.Equals(string.Empty))
                    Debug.WriteLine("String is empty!");
            }
        }
    }
}
