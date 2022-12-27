namespace G_UNAMAD_CEPRE_API.Helpers
{
    public class ConvertVersion
    {
        public string StringVersion(byte[] cVersion)
        {
            return string.Concat("0x", BitConverter.ToString(cVersion).Replace("-", ""));
        }
        public byte[] ByteVersion(string cVersion)
        {
            return Convert.FromHexString(cVersion.Replace("0x", ""));
        }
    }
}
