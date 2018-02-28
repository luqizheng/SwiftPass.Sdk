using System;

namespace SwiftPass.Sdk.Utils
{
    public class SwiftPassResponseException : Exception
    {
        public SwiftPassResponseException(string code, string desc)
        {
            Code = code;
            Desc = desc;
        }

        public string Code { get; }
        public string Desc { get; }

        public override string Message => Desc + "(code=" + Code + ")";
    }
}