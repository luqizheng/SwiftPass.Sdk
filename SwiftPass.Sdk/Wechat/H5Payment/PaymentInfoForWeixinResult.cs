using System;
using System.Collections.Generic;
using System.Text;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Wechat.H5Payment
{
    public class PaymentInfoForWeixinResult : ResponseBase
    {
        /// <summary>
        ///动态口令授权口令是必填：是 
        /// </summary>
        public string TokenId { get; set; }
        /// <summary>
        ///原生态js支付信息或小程序支付信息原生态js支付：is_raw为1时返回，json格式的字符串，作用于原生态js支付时的参数是必填：是 
        /// </summary>
        public string PayInfo { get; set; }

        public override void FillBy(IDictionary<string, string> data)
        {
            base.FillBy(data);
            this.TokenId = data.GetValueFromDic("token_id");
            this.PayInfo = data.GetValueFromDic("pay_info");
        }
    }
}
