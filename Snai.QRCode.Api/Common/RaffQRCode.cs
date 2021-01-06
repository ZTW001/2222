using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Snai.QRCode.Api.Common
{
    public class RaffQRCode : IQRCode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">存储大小</param>
        /// <param name="pixel">像素大小</param>
        /// <returns></returns>
        public Bitmap GetQRCode(string url, int pixel)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData codeData = generator.CreateQrCode(url,QRCodeGenerator.ECCLevel.M,true);
            QRCoder.QRCode qrcode = new QRCoder.QRCode(codeData);

            Bitmap qrImage = qrcode.GetGraphic(pixel,Color.Black,Color.White,true);

            return qrImage;
        }
    }
}
