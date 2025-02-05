namespace CoreDemo.Models
{
    public class FileHelper
    {
        // Genel dosya yükleme metodu
        private static string AddImage(IFormFile image, string folderName)
        {
            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

            // Klasör yoksa oluştur
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var location = Path.Combine(folderPath, newImageName);
            using (var stream = new FileStream(location, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return newImageName;
        }

        // Dosya silme metodu
        public static void DeleteImage(string imageName, string folderName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                return;
            }

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, imageName);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        // Writer images
        public static string AddWriterImage(IFormFile image)
        {
            return AddImage(image, "WriterImagesFolder");
        }

        public static void DeleteWriterImage(string imageName)
        {
            DeleteImage(imageName, "WriterImagesFolder");
        }

        // Blog thumbnail image
        public static string AddBlogThumbnailImage(IFormFile image)
        {
            return AddImage(image, "BlogImagesFolder/BlogThumbnailImage");
        }

        public static void DeleteBlogThumbnailImage(string imageName)
        {
            DeleteImage(imageName, "BlogImagesFolder/BlogThumbnailImage");
        }

        // Blog content image
        public static string AddBlogImage(IFormFile image)
        {
            return AddImage(image, "BlogImagesFolder/BlogImage");
        }

        public static void DeleteBlogImage(string imageName)
        {
            DeleteImage(imageName, "BlogImagesFolder/BlogImage");
        }
    }
}
