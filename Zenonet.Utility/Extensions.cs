namespace Zenonet.Utility;

public static class Extensions
{
    /// <summary>
    /// Finds all classes in the current process which derive from a type
    /// </summary>
    /// <param name="t">The type, all outputted types should derive from</param>
    /// <returns>An array of all Types deriving from</returns>
    public static Type[] GetAllInheritors(this Type t)
    {
        //Thanks to 'Yahoo Serious' for his answer here: https://stackoverflow.com/questions/857705/get-all-derived-types-of-a-type
        return (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                from assemblyType in domainAssembly.GetTypes()
                where t.IsAssignableFrom(assemblyType) && t != assemblyType
                select assemblyType
            ).ToArray();
    }
}