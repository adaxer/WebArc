using System;

namespace Southwind.Models
{
    class TableAttribute : Attribute
    {
        private string v;
        public string Schema { get; set; }

        public TableAttribute(string v)
        {
            this.v = v;
        }
    }
}

namespace Southwind.Models
{
    class ColumnAttribute : Attribute
    {
        private string v;
        public int Order;
        public string TypeName;

        public ColumnAttribute(string v)
        {
            this.v = v;
        }
    }
}

namespace Southwind.Models
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple =true)]
    public class IndexAttribute : Attribute
    {
        private string v1;
        public bool IsUnique;
        public bool IsClustered;

        public IndexAttribute(string v1, int v2)
        {
            this.v1 = v1;
        }
    }
}

namespace Southwind.Models
{
    class MaxLengthAttribute : Attribute
    {
        public MaxLengthAttribute(int v=0)
        {
        }
    }
}

namespace Southwind.Models
{
    class ForeignKeyAttribute : Attribute
    {
        private string v;

        public ForeignKeyAttribute(string v)
        {
            this.v = v;
        }
    }
}