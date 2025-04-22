public class ImageOptimizer
{
    public static async Task<string> OptimizeAndSave(IFormFile image)
    {
        using var imageResult = await Image.LoadAsync(image.OpenReadStream());
        
        imageResult.Mutate(x => x
             .Resize(new ResizeOptions
             {
                 Size = new Size(1200, 630),
                 Mode = ResizeMode.Max
             })
             .BackgroundColor(Color.White));

        var savePath = Path.Combine("wwwroot/images/events", Guid.NewGuid() + ".webp");
        await imageResult.SaveAsync(savePath, new WebpEncoder { Quality = 80 });
        
        return $"/images/events/{Path.GetFileName(savePath)}";
    }
}