
namespace CoreDemo.Models
{
    public class FileHelper
    {
        // Genel dosya yükleme metodu
        private static string AddImage(IFormFile image, string folderName)
        {
            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{folderName}", newImageName);
            using (var stream = new FileStream(location, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return newImageName;
        }

        // Writer images
        public static string AddWriterImage(IFormFile image)
        {
            return AddImage(image, "WriterImagesFolder");
        }

        // Blog thumbnail image
        public static string AddBlogThumbnailImage(IFormFile image)
        {
            return AddImage(image, "BlogImagesFolder/BlogThumbnailImage");
        }

        // Blog content image
        public static string AddBlogImage(IFormFile image)
        {
            return AddImage(image, "BlogImagesFolder/BlogImage");
        }
    }
}
