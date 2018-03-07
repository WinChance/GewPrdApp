using System;

namespace GMS.Web.Admin.Infrastructure
{
    public class PropertyItem
    {
        public PropertyItem(string name, Type type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { set; get; }
        public Type Type { set; get; }
    }
}