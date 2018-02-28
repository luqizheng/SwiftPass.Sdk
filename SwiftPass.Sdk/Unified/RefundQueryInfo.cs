using System.Collections.Generic;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Unified
{
    public class RefundQueryInfo : RequestBase
    {
        public RefundQueryInfo(string outTradeNo, string transactionId, string outRefundNo, string refundId) : base("unified.trade.refundquery")
        {
            var isconditionfull = string.IsNullOrEmpty(outTradeNo) &&
                                  string.IsNullOrEmpty(transactionId) &&
                                  string.IsNullOrEmpty(outRefundNo) &&
                                  string.IsNullOrEmpty(refundId);


            if (isconditionfull)
            {
                throw new SwiftPassException("00002", "4个参数不能都为空！");
            }
            this.OutTradeNo = outTradeNo;
            this.TransactionId = transactionId;
            this.OutRefundNo = outRefundNo;
            this.RefundId = refundId;
        }

        /// <summary>
        ///商户订单号商户系统内部的订单号, out_trade_no和transaction_id至少一个必填，同时存在时transaction_id优先是必填：否 
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        ///平台订单号平台单号, out_trade_no和transaction_id至少一个必填，同时存在时transaction_id优先是必填：否 
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        ///商户退款单号商户退款单号，32个字符内、可包含字母,确保在商户系统唯一。是必填：否 
        /// </summary>
        public string OutRefundNo { get; set; }
        /// <summary>
        ///平台退款单号平台退款单号关于refund_id、out_refund_no、out_trade_no 、transaction_id 四个参数必填一个， 如果同时存在优先级为：refund_id>out_refund_no>transaction_id>out_trade_no特殊说明：如果是支付宝，refund_id、out_refund_no必填其中一个是必填：否 
        /// </summary>
        public string RefundId { get; set; }

        protected override void FillTo(IDictionary<string, string> data)
        {
            base.FillTo(data);
            data.AddOrUpdateValueToDic("out_trade_no", this.OutTradeNo);
            data.AddOrUpdateValueToDic("transaction_id", this.TransactionId);
            data.AddOrUpdateValueToDic("out_refund_no", this.OutRefundNo);
            data.AddOrUpdateValueToDic("refund_id", this.RefundId);

        }
    }
}
