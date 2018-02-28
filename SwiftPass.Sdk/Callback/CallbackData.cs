using System;
using System.Collections.Generic;
using System.Text;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Callback
{
    public class CallbackData : ResponseBase
    {
        /// <summary>
        ///用户标识用户在商户 appid 下的唯一标识是必填：是 
        /// </summary>
        public string Openid { get; set; }
        /// <summary>
        ///交易类型pay.weixin.wappay是必填：是 
        /// </summary>
        public string TradeType { get; set; }
        /// <summary>
        ///是否关注公众账号用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效是必填：是 
        /// </summary>
        public string IsSubscribe { get; set; }
        /// <summary>
        ///支付结果支付结果：0—成功；其它—失败是必填：是 
        /// </summary>
        public string PayResult { get; set; }
        /// <summary>
        ///支付结果信息支付结果信息，支付成功时为空是必填：否 
        /// </summary>
        public string PayInfo { get; set; }
        /// <summary>
        ///平台订单号平台订单号是必填：是 
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        ///第三方订单号第三方订单号是必填：是 
        /// </summary>
        public string OutTransactionId { get; set; }
        /// <summary>
        ///子商户是否关注用户是否关注子公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效是必填：否 
        /// </summary>
        public string SubIsSubscribe { get; set; }
        /// <summary>
        ///子商户appid子商户appid是必填：否 
        /// </summary>
        public string SubAppid { get; set; }
        /// <summary>
        ///用户openid用户在商户 sub_appid 下的唯一标识是必填：否 
        /// </summary>
        public string SubOpenid { get; set; }
        /// <summary>
        ///商户订单号商户系统内部的定单号，32个字符内、可包含字母是必填：是 
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        ///总金额总金额，以分为单位，不允许包含任何字、符号是必填：是 
        /// </summary>
        public int TotalFee { get; set; }
        /// <summary>
        ///现金券金额现金券支付金额小于等于订单总金额， 订单总金额-现金券金额为现金支付金额是必填：否 
        /// </summary>
        public int CouponFee { get; set; }
        /// <summary>
        ///货币种类货币类型，符合 ISO 4217 标准的三位字母代码，默认人民币：CNY是必填：否 
        /// </summary>
        public string FeeType { get; set; }
        /// <summary>
        ///附加信息商家数据包，原样返回是必填：否 
        /// </summary>
        public string Attach { get; set; }
        /// <summary>
        ///付款银行银行类型是必填：是 
        /// </summary>
        public string BankType { get; set; }
        /// <summary>
        ///银行订单号银行订单号，若为微信支付则为空是必填：否 
        /// </summary>
        public string BankBillno { get; set; }
        /// <summary>
        ///支付完成时间支付完成时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。时区为GMT+8 beijing。该时间取自平台服务器是必填：是 
        /// </summary>
        public DateTime? TimeEnd { get; set; }

        public override void FillBy(IDictionary<string, string> data)
        {
            base.FillBy(data);
            this.Openid = data.GetValueFromDic("openid");
            this.TradeType = data.GetValueFromDic("trade_type");
            this.IsSubscribe = data.GetValueFromDic("is_subscribe");
            this.PayResult = data.GetValueFromDic("pay_result");
            this.PayInfo = data.GetValueFromDic("pay_info");
            this.TransactionId = data.GetValueFromDic("transaction_id");
            this.OutTransactionId = data.GetValueFromDic("out_transaction_id");
            this.SubIsSubscribe = data.GetValueFromDic("sub_is_subscribe");
            this.SubAppid = data.GetValueFromDic("sub_appid");
            this.SubOpenid = data.GetValueFromDic("sub_openid");
            this.OutTradeNo = data.GetValueFromDic("out_trade_no");
            this.TotalFee = data.GetIntValueFromDic("total_fee");
            this.CouponFee = data.GetIntValueFromDic("coupon_fee");
            this.FeeType = data.GetValueFromDic("fee_type");
            this.Attach = data.GetValueFromDic("attach");
            this.BankType = data.GetValueFromDic("bank_type");
            this.BankBillno = data.GetValueFromDic("bank_billno");
            this.TimeEnd = data.GetDateTimeValueFromDic("time_end");

        }
    }
}
