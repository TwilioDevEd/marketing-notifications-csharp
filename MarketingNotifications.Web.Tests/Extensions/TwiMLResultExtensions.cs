using System.Reflection;
using System.Web.Mvc;

namespace MarketingNotifications.Web.Tests.Extensions
{
    public static class TwiMLResultExtensions
    {
        public static object Data(this ContentResult xmlResult)
        {
            return GetInstanceField(typeof(ContentResult), xmlResult, "data");
        }

        private static object GetInstanceField(IReflect type, object instance, string fieldName)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            var field = type.GetField(fieldName, bindFlags);
            return field.GetValue(instance);
        }
    }
}
