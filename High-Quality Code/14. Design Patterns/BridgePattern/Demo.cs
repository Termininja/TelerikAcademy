/*
 * Bridge Pattern is sometimes used, useful to decouple an abstraction
 * from its implementation and to be able to modify them independently. 
 * 
 * The Bridge pattern has nearly the same structure as the Adapter Pattern.
 * But it is used when designing new systems instead of the Adapter pattern
 * which is used in already existing systems.
 * 
 * The abstract Repository class defines the interface that all inheriting
 * refined Repository classes will use for object management purposes.
 * 
 * The operations within the Repository classes define high-level operations.
 * 
 * The refined Repositories extend the basic functionalities and implement
 * the execution code that uses the implementation classes. They should
 * contain specializations which only apply to specific Repositories.
 * 
 * The abstract DataObject class defines the interfaces of the implementation
 * classes. The abstract Repository and the abstract DataObject classes can
 * have completely different interfaces.
 * 
 */

using System;

namespace BridgePattern
{
    class Demo
    {
        static void Main()
        {
            Bridge();
        }

        public static void Bridge()
        {
            var clientRepository = new ClientRepository();
            var productRepository = new ProductRepository();

            var clientDataObject = new ClientDataObject();
            clientRepository.AddObject(clientDataObject);
            clientRepository.SaveChanges();

            clientRepository.CopyObject(clientDataObject);

            clientRepository.RemoveObject(clientDataObject);
            clientRepository.SaveChanges();

            var productDataObject = new ProductDataObject();
            productRepository.AddObject(productDataObject);
            clientRepository.SaveChanges();

            productRepository.CopyObject(productDataObject);

            productRepository.RemoveObject(productDataObject);
            productRepository.SaveChanges();

            Console.ReadKey();
        }
    }
}