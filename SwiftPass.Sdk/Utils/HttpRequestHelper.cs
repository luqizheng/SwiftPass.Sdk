using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Collections;
using static System.String;

namespace SwiftPass.Sdk.Utils
{
    public class HttpRequestHelper
    {

        protected readonly ILogger Logger;
        private readonly string _url;
        private readonly string _key;
        private readonly string _mchId;
        private void LogPostData(string url, HttpContent content)
        {
            content.ReadAsStreamAsync().ContinueWith(task =>
            {
                using (var stream = new StreamReader(task.Result))
                {
                    var r = stream.ReadToEnd();
                    Logger.LogInformation("post 数据 ：url:{0} data:{1}", url, r);
                }
            });
        }
        public HttpRequestHelper(string url,string mchId ,string key,ILogger logger)
        {
            _url = url;
            _mchId = mchId;
            _key = key;
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public T Post<T>(RequestBase trans)
            where T : ResponseBase, new()
        {
            var postData = trans.ToDictionary();
            postData.Add("mch_id",_mchId);
            postData.Add("nonce_str",Guid.NewGuid().ToString("N"));
            postData.Add("sign", CreateSign(postData, _key));
            string postXml = SwiftpassUtils.toXml(postData);
            var client = new HttpClient { Timeout = new TimeSpan(0, 1, 0) };
            var contentStr = new StringContent(postXml);
            var result = new T();
            try
            {
                LogPostData(_url, contentStr);
                var content = client.PostAsync(_url, contentStr, CancellationToken.None);
                var resp = content.Result;
                var code = resp.StatusCode;
                var strResult = resp.Content.ReadAsStringAsync().Result;
                Logger.LogInformation("威富通返回数据:{0}", strResult);
                if (code == HttpStatusCode.NotFound)
                {
                    Logger.LogError("支付通道出现问题,status-code:{0},content:{1}", strResult, code);
                    result.Status = "9994";
                    result.Message = "支付通道无法访问";
                    return result;
                }

                if (String.IsNullOrEmpty(strResult))
                {
                    Logger.LogError("支付通道出现问题,status-code:{0},content:{1}", strResult, code);
                    result.Status = "9997";
                    result.Message = "交易结果未知（应当发起交易查询）";
                    return result;
                }
                var handler = new ClientResponseHandler();
                handler.SetContent(strResult);
                handler.SetKey(this._key);
                var param = handler.GetAllParameters();
                handler.IsTenpaySign();
                result.FillBy(param);
                return result;
            }
            catch (AggregateException ex)
            {
                foreach (var inner in ex.InnerExceptions)
                {
                    Logger.LogError(new EventId(9998), "对接威富通出现异常", inner);
                    var cancelExcepton = inner as TaskCanceledException;
                    if (cancelExcepton != null)
                    {
                    
                        result.Status = "9997";
                        result.Message = "交易结果未知（应当发起交易查询）";
                        break;
                    }
                    var request = inner as HttpRequestException;
                    if (request != null)
                    {
                        result.Status = "9994";
                        result.Message = "支付通道无法访问";
                        break;
                    }
                }
            }
            return result;
        }

        private string CreateSign(IDictionary<string, string> dictionary, string key)
        {
            var sb = new StringBuilder();
            var akeys = dictionary.Keys.ToList();
            akeys.Sort();
            foreach (string k in akeys)
            {
                var v = (string)dictionary[k];
                if (null != v && Compare("", v, StringComparison.Ordinal) != 0
                    && Compare("sign", k, StringComparison.Ordinal) != 0
                    && Compare("key", k, StringComparison.Ordinal) != 0)
                {
                    sb.Append(k + "=" + v + "&");
                }
            }
            sb.Append("key=" + key);
            var sign = Md5Util.GetMd5(sb.ToString(), dictionary["charset"].ToUpper());
            return sign;
        }



    }
}
