using System;

namespace serialization
{
    public class Serializer
    {
        public string Serialize(object source)
        {
            string serializedString = "";

            Type serializingType = source.GetType();
            serializedString += serializingType.Name;

            var properties = serializingType.GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetGetMethod().Invoke(source, null);

                serializedString += Environment.NewLine;
                serializedString += "\t";
                serializedString += propertyName;
                serializedString += ":";
                serializedString += " ";
                serializedString += propertyValue.ToString();
            }

            return serializedString;
        }
    }
}