using System.Collections.Generic;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Unified
{
    public class RefundPayment : RequestBase
    {
        public RefundPayment(string outTradeNo,string transactionId, string outRefundNo, int totalFee, int refundFee, string opUserId) : base(
            "unified.trade.refund")
        {
            if (string.IsNullOrEmpty(outTradeNo)&&string.IsNullOrEmpty(transactionId))
            {
                throw new SwiftPassException("500","商户订单号和平台订单号不能同时为空！");
            }
            this.OutTradeNo = outTradeNo;
            this.TransactionId = transactionId;
            this.OutRefundNo = outRefundNo;
            this.TotalFee = totalFee;
            this.RefundFee = refundFee;
            this.OpUserId = opUserId;
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
        ///商户退款单号商户退款单号，32个字符内、可包含字母,确保在商户系统唯一。同个退款单号多次请求，平台当一个单处理，只会退一次款。如果出现退款不成功，请采用原退款单号重新发起，避免出现重复退款。是必填：是 
        /// </summary>
        public string OutRefundNo { get; set; }
        /// <summary>
        ///总金额订单总金额，单位为分是必填：是 
        /// </summary>
        public int TotalFee { get; set; }
        /// <summary>
        ///退款金额退款总金额,单位为分,可以做部分退款是必填：是 
        /// </summary>
        public int RefundFee { get; set; }
        /// <summary>
        ///操作员操作员帐号,默认为商户号是必填：是 
        /// </summary>
        public string OpUserId { get; set; }
        /// <summary>
        ///退款渠道ORIGINAL-原路退款，默认是必填：否 
        /// </summary>
        public string RefundChannel { get; set; }

        protected override void FillTo(IDictionary<string, string> data)
        {
            base.FillTo(data);
            data.AddOrUpdateValueToDic("out_trade_no", this.OutTradeNo);
            data.AddOrUpdateValueToDic("transaction_id", this.TransactionId);
            data.AddOrUpdateValueToDic("out_refund_no", this.OutRefundNo);
            data.AddOrUpdateValueToDic("total_fee", this.TotalFee.ToString());
            data.AddOrUpdateValueToDic("refund_fee", this.RefundFee.ToString());
            data.AddOrUpdateValueToDic("op_user_id", this.OpUserId);
            data.AddOrUpdateValueToDic("refund_channel", this.RefundChannel);

        }
    }
}
