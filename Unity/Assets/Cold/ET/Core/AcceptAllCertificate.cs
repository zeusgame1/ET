using UnityEngine.Networking;

namespace ETCold 
{
    public class AcceptAllCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
}
