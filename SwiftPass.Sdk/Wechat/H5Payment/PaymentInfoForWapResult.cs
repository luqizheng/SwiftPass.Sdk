using System;
using System.Collections.Generic;
using System.Text;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Wechat.H5Payment
{
    public class PaymentInfoForWapResult : ResponseBase
    {
        /// <summary>
        ///支付地址唤起手机微信支付url地址是必填：是 
        /// </summary>
        public string PayInfo { get; set; }

        public override void FillBy(IDictionary<string, string> data)
        {
            base.FillBy(data);
            this.PayInfo = data.GetValueFromDic("pay_info");

        }
    }
}
