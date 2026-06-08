namespace MyUtils.Constants
{
    /// <summary>
    /// Common HTTP status codes as named constants.
    /// </summary>
    public class HttpStatusCodes
    {
        /// <summary>Continue.</summary>
        public const short Continue = 100;

        /// <summary>Switching protocols.</summary>
        public const short SwitchingProtocols = 101;

        /// <summary>Processing request.</summary>
        public const short Processing = 102;

        /// <summary>Request succeeded.</summary>
        public const short OK = 200;

        /// <summary>Resource created.</summary>
        public const short Created = 201;

        /// <summary>Request accepted.</summary>
        public const short Accepted = 202;

        /// <summary>Non-authoritative information.</summary>
        public const short NonAuthoritative = 203;

        /// <summary>No content.</summary>
        public const short NoContent = 204;

        /// <summary>Reset content.</summary>
        public const short ResetContent = 205;

        /// <summary>Partial content returned.</summary>
        public const short PartialContent = 206;

        /// <summary>Multiple status values.</summary>
        public const short MultiStatus = 207;

        /// <summary>Resource already reported.</summary>
        public const short AlreadyReported = 208;

        /// <summary>IM used.</summary>
        public const short IMUsed = 226;

        /// <summary>Multiple choices available.</summary>
        public const short MultipleChoices = 300;

        /// <summary>Resource moved permanently.</summary>
        public const short MovedPermanently = 301;

        /// <summary>Resource found.</summary>
        public const short Found = 302;

        /// <summary>See other resource.</summary>
        public const short SeeOther = 303;

        /// <summary>Resource not modified.</summary>
        public const short NotModified = 304;

        /// <summary>Use proxy.</summary>
        public const short UseProxy = 305;

        /// <summary>Switch proxy.</summary>
        public const short SwitchProxy = 306;

        /// <summary>Temporary redirect.</summary>
        public const short TemporaryRedirect = 307;

        /// <summary>Permanent redirect.</summary>
        public const short PermanentRedirect = 308;

        /// <summary>Bad request.</summary>
        public const short BadRequest = 400;

        /// <summary>Authentication required.</summary>
        public const short Unauthorized = 401;

        /// <summary>Payment required.</summary>
        public const short PaymentRequired = 402;

        /// <summary>Access forbidden.</summary>
        public const short Forbidden = 403;

        /// <summary>Resource not found.</summary>
        public const short NotFound = 404;

        /// <summary>Method not allowed.</summary>
        public const short MethodNotAllowed = 405;

        /// <summary>Not acceptable.</summary>
        public const short NotAcceptable = 406;

        /// <summary>Proxy authentication required.</summary>
        public const short ProxyAuthenticationRequired = 407;

        /// <summary>Request timeout.</summary>
        public const short RequestTimeout = 408;

        /// <summary>Request conflict.</summary>
        public const short Conflict = 409;

        /// <summary>Resource gone.</summary>
        public const short Gone = 410;

        /// <summary>Content length required.</summary>
        public const short LengthRequired = 411;

        /// <summary>Precondition failed.</summary>
        public const short PreconditionFailed = 412;

        /// <summary>Request entity too large.</summary>
        public const short RequestEntityTooLarge = 413;

        /// <summary>Payload too large.</summary>
        public const short PayloadTooLarge = 413;

        /// <summary>Request URI too long.</summary>
        public const short RequestUriTooLong = 414;

        /// <summary>URI too long.</summary>
        public const short UriTooLong = 414;

        /// <summary>Unsupported media type.</summary>
        public const short UnsupportedMediaType = 415;

        /// <summary>Requested range not satisfiable.</summary>
        public const short RequestedRangeNotSatisfiable = 416;

        /// <summary>Range not satisfiable.</summary>
        public const short RangeNotSatisfiable = 416;

        /// <summary>Expectation failed.</summary>
        public const short ExpectationFailed = 417;

        /// <summary>I'm a teapot.</summary>
        public const short ImATeapot = 418;

        /// <summary>Authentication timeout.</summary>
        public const short AuthenticationTimeout = 419;

        /// <summary>Misdirected request.</summary>
        public const short MisdirectedRequest = 421;

        /// <summary>Unprocessable entity.</summary>
        public const short UnProcessableEntity = 422;

        /// <summary>Resource locked.</summary>
        public const short Locked = 423;

        /// <summary>Failed dependency.</summary>
        public const short FailedDependency = 424;

        /// <summary>Upgrade required.</summary>
        public const short UpgradeRequired = 426;

        /// <summary>Precondition required.</summary>
        public const short PreconditionRequired = 428;

        /// <summary>Too many requests.</summary>
        public const short TooManyRequests = 429;

        /// <summary>Request header fields too large.</summary>
        public const short RequestHeaderFieldsTooLarge = 431;

        /// <summary>Unavailable for legal reasons.</summary>
        public const short UnavailableForLegalReasons = 451;

        /// <summary>Internal server error.</summary>
        public const short InternalServerError = 500;

        /// <summary>Not implemented.</summary>
        public const short NotImplemented = 501;

        /// <summary>Bad gateway.</summary>
        public const short BadGateway = 502;

        /// <summary>Service unavailable.</summary>
        public const short ServiceUnavailable = 503;

        /// <summary>Gateway timeout.</summary>
        public const short GatewayTimeout = 504;

        /// <summary>HTTP version not supported.</summary>
        public const short HttpVersionNotSupported = 505;

        /// <summary>Variant also negotiates.</summary>
        public const short VariantAlsoNegotiates = 506;

        /// <summary>Insufficient storage.</summary>
        public const short InsufficientStorage = 507;

        /// <summary>Loop detected.</summary>
        public const short LoopDetected = 508;

        /// <summary>Not extended.</summary>
        public const short NotExtended = 510;

        /// <summary>Network authentication required.</summary>
        public const short NetworkAuthenticationRequired = 511;
    }
}
