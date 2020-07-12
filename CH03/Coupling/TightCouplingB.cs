using System.Diagnostics;

namespace CH3.Coupling
{
    /// <summary>
    /// This class demonstrates tight coupling.
    /// </summary>
    public class TightCouplingB
    {
        /// <summary>
        /// This class demonstrates tight coupling.
        /// </summary>
        public TightCouplingB()
        {
            TightCouplingA tca = new TightCouplingA();

            // Since we are directly setting the "_name data member, we are coupling the two classes together.
            // This is an example of tight coupling.
            tca._name = null;

            // Since we are directly accessing the "_name data member, we are coupling the two classes together.
            // This is an example of tight coupling
            Debug.WriteLine("Name is " + tca._name);
        }
    }
}
