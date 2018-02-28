using System.Collections.Generic;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Unified
{
    public class RefundPaymentResult : ResponseBase
    {
       

        /// <summary>
        ///平台订单号平台交易号是必填：是 
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        ///商户订单号商户系统内部的订单号是必填：是 
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        ///商户退款单号商户退款单号是必填：是 
        /// </summary>
        public string OutRefundNo { get; set; }
        /// <summary>
        ///平台退款单号平台退款单号是必填：是 
        /// </summary>
        public string RefundId { get; set; }
        /// <summary>
        ///退款渠道ORIGINAL—原路退款，默认是必填：是 
        /// </summary>
        public string RefundChannel { get; set; }
        /// <summary>
        ///退款金额退款总金额,单位为分,可以做部分退款是必填：是 
        /// </summary>
        public string RefundFee { get; set; }
        /// <summary>
        ///现金券退款金额现金券退款金额 小于等于退款金额， 退款金额-现金券退款金额为现金是必填：否 
        /// </summary>
        public string CouponRefundFee { get; set; }

        public override void FillBy(IDictionary<string, string> data)
        {
            base.FillBy(data);
            this.TransactionId = data.GetValueFromDic("transaction_id");
            this.OutTradeNo = data.GetValueFromDic("out_trade_no");
            this.OutRefundNo = data.GetValueFromDic("out_refund_no");
            this.RefundId = data.GetValueFromDic("refund_id");
            this.RefundChannel = data.GetValueFromDic("refund_channel");
            this.RefundFee = data.GetValueFromDic("refund_fee");
            this.CouponRefundFee = data.GetValueFromDic("coupon_refund_fee");

        }
    }
}
