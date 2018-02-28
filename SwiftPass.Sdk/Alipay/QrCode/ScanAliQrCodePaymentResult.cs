using System;
using System.Collections.Generic;
using System.Text;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Alipay.QrCode
{
    public class ScanAliQrCodePaymentResult : ResponseBase
    {
        /// <summary>
        ///二维码链接此参数可直接生成二维码展示出来进行扫码支付是必填：是 
        /// </summary>
        public string CodeUrl { get; set; }
        /// <summary>
        ///二维码图片直接用此链接请求二维码图片是必填：是 
        /// </summary>
        public string CodeImgUrl { get; set; }

        public override void FillBy(IDictionary<string, string> data)
        {
            base.FillBy(data);
            this.CodeUrl = data.GetValueFromDic("code_url");
            this.CodeImgUrl = data.GetValueFromDic("code_img_url");

        }
    }
}
