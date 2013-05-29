namespace ResourceManagementSystem.BusinessLogic
{
    public static class Constants
    {
        public readonly static string EmailCheckRegex = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        public readonly static string NameCheckRegex = @"\p{Lu}\p{Ll}+((\s|-)\p{Lu}\p{Ll}+)*";
    }
}
