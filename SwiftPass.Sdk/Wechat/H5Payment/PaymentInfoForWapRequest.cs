using System;
using System.Collections.Generic;
using System.Text;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Wechat.H5Payment
{
    public class PaymentInfoForWapRequest : RequestBase
    {
        public PaymentInfoForWapRequest(string outTradeNo,string body,int totalfee,string mchCreateIp,string notifyUrl,string deviceInfo,string mchAppId,string mchAppName) : base("pay.weixin.wappay")
        {
            if (string.IsNullOrEmpty(outTradeNo))
                throw new ArgumentException("Value cannot be null or empty.", nameof(outTradeNo));
            if (string.IsNullOrEmpty(body))
                throw new ArgumentException("Value cannot be null or empty.", nameof(body));
            if (string.IsNullOrEmpty(mchCreateIp))
                throw new ArgumentException("Value cannot be null or empty.", nameof(mchCreateIp));
            if (string.IsNullOrEmpty(notifyUrl))
                throw new ArgumentException("Value cannot be null or empty.", nameof(notifyUrl));
            if (string.IsNullOrEmpty(deviceInfo))
                throw new ArgumentException("Value cannot be null or empty.", nameof(deviceInfo));
            if (string.IsNullOrEmpty(mchAppId))
                throw new ArgumentException("Value cannot be null or empty.", nameof(mchAppId));
            if (string.IsNullOrEmpty(mchAppName))
                throw new ArgumentException("Value cannot be null or empty.", nameof(mchAppName));
            this.OutTradeNo = outTradeNo;
            this.Body = body;
            this.TotalFee = totalfee;
            this.MchCreateIp = mchCreateIp;
            this.NotifyUrl = notifyUrl;
            this.DeviceInfo = deviceInfo;
            this.MchAppId = mchAppId;
            this.MchAppName = mchAppName;

        }

        /// <summary>
        ///大商户编号大商户模式下专用（用到时签名必须使用大商户密钥），正常模式下忽略不传此字段是必填：否 
        /// </summary>
        public string GroupNo { get; set; }
        /// <summary>
        ///商户订单号商户系统内部的订单号 ,32个字符内、 可包含字母,确保在商户系统唯一是必填：是 
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        ///商品描述商品描述是必填：是 
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        ///附加信息商户附加信息，可做扩展参数，255字符内是必填：否 
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
        ///通知地址接收通知的URL，需给绝对路径，255字符内格式，确保平台能通过互联网访问该地址是必填：是 
        /// </summary>
        public string NotifyUrl { get; set; }
        /// <summary>
        ///前台地址前端页面跳转的URL（包括支付成功和关闭时都会跳到这个地址,商户需自行处理逻辑），需给绝对路径，255字符内格式如:http://wap.tenpay.com/callback.asp注:该地址只作为前端页面的一个跳转，须使用notify_url通知结果作为支付最终结果。是必填：否 
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        ///订单生成时间订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。时区为GMT+8 beijing。该时间取自商户服务器。注：订单生成时间与超时时间需要同时传入才会生效。是必填：否 
        /// </summary>
        public DateTime? TimeStart { get; set; }
        /// <summary>
        ///订单超时时间订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。时区为GMT+8 beijing。该时间取自商户服务器。注：订单生成时间与超时时间需要同时传入才会生效。是必填：否 
        /// </summary>
        public DateTime? TimeExpire { get; set; }
        /// <summary>
        ///商品标记商品标记是必填：否 
        /// </summary>
        public string GoodsTag { get; set; }
        /// <summary>
        ///应用类型如果是用于苹果app应用里值为iOS_SDK；如果是用于安卓app应用里值为AND_SDK；如果是用于手机网站，值为iOS_WAP或AND_WAP均可是必填：是 
        /// </summary>
        public string DeviceInfo { get; set; }
        /// <summary>
        ///应用名如果是用于苹果或安卓app应用中，传分别对应在AppStore和安桌分发市场中的应用名（如：王者荣耀）如果是用于手机网站，传对应的网站名(如：京东官网)是必填：是 
        /// </summary>
        public string MchAppName { get; set; }
        /// <summary>
        ///应用标识如果是用于苹果或安卓app应用中，苹果传IOS 应用唯一标识(如：com.tencent.wzryIOS)安卓传包名(如：com.tencent.tmgp.sgame)如果是用于手机网站，传网站首页URL地址,必须保证公网能正常访问(如：https://m.jd.com)是必填：是 
        /// </summary>
        public string MchAppId { get; set; }

        protected override void FillTo(IDictionary<string, string> data)
        {
            base.FillTo(data);
            data.AddOrUpdateValueToDic("groupno", this.GroupNo);
            data.AddOrUpdateValueToDic("out_trade_no", this.OutTradeNo);
            data.AddOrUpdateValueToDic("body", this.Body);
            data.AddOrUpdateValueToDic("attach", this.Attach);
            data.AddOrUpdateValueToDic("total_fee", this.TotalFee.ToString());
            data.AddOrUpdateValueToDic("mch_create_ip", this.MchCreateIp);
            data.AddOrUpdateValueToDic("notify_url", this.NotifyUrl);
            data.AddOrUpdateValueToDic("callback_url", this.CallbackUrl);
            data.AddOrUpdateValueToDic("time_start", this.TimeStart);
            data.AddOrUpdateValueToDic("time_expire", this.TimeExpire);
            data.AddOrUpdateValueToDic("goods_tag", this.GoodsTag);
            data.AddOrUpdateValueToDic("device_info", this.DeviceInfo);
            data.AddOrUpdateValueToDic("mch_app_name", this.MchAppName);
            data.AddOrUpdateValueToDic("mch_app_id", this.MchAppId);

        }
    }
}
