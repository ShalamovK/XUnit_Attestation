namespace Common.Responses {
    public class BaseResponse {
        public BaseResponse() { }
        public BaseResponse(bool isOk) {
            this.IsOk = isOk;
        }
        public BaseResponse(bool isOk, string msg) {
            this.IsOk = isOk;
            this.Message = msg;
        }

        public bool IsOk { get; set; }
        public string Message { get; set; }
    }

    public class BaseResponse<T> : BaseResponse {
        public BaseResponse(bool isOk, T obj)
            : base(isOk) {
            this.Payload = obj;
        }
        public BaseResponse(bool isOk, string msg, T obj)
            : base(isOk, msg){
            this.Payload = obj;
        }

        public T Payload { get; set; }
    }
}
