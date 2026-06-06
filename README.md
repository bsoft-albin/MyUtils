# MyUtils — Personal .NET Utility Library

A personal NuGet package with reusable helpers, extensions, validators, security tools, and more.
Drop it into any project and skip the boilerplate.

---

## 📦 Installation

```bash
dotnet add package YourName.MyUtils
```

---

## 🗂️ Folder Structure

```
MyUtils/
├── Configuration/     AppSettings.cs          — Strongly-typed settings (JWT, Email, Storage, OTP, Pagination)
├── Constants/         AppConstants.cs         — Date formats, MIME types, HTTP codes, regex patterns
├── Converters/        Converters.cs           — JSON, Unit (temp/distance/weight/data), Currency (INR/USD/GST)
├── Exceptions/        CustomExceptions.cs     — NotFoundException, BusinessException, ValidationException, etc.
├── Extensions/
│   ├── StringExtensions.cs                   — Extension wrappers for all StringHelper methods + ToEnum, ToInt, etc.
│   ├── ListExtensions.cs                     — Paginate, Chunk, Shuffle, ForEach, DistinctBy, ToCsv, etc.
│   └── DateTimeExtensions.cs                 — ToIST, TimeAgo, IsWeekend, StartOfDay, ToUnixTimestamp, etc.
├── Helpers/
│   ├── StringHelper.cs                       — Truncate, ToSlug, ToCamelCase, Mask, Base64, GenerateRandom, etc.
│   ├── DateHelper.cs                         — NowIST, CalculateAge, TimeAgo, BusinessDaysBetween, etc.
│   ├── FileHelper.cs                         — FormatFileSize, IsImage, EnsureDirectory, GenerateUniqueFileName, etc.
│   └── NumberHelper.cs                       — ToOrdinal, ToWords (with Crore/Lakh), ToIndianFormat, Percentage, etc.
├── Models/
│   ├── ApiResponse.cs                        — ApiResponse<T> with factory methods (Ok, Fail, NotFound, Created, etc.)
│   └── CommonModels.cs                       — Result<T>, SelectItem, FileResult, AuditableEntity, BaseEntity<TKey>
├── Pagination/        PaginationHelper.cs     — PagedResult<T>, PagedRequest, PaginationHelper factory methods
├── Security/          SecurityHelper.cs       — BCrypt hashing, JWT generate/validate, OTP, SHA256/512, HMAC
├── Utilities/         Utilities.cs            — RetryHelper, Guard clauses, EnvironmentHelper, MiscUtils
└── Validators/        CommonValidator.cs      — Email, Indian Mobile, Aadhaar, PAN, GST, IFSC, PinCode, Password
```

---

## ✅ Usage Examples

### ApiResponse
```csharp
return ApiResponse<User>.Ok(user);
return ApiResponse<User>.NotFound("User not found");
return ApiResponse<User>.ValidationError(["Email is required", "Name too short"]);
```

### Result Pattern (Service Layer)
```csharp
public Result<User> GetUser(int id) {
    if (user == null) return Result<User>.Failure("User not found");
    return Result<User>.Success(user);
}
```

### String Extensions
```csharp
"hello world".ToSlug();          // "hello-world"
"ABCDE1234F".IsNullOrEmpty();   // false
"John Doe".ToCamelCase();        // "johnDoe"
"test@gmail.com".Mask(2, 9);    // "te*********com"
```

### DateTime Extensions
```csharp
DateTime.UtcNow.ToIST();
birthDate.CalculateAge();
someDate.TimeAgo();              // "3 days ago"
someDate.StartOfMonth();
```

### Pagination
```csharp
var paged = PaginationHelper.Paginate(allUsers, page: 1, pageSize: 10);
// paged.Items, paged.TotalPages, paged.HasNextPage
```

### Validators
```csharp
CommonValidator.IsValidEmail("user@example.com");   // true
CommonValidator.IsValidPAN("ABCDE1234F");           // true
CommonValidator.IsValidIndianMobile("9876543210");  // true
CommonValidator.IsStrongPassword("P@ssword1");      // true
```

### Security
```csharp
string hash  = SecurityHelper.HashPassword("mypassword");
bool valid = SecurityHelper.VerifyPassword("mypassword", hash);
string jwt   = SecurityHelper.GenerateJwt(claims, secretKey, issuer, audience);
string otp   = SecurityHelper.GenerateOtp(6);          // "482931"
string token = SecurityHelper.GenerateSecureToken();   // hex string
```

### Converters
```csharp
JsonConverter.Serialize(myObject);
UnitConverter.CelsiusToFahrenheit(37);   // 98.6
CurrencyConverter.ToINR(1234567.89m);    // "₹12,34,567.89"
CurrencyConverter.CalculateGst(1000, 18); // (1000, 180, 1180)
```

### Guard Clauses
```csharp
Guard.NotNull(user, nameof(user));
Guard.NotNullOrEmpty(email, nameof(email));
Guard.Range(age, 18, 100, nameof(age));
```

### Retry
```csharp
await RetryHelper.ExecuteAsync(async () => {
    await externalApi.CallAsync();
}, maxRetries: 3, delayMs: 300);
```

---

## 🚀 Publishing to NuGet

```bash
# 1. Update version in .csproj
# 2. Pack
dotnet pack -c Release

# 3. Push
dotnet nuget push ./bin/Release/YourName.MyUtils.1.0.0.nupkg \
  --api-key YOUR_API_KEY \
  --source https://api.nuget.org/v3/index.json
```

## 🔢 Versioning

| Change Type         | Version Bump |
|---------------------|-------------|
| Bug fix             | 1.0.x Patch |
| New helper added    | 1.x.0 Minor |
| Breaking change     | x.0.0 Major |

---

## 📄 License
MIT
