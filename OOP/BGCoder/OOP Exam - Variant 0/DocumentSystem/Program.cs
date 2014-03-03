using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class DocumentSystem
    {
        static List<IDocument> files = new List<IDocument>();

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            AddSomeDocument(new TextDocument(), attributes);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddSomeDocument(new PDFDocument(), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddSomeDocument(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddSomeDocument(new ExcelDocument(), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddSomeDocument(new AudioDocument(), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddSomeDocument(new VideoDocument(), attributes);
        }

        private static void AddSomeDocument(IDocument file, string[] attributes)
        {
            foreach (var properties in attributes)
            {
                string[] property = properties.Split('=');
                file.LoadProperty(property[0], property[1]);
            }
            if (file.Name != null)
            {
                files.Add(file);
                Console.WriteLine("Document added: " + file.Name);
            }
            else Console.WriteLine("Document has no name");
        }

        private static void ListDocuments()
        {
            if (files.Count == 0) Console.WriteLine("No documents found");
            else foreach (IDocument file in files) Console.WriteLine(file);
        }

        private static void EncryptDocument(string name)
        {
            bool found = false;
            foreach (var file in files)
            {
                if (file.Name == name)
                {
                    found = true;
                    if (file is IEncryptable)
                    {
                        (file as IEncryptable).Encrypt();
                        Console.WriteLine("Document encrypted: " + file.Name);
                    }
                    else Console.WriteLine("Document does not support encryption: " + file.Name);
                }
            }
            if (!found) Console.WriteLine("Document not found: " + name);
        }

        private static void DecryptDocument(string name)
        {
            bool found = false;
            foreach (var file in files)
            {
                if (file.Name == name)
                {
                    found = true;
                    if (file is IEncryptable)
                    {
                        (file as IEncryptable).Decrypt();
                        Console.WriteLine("Document decrypted: " + file.Name);
                    }
                    else Console.WriteLine("Document does not support decryption: " + file.Name);
                }
            }
            if (!found) Console.WriteLine("Document not found: " + name);
        }

        private static void EncryptAllDocuments()
        {
            bool found = false;
            foreach (var file in files)
            {
                if (file is IEncryptable)
                {
                    found = true;
                    (file as IEncryptable).Encrypt();
                }
            }
            Console.WriteLine((found) ? "All documents encrypted" : "No encryptable documents found");
        }

        private static void ChangeContent(string name, string content)
        {
            bool found = false;
            foreach (var file in files)
            {
                if (file.Name == name)
                {
                    found = true;
                    if (file is IEditable)
                    {
                        (file as IEditable).ChangeContent(content);
                        Console.WriteLine("Document content changed: " + file.Name);
                    }
                    else Console.WriteLine("Document is not editable: " + file.Name);
                }
            }
            if (!found) Console.WriteLine("Document not found: " + name);
        }
    }
}