using System;

namespace AccountingNotebook.Data
{
    public class DataEntityAttribute : Attribute
    {
        public DataEntityAttribute(Type dataEntityType)
        {
            DataEntityType = dataEntityType;
        }

        public Type DataEntityType { get; set; }
    }
}
