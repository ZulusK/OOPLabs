using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Lab4.UI.Entities
{
    [Serializable]
    [DataContract]
    class ObjectID
    {
        [DataMember]
        uint currentID;

        public uint nextID
        {
            get => currentID++;
        }

        public ObjectID()
        {
            this.currentID = 0;
        }
    }
}
