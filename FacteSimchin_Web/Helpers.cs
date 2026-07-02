using QRCoder;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using static QRCoder.PayloadGenerator;

namespace FacteSimchin_Web
{
    public static class Helpers
    {
        [SupportedOSPlatform("windows")]
        public static string GenerateQrCodeBase64ImgSrc(string url)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            using Bitmap qrCodeImage = qrCode.GetGraphic(20);
            using var ms = new MemoryStream();
            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return $"data:image/png;base64,{Convert.ToBase64String(ms.ToArray())}";
        }
    }
}
