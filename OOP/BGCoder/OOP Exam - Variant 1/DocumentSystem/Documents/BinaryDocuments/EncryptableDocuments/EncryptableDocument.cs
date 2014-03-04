namespace DocumentSystem
{
    public class EncryptableDocument : BinaryDocument, IEncryptable
    {
        // Property
        public bool IsEncrypted { get; protected set; }

        // Methods
        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }
    }
}
