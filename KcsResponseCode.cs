using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS_Retro
{
    public enum KcsResponseCode
    {
        Success = 0,
        NoLeadIn = 1,
        AudioAnomaly = 2,
        DecodingError = 3,
        StreamAborted = 4
    }

    public class KcsResponse
    {
        public KcsResponseCode Code { get; set; }
        public string Message { get; set; }
        public byte[] Data { get; set; }

        public bool IsSuccess => Code == KcsResponseCode.Success;

        public static KcsResponse Success(byte[] data) =>
            new() { Code = KcsResponseCode.Success, Message = "Success", Data = data };

        public static KcsResponse Error(KcsResponseCode code, string message) =>
            new() { Code = code, Message = message };
    }
}
