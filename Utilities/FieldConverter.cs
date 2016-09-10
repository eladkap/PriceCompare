using System;
using System.Linq;
using System.Xml.Linq;

namespace Utilities
{
    public class FieldConverter
    {
        public static string DecodeItemField(XElement itemElement, string fieldName)
        {
            var fieldElement = (from node in itemElement.Descendants()
                                where node.Name.ToString().ToLower().Equals(fieldName)
                                select node).FirstOrDefault();
            return fieldElement?.Value;
        }

        public static int DecodeItemFieldInt(XElement itemElement, string fieldName)
        {
            var fieldValueString = DecodeItemField(itemElement, fieldName);
            if (fieldValueString == null)
            {
                return default(int);
            }
            int fieldValueInt = default(int);
            bool result = int.TryParse(fieldValueString, out fieldValueInt);
            return fieldValueInt;
        }

        public static bool DecodeItemFieldBool(XElement itemElement, string fieldName)
        {
            var fieldValueString = DecodeItemField(itemElement, fieldName);
            if (fieldValueString == null)
            {
                return default(bool);
            }
            bool fieldValueBool = default(bool);
            bool result = bool.TryParse(fieldValueString, out fieldValueBool);
            return fieldValueBool;
        }

        public static float DecodeItemFieldFloat(XElement itemElement, string fieldName)
        {
            var fieldValueString = DecodeItemField(itemElement, fieldName);
            if (fieldValueString == null)
            {
                return default(float);
            }
            float fieldValueFloat = default(float);
            bool result = float.TryParse(fieldValueString, out fieldValueFloat);
            return fieldValueFloat;
        }

        public static DateTime DecodeItemFieldDateTime(XElement itemElement, string fieldName)
        {
            var fieldValueString = DecodeItemField(itemElement, fieldName);
            if (fieldValueString == null)
            {
                return default(DateTime);
            }
            DateTime fieldValueDateTime= default(DateTime);
            bool result = DateTime.TryParse(fieldValueString, out fieldValueDateTime);
            return fieldValueDateTime;
        }
    }
}
