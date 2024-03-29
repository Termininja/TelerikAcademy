﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class ClientDataObject : DataObject
    {
        public override void Register()
        {
            Console.WriteLine("ClientDataObject was registered");
        }

        public override DataObject Copy()
        {
            Console.WriteLine("ClientDataObject was copied");
            return new ClientDataObject();
        }

        public override void Delete()
        {
            Console.WriteLine("ClientDataObject was deleted");
        }
    }
}
