using System.Collections.Generic;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Wechat.QrCode
{
    public class ScanQrCodePaymentResult:ResponseBase
    {
        /// <summary>
        /// 商户可用此参数自定义去生成二维码后展示出来进行扫码支付
        /// </summary>
        public string CodeUrl { get; set; }
        /// <summary>
        /// 此参数的值即是根据code_url生成的可以扫码支付的二维码图片地址
        /// </summary>
        public string CodeImgUrl { get; set; }

        public override void FillBy(IDictionary<string, string> data)
        {
            base.FillBy(data);
            this.CodeImgUrl = data.GetValueFromDic("code_img_url");
            this.CodeUrl = data.GetValueFromDic("code_url"); 
        }


    }
}
