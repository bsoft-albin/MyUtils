using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MyUtils.Security;

/// <summary>
/// Security utilities — password hashing, JWT generation/validation, token generation.
/// </summary>
public static class SecurityHelper
{
    // ── Password Hashing (BCrypt) ─────────────────────────────────────

    /// <summary>Hashes a plain-text password using BCrypt.</summary>
    public static string HashPassword(string plainPassword) =>
        BCrypt.Net.BCrypt.HashPassword(plainPassword, workFactor: 12);

    /// <summary>Verifies a plain-text password against a BCrypt hash.</summary>
    public static bool VerifyPassword(string plainPassword, string hashedPassword) =>
        BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);

    // ── JWT ───────────────────────────────────────────────────────────

    /// <summary>
    /// Generates a signed JWT token.
    /// </summary>
    /// <param name="claims">Custom claims to embed in the token.</param>
    /// <param name="secretKey">Secret signing key (min 32 chars for HS256).</param>
    /// <param name="issuer">Token issuer.</param>
    /// <param name="audience">Token audience.</param>
    /// <param name="expiryMinutes">Token validity in minutes (default: 60).</param>
    public static string GenerateJwt(
        IEnumerable<Claim> claims,
        string secretKey,
        string issuer,
        string audience,
        int expiryMinutes = 60)
    {
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(secretKey));
        SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// Validates a JWT token and returns the ClaimsPrincipal if valid, or null if not.
    /// </summary>
    public static ClaimsPrincipal? ValidateJwt(
        string token,
        string secretKey,
        string issuer,
        string audience)
    {
        try
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(secretKey));
            JwtSecurityTokenHandler handler = new();
            TokenValidationParameters parameters = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            return handler.ValidateToken(token, parameters, out _);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>Reads claims from a JWT token without validating the signature.</summary>
    public static IEnumerable<Claim> ReadClaims(string token)
    {
        JwtSecurityTokenHandler handler = new();
        if (!handler.CanReadToken(token))
        {
            return [];
        }

        JwtSecurityToken jwt = handler.ReadJwtToken(token);
        return jwt.Claims;
    }

    /// <summary>Gets a single claim value from a JWT by claim type.</summary>
    public static string? GetClaim(string token, string claimType) =>
        ReadClaims(token).FirstOrDefault(c => c.Type == claimType)?.Value;

    // ── Secure Token Generation ───────────────────────────────────────

    /// <summary>Generates a cryptographically secure random token (hex string).</summary>
    public static string GenerateSecureToken(int byteLength = 32)
    {
        byte[] bytes = RandomNumberGenerator.GetBytes(byteLength);
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }

    /// <summary>Generates a cryptographically secure OTP of given digit length.</summary>
    public static string GenerateOtp(int digits = 6)
    {
        int max = (int)Math.Pow(10, digits);
        int otp = RandomNumberGenerator.GetInt32(max);
        return otp.ToString().PadLeft(digits, '0');
    }

    /// <summary>Generates a new GUID-based refresh token string.</summary>
    public static string GenerateRefreshToken() =>
        Convert.ToBase64String(Guid.NewGuid().ToByteArray())
            .Replace("+", "-").Replace("/", "_").TrimEnd('=');

    // ── Hashing ───────────────────────────────────────────────────────

    /// <summary>Computes an MD5 hash of a string (for checksums only — not security).</summary>
    public static string Md5Hash(string input)
    {
        byte[] bytes = MD5.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }

    /// <summary>Computes a SHA-256 hash of a string.</summary>
    public static string Sha256Hash(string input)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }

    /// <summary>Computes a SHA-512 hash of a string.</summary>
    public static string Sha512Hash(string input)
    {
        byte[] bytes = SHA512.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }

    /// <summary>
    /// Generates an HMAC-SHA256 signature for a message using a secret key.
    /// Useful for webhook signature verification.
    /// </summary>
    public static string HmacSha256(string message, string secret)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
        byte[] msgBytes = Encoding.UTF8.GetBytes(message);
        byte[] hash = HMACSHA256.HashData(keyBytes, msgBytes);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }
}
