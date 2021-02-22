namespace HMF.Thesis.Interfaces
{
    /// Interface for the objects that can Jump
    public interface IJump
    {
        /// Jump Force of the object.
        int JumpForce {get; set;}

        /// Implementation of a jump.
        void Jump();
    }
}
