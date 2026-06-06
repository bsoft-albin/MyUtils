namespace MyUtils.Constants
{
    /// <summary>
    /// Common HTTP status codes as named constants.
    /// </summary>
    public class HttpStatusCodes
    {
        public const short Continue = 100;
        public const short SwitchingProtocols = 101;
        public const short Processing = 102;
        public const short OK = 200;
        public const short Created = 201;
        public const short Accepted = 202;
        public const short NonAuthoritative = 203;
        public const short NoContent = 204;
        public const short ResetContent = 205;
        public const short PartialContent = 206;
        public const short MultiStatus = 207;
        public const short AlreadyReported = 208;
        public const short IMUsed = 226;
        public const short MultipleChoices = 300;
        public const short MovedPermanently = 301;
        public const short Found = 302;
        public const short SeeOther = 303;
        public const short NotModified = 304;
        public const short UseProxy = 305;
        public const short SwitchProxy = 306;
        public const short TemporaryRedirect = 307;
        public const short PermanentRedirect = 308;
        public const short BadRequest = 400;
        public const short Unauthorized = 401;
        public const short PaymentRequired = 402;
        public const short Forbidden = 403;
        public const short NotFound = 404;
        public const short MethodNotAllowed = 405;
        public const short NotAcceptable = 406;
        public const short ProxyAuthenticationRequired = 407;
        public const short RequestTimeout = 408;
        public const short Conflict = 409;
        public const short Gone = 410;
        public const short LengthRequired = 411;
        public const short PreconditionFailed = 412;
        public const short RequestEntityTooLarge = 413;
        public const short PayloadTooLarge = 413;
        public const short RequestUriTooLong = 414;
        public const short UriTooLong = 414;
        public const short UnsupportedMediaType = 415;
        public const short RequestedRangeNotSatisfiable = 416;
        public const short RangeNotSatisfiable = 416;
        public const short ExpectationFailed = 417;
        public const short ImATeapot = 418;
        public const short AuthenticationTimeout = 419;
        public const short MisdirectedRequest = 421;
        public const short UnProcessableEntity = 422;
        public const short Locked = 423;
        public const short FailedDependency = 424;
        public const short UpgradeRequired = 426;
        public const short PreconditionRequired = 428;
        public const short TooManyRequests = 429;
        public const short RequestHeaderFieldsTooLarge = 431;
        public const short UnavailableForLegalReasons = 451;
        public const short InternalServerError = 500;
        public const short NotImplemented = 501;
        public const short BadGateway = 502;
        public const short ServiceUnavailable = 503;
        public const short GatewayTimeout = 504;
        public const short HttpVersionNotSupported = 505;
        public const short VariantAlsoNegotiates = 506;
        public const short InsufficientStorage = 507;
        public const short LoopDetected = 508;
        public const short NotExtended = 510;
        public const short NetworkAuthenticationRequired = 511;
    }
}
