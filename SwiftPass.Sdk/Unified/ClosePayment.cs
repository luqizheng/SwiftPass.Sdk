using System;
using System.Collections.Generic;
using System.Text;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Unified
{
    public class ClosePayment : RequestBase
    {
        public ClosePayment(string outTradeNo) : base("unified.trade.close")
        {
            this.OutTradeNo = outTradeNo;
        }

        /// <summary>
        ///商户订单号商户系统内部的订单号 ,32个字符内、 可包含字母,确保在商户系统唯一是必填：是 
        /// </summary>
        public string OutTradeNo { get; set; }

        protected override void FillTo(IDictionary<string, string> data)
        {
            base.FillTo(data);
            data.AddOrUpdateValueToDic("out_trade_no", this.OutTradeNo);

        }
    }
}
