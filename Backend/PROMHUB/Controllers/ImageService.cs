using Microsoft.AspNetCore.Http;

namespace PROMHUB.Controllers
{
    public class ImageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImageService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetImageUrl(string imagePath)
        {
            if (_httpContextAccessor?.HttpContext == null || string.IsNullOrEmpty(imagePath))
            {
                return null;
            }

            // Получаем порт текущего запроса
            var port = _httpContextAccessor.HttpContext.Request.Host.Port;

            // Формируем URL изображения с автоматически определенным портом
            return $"http://192.168.1.18:{port}/img/{imagePath}";
        }
    }
}
