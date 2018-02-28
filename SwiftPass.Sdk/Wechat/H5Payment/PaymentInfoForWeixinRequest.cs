using System;
using System.Collections.Generic;
using System.Text;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Wechat.H5Payment
{
    public class PaymentInfoForWeixinRequest:RequestBase
    {

        public PaymentInfoForWeixinRequest(bool isRawjs,string outTradeNo,string body,string subOpenid,int totalFee,string mchCreateIp,string notifyUrl) : base("pay.weixin.jspay")
        {
            if (string.IsNullOrEmpty(outTradeNo))
                throw new ArgumentException("Value cannot be null or empty.", nameof(outTradeNo));
            if (string.IsNullOrEmpty(body))
                throw new ArgumentException("Value cannot be null or empty.", nameof(body));
            if (string.IsNullOrEmpty(subOpenid))
                throw new ArgumentException("Value cannot be null or empty.", nameof(subOpenid));
            if (string.IsNullOrEmpty(mchCreateIp))
                throw new ArgumentException("Value cannot be null or empty.", nameof(mchCreateIp));
            if (string.IsNullOrEmpty(notifyUrl))
                throw new ArgumentException("Value cannot be null or empty.", nameof(notifyUrl));
            this.IsRaw = isRawjs?"1":"0";
            this.OutTradeNo = outTradeNo;
            this.Body = body;
            this.SubOpenid = subOpenid;
            this.TotalFee = totalFee;
            this.MchCreateIp = mchCreateIp;
            this.NotifyUrl = notifyUrl;
        }

        /// <summary>
        ///原生JS值为1是必填：是 
        /// </summary>
        public string IsRaw { get; set; }
        /// <summary>
        ///是否小程序支付值为1，表示小程序支付；不传或值不为1，表示公众账号内支付是必填：否 
        /// </summary>
        public string IsMinipg { get; set; }
        /// <summary>
        ///商户订单号商户系统内部的订单号 ,32个字符内、 可包含字母,确保在商户系统唯一是必填：是 
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        ///设备号终端设备号是必填：否 
        /// </summary>
        public string DeviceInfo { get; set; }
        /// <summary>
        ///商品描述商品描述是必填：是 
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        ///用户openid微信用户关注商家公众号的openid（注：使用测试号时此参数置空，即不要传这个参数，使用正式商户号时才传入，参数名是sub_openid，具体请看文档最后注意事项第7点）是必填：是 
        /// </summary>
        public string SubOpenid { get; set; }
        /// <summary>
        ///公众账号或小程序ID当发起公众号支付时，值是微信公众平台基本配置中的AppID(应用ID)；当发起小程序支付时，值是对应小程序的AppID是必填：是 
        /// </summary>
        public string SubAppid { get; set; }
        /// <summary>
        ///附加信息商户附加信息，可做扩展参数是必填：否 
        /// </summary>
        public string Attach { get; set; }
        /// <summary>
        ///总金额总金额，以分为单位，不允许包含任何字、符号是必填：是 
        /// </summary>
        public int TotalFee { get; set; }
        /// <summary>
        ///终端IP订单生成的机器 IP是必填：是 
        /// </summary>
        public string MchCreateIp { get; set; }
        /// <summary>
        ///通知地址接收平台通知的URL，需给绝对路径，255字符内格式如:http://wap.tenpay.com/tenpay.asp，确保平台能通过互联网访问该地址是必填：是 
        /// </summary>
        public string NotifyUrl { get; set; }
        /// <summary>
        ///订单生成时间订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。时区为GMT+8 beijing。该时间取自商户服务器。注：订单生成时间与超时时间需要同时传入才会生效。是必填：否 
        /// </summary>
        public DateTime? TimeStart { get; set; }
        /// <summary>
        ///订单超时时间订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。时区为GMT+8 beijing。该时间取自商户服务器。注：订单生成时间与超时时间需要同时传入才会生效。是必填：否 
        /// </summary>
        public DateTime? TimeExpire { get; set; }
        /// <summary>
        ///商品标记商品标记，微信平台配置的商品标记，用于优惠券或者满减使用是必填：否 
        /// </summary>
        public string GoodsTag { get; set; }
        /// <summary>
        ///是否限制信用卡限定用户使用时能否使用信用卡，值为1，禁用信用卡；值为0或者不传此参数则不禁用是必填：否 
        /// </summary>
        public string LimitCreditPay { get; set; }


        protected override void FillTo(IDictionary<string, string> data)
        {
            base.FillTo(data);
            data.AddOrUpdateValueToDic("is_raw", this.IsRaw);
            data.AddOrUpdateValueToDic("is_minipg", this.IsMinipg);
            data.AddOrUpdateValueToDic("out_trade_no", this.OutTradeNo);
            data.AddOrUpdateValueToDic("device_info", this.DeviceInfo);
            data.AddOrUpdateValueToDic("body", this.Body);
            data.AddOrUpdateValueToDic("sub_openid", this.SubOpenid);
            data.AddOrUpdateValueToDic("sub_appid", this.SubAppid);
            data.AddOrUpdateValueToDic("attach", this.Attach);
            data.AddOrUpdateValueToDic("total_fee", this.TotalFee.ToString());
            data.AddOrUpdateValueToDic("mch_create_ip", this.MchCreateIp);
            data.AddOrUpdateValueToDic("notify_url", this.NotifyUrl);
            data.AddOrUpdateValueToDic("time_start", this.TimeStart);
            data.AddOrUpdateValueToDic("time_expire", this.TimeExpire);
            data.AddOrUpdateValueToDic("goods_tag", this.GoodsTag);
            data.AddOrUpdateValueToDic("limit_credit_pay", this.LimitCreditPay);

        }
    }
}
