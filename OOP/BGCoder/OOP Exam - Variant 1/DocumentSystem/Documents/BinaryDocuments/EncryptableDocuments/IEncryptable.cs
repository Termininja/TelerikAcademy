namespace DocumentSystem
{
    public interface IEncryptable
    {
        // Property
        bool IsEncrypted { get; }

        // Methods
        void Encrypt();
        void Decrypt();
    }
}
