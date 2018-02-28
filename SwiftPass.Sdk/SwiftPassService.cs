
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SwiftPass.Sdk.Alipay.QrCode;
using SwiftPass.Sdk.Callback;
using SwiftPass.Sdk.Unified;
using SwiftPass.Sdk.Utils;
using SwiftPass.Sdk.Wechat;
using SwiftPass.Sdk.Wechat.H5Payment;
using SwiftPass.Sdk.Wechat.QrCode;

namespace SwiftPass.Sdk
{
    public class SwiftPassService
    {
        private readonly string _key;
        private readonly HttpRequestHelper _httpHelper;
        private readonly ILogger _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">接口请求地址，固定不变，无需修改https://pay.swiftpass.cn/pay/gateway </param>
        /// <param name="key">key=9d101c97133837e13dde2d32a5054abb 测试密钥，商户需改为自己的</param>
        /// <param name="mchId"> mch_id=7551000001 测试商户号，商户需改为自己的 </param>
        /// <param name="logger">日志</param>
        /// verison version=1.0 #版本号，固定不变，无需修改
        /// notify_url 测试通知回调地址，商户需改为自己的，且保证外网能访问到
        public SwiftPassService(string url, string mchId, string key, ILogger<SwiftPassService> logger)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            if (mchId == null) throw new ArgumentNullException(nameof(mchId));
            _key = key ?? throw new ArgumentNullException(nameof(key));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpHelper = new HttpRequestHelper(url, mchId, key, logger);
        }

        /// <summary>
        /// 产生二维码（微信）。供用户扫码支付
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public ScanQrCodePaymentResult GetPayCode(ScanQrCodePayment payment)
        {
            var result = _httpHelper.Post<ScanQrCodePaymentResult>(payment);
            return result;
        }
        /// <summary>
        /// 产生二维码（支付宝）。供用户扫码支付
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public ScanAliQrCodePaymentResult GetAliPayCode(ScanAliQrCodePayment payment)
        {
            var result = _httpHelper.Post<ScanAliQrCodePaymentResult>(payment);
            return result;
        }

        /// <summary>
        /// 扫用户手机条形码创建支付帐单。（微信，支付宝）
        /// </summary>
        /// <param name="payment">条码信息</param>
        /// <returns></returns>
        public ScanBarcodePaymentResult ScanBarCode(ScanBarcodePayment payment)
        {
            var result = _httpHelper.Post<ScanBarcodePaymentResult>(payment);
            return result;
        }

        /// <summary>
        /// 获取支付信息，供js调用。 微信及小程序发起h5 微信请求支付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PaymentInfoForWeixinResult PrepareForWeixinH5Payment(PaymentInfoForWeixinRequest request)
        {
            var result = _httpHelper.Post<PaymentInfoForWeixinResult>(request);
            return result;
        }

        /// <summary>
        /// 回调结果解释
        /// </summary>
        /// <param name="callbackContent">回调字符串</param>
        /// <returns></returns>
        public CallbackData Callback(string callbackContent)
        {
            _logger.LogInformation("callback收到的信息:" + callbackContent);
            var handler = new ClientResponseHandler();
            handler.SetContent(callbackContent);
            handler.SetKey(_key);
            var param = handler.GetAllParameters();
            handler.IsTenpaySign();
            var data = new CallbackData();
            data.FillBy(param);
            _logger.LogDebug("callback-back TransactionId:" + data.TransactionId);
            return data;
        }

        /// <summary>
        /// 获取支付信息，供js调用。  其它浏览器h5启动发起的微信请求支付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PaymentInfoForWapResult PrepareForH5Payement(PaymentInfoForWapRequest request)
        {
            var result = _httpHelper.Post<PaymentInfoForWapResult>(request);
            return result;
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="payment">订单信息</param>
        /// <returns></returns>
        public QueryPaymentResult Query(QueryPayment payment)
        {
            var result = _httpHelper.Post<QueryPaymentResult>(payment);
            return result;
        }

        /// <summary>
        /// 取消支付
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public ReversePaymentResult Reverse(ReverseTransaction payment)
        {
            var result = _httpHelper.Post<ReversePaymentResult>(payment);
            return result;
        }

        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public RefundPaymentResult Refund(RefundPayment payment)
        {
            var result = _httpHelper.Post<RefundPaymentResult>(payment);
            return result;
        }

        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public RefundQueryResult QueryRefund(RefundQueryInfo info)
        {
            var result = _httpHelper.Post<RefundQueryResult>(info);
            return result;

        }







    }
}
