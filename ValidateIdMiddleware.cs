public class ValidateStatusMiddleware
{
    private readonly RequestDelegate _next;
    public ValidateStatusMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        // Kiểm tra nếu yêu cầu là POST và liên quan đến create
        if (context.Request.Method == HttpMethods.Post && context.Request.Path.StartsWithSegments("/create"))
        {
            string statusValue = null;

            // Kiểm tra Status trong query string
            if (context.Request.Query.TryGetValue("status", out var statusQueryValues))
            {
                statusValue = statusQueryValues.FirstOrDefault();
            }
            // Nếu không có trong query string, kiểm tra trong body của yêu cầu
            else if (context.Request.HasFormContentType && context.Request.Form.TryGetValue("status", out var statusFormValues))
            {
                statusValue = statusFormValues.FirstOrDefault();
            }

            if (statusValue != null)
            {
                // Kiểm tra xem Status có phải là "0" hoặc "1"
                if (statusValue == "0" || statusValue == "1")
                {
                    // Status là hợp lệ (0 hoặc 1)
                    context.Items["StatusValidation"] = "Valid";
                }
                else
                {
                    // Status không hợp lệ
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid Status: Status must be either 0 or 1.");
                    return;
                }
            }
            else
            {
                // Status trống hoặc không tồn tại
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Status is required.");
                return;
            }
        }
        await _next(context);
    }

    public async Task InvokeAsyncPrice(HttpContext context)
    {
        // Kiểm tra nếu yêu cầu là POST và liên quan đến Create
        if (context.Request.Method == HttpMethods.Post && context.Request.Path.StartsWithSegments("/create"))
        {
            string priceValue = null;

            // Kiểm tra giá trị Price trong query string
            if (context.Request.Query.TryGetValue("price", out var priceQueryValues))
            {
                priceValue = priceQueryValues.FirstOrDefault();
            }
            // Nếu không có trong query string, kiểm tra trong body của yêu cầu
            else if (context.Request.HasFormContentType && context.Request.Form.TryGetValue("price", out var priceFormValues))
            {
                priceValue = priceFormValues.FirstOrDefault();
            }

            if (!string.IsNullOrEmpty(priceValue))
            {
                // Kiểm tra xem giá trị Price có phải là số hợp lệ không
                if (decimal.TryParse(priceValue, out decimal parsedPrice))
                {
                    // Price hợp lệ (là số)
                    context.Items["PriceValidation"] = "Valid";
                }
                else
                {
                    // Price không hợp lệ (không phải là số)
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid Price: Price must be a valid number.");
                    return;
                }
            }
            else
            {
                // Price trống hoặc không tồn tại
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Price is required.");
                return;
            }
        }

        // Chuyển tiếp yêu cầu đến middleware tiếp theo
        await _next(context);
    }
}
